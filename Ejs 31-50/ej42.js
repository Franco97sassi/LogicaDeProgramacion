class Luchador {
    constructor(nombre, velocidad, ataque, defensa) {
        this.nombre = nombre;
        this.velocidad = velocidad;
        this.ataque = ataque;
        this.defensa = defensa;
        this.salud = 100;
    }

    atacar(oponente) {
        // 20% de probabilidad de esquivar
        if (Math.random() < 0.2) {
            console.log(`${oponente.nombre} esquivó el ataque de ${this.nombre}!`);
            return;
        }

        let danio;
        if (oponente.defensa > this.ataque) {
            // Si la defensa es mayor, solo hace 10% del daño
            danio = this.ataque * 0.1;
        } else {
            // Daño normal: ataque - defensa
            danio = this.ataque - oponente.defensa;
        }

        // Asegurarse de que el daño no sea negativo
        danio = Math.max(0, Math.floor(danio));
        
        oponente.salud -= danio;
        console.log(`${this.nombre} ataca a ${oponente.nombre} y causa ${danio} de daño! (Salud restante: ${oponente.salud})`);
    }
}

function simularBatalla(luchador1, luchador2) {
    console.log(`\n¡COMIENZA LA BATALLA ENTRE ${luchador1.nombre.toUpperCase()} Y ${luchador2.nombre.toUpperCase()}!`);
    
    // Determinar quién ataca primero (mayor velocidad)
    let atacante, defensor;
    if (luchador1.velocidad >= luchador2.velocidad) {
        atacante = luchador1;
        defensor = luchador2;
    } else {
        atacante = luchador2;
        defensor = luchador1;
    }
    
    console.log(`${atacante.nombre} es más rápido y ataca primero!`);
    
    while (luchador1.salud > 0 && luchador2.salud > 0) {
        atacante.atacar(defensor);
        
        // Verificar si el defensor fue derrotado
        if (defensor.salud <= 0) {
            console.log(`\n¡${defensor.nombre} ha sido derrotado! ¡${atacante.nombre} gana la batalla!`);
            return atacante;
        }
        
        // Cambiar turnos
        [atacante, defensor] = [defensor, atacante];
    }
}

function simularTorneo(luchadores) {
    // Verificar que el número de luchadores sea potencia de 2
    if (!esPotenciaDeDos(luchadores.length)) {
        console.log("El torneo necesita un número de luchadores que sea potencia de 2.");
        return null;
    }
    
    console.log("¡COMIENZA EL TORNEO DE ARTES MARCIALES!");
    console.log("Participantes:");
    luchadores.forEach(l => console.log(`- ${l.nombre} (Vel: ${l.velocidad}, Atq: ${l.ataque}, Def: ${l.defensa})`));
    
    let ronda = 1;
    let participantes = [...luchadores];
    
    while (participantes.length > 1) {
        console.log(`\n=== RONDA ${ronda} ===`);
        let ganadores = [];
        
        // Mezclar los participantes para emparejar al azar
        participantes = shuffleArray(participantes);
        
        // Simular batallas por parejas
        for (let i = 0; i < participantes.length; i += 2) {
            // Crear nuevas instancias para cada batalla
            const luchador1 = new Luchador(
                participantes[i].nombre,
                participantes[i].velocidad,
                participantes[i].ataque,
                participantes[i].defensa
            );
            
            const luchador2 = new Luchador(
                participantes[i+1].nombre,
                participantes[i+1].velocidad,
                participantes[i+1].ataque,
                participantes[i+1].defensa
            );
            
            const ganador = simularBatalla(luchador1, luchador2);
            ganadores.push(ganador);
        }
        
        participantes = ganadores;
        ronda++;
    }
    
    console.log(`\n¡EL GANADOR DEL TORNEO ES ${participantes[0].nombre.toUpperCase()}!`);
    return participantes[0];
}

// Funciones auxiliares
function esPotenciaDeDos(numero) {
    return (numero & (numero - 1)) === 0 && numero > 0;
}

function shuffleArray(array) {
    const newArray = [...array];
    for (let i = newArray.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [newArray[i], newArray[j]] = [newArray[j], newArray[i]];
    }
    return newArray;
}

// Crear luchadores para el torneo
const luchadores = [
    new Luchador("Goku", 90, 85, 80),
    new Luchador("Vegeta", 85, 90, 75),
    new Luchador("Piccolo", 70, 75, 90),
    new Luchador("Gohan", 80, 95, 70),
    new Luchador("Freezer", 95, 80, 85),
    new Luchador("Cell", 75, 85, 85),
    new Luchador("Majin Boo", 60, 100, 95),
    new Luchador("Trunks", 85, 80, 75)
];

// Iniciar el torneo
simularTorneo(luchadores);