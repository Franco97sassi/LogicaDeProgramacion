// Función para inicializar el laberinto
function inicializarLaberinto() {
    const laberinto = [
        ["⬜️", "⬜️", "⬛️", "⬜️", "⬜️", "⬜️"],
        ["⬜️", "⬛️", "⬛️", "⬜️", "⬛️", "⬜️"],
        ["⬜️", "⬜️", "🐭", "⬜️", "⬛️", "⬜️"],
        ["⬛️", "⬜️", "⬛️", "⬛️", "⬜️", "⬜️"],
        ["⬜️", "⬜️", "⬜️", "⬜️", "⬛️", "⬛️"],
        ["⬜️", "⬛️", "⬜️", "⬜️", "⬜️", "🚪"]
    ];
    return {
        laberinto: laberinto,
        posicionMickey: { fila: 2, col: 2 } // Posición inicial de Mickey
    };
}

// Función para mostrar el laberinto en la consola
function mostrarLaberinto(laberinto) {
    console.clear(); // Limpiar la consola
    console.log("\nLaberinto de Mickey:");
    laberinto.forEach(fila => {
        console.log(fila.join(" "));
    });
    console.log();
}

// Función para mover a Mickey
function moverMickey(estado, direccion) {
    const { laberinto, posicionMickey } = estado;
    let { fila, col } = posicionMickey;
    let nuevaFila = fila, nuevaCol = col;

    // Calcular nueva posición según la dirección
    switch (direccion) {
        case "arriba":
            nuevaFila = fila - 1;
            break;
        case "abajo":
            nuevaFila = fila + 1;
            break;
        case "izquierda":
            nuevaCol = col - 1;
            break;
        case "derecha":
            nuevaCol = col + 1;
            break;
        default:
            console.log("Dirección no válida. Usa: arriba, abajo, izquierda o derecha");
            return estado;
    }

    // Validar movimiento
    if (nuevaFila < 0 || nuevaFila >= 6 || nuevaCol < 0 || nuevaCol >= 6) {
        console.log("¡No puedes salir del laberinto!");
        return estado;
    }

    if (laberinto[nuevaFila][nuevaCol] === "⬛️") {
        console.log("¡Hay un obstáculo! No puedes pasar.");
        return estado;
    }

    // Verificar si llegó a la salida
    if (laberinto[nuevaFila][nuevaCol] === "🚪") {
        laberinto[fila][col] = "⬜️"; // Limpiar posición anterior
        mostrarLaberinto(laberinto);
        console.log("¡Felicidades! Mickey ha escapado del laberinto. 🎉");
        process.exit(0); // Terminar el programa
    }

    // Mover a Mickey
    laberinto[fila][col] = "⬜️"; // Limpiar posición anterior
    laberinto[nuevaFila][nuevaCol] = "🐭"; // Colocar en nueva posición

    return {
        laberinto: laberinto,
        posicionMickey: { fila: nuevaFila, col: nuevaCol }
    };
}

// Función principal del juego
function jugar() {
    let estado = inicializarLaberinto();
    const readline = require('readline').createInterface({
        input: process.stdin,
        output: process.stdout
    });

    function preguntarMovimiento() {
        mostrarLaberinto(estado.laberinto);
        readline.question(
            "¿Hacia dónde quieres mover a Mickey? (arriba/abajo/izquierda/derecha): ",
            direccion => {
                estado = moverMickey(estado, direccion.toLowerCase());
                preguntarMovimiento(); // Volver a preguntar
            }
        );
    }

    console.log("¡Ayuda a Mickey a escapar del laberinto!");
    console.log("Usa los comandos: arriba, abajo, izquierda o derecha");
    preguntarMovimiento();
}

// Iniciar el juego
jugar();