/*
 * EJERCICIO:
 * ¡Cada año celebramos el aDEViento! 24 días, 24 regalos para
 * developers. Del 1 al 24 de diciembre: https://adviento.dev
 *
 * Implementación de un calendario interactivo por terminal.
 */

const readline = require('readline');

// Configuración de la interfaz de lectura
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

// Almacén de días descubiertos
const discoveredDays = new Set();

// Función para crear una cuadrícula de día
function createDayGrid(day, discovered) {
  const dayStr = day.toString().padStart(2, '0');
  const line = '****';
  
  if (discovered) {
    return [line, `*${dayStr}*`, line];
  } else {
    return [line, line, line];
  }
}

// Función para dibujar el calendario completo
function drawCalendar() {
  const rows = [];
  
  // Crear 4 filas de calendario (6 columnas x 4 filas = 24 días)
  for (let row = 0; row < 4; row++) {
    const line1 = [];
    const line2 = [];
    const line3 = [];
    
    for (let col = 0; col < 6; col++) {
      const day = row * 6 + col + 1;
      if (day > 24) break;
      
      const grid = createDayGrid(day, discoveredDays.has(day));
      line1.push(grid[0]);
      line2.push(grid[1]);
      line3.push(grid[2]);
    }
    
    rows.push(line1.join(' '));
    rows.push(line2.join(' '));
    rows.push(line3.join(' '));
    rows.push(''); // Espacio entre filas de días
  }
  
  console.clear();
  console.log('¡Calendario de aDEViento!');
  console.log('Selecciona un día del 1 al 24 para descubrir tu regalo.\n');
  console.log(rows.join('\n'));
}

// Función principal
function main() {
  drawCalendar();
  
  rl.question('Elige un día (1-24) o "q" para salir: ', (input) => {
    if (input.toLowerCase() === 'q') {
      rl.close();
      return;
    }
    
    const day = parseInt(input);
    
    if (isNaN(day) || day < 1 || day > 24) {
      console.log('Por favor, introduce un número válido entre 1 y 24.');
      setTimeout(() => {
        drawCalendar();
        main();
      }, 1500);
      return;
    }
    
    if (discoveredDays.has(day)) {
      console.log(`¡Ya has descubierto el regalo del día ${day}!`);
      setTimeout(() => {
        drawCalendar();
        main();
      }, 1500);
    } else {
      discoveredDays.add(day);
      console.log(`¡Felicidades! Has abierto el día ${day}.`);
      setTimeout(() => {
        drawCalendar();
        main();
      }, 1500);
    }
  });
}

// Iniciar la aplicación
main();

// Manejar el cierre del programa
rl.on('close', () => {
  console.log('\n¡Espero que hayas disfrutado del aDEViento! ¡Hasta pronto!');
  process.exit(0);
});