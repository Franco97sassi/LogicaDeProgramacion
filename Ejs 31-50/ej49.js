/*
 * EJERCICIO: Código Secreto de Papá Noel
 */
class JuegoCodigoSecreto {
    constructor() {
      this.caracteresPermitidos = ['A', 'B', 'C', '1', '2', '3'];
      this.longitudCodigo = 4;
      this.intentosMaximos = 10;
      this.codigoSecreto = this.generarCodigoSecreto();
      this.intentos = 0;
    }
  
    // Genera un código secreto aleatorio sin caracteres repetidos
    generarCodigoSecreto() {
      const caracteresDisponibles = [...this.caracteresPermitidos];
      const codigo = [];
      
      while (codigo.length < this.longitudCodigo) {
        const indiceAleatorio = Math.floor(Math.random() * caracteresDisponibles.length);
        const caracter = caracteresDisponibles.splice(indiceAleatorio, 1)[0];
        codigo.push(caracter);
      }
      
      return codigo.join('');
    }
  
    // Valida que el intento del usuario sea correcto
    validarIntento(intento) {
      // Verificar longitud
      if (intento.length !== this.longitudCodigo) {
        return {
          valido: false,
          error: `El código debe tener exactamente ${this.longitudCodigo} caracteres.`
        };
      }
      
      // Verificar caracteres permitidos y mayúsculas
      for (let i = 0; i < intento.length; i++) {
        const caracter = intento[i].toUpperCase();
        if (!this.caracteresPermitidos.includes(caracter)) {
          return {
            valido: false,
            error: `Carácter no permitido: '${intento[i]}'. Solo se permiten: ${this.caracteresPermitidos.join(', ')}.`
          };
        }
      }
      
      // Verificar caracteres repetidos
      const caracteresUnicos = new Set(intento.toUpperCase().split(''));
      if (caracteresUnicos.size !== this.longitudCodigo) {
        return {
          valido: false,
          error: 'El código no puede tener caracteres repetidos.'
        };
      }
      
      return { valido: true };
    }
  
    // Compara el intento con el código secreto
    compararConCodigoSecreto(intento) {
      const resultado = [];
      const intentoUpper = intento.toUpperCase();
      
      for (let i = 0; i < this.longitudCodigo; i++) {
        const caracterIntento = intentoUpper[i];
        const caracterSecreto = this.codigoSecreto[i];
        
        if (caracterIntento === caracterSecreto) {
          resultado.push({ caracter: caracterIntento, estado: 'Correcto' });
        } else if (this.codigoSecreto.includes(caracterIntento)) {
          resultado.push({ caracter: caracterIntento, estado: 'Presente' });
        } else {
          resultado.push({ caracter: caracterIntento, estado: 'Incorrecto' });
        }
      }
      
      this.intentos++;
      return resultado;
    }
  
    // Jugar un turno
    jugarTurno(intento) {
      const validacion = this.validarIntento(intento);
      if (!validacion.valido) {
        return { error: validacion.error };
      }
      
      const resultado = this.compararConCodigoSecreto(intento);
      const acertado = intento.toUpperCase() === this.codigoSecreto;
      
      return { resultado, acertado, intentosRestantes: this.intentosMaximos - this.intentos };
    }
  }
  
  // Función para jugar en la consola (para Node.js)
  function jugarEnConsola() {
    const juego = new JuegoCodigoSecreto();
    const readline = require('readline').createInterface({
      input: process.stdin,
      output: process.stdout
    });
    
    console.log('¡Papá Noel ha olvidado el código secreto del almacén!');
    console.log('Debes adivinar un código de 4 caracteres (A-C y 1-3) sin repetidos.');
    console.log(`Tienes ${juego.intentosMaximos} intentos. ¡Buena suerte!\n`);
    
    function preguntarIntento() {
      readline.question(`Intento #${juego.intentos + 1}: `, (intento) => {
        const respuesta = juego.jugarTurno(intento);
        
        if (respuesta.error) {
          console.log(`Error: ${respuesta.error}\n`);
          return preguntarIntento();
        }
        
        // Mostrar resultado
        console.log('\nResultado:');
        respuesta.resultado.forEach((item, index) => {
          console.log(`Posición ${index + 1}: '${item.caracter}' -> ${item.estado}`);
        });
        console.log(`Intentos restantes: ${respuesta.intentosRestantes}\n`);
        
        // Verificar si ganó o perdió
        if (respuesta.acertado) {
          console.log('¡Felicidades! Has encontrado el código secreto. ¡Papá Noel puede repartir los regalos!');
          readline.close();
        } else if (juego.intentos >= juego.intentosMaximos) {
          console.log(`¡Oh no! Te has quedado sin intentos. El código secreto era: ${juego.codigoSecreto}`);
          console.log('Papá Noel no podrá repartir los regalos este año...');
          readline.close();
        } else {
          preguntarIntento();
        }
      });
    }
    
    preguntarIntento();
  }
  
  // Para jugar en un navegador, usaría eventos del DOM en lugar de readline
  // Esta implementación es para consola con Node.js
  
  // Descomenta la siguiente línea para jugar en Node.js
    jugarEnConsola();
  
  // Exportar la clase para poder usarla en otros archivos o tests
  module.exports = JuegoCodigoSecreto;