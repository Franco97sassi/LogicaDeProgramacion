const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
  });
  
  class Personaje {
    constructor(nombre, vidaInicial, minDano, maxDano, probabilidadEvasion) {
      this.nombre = nombre;
      this.vida = vidaInicial;
      this.minDano = minDano;
      this.maxDano = maxDano;
      this.probabilidadEvasion = probabilidadEvasion;
      this.regenerandose = false;
    }
  
    atacar() {
      if (this.regenerandose) {
        this.regenerandose = false;
        return { dano: 0, esMaximo: false };
      }
      
      const dano = Math.floor(Math.random() * (this.maxDano - this.minDano + 1)) + this.minDano;
      const esMaximo = dano === this.maxDano;
      return { dano, esMaximo };
    }
  
    esquivar() {
      return Math.random() < this.probabilidadEvasion;
    }
  
    recibirDano(dano, esMaximo) {
      if (this.esquivar()) {
        return { danoRecibido: 0, fueEsquivado: true };
      }
      
      this.vida -= dano;
      if (esMaximo) {
        this.regenerandose = true;
      }
      return { danoRecibido: dano, fueEsquivado: false };
    }
  
    estaDerrotado() {
      return this.vida <= 0;
    }
  }
  
  function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }
  
  async function simularBatalla() {
    // Solicitar vida inicial para cada personaje usando readline
    const vidaDeadpool = await new Promise(resolve => {
      readline.question("Ingrese la vida inicial para Deadpool: ", input => {
        resolve(parseInt(input));
      });
    });
  
    const vidaWolverine = await new Promise(resolve => {
      readline.question("Ingrese la vida inicial para Wolverine: ", input => {
        resolve(parseInt(input));
      });
    });
    
    // Validar entrada
    if (isNaN(vidaDeadpool) || vidaDeadpool <= 0 || isNaN(vidaWolverine) || vidaWolverine <= 0) {
      console.log("Por favor ingrese valores válidos para la vida de los personajes.");
      readline.close();
      return;
    }
  
    // Crear personajes
    const deadpool = new Personaje("Deadpool", vidaDeadpool, 10, 100, 0.25);
    const wolverine = new Personaje("Wolverine", vidaWolverine, 10, 120, 0.20);
    
    let turno = 1;
    let ganador = null;
    
    console.log("¡Comienza la batalla épica entre Deadpool y Wolverine!");
    
    while (!ganador) {
      await sleep(1000); // Pausa de 1 segundo entre turnos
      
      console.log(`\n=== Turno ${turno} ===`);
      
      // Deadpool ataca primero
      const ataqueDeadpool = deadpool.atacar();
      if (ataqueDeadpool.dano > 0) {
        const resultado = wolverine.recibirDano(ataqueDeadpool.dano, ataqueDeadpool.esMaximo);
        
        if (resultado.fueEsquivado) {
          console.log(`${wolverine.nombre} esquivó el ataque de ${deadpool.nombre}!`);
        } else {
          console.log(`${deadpool.nombre} ataca a ${wolverine.nombre} por ${ataqueDeadpool.dano} de daño.`);
          if (ataqueDeadpool.esMaximo) {
            console.log(`¡Ataque máximo! ${wolverine.nombre} no podrá atacar en el siguiente turno.`);
          }
        }
      } else {
        console.log(`${deadpool.nombre} no ataca este turno (regenerándose).`);
      }
      
      // Verificar si Wolverine fue derrotado
      if (wolverine.estaDerrotado()) {
        ganador = deadpool;
        break;
      }
      
      // Wolverine ataca (si no está regenerándose)
      const ataqueWolverine = wolverine.atacar();
      if (ataqueWolverine.dano > 0) {
        const resultado = deadpool.recibirDano(ataqueWolverine.dano, ataqueWolverine.esMaximo);
        
        if (resultado.fueEsquivado) {
          console.log(`${deadpool.nombre} esquivó el ataque de ${wolverine.nombre}!`);
        } else {
          console.log(`${wolverine.nombre} ataca a ${deadpool.nombre} por ${ataqueWolverine.dano} de daño.`);
          if (ataqueWolverine.esMaximo) {
            console.log(`¡Ataque máximo! ${deadpool.nombre} no podrá atacar en el siguiente turno.`);
          }
        }
      } else {
        console.log(`${wolverine.nombre} no ataca este turno (regenerándose).`);
      }
      
      // Verificar si Deadpool fue derrotado
      if (deadpool.estaDerrotado()) {
        ganador = wolverine;
        break;
      }
      
      // Mostrar vida actual
      console.log(`Vida actual - ${deadpool.nombre}: ${deadpool.vida}, ${wolverine.nombre}: ${wolverine.vida}`);
      
      turno++;
    }
    
    // Mostrar resultado final
    console.log(`\n=== RESULTADO FINAL ===`);
    console.log(`¡${ganador.nombre} gana la batalla en el turno ${turno}!`);
    console.log(`Vida final - ${deadpool.nombre}: ${deadpool.vida}, ${wolverine.nombre}: ${wolverine.vida}`);
    
    readline.close();
  }
  
  // Iniciar la batalla
  simularBatalla();