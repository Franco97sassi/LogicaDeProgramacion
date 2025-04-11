/**
 * Implementa el sistema de seguridad de la Batcueva
 */
class BatcuevaSecurity {
    constructor() {
        this.gridSize = 20;
        this.threshold = 20;
        this.batcuevaPos = { x: 0, y: 0 };
    }
    
    /**
     * Analiza las amenazas y determina la zona más crítica
     * @param {Array} sensores - Array de objetos {x, y, threat}
     * @returns {Object} Información de la zona crítica
     */
    analizarAmenazas(sensores) {
        // Crear matriz de amenazas
        const threatGrid = Array.from({ length: this.gridSize }, () => 
            Array(this.gridSize).fill(0));
        
        // Poblar la matriz con los datos de los sensores
        sensores.forEach(sensor => {
            if (this.esCoordenadaValida(sensor.x, sensor.y)) {
                threatGrid[sensor.y][sensor.x] += sensor.threat;
            }
        });
        
        // Encontrar la cuadrícula 3x3 con mayor suma de amenazas
        let maxSum = 0;
        let criticalCenter = { x: 0, y: 0 };
        
        for (let y = 1; y < this.gridSize - 1; y++) {
            for (let x = 1; x < this.gridSize - 1; x++) {
                const sum = this.calcularSuma3x3(threatGrid, x, y);
                if (sum > maxSum) {
                    maxSum = sum;
                    criticalCenter = { x, y };
                }
            }
        }
        
        // Calcular distancia a la Batcueva
        const distance = Math.abs(criticalCenter.x - this.batcuevaPos.x) + 
                         Math.abs(criticalCenter.y - this.batcuevaPos.y);
        
        // Determinar si activar protocolo
        const activarProtocolo = maxSum > this.threshold;
        
        return {
            centro: criticalCenter,
            sumaAmenazas: maxSum,
            distancia: distance,
            activarProtocolo: activarProtocolo
        };
    }
    
    /**
     * Calcula la suma de amenazas en una cuadrícula 3x3 centrada en (x, y)
     */
    calcularSuma3x3(grid, centerX, centerY) {
        let sum = 0;
        for (let y = centerY - 1; y <= centerY + 1; y++) {
            for (let x = centerX - 1; x <= centerX + 1; x++) {
                if (this.esCoordenadaValida(x, y)) {
                    sum += grid[y][x];
                }
            }
        }
        return sum;
    }
    
    /**
     * Verifica si las coordenadas están dentro de la cuadrícula
     */
    esCoordenadaValida(x, y) {
        return x >= 0 && x < this.gridSize && y >= 0 && y < this.gridSize;
    }
}

// Ejemplo de uso
const securitySystem = new BatcuevaSecurity();

// Datos de ejemplo de sensores
const sensores = [
    { x: 5, y: 5, threat: 3 },
    { x: 6, y: 5, threat: 5 },
    { x: 5, y: 6, threat: 4 },
    { x: 6, y: 6, threat: 7 },
    { x: 15, y: 15, threat: 8 },
    { x: 16, y: 15, threat: 6 },
    { x: 15, y: 16, threat: 9 },
    { x: 10, y: 10, threat: 2 }
];

const resultado = securitySystem.analizarAmenazas(sensores);

console.log("Resultado del análisis de seguridad:");
console.log(`- Centro de la zona crítica: (${resultado.centro.x}, ${resultado.centro.y})`);
console.log(`- Suma de amenazas: ${resultado.sumaAmenazas}`);
console.log(`- Distancia a la Batcueva: ${resultado.distancia}`);
console.log(`- Activar protocolo de seguridad: ${resultado.activarProtocolo ? 'SÍ' : 'NO'}`);