const readline = require('readline');
const { exec, execSync } = require('child_process');
const fs = require('fs');
const path = require('path');

// Configuración de la interfaz de lectura
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

// Función para limpiar la pantalla
function clearScreen() {
  console.clear();
}

// Función para mostrar el menú
function printMenu() {
  console.log("\nGitHub Universe 2024 CLI Tool");
  console.log("1. Establecer el directorio de trabajo");
  console.log("2. Crear un nuevo repositorio");
  console.log("3. Crear una nueva rama");
  console.log("4. Cambiar de rama");
  console.log("5. Mostrar ficheros pendientes de hacer commit");
  console.log("6. Hacer commit (con add de todos los ficheros)");
  console.log("7. Mostrar el historial de commits");
  console.log("8. Eliminar rama");
  console.log("9. Establecer repositorio remoto");
  console.log("10. Hacer pull");
  console.log("11. Hacer push");
  console.log("12. Salir");
}

// Función para ejecutar comandos Git
async function runGitCommand(command, options = {}) {
  return new Promise((resolve, reject) => {
    exec(command, { ...options, encoding: 'utf8' }, (error, stdout, stderr) => {
      if (error) {
        console.error(`Error: ${stderr || error.message}`);
        resolve(false);
      } else {
        console.log(stdout.trim());
        resolve(true);
      }
    });
  });
}

// Función para obtener la rama actual
function getCurrentBranch(cwd = process.cwd()) {
  try {
    return execSync('git branch --show-current', { cwd, encoding: 'utf8' }).trim();
  } catch (error) {
    return null;
  }
}

// 1. Establecer directorio de trabajo
async function setWorkingDirectory() {
  const dir = await questionAsync("Introduce la ruta del directorio: ");
  try {
    process.chdir(dir);
    console.log(`Directorio cambiado a: ${process.cwd()}`);
  } catch (error) {
    console.error("El directorio no existe o no se puede acceder.");
  }
}

// 2. Crear nuevo repositorio
async function createNewRepo() {
  const success = await runGitCommand('git init');
  if (!success) return;

  console.log("Repositorio Git creado exitosamente.");
  
  const createRemote = await questionAsync("¿Deseas crear un repositorio remoto en GitHub? (s/n): ");
  if (createRemote.toLowerCase() === 's') {
    const repoName = await questionAsync("Nombre del repositorio en GitHub: ");
    await runGitCommand(`gh repo create ${repoName} --public --source=. --push`);
  }
}

// 3. Crear nueva rama
async function createNewBranch() {
  const branchName = await questionAsync("Introduce el nombre de la nueva rama: ");
  await runGitCommand(`git checkout -b ${branchName}`);
}

// 4. Cambiar de rama
async function switchBranch() {
  await runGitCommand('git branch');
  const branchName = await questionAsync("Introduce el nombre de la rama a la que deseas cambiar: ");
  await runGitCommand(`git checkout ${branchName}`);
}

// 5. Mostrar ficheros pendientes de commit
async function showPendingFiles() {
  await runGitCommand('git status');
}

// 6. Hacer commit
async function commitChanges() {
  const message = await questionAsync("Introduce el mensaje del commit: ");
  const addSuccess = await runGitCommand('git add .');
  if (addSuccess) {
    await runGitCommand(`git commit -m "${message}"`);
  }
}

// 7. Mostrar historial de commits
async function showCommitHistory() {
  await runGitCommand('git log --oneline --graph --all');
}

// 8. Eliminar rama
async function deleteBranch() {
  await runGitCommand('git branch');
  const branchName = await questionAsync("Introduce el nombre de la rama a eliminar: ");
  const currentBranch = getCurrentBranch();

  if (branchName === currentBranch) {
    console.log("No puedes eliminar la rama actual. Cambia a otra rama primero.");
    return;
  }

  const success = await runGitCommand(`git branch -d ${branchName}`);
  if (!success) return;

  const deleteRemote = await questionAsync("¿Deseas eliminar la rama remota también? (s/n): ");
  if (deleteRemote.toLowerCase() === 's') {
    const remote = await questionAsync("Nombre del remoto (por defecto 'origin'): ") || 'origin';
    await runGitCommand(`git push ${remote} --delete ${branchName}`);
  }
}

// 9. Establecer repositorio remoto
async function setRemoteRepo() {
  const remoteUrl = await questionAsync("Introduce la URL del repositorio remoto: ");
  const remoteName = await questionAsync("Nombre del remoto (por defecto 'origin'): ") || 'origin';
  await runGitCommand(`git remote add ${remoteName} ${remoteUrl}`);
}

// 10. Hacer pull
async function pullChanges() {
  const remote = await questionAsync("Nombre del remoto (por defecto 'origin'): ") || 'origin';
  let branch = await questionAsync("Nombre de la rama (deja vacío para usar la actual): ");

  if (!branch) {
    branch = getCurrentBranch();
    if (!branch) {
      console.log("No se pudo determinar la rama actual.");
      return;
    }
  }

  await runGitCommand(`git pull ${remote} ${branch}`);
}

// 11. Hacer push
async function pushChanges() {
  const remote = await questionAsync("Nombre del remoto (por defecto 'origin'): ") || 'origin';
  let branch = await questionAsync("Nombre de la rama (deja vacío para usar la actual): ");

  if (!branch) {
    branch = getCurrentBranch();
    if (!branch) {
      console.log("No se pudo determinar la rama actual.");
      return;
    }
  }

  await runGitCommand(`git push -u ${remote} ${branch}`);
}

// Helper para preguntas asíncronas
function questionAsync(prompt) {
  return new Promise((resolve) => {
    rl.question(prompt, resolve);
  });
}

// Función principal
async function main() {
  clearScreen();

  while (true) {
    printMenu();
    const choice = await questionAsync("\nSelecciona una opción (1-12): ");

    try {
      const option = parseInt(choice);
      
      clearScreen();
      switch (option) {
        case 1:
          await setWorkingDirectory();
          break;
        case 2:
          await createNewRepo();
          break;
        case 3:
          await createNewBranch();
          break;
        case 4:
          await switchBranch();
          break;
        case 5:
          await showPendingFiles();
          break;
        case 6:
          await commitChanges();
          break;
        case 7:
          await showCommitHistory();
          break;
        case 8:
          await deleteBranch();
          break;
        case 9:
          await setRemoteRepo();
          break;
        case 10:
          await pullChanges();
          break;
        case 11:
          await pushChanges();
          break;
        case 12:
          console.log("¡Hasta luego! ¡Disfruta el GitHub Universe 2024!");
          rl.close();
          process.exit(0);
        default:
          console.log("Opción no válida. Por favor, selecciona un número del 1 al 12.");
      }
    } catch (error) {
      console.error("Error:", error.message);
    }

    await questionAsync("\nPresiona Enter para continuar...");
    clearScreen();
  }
}

// Iniciar la aplicación
main().catch(console.error);