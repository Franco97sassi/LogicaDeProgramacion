using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Compresor de Archivos en .NET ===");

        // Configuración de rutas (ajusta estas rutas según tu sistema)
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string documentoPath = Path.Combine(desktopPath, "documento.txt");
        string imagenPath = Path.Combine(desktopPath, "imagen.jpg");
        string carpetaPath = Path.Combine(desktopPath, "mi_carpeta");

        // Crear archivos de prueba si no existen
        CrearArchivosDePrueba(documentoPath, imagenPath, carpetaPath);

        // Ejemplos de uso con rutas absolutas:
        ComprimirArchivos(documentoPath, Path.Combine(desktopPath, "comprimido-solo.zip"));
        ComprimirArchivos(new string[] { documentoPath, imagenPath }, Path.Combine(desktopPath, "comprimido-multiples.zip"));
        ComprimirDirectorio(carpetaPath, Path.Combine(desktopPath, "comprimido-directorio.zip"));
    }

    static void CrearArchivosDePrueba(string docPath, string imgPath, string carpetaPath)
    {
        try
        {
            // Crear archivo de texto si no existe
            if (!File.Exists(docPath))
            {
                File.WriteAllText(docPath, "Este es un documento de prueba creado automáticamente.");
                Console.WriteLine($"Archivo creado: {docPath}");
            }

            // Crear archivo de imagen simulado si no existe
            if (!File.Exists(imgPath))
            {
                byte[] fakeImage = new byte[100]; // Imagen simulada
                File.WriteAllBytes(imgPath, fakeImage);
                Console.WriteLine($"Archivo creado: {imgPath}");
            }

            // Crear directorio y archivos de prueba si no existe
            if (!Directory.Exists(carpetaPath))
            {
                Directory.CreateDirectory(carpetaPath);
                File.WriteAllText(Path.Combine(carpetaPath, "archivo1.txt"), "Contenido 1");
                File.WriteAllText(Path.Combine(carpetaPath, "archivo2.txt"), "Contenido 2");
                Console.WriteLine($"Directorio creado: {carpetaPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creando archivos de prueba: {ex.Message}");
        }
    }
    static void ComprimirArchivos(string[] archivos, string nombreZip)
    {
        try
        {
            using (FileStream zipStream = new FileStream(nombreZip, FileMode.Create))
            {
                using (ZipArchive archivoZip = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    foreach (var archivo in archivos)
                    {
                        if (File.Exists(archivo))
                        {
                            string nombreEntry = Path.GetFileName(archivo);
                            archivoZip.CreateEntryFromFile(archivo, nombreEntry);
                            Console.WriteLine($"Añadido: {archivo}");
                        }
                        else
                        {
                            Console.WriteLine($"Advertencia: {archivo} no existe");
                        }
                    }
                }
            }
            Console.WriteLine($"\nArchivos comprimidos en: {nombreZip}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Sobrecarga para un solo archivo
    static void ComprimirArchivos(string archivo, string nombreZip)
    {
        ComprimirArchivos(new string[] { archivo }, nombreZip);
    }

    static void ComprimirDirectorio(string directorio, string nombreZip)
    {
        try
        {
            if (!Directory.Exists(directorio))
            {
                Console.WriteLine($"El directorio {directorio} no existe");
                return;
            }

            using (FileStream zipStream = new FileStream(nombreZip, FileMode.Create))
            {
                using (ZipArchive archivoZip = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    string[] archivos = Directory.GetFiles(directorio, "*", SearchOption.AllDirectories);

                    foreach (var archivo in archivos)
                    {
                        string nombreEntry = archivo.Substring(directorio.Length + 1);
                        archivoZip.CreateEntryFromFile(archivo, nombreEntry);
                        Console.WriteLine($"Añadido: {archivo}");
                    }
                }
            }
            Console.WriteLine($"\nDirectorio comprimido en: {nombreZip}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}