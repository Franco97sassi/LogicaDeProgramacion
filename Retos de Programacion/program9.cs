using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retos_de_Programacion
{
    using System;
    using System.Collections.Generic;

    // Ejercicio de Herencia con Animales

    // Superclase Animal
    public class Animal
    {
        public string Nombre { get; set; }

        public Animal(string nombre)
        {
            Nombre = nombre;
        }

        // Método virtual para que las subclases lo sobrescriban
        public virtual void HacerSonido()
        {
            Console.WriteLine("Este animal hace un sonido.");
        }
    }

    // Subclase Perro
    public class Perro : Animal
    {
        public Perro(string nombre) : base(nombre) { }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Guau guau!");
        }
    }

    // Subclase Gato
    public class Gato : Animal
    {
        public Gato(string nombre) : base(nombre) { }

        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Miau miau!");
        }
    }

    // Dificultad Extra: Jerarquía de Empleados

    // Superclase Empleado
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Empleado> Subordinados { get; set; } = new List<Empleado>();

        public Empleado(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public virtual void Trabajar()
        {
            Console.WriteLine($"{Nombre} está trabajando.");
        }

        public void AgregarSubordinado(Empleado empleado)
        {
            Subordinados.Add(empleado);
        }

        public void MostrarSubordinados()
        {
            if (Subordinados.Count > 0)
            {
                Console.WriteLine($"Subordinados de {Nombre}:");
                foreach (var subordinado in Subordinados)
                {
                    Console.WriteLine($"- {subordinado.Nombre}");
                }
            }
            else
            {
                Console.WriteLine($"{Nombre} no tiene subordinados.");
            }
        }
    }

    // Subclase Gerente
    public class Gerente : Empleado
    {
        public Gerente(int id, string nombre) : base(id, nombre) { }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está gestionando la empresa.");
        }
    }

    // Subclase Gerente de Proyectos
    public class GerenteProyectos : Empleado
    {
        public string Proyecto { get; set; }

        public GerenteProyectos(int id, string nombre, string proyecto) : base(id, nombre)
        {
            Proyecto = proyecto;
        }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está gestionando el proyecto {Proyecto}.");
        }
    }

    // Subclase Programador
    public class Programador : Empleado
    {
        public string Lenguaje { get; set; }

        public Programador(int id, string nombre, string lenguaje) : base(id, nombre)
        {
            Lenguaje = lenguaje;
        }

        public override void Trabajar()
        {
            Console.WriteLine($"{Nombre} está programando en {Lenguaje}.");
        }
    }

    class Program9
    {
        static void Main(string[] args)
        {
            // Ejercicio de Herencia con Animales
            Console.WriteLine("=== Ejercicio de Herencia con Animales ===");
            Animal miPerro = new Perro("Rex");
            Animal miGato = new Gato("Mimi");

            miPerro.HacerSonido();  // Rex dice: ¡Guau guau!
            miGato.HacerSonido();   // Mimi dice: ¡Miau miau!

            Console.WriteLine();

            // Dificultad Extra: Jerarquía de Empleados
            Console.WriteLine("=== Dificultad Extra: Jerarquía de Empleados ===");
            Gerente gerente = new Gerente(1, "Carlos");
            GerenteProyectos gerenteProyectos = new GerenteProyectos(2, "Ana", "Sistema de Gestión");
            Programador programador1 = new Programador(3, "Luis", "C#");
            Programador programador2 = new Programador(4, "Marta", "JavaScript");

            gerente.AgregarSubordinado(gerenteProyectos);
            gerenteProyectos.AgregarSubordinado(programador1);
            gerenteProyectos.AgregarSubordinado(programador2);

            gerente.Trabajar();
            gerenteProyectos.Trabajar();
            programador1.Trabajar();
            programador2.Trabajar();

            Console.WriteLine();

            gerente.MostrarSubordinados();
            gerenteProyectos.MostrarSubordinados();
        }
    }
}
