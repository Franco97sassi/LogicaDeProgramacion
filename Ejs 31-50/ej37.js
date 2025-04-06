const axios = require('axios');
const qs = require('querystring');

// Configuración de credenciales de Spotify API
const CLIENT_ID = '0a5418e910fa4cefaa7854c03580a0a1'; // Reemplaza con tu Client ID de Spotify
const CLIENT_SECRET = '7ccc18f3179142cf9b20d0d6f1119280'; // Reemplaza con tu Client Secret
const TOKEN_URL = 'https://accounts.spotify.com/api/token';
const API_URL = 'https://api.spotify.com/v1';

// Función para obtener el token de acceso
async function getAccessToken() {
    const authString = Buffer.from(`${CLIENT_ID}:${CLIENT_SECRET}`).toString('base64');
    
    const headers = {
        'Authorization': `Basic ${authString}`,
        'Content-Type': 'application/x-www-form-urlencoded'
    };
    
    const data = qs.stringify({
        grant_type: 'client_credentials'
    });
    
    try {
        const response = await axios.post(TOKEN_URL, data, { headers });
        return response.data.access_token;
    } catch (error) {
        console.error('Error al obtener token:', error.message);
        throw error;
    }
}

// Función para buscar un artista por nombre
async function searchArtist(artistName, accessToken) {
    const headers = {
        'Authorization': `Bearer ${accessToken}`
    };
    
    const params = {
        q: artistName,
        type: 'artist',
        limit: 1
    };
    
    try {
        const response = await axios.get(`${API_URL}/search`, { params, headers });
        return response.data.artists.items[0];
     

    } catch (error) {
        console.error(`Error al buscar artista ${artistName}:`, error.message);
        throw error;
    }
}

// Función para obtener los álbumes de un artista
async function getArtistAlbums(artistId, accessToken) {
    const headers = {
        'Authorization': `Bearer ${accessToken}`
    };
    
    const params = {
        limit: 50 // Máximo permitido
    };
    
    try {
        const response = await axios.get(`${API_URL}/artists/${artistId}/albums`, { params, headers });
        return response.data.items;
    } catch (error) {
        console.error('Error al obtener álbumes:', error.message);
        throw error;
    }
}

// Función para obtener las canciones más populares de un artista
async function getTopTracks(artistId, accessToken) {
    const headers = {
        'Authorization': `Bearer ${accessToken}`
    };
    
    const params = {
        market: 'ES'
    };
    
    try {
        const response = await axios.get(`${API_URL}/artists/${artistId}/top-tracks`, { params, headers });
        return response.data.tracks;
    } catch (error) {
        console.error('Error al obtener top tracks:', error.message);
        throw error;
    }
}

// Función principal para comparar los artistas
async function compareArtists() {
    try {
        // Obtener token de acceso
        const accessToken = await getAccessToken();
        
        // Buscar información de los artistas
        const oasis = await searchArtist('Oasis', accessToken);
        const linkinPark = await searchArtist('Linkin Park', accessToken);
        
        if (!oasis || !linkinPark) {
            throw new Error('No se encontraron ambos artistas');
        }
        
        // Obtener datos adicionales
        const oasisTopTracks = await getTopTracks(oasis.id, accessToken);
        const linkinParkTopTracks = await getTopTracks(linkinPark.id, accessToken);
        
        const oasisAlbums = await getArtistAlbums(oasis.id, accessToken);
        const linkinParkAlbums = await getArtistAlbums(linkinPark.id, accessToken);
        
        // Mostrar resultados
        console.log('=== Comparación de popularidad en Spotify ===');
        console.log('\n--- Estadísticas generales ---');
        console.log(`Oasis - Seguidores: ${oasis.followers.total.toLocaleString()}`);
        console.log(`Linkin Park - Seguidores: ${linkinPark.followers.total.toLocaleString()}`);
        console.log(`Oasis - Popularidad: ${oasis.popularity}/100`);
        console.log(`Linkin Park - Popularidad: ${linkinPark.popularity}/100`);
        
        console.log('\n--- Canciones más populares ---');
        console.log(`Oasis - Canción más popular: "${oasisTopTracks[0].name}" (${oasisTopTracks[0].popularity}/100)`);
        console.log(`Linkin Park - Canción más popular: "${linkinParkTopTracks[0].name}" (${linkinParkTopTracks[0].popularity}/100)`);
        
        console.log('\n--- Álbumes ---');
        console.log(`Oasis - Total de álbumes: ${oasisAlbums.length}`);
        console.log(`Linkin Park - Total de álbumes: ${linkinParkAlbums.length}`);
        
        // Determinar qué banda es más popular
        const oasisScore = oasis.followers.total + (oasis.popularity * 10000) + (oasisTopTracks[0].popularity * 1000);
        const linkinParkScore = linkinPark.followers.total + (linkinPark.popularity * 10000) + (linkinParkTopTracks[0].popularity * 1000);
        
        console.log('\n--- Resultado final ---');
        if (oasisScore > linkinParkScore) {
            console.log('¡Oasis es más popular en Spotify!');
        } else if (linkinParkScore > oasisScore) {
            console.log('¡Linkin Park es más popular en Spotify!');
        } else {
            console.log('¡Ambas bandas tienen una popularidad similar en Spotify!');
        }
        
        console.log(`Puntuación Oasis: ${oasisScore.toLocaleString()}`);
        console.log(`Puntuación Linkin Park: ${linkinParkScore.toLocaleString()}`);
        
    } catch (error) {
        console.error('Error en la comparación:', error.message);
    }
}

// Ejecutar la comparación
compareArtists();