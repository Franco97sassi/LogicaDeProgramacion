const readline = require('readline');

class ChristmasTree {
  constructor(height) {
    this.height = height;
    this.star = false;
    this.balls = [];
    this.lights = [];
    this.lightsOn = true;
    this.tree = this.buildTree();
  }

  buildTree() {
    const tree = [];
    for (let i = 0; i < this.height; i++) {
      const spaces = ' '.repeat(this.height - i - 1);
      const stars = '*'.repeat(2 * i + 1);
      tree.push(spaces + stars + spaces);
    }
    return tree;
  }

  toggleStar() {
    this.star = !this.star;
    return this.star ? 'Estrella añadida' : 'Estrella eliminada';
  }

  addBalls() {
    const availablePositions = this.getAvailablePositions().filter(pos => 
      !this.balls.includes(pos) && !this.lights.includes(pos)
    );
    
    if (availablePositions.length < 2) {
      return 'No hay suficiente espacio para añadir bolas';
    }

    // Seleccionar 2 posiciones aleatorias
    const shuffled = [...availablePositions].sort(() => 0.5 - Math.random());
    this.balls.push(...shuffled.slice(0, 2));
    return 'Bolas añadidas';
  }

  removeBalls() {
    if (this.balls.length < 2) {
      return 'No hay suficientes bolas para eliminar';
    }
    
    // Eliminar 2 bolas aleatorias
    const shuffled = [...this.balls].sort(() => 0.5 - Math.random());
    this.balls = shuffled.slice(2);
    return 'Bolas eliminadas';
  }

  addLights() {
    const availablePositions = this.getAvailablePositions().filter(pos => 
      !this.lights.includes(pos) && !this.balls.includes(pos)
    );
    
    if (availablePositions.length < 3) {
      return 'No hay suficiente espacio para añadir luces';
    }

    // Seleccionar 3 posiciones aleatorias
    const shuffled = [...availablePositions].sort(() => 0.5 - Math.random());
    this.lights.push(...shuffled.slice(0, 3));
    return 'Luces añadidas';
  }

  removeLights() {
    if (this.lights.length < 3) {
      return 'No hay suficientes luces para eliminar';
    }
    
    // Eliminar 3 luces aleatorias
    const shuffled = [...this.lights].sort(() => 0.5 - Math.random());
    this.lights = shuffled.slice(3);
    return 'Luces eliminadas';
  }

  toggleLights() {
    this.lightsOn = !this.lightsOn;
    return this.lightsOn ? 'Luces encendidas' : 'Luces apagadas';
  }

  getAvailablePositions() {
    const positions = [];
    for (let i = 0; i < this.height; i++) {
      const rowLength = 2 * i + 1;
      for (let j = 0; j < rowLength; j++) {
        // Saltar el primer y último carácter si no es la punta
        if (i === 0 || (j !== 0 && j !== rowLength - 1)) {
          positions.push(`${i},${j}`);
        }
      }
    }
    return positions;
  }

  renderTree() {
    const treeCopy = [...this.tree];
    
    // Aplicar decoraciones
    for (let i = 0; i < treeCopy.length; i++) {
      let row = treeCopy[i].split('');
      const rowLength = 2 * i + 1;
      
      // Aplicar luces
      this.lights.forEach(pos => {
        const [rowIdx, colIdx] = pos.split(',').map(Number);
        if (rowIdx === i && colIdx < rowLength) {
          row[this.height - i - 1 + colIdx] = this.lightsOn ? '+' : '*';
        }
      });
      
      // Aplicar bolas
      this.balls.forEach(pos => {
        const [rowIdx, colIdx] = pos.split(',').map(Number);
        if (rowIdx === i && colIdx < rowLength) {
          row[this.height - i - 1 + colIdx] = 'o';
        }
      });
      
      treeCopy[i] = row.join('');
    }
    
    // Aplicar estrella
    if (this.star && treeCopy.length > 0) {
      const firstRow = treeCopy[0].split('');
      const starPos = Math.floor(firstRow.length / 2);
      firstRow[starPos] = '@';
      treeCopy[0] = firstRow.join('');
    }
    
    // Añadir tronco
    const trunkSpaces = ' '.repeat(Math.max(0, this.height - 2));
    const trunk = `${trunkSpaces}|||\n${trunkSpaces}|||`;
    
    return treeCopy.join('\n') + '\n' + trunk;
  }
}

// Interfaz de usuario
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

function askQuestion(question) {
  return new Promise(resolve => {
    rl.question(question, answer => {
      resolve(answer);
    });
  });
}

async function main() {
  const height = parseInt(await askQuestion('Introduce la altura del árbol: '));
  if (isNaN(height) || height < 1) {
    console.log('Altura no válida. Debe ser un número mayor que 0.');
    rl.close();
    return;
  }

  const tree = new ChristmasTree(height);
  console.log('\nÁrbol creado:');
  console.log(tree.renderTree());

  while (true) {
    console.log('\nOpciones:');
    console.log('1. Añadir/Eliminar estrella (@)');
    console.log('2. Añadir bolas (o)');
    console.log('3. Eliminar bolas (o)');
    console.log('4. Añadir luces (+)');
    console.log('5. Eliminar luces (+)');
    console.log('6. Encender/Apagar luces');
    console.log('7. Mostrar árbol');
    console.log('8. Salir');

    const option = await askQuestion('Selecciona una opción: ');

    switch (option) {
      case '1':
        console.log(tree.toggleStar());
        break;
      case '2':
        console.log(tree.addBalls());
        break;
      case '3':
        console.log(tree.removeBalls());
        break;
      case '4':
        console.log(tree.addLights());
        break;
      case '5':
        console.log(tree.removeLights());
        break;
      case '6':
        console.log(tree.toggleLights());
        break;
      case '7':
        console.log('\nÁrbol actual:');
        console.log(tree.renderTree());
        break;
      case '8':
        rl.close();
        return;
      default:
        console.log('Opción no válida');
    }
  }
}

main();