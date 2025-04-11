const fs = require('fs');
const csv = require('csv-parser');
const path = require('path');

function seleccionarGanadores() {
    const suscriptoresActivos = [];
    const resultados = {
        suscripcion: null,
        descuento: null,
        libro: null
    };

    // Leer el archivo CSV
    fs.createReadStream(path.join(__dirname, 'suscriptores.csv'))
        .pipe(csv({
            separator: '|', // Usamos | como separador según el ejemplo
            mapHeaders: ({ header }) => header.trim(), // Limpiar espacios en los headers
            mapValues: ({ value }) => value.trim() // Limpiar espacios en los valores
        }))
        .on('data', (row) => {
            // Ignorar filas sin id o email válido
            if (row.id && row.email && row.status) {
                suscriptoresActivos.push({
                    id: row.id,
                    email: row.email,
                    status: row.status.toLowerCase()
                });
            }
        })
        .on('end', () => {
            // Filtrar solo los activos
            const activos = suscriptoresActivos.filter(s => s.status === 'activo');
            
            if (activos.length === 0) {
                console.log('No hay suscriptores activos para realizar el sorteo.');
                return;
            }

            // Seleccionar ganadores únicos
            const ganadores = new Set();
            
            // Función para seleccionar un ganador único
            const seleccionarGanadorUnico = () => {
                if (ganadores.size >= activos.length) {
                    return null; // No hay más ganadores posibles
                }
                
                let ganador;
                do {
                    const indice = Math.floor(Math.random() * activos.length);
                    ganador = activos[indice];
                } while (ganadores.has(ganador.email));
                
                ganadores.add(ganador.email);
                return ganador;
            };

            // Asignar premios
            resultados.suscripcion = seleccionarGanadorUnico();
            resultados.descuento = seleccionarGanadorUnico();
            resultados.libro = seleccionarGanadorUnico();

            // Mostrar resultados
            console.log('🎉 Resultados del sorteo 🎉\n');
            
            if (resultados.suscripcion) {
                console.log(`🏆 Ganador de suscripción: ${resultados.suscripcion.email} (ID: ${resultados.suscripcion.id})`);
            } else {
                console.log('No hay ganador para suscripción');
            }
            
            if (resultados.descuento) {
                console.log(`🎁 Ganador de descuento: ${resultados.descuento.email} (ID: ${resultados.descuento.id})`);
            } else {
                console.log('No hay ganador para descuento');
            }
            
            if (resultados.libro) {
                console.log(`📚 Ganador de libro: ${resultados.libro.email} (ID: ${resultados.libro.id})`);
            } else {
                console.log('No hay ganador para libro');
            }
        })
        .on('error', (error) => {
            console.error('Error al leer el archivo CSV:', error.message);
        });
}

// Ejecutar la función
seleccionarGanadores();