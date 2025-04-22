// Informe de Usuario GitHub - Octoverse 2024

// Configuración inicial
const fetch = require('node-fetch').default;
const GITHUB_API_URL = 'https://api.github.com';
const USERNAME = 'Franco97sassi'; // Cambiar por el usuario a analizar

// Función principal para generar el informe
async function generateGitHubUserReport(username) {
    try {
        console.log(`Generando informe para el usuario: ${username}\n`);
        
        // 1. Obtener información básica del usuario
        const userInfo = await fetchGitHubData(`/users/${username}`);
        console.log('1. Información Básica:');
        console.log(`- Nombre: ${userInfo.name || 'No disponible'}`);
        console.log(`- Ubicación: ${userInfo.location || 'No disponible'}`);
        console.log(`- Compañía: ${userInfo.company || 'No disponible'}`);
        console.log(`- Biografía: ${userInfo.bio || 'No disponible'}`);
        console.log(`- Seguidores: ${userInfo.followers}`);
        console.log(`- Siguiendo: ${userInfo.following}`);
        
        // 2. Obtener repositorios del usuario
        const repos = await fetchGitHubData(`/users/${username}/repos`);
        console.log('\n2. Estadísticas de Repositorios:');
        console.log(`- Repositorios públicos: ${repos.length}`);
        
        const starsCount = repos.reduce((acc, repo) => acc + repo.stargazers_count, 0);
        const forksCount = repos.reduce((acc, repo) => acc + repo.forks_count, 0);
        console.log(`- Estrellas totales: ${starsCount}`);
        console.log(`- Forks totales: ${forksCount}`);
        
        // 3. Lenguajes más utilizados
        const languages = await analyzeRepoLanguages(repos);
        console.log('\n3. Lenguajes más utilizados:');
        if (Object.keys(languages).length > 0) {
            const sortedLanguages = Object.entries(languages)
                .sort((a, b) => b[1] - a[1]);
            
            sortedLanguages.slice(0, 5).forEach(([lang, bytes], index) => {
                console.log(`${index + 1}. ${lang}: ${bytes} bytes`);
            });
        } else {
            console.log('- No hay datos de lenguajes disponibles');
        }
        
        // 4. Actividad reciente (eventos)
        const events = await fetchGitHubData(`/users/${username}/events/public`);
        console.log('\n4. Actividad Reciente:');
        const pushEvents = events.filter(event => event.type === 'PushEvent').length;
        const pullRequestEvents = events.filter(event => event.type === 'PullRequestEvent').length;
        console.log(`- Push events (últimos 90 días): ${pushEvents}`);
        console.log(`- Pull requests (últimos 90 días): ${pullRequestEvents}`);
        
        // 5. Repositorios más populares
        console.log('\n5. Repositorios más populares:');
        const sortedRepos = [...repos]
            .sort((a, b) => b.stargazers_count - a.stargazers_count)
            .slice(0, 3);
        
        sortedRepos.forEach((repo, index) => {
            console.log(`${index + 1}. ${repo.name}:`);
            console.log(`   - Estrellas: ${repo.stargazers_count}`);
            console.log(`   - Forks: ${repo.forks_count}`);
            console.log(`   - Última actualización: ${new Date(repo.updated_at).toLocaleDateString()}`);
        });
        
    } catch (error) {
        console.error('Error al generar el informe:', error.message);
    }
}

// Función para analizar los lenguajes de los repositorios
async function analyzeRepoLanguages(repos) {
    const languages = {};
    
    for (const repo of repos) {
        if (repo.languages_url) {
            try {
                const repoLanguages = await fetchGitHubData(repo.languages_url.split(GITHUB_API_URL)[1]);
                
                for (const [lang, bytes] of Object.entries(repoLanguages)) {
                    languages[lang] = (languages[lang] || 0) + bytes;
                }
            } catch (error) {
                console.warn(`No se pudieron obtener lenguajes para ${repo.name}: ${error.message}`);
            }
        }
    }
    
    return languages;
}

// Función genérica para obtener datos de GitHub
async function fetchGitHubData(endpoint) {
    const response = await fetch(`${GITHUB_API_URL}${endpoint}`, {
        headers: {
            'Accept': 'application/vnd.github.v3+json',
            // Para más peticiones, añadir un token de GitHub
            // 'Authorization': 'token TU_TOKEN_GITHUB'
        }
    });
    
    if (!response.ok) {
        throw new Error(`Error en la petición: ${response.status} ${response.statusText}`);
    }
    
    return await response.json();
}

// Ejecutar el informe
generateGitHubUserReport(USERNAME);