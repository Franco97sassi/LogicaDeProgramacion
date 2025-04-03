class Persona {
    constructor(id, nombre) {
        this.id = id;
        this.nombre = nombre;
        this.pareja = null;
        this.hijos = [];
    }

    toString() {
        return `${this.nombre} (ID: ${this.id})`;
    }
}

class ArbolGenealogico {
    constructor() {
        this.personas = new Map();
    }

    agregarPersona(id, nombre) {
        if (this.personas.has(id)) {
            console.log(`Error: Ya existe una persona con ID ${id}`);
            return false;
        }

        this.personas.set(id, new Persona(id, nombre));
        console.log(`Persona ${nombre} agregada con éxito.`);
        return true;
    }

    eliminarPersona(id) {
        if (!this.personas.has(id)) {
            console.log(`Error: No existe una persona con ID ${id}`);
            return false;
        }

        const persona = this.personas.get(id);

        // Eliminar referencias como pareja
        if (persona.pareja) {
            persona.pareja.pareja = null;
        }

        // Eliminar referencias como hijo en los padres
        for (const [_, p] of this.personas) {
            p.hijos = p.hijos.filter(hijoId => hijoId !== id);
        }

        this.personas.delete(id);
        console.log(`Persona ${persona.nombre} eliminada con éxito.`);
        return true;
    }

    establecerPareja(id1, id2) {
        if (!this.personas.has(id1) || !this.personas.has(id2)) {
            console.log("Error: Una o ambas personas no existen");
            return false;
        }

        const persona1 = this.personas.get(id1);
        const persona2 = this.personas.get(id2);

        if (persona1.pareja || persona2.pareja) {
            console.log("Error: Una o ambas personas ya tienen pareja");
            return false;
        }

        persona1.pareja = persona2;
        persona2.pareja = persona1;
        console.log(`Pareja establecida entre ${persona1.nombre} y ${persona2.nombre}`);
        return true;
    }

    agregarHijo(idPadre, idMadre, idHijo) {
        if (!this.personas.has(idPadre) || !this.personas.has(idMadre) || !this.personas.has(idHijo)) {
            console.log("Error: Alguna de las personas no existe");
            return false;
        }

        const padre = this.personas.get(idPadre);
        const madre = this.personas.get(idMadre);
        const hijo = this.personas.get(idHijo);

        if (padre.pareja !== madre && madre.pareja !== padre) {
            console.log("Error: Las personas indicadas no son pareja");
            return false;
        }

        padre.hijos.push(idHijo);
        madre.hijos.push(idHijo);
        console.log(`Hijo ${hijo.nombre} agregado a ${padre.nombre} y ${madre.nombre}`);
        return true;
    }

    imprimirArbol() {
        console.log("\nÁrbol Genealógico de la Casa Targaryen:");
        for (const [id, persona] of this.personas) {
            let info = `${persona}`;
            
            if (persona.pareja) {
                info += ` está casado/a con ${persona.pareja.nombre}`;
            }
            
            if (persona.hijos.length > 0) {
                const nombresHijos = persona.hijos.map(hijoId => this.personas.get(hijoId).nombre);
                info += `\n  Hijos: ${nombresHijos.join(", ")}`;
            }
            
            console.log(info);
        }
    }
}

// Ejemplo de uso
const arbol = new ArbolGenealogico();

// Agregar personas
arbol.agregarPersona(1, "Aegon I Targaryen");
arbol.agregarPersona(2, "Rhaenys Targaryen");
arbol.agregarPersona(3, "Visenya Targaryen");
arbol.agregarPersona(4, "Aenys I Targaryen");
arbol.agregarPersona(5, "Maegor I Targaryen");

// Establecer parejas
arbol.establecerPareja(1, 2); // Aegon y Rhaenys
arbol.establecerPareja(1, 3); // Aegon y Visenya (poligamia permitida en Targaryen)

// Agregar hijos
arbol.agregarHijo(1, 2, 4); // Aegon y Rhaenys son padres de Aenys
arbol.agregarHijo(1, 3, 5); // Aegon y Visenya son padres de Maegor

// Imprimir árbol
arbol.imprimirArbol();

// Eliminar persona (ejemplo)
// arbol.eliminarPersona(5);