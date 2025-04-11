// Configuración inicial (las credenciales deberían manejarse de forma segura en un entorno real)
const CLIENT_ID = 'k4z5ir9ltzcfukl9cfr7uyz5ls80jq'; // Esto debería ser manejado de forma segura
const CLIENT_SECRET='7rb9734d1zcqtp56yl6ngbfei8jnh1'
const ACCESS_TOKEN = '0g2vzp4bohocsxrn4wg6p9odtaasbz'; // Debería obtenerse mediante OAuth
// C:\Users\Franc>curl -X POST "https://id.twitch.tv/oauth2/token" -H "Content-Type: application/x-www-form-urlencoded" -d "client_id=k4z5ir9ltzcfukl9cfr7uyz5ls80jq" -d "client_secret=7rb9734d1zcqtp56yl6ngbfei8jnh1" -d "grant_type=client_credentials"

// {"access_token":"0g2vzp4bohocsxrn4wg6p9odtaasbz","expires_in":5678749,"token_type":"bearer"}
// Lista de participantes (extraída del tweet mencionado)
// Configuración inicial (usa variables de entorno en producción)
 
// Lista de participantes
const participantes = [
    "Illojuan", "TheGrefg", "Masi", "Fernanfloo", "Spreen",
    "Rivers_gg", "Quackity", "Vegetta777", "Willyrex", "LolitoFDEZ",
    "xQc", "Ibai", "Auronplay", "Rubiu5", "NexxuzHD",
    "Cristinini", "Zeling", "Komanche", "Perxitaa", "Mayichi",
    "Viviendoenlacalle"
];

// Función para renovar el token de acceso
async function renovarToken() {
    try {
        const response = await fetch("https://id.twitch.tv/oauth2/token", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: new URLSearchParams({
                client_id: CLIENT_ID,
                client_secret: CLIENT_SECRET,
                grant_type: 'client_credentials'
            })
        });
        
        if (!response.ok) {
            throw new Error(`Error al renovar token: ${response.status}`);
        }
        
        const data = await response.json();
        ACCESS_TOKEN = data.access_token;
        console.log('Token renovado correctamente');
    } catch (error) {
        console.error('Error al renovar token:', error);
        throw error;
    }
}

// Función para obtener información de usuarios de Twitch (actualizada)
async function obtenerInfoTwitch(usernames) {
    try {
        // 1. Obtener IDs de usuario
        const queryParams = usernames.map(u => `login=${encodeURIComponent(u)}`).join('&');
        const responseUsers = await fetch(`https://api.twitch.tv/helix/users?${queryParams}`, {
            headers: {
                'Client-ID': CLIENT_ID,
                'Authorization': `Bearer ${ACCESS_TOKEN}`
            }
        });
        
        // Si el token es inválido, intentamos renovarlo
        if (responseUsers.status === 401) {
            await renovarToken();
            return obtenerInfoTwitch(usernames); // Reintentar con nuevo token
        }
        
        if (!responseUsers.ok) {
            throw new Error(`Error al obtener usuarios: ${responseUsers.status}`);
        }
        
        const usersData = await responseUsers.json();
        
        // 2. Obtener seguidores usando el endpoint actual
        const usersWithFollowers = await Promise.all(usersData.data.map(async user => {
            let totalFollowers = 0;
            let pagination = null;
            
            do {
                const url = `https://api.twitch.tv/helix/channels/followers?broadcaster_id=${user.id}&first=100${pagination ? `&after=${pagination.cursor}` : ''}`;
                const responseFollowers = await fetch(url, {
                    headers: {
                        'Client-ID': CLIENT_ID,
                        'Authorization': `Bearer ${ACCESS_TOKEN}`
                    }
                });
                
                if (!responseFollowers.ok) {
                    throw new Error(`Error al obtener seguidores: ${responseFollowers.status}`);
                }
                
                const followersData = await responseFollowers.json();
                totalFollowers += followersData.total || followersData.data?.length || 0;
                pagination = followersData.pagination;
            } while (pagination?.cursor);
            
            return {
                ...user,
                followers: totalFollowers
            };
        }));
        
        return usersWithFollowers.map(user => ({
            username: user.login,
            displayName: user.display_name,
            followers: user.followers,
            createdAt: new Date(user.created_at),
            found: true
        }));
    } catch (error) {
        console.error('Error en obtenerInfoTwitch:', error);
        return [];
    }
}

// Función principal (igual que antes pero con manejo de errores mejorado)
async function main() {
    try {
        // Dividimos en chunks para no exceder límites de la API
        const chunkSize = 10;
        const chunks = [];
        
        for (let i = 0; i < participantes.length; i += chunkSize) {
            chunks.push(participantes.slice(i, i + chunkSize));
        }
        
        const results = [];
        
        for (const chunk of chunks) {
            const chunkResults = await obtenerInfoTwitch(chunk);
            results.push(...chunkResults);
        }
        
        // Marcamos los usuarios no encontrados
        const usuariosEncontrados = results.map(r => r.username.toLowerCase());
        const noEncontrados = participantes.filter(p => !usuariosEncontrados.includes(p.toLowerCase()));
        
        noEncontrados.forEach(username => {
            results.push({
                username,
                displayName: username,
                followers: 0,
                createdAt: null,
                found: false
            });
        });
        
        // Ordenamos por seguidores (descendente)
        const rankingSeguidores = [...results].sort((a, b) => b.followers - a.followers);
        
        // Ordenamos por antigüedad (ascendente)
        const rankingAntiguedad = [...results]
            .filter(user => user.found)
            .sort((a, b) => a.createdAt - b.createdAt);
        
        // Mostramos resultados
        console.log('=== Ranking por Seguidores ===');
        rankingSeguidores.forEach((user, index) => {
            if (user.found) {
                console.log(`${index + 1}. ${user.displayName} - ${user.followers.toLocaleString()} seguidores (desde ${user.createdAt.toLocaleDateString()})`);
            } else {
                console.log(`${index + 1}. ${user.username} - NO ENCONTRADO EN TWITCH`);
            }
        });
        
        console.log('\n=== Ranking por Antigüedad ===');
        rankingAntiguedad.forEach((user, index) => {
            console.log(`${index + 1}. ${user.displayName} - desde ${user.createdAt.toLocaleDateString()} (${user.followers.toLocaleString()} seguidores)`);
        });
        
        console.log('\n=== Usuarios no encontrados ===');
        noEncontrados.forEach(user => console.log(`- ${user}`));
    } catch (error) {
        console.error('Error en main:', error);
    }
}

// Ejecutamos el programa
main().catch(console.error);