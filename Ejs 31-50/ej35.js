function esPrimo(num) {
    if (num <= 1) return false;
    if (num <= 3) return true;
    if (num % 2 === 0 || num % 3 === 0) return false;
    for (let i = 5; i * i <= num; i += 6) {
        if (num % i === 0 || num % (i + 2) === 0) return false;
    }
    return true;
}

function distribuirAnillos(totalAnillos) {
    // Verificar que Sauron siempre recibe 1 anillo
    if (totalAnillos < 1) {
        return "Error: Debe haber al menos 1 anillo para Sauron";
    }

    const anillosRestantes = totalAnillos - 1; // 1 para Sauron
    let elfos = 0;
    let enanos = 0;
    let hombres = 0;

    // Intentamos encontrar una combinación válida
    for (let e = 1; e <= anillosRestantes; e += 2) { // Elfos reciben impar
        for (let d = 2; d <= anillosRestantes - e; d++) { // Enanos reciben primo
            if (esPrimo(d)) {
                const h = anillosRestantes - e - d;
                if (h >= 0 && h % 2 === 0) { // Hombres reciben par
                    elfos = e;
                    enanos = d;
                    hombres = h;
                    return {
                        sauron: 1,
                        elfos: elfos,
                        enanos: enanos,
                        hombres: hombres,
                        mensaje: "Distribución exitosa"
                    };
                }
            }
        }
    }

    return {
        sauron: 1,
        elfos: 0,
        enanos: 0,
        hombres: 0,
        mensaje: "Error: No se encontró una combinación válida"
    };
}

// Ejemplo de uso
console.log(distribuirAnillos(10));
console.log(distribuirAnillos(7));
console.log(distribuirAnillos(1));
console.log(distribuirAnillos(0));