const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
  });
  
  // Definición de las casas y sus puntuaciones
  const casas = {
      Frontend: 0,
      Backend: 0,
      Mobile: 0,
      Data: 0
  };
  
  // Preguntas y respuestas
  const preguntas = [
      {
          texto: "1. ¿Qué tipo de proyectos prefieres?",
          respuestas: [
              { texto: "Interfaces de usuario bonitas", casa: "Frontend", puntos: 2 },
              { texto: "Lógica y sistemas complejos", casa: "Backend", puntos: 2 },
              { texto: "Aplicaciones para móviles", casa: "Mobile", puntos: 2 },
              { texto: "Análisis de datos y estadísticas", casa: "Data", puntos: 2 }
          ]
      },
      {
          texto: "2. Tu lenguaje favorito es...",
          respuestas: [
              { texto: "JavaScript/TypeScript", casa: "Frontend", puntos: 1 },
              { texto: "Python/Java/C#", casa: "Backend", puntos: 1 },
              { texto: "Dart (Flutter) o Swift/Kotlin", casa: "Mobile", puntos: 1 },
              { texto: "R o Python (para datos)", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "3. En tu tiempo libre prefieres...",
          respuestas: [
              { texto: "Diseñar páginas web", casa: "Frontend", puntos: 1 },
              { texto: "Resolver problemas lógicos", casa: "Backend", puntos: 1 },
              { texto: "Probar nuevas apps en tu móvil", casa: "Mobile", puntos: 1 },
              { texto: "Analizar tendencias y patrones", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "4. Tu asignatura favorita sería...",
          respuestas: [
              { texto: "Diseño de interfaces", casa: "Frontend", puntos: 1 },
              { texto: "Arquitectura de sistemas", casa: "Backend", puntos: 1 },
              { texto: "Desarrollo de aplicaciones", casa: "Mobile", puntos: 1 },
              { texto: "Minería de datos", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "5. ¿Cómo te describes?",
          respuestas: [
              { texto: "Creativo y detallista", casa: "Frontend", puntos: 1 },
              { texto: "Analítico y estructurado", casa: "Backend", puntos: 1 },
              { texto: "Innovador y práctico", casa: "Mobile", puntos: 1 },
              { texto: "Curioso y metódico", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "6. Tu herramienta favorita es...",
          respuestas: [
              { texto: "Figma o Adobe XD", casa: "Frontend", puntos: 1 },
              { texto: "Postman o Docker", casa: "Backend", puntos: 1 },
              { texto: "Android Studio o Xcode", casa: "Mobile", puntos: 1 },
              { texto: "Jupyter Notebook o Tableau", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "7. En un equipo de trabajo prefieres...",
          respuestas: [
              { texto: "Diseñar la experiencia de usuario", casa: "Frontend", puntos: 1 },
              { texto: "Construir la arquitectura del sistema", casa: "Backend", puntos: 1 },
              { texto: "Desarrollar funcionalidades clave", casa: "Mobile", puntos: 1 },
              { texto: "Extraer insights de los datos", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "8. ¿Qué te emociona más?",
          respuestas: [
              { texto: "Ver una interfaz bonita funcionando", casa: "Frontend", puntos: 1 },
              { texto: "Resolver un problema complejo", casa: "Backend", puntos: 1 },
              { texto: "Probar tu app en un dispositivo real", casa: "Mobile", puntos: 1 },
              { texto: "Descubrir un patrón interesante", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "9. Tu enfoque ante un problema es...",
          respuestas: [
              { texto: "Cómo se verá y sentirá la solución", casa: "Frontend", puntos: 1 },
              { texto: "Cómo funcionará internamente", casa: "Backend", puntos: 1 },
              { texto: "Cómo interactuarán los usuarios", casa: "Mobile", puntos: 1 },
              { texto: "Qué datos pueden ayudar a resolverlo", casa: "Data", puntos: 1 }
          ]
      },
      {
          texto: "10. ¿Qué te gustaría aprender más?",
          respuestas: [
              { texto: "Animaciones y efectos visuales", casa: "Frontend", puntos: 1 },
              { texto: "Microservicios y APIs", casa: "Backend", puntos: 1 },
              { texto: "Nuevas tecnologías móviles", casa: "Mobile", puntos: 1 },
              { texto: "Machine Learning", casa: "Data", puntos: 1 }
          ]
      }
  ];
  
  // Función para hacer preguntas con readline
  function hacerPregunta(pregunta) {
      return new Promise((resolve) => {
          readline.question(pregunta + '\n', (respuesta) => {
              resolve(respuesta);
          });
      });
  }
  
  // Función para realizar las preguntas
  async function realizarPreguntas() {
      const nombre = await hacerPregunta("¡Bienvenido al Expreso de Hogwarts para Programadores!\n¿Cuál es tu nombre?");
      
      for (const pregunta of preguntas) {
          let respuestaTexto = pregunta.texto + "\n";
          for (let i = 0; i < pregunta.respuestas.length; i++) {
              respuestaTexto += `${i + 1}. ${pregunta.respuestas[i].texto}\n`;
          }
          
          let respuesta;
          while (true) {
              respuesta = parseInt(await hacerPregunta(respuestaTexto));
              if (respuesta >= 1 && respuesta <= 4) break;
              console.log("Por favor, ingresa un número entre 1 y 4");
          }
          
          const respuestaSeleccionada = pregunta.respuestas[respuesta - 1];
          casas[respuestaSeleccionada.casa] += respuestaSeleccionada.puntos;
      }
      
      determinarCasa(nombre);
      readline.close();
  }
  
  // Función para determinar la casa ganadora
  function determinarCasa(nombre) {
      let casaGanadora = "";
      let maxPuntos = -1;
      let empate = false;
      let casasEmpatadas = [];
      
      // Encontrar la casa con más puntos
      for (const casa in casas) {
          if (casas[casa] > maxPuntos) {
              maxPuntos = casas[casa];
              casaGanadora = casa;
              casasEmpatadas = [casa];
              empate = false;
          } else if (casas[casa] === maxPuntos) {
              empate = true;
              casasEmpatadas.push(casa);
          }
      }
      
      // Manejar empate
      if (empate) {
          casaGanadora = casasEmpatadas[Math.floor(Math.random() * casasEmpatadas.length)];
          console.log(`\n¡La decisión ha sido complicada, ${nombre}!`);
          console.log(`Hubo un empate entre ${casasEmpatadas.join(" y ")}.\n`);
      }
      
      // Mostrar resultados
      console.log(`\n¡${nombre}, el Sombrero Seleccionador ha decidido!`);
      console.log(`\nPerteneces a la casa: ${casaGanadora.toUpperCase()}!\n`);
      console.log("Puntuación final:");
      
      for (const casa in casas) {
          console.log(`${casa}: ${casas[casa]} puntos`);
      }
  }
  
  // Iniciar el proceso
  console.log("=== Sombrero Seleccionador de Hogwarts para Programadores ===");
  realizarPreguntas();