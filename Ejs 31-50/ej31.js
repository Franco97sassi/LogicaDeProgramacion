const prompt = require('prompt-sync')();

class SimuladorJJOO {
    constructor() {
        this.eventos = [];
        this.participantes = [];
        this.resultados = [];
        this.medallasPaises = new Map();
    }

    registrarEvento() {
        const nombre = prompt("Ingrese el nombre del evento deportivo: ");
        if (nombre && nombre.trim() !== "") {
            this.eventos.push(nombre.trim());
            console.log(`Evento '${nombre.trim()}' registrado con éxito!`);
        } else {
            console.log("El nombre del evento no puede estar vacío.");
        }
    }

    registrarParticipante() {
        const nombre = prompt("Ingrese el nombre del participante: ");
        const pais = prompt("Ingrese el país del participante: ");

        if (nombre && nombre.trim() !== "" && pais && pais.trim() !== "") {
            const participante = {
                nombre: nombre.trim(),
                pais: pais.trim()
            };
            this.participantes.push(participante);
            console.log(`Participante ${nombre.trim()} de ${pais.trim()} registrado con éxito!`);
        } else {
            console.log("Nombre y país son campos obligatorios.");
        }
    }

    simularEvento() {
        if (this.eventos.length === 0) {
            console.log("No hay eventos registrados.");
            return;
        }

        if (this.participantes.length < 3) {
            console.log("Se necesitan al menos 3 participantes para simular un evento.");
            return;
        }

        console.log("\nEventos disponibles:");
        this.eventos.forEach((evento, index) => {
            console.log(`${index + 1}. ${evento}`);
        });

        const seleccion = parseInt(prompt("Seleccione el número del evento a simular: ")) - 1;
        if (isNaN(seleccion) || seleccion < 0 || seleccion >= this.eventos.length) {
            console.log("Selección inválida.");
            return;
        }

        const evento = this.eventos[seleccion];
        const participantesEvento = [...this.participantes]
            .sort(() => Math.random() - 0.5)
            .slice(0, Math.min(10, this.participantes.length));

        if (participantesEvento.length < 3) {
            console.log("No hay suficientes participantes para este evento.");
            return;
        }

        const ganadores = participantesEvento.slice(0, 3);
        const [oro, plata, bronce] = ganadores;

        // Registrar resultados
        this.resultados.push({
            evento: evento,
            oro: oro,
            plata: plata,
            bronce: bronce
        });

        // Actualizar conteo de medallas por país
        this.actualizarMedallas(oro.pais, 'oro');
        this.actualizarMedallas(plata.pais, 'plata');
        this.actualizarMedallas(bronce.pais, 'bronce');

        console.log("\nResultados del evento:");
        console.log(`🥇 Oro: ${oro.nombre} (${oro.pais})`);
        console.log(`🥈 Plata: ${plata.nombre} (${plata.pais})`);
        console.log(`🥉 Bronce: ${bronce.nombre} (${bronce.pais})`);
    }

    actualizarMedallas(pais, tipoMedalla) {
        if (!this.medallasPaises.has(pais)) {
            this.medallasPaises.set(pais, { oro: 0, plata: 0, bronce: 0 });
        }
        const medallas = this.medallasPaises.get(pais);
        medallas[tipoMedalla]++;
        this.medallasPaises.set(pais, medallas);
    }

    generarInforme() {
        if (this.resultados.length === 0) {
            console.log("No hay resultados para generar informe.");
            return;
        }

        console.log("\n=== INFORME FINAL ===");

        // Mostrar ganadores por evento
        console.log("\n🏆 Ganadores por evento:");
        this.resultados.forEach(resultado => {
            console.log(`\nEvento: ${resultado.evento}`);
            console.log(`  Oro: ${resultado.oro.nombre} (${resultado.oro.pais})`);
            console.log(`  Plata: ${resultado.plata.nombre} (${resultado.plata.pais})`);
            console.log(`  Bronce: ${resultado.bronce.nombre} (${resultado.bronce.pais})`);
        });

        // Mostrar ranking de países
        console.log("\n🏅 Ranking de países por medallas:");

        // Convertir el Map a array y ordenar
        const ranking = Array.from(this.medallasPaises.entries()).map(([pais, medallas]) => ({
            pais: pais,
            oro: medallas.oro,
            plata: medallas.plata,
            bronce: medallas.bronce,
            total: medallas.oro + medallas.plata + medallas.bronce
        }));

        // Ordenar por oro, luego plata, luego bronce
        ranking.sort((a, b) => {
            if (b.oro !== a.oro) return b.oro - a.oro;
            if (b.plata !== a.plata) return b.plata - a.plata;
            return b.bronce - a.bronce;
        });

        console.log("\nPos | País\t| Oro | Plata | Bronce | Total");
        console.log("-".repeat(45));
        ranking.forEach((paisInfo, index) => {
            console.log(`${(index + 1).toString().padStart(3)} | ${paisInfo.pais.padEnd(10)} | ${paisInfo.oro.toString().padStart(3)} | ${paisInfo.plata.toString().padStart(5)} | ${paisInfo.bronce.toString().padStart(6)} | ${paisInfo.total.toString().padStart(5)}`);
        });
    }
}

function main() {
    const simulador = new SimuladorJJOO();
    let opcion;

    do {
        console.log("\n=== MENÚ PRINCIPAL ===");
        console.log("1. Registrar evento deportivo");
        console.log("2. Registrar participante");
        console.log("3. Simular evento");
        console.log("4. Generar informe final");
        console.log("5. Salir");

        opcion = prompt("Seleccione una opción: ");

        switch (opcion) {
            case "1":
                simulador.registrarEvento();
                break;
            case "2":
                simulador.registrarParticipante();
                break;
            case "3":
                simulador.simularEvento();
                break;
            case "4":
                simulador.generarInforme();
                break;
            case "5":
                console.log("¡Hasta luego! Que disfrutes de los Juegos Olímpicos de París 2024!");
                break;
            default:
                console.log("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
        }
    } while (opcion !== "5");
}

// Ejecutar el programa
main();