class GoalManager {
    constructor() {
      this.goals = [];
      this.maxGoals = 10;
    }
  
    addGoal(goal, quantity, units, deadline) {
      if (this.goals.length >= this.maxGoals) {
        console.log(`No se pueden añadir más objetivos (máximo ${this.maxGoals})`);
        return false;
      }
  
      if (deadline < 1 || deadline > 12) {
        console.log("El plazo debe estar entre 1 y 12 meses");
        return false;
      }
  
      this.goals.push({
        goal,
        quantity,
        units,
        deadline,
        monthlyQuantity: Math.ceil(quantity / deadline)
      });
  
      return true;
    }
  
    calculateDetailedPlan() {
      if (this.goals.length === 0) {
        return "No hay objetivos para planificar";
      }
  
      const months = [
        "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
        "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
      ];
      
      let plan = "";
      const maxMonth = Math.max(...this.goals.map(g => g.deadline));
      
      for (let month = 0; month < maxMonth; month++) {
        plan += `${months[month]}:\n`;
        
        this.goals.forEach((goal, index) => {
          if (month < goal.deadline) {
            plan += `[ ] ${index + 1}. ${goal.goal} (${goal.monthlyQuantity} ${goal.units}/mes). Total: ${goal.quantity}.\n`;
          }
        });
        
        plan += "\n";
      }
      
      return plan;
    }
  
    savePlanToFile() {
      const plan = this.calculateDetailedPlan();
      const blob = new Blob([plan], { type: 'text/plain' });
      const url = URL.createObjectURL(blob);
      
      const a = document.createElement('a');
      a.href = url;
      a.download = 'plan_anual.txt';
      document.body.appendChild(a);
      a.click();
      document.body.removeChild(a);
      URL.revokeObjectURL(url);
    }
  }
  
  // Ejemplo de uso
  const manager = new GoalManager();
  
  // Añadir objetivos
  manager.addGoal("Leer libros", 12, "libros", 12);
  manager.addGoal("Estudiar Git", 1, "curso", 1);
  manager.addGoal("Hacer ejercicio", 100, "horas", 6);
  
  // Calcular y mostrar plan
  console.log(manager.calculateDetailedPlan());
  
  // Guardar plan en archivo (esto funcionará en un navegador)
  // manager.savePlanToFile();