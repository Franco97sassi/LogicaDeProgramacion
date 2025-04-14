const fs = require('fs');
const path = require('path');
const { exec } = require('child_process');
const archiver = require('archiver');

async function comprimirArchivos(archivosAComprimir, nombreZip) {
    // Asegurar que el nombre del ZIP tenga la extensión correcta
    if (!nombreZip.toLowerCase().endsWith('.zip')) {
        nombreZip += '.zip';
    }

    return new Promise((resolve, reject) => {
        const output = fs.createWriteStream(nombreZip);
        const archive = archiver('zip', {
            zlib: { level: 9 } // Nivel máximo de compresión
        });

        output.on('close', () => {
            console.log(`Archivo(s) comprimido(s) correctamente en ${nombreZip}`);
            console.log(`Tamaño del ZIP: ${archive.pointer()} bytes`);
            resolve(true);
        });

        archive.on('error', (err) => {
            console.error('Error al comprimir:', err);
            reject(false);
        });

        archive.pipe(output);

        // Si es un solo archivo como string, convertirlo a array
        if (typeof archivosAComprimir === 'string') {
            archivosAComprimir = [archivosAComprimir];
        }

        archivosAComprimir.forEach(archivo => {
            const stats = fs.statSync(archivo);
            
            if (stats.isFile()) {
                // Añadir archivo al ZIP
                archive.file(archivo, { name: path.basename(archivo) });
            } else if (stats.isDirectory()) {
                // Añadir directorio y su contenido recursivamente
                archive.directory(archivo, path.basename(archivo));
            } else {
                console.log(`Advertencia: ${archivo} no existe y será omitido.`);
            }
        });

        archive.finalize();
    });
}

// Ejemplo de uso
// (async () => {
//     console.log("=== Compresor de Archivos en Node.js ===");
    
//     try {
//         // Instalar archiver si no está instalado
//         try {
//             require.resolve('archiver');
//         } catch (e) {
//             console.log("Instalando el paquete 'archiver'...");
//             await new Promise((resolve, reject) => {
//                 exec('npm install archiver', (error, stdout, stderr) => {
//                     if (error) {
//                         console.error("Error al instalar archiver:", error);
//                         reject(false);
//                     }
//                     resolve(true);
//                 });
//             });
//         }

//         // Ejemplos de uso:
//         // Comprimir un solo archivo
//         await comprimirArchivos('documento.txt', 'documento_comprimido');
        
//         // Comprimir múltiples archivos
//         // await comprimirArchivos(['foto.jpg', 'informe.pdf'], 'archivos_comprimidos');
        
//         // Comprimir un directorio completo
//         // await comprimirArchivos('mi_carpeta', 'carpeta_comprimida');
        
//     } catch (error) {
//         console.error("Error:", error);
//     }
// })();

// Ejemplo de uso
// (async () => {
//     console.log("=== Prueba 1: Comprimir un solo archivo ===");
//     await comprimirArchivos('documento.txt', 'prueba1-solo-archivo');
// })();

(async () => {
    console.log("=== Prueba 3: Comprimir una carpeta ===");
    await comprimirArchivos('mi-carpeta', 'prueba3-carpeta-completa');
})();

(async () => {
    console.log("=== Prueba 3: Comprimir una carpeta ===");
    await comprimirArchivos('mi-carpeta', 'prueba3-carpeta-completa');
})();