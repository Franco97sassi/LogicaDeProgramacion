//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class Persona
//{
//    public int Id { get; set; }
//    public string Nombre { get; set; }
//    public Persona Pareja { get; set; }
//    public List<Persona> Hijos { get; set; }

//    public Persona(int id, string nombre)
//    {
//        Id = id;
//        Nombre = nombre;
//        Hijos = new List<Persona>();
//    }

//    public override string ToString()
//    {
//        return $"{Nombre} (ID: {Id})";
//    }
//}

//public class ArbolGenealogico
//{
//    private Dictionary<int, Persona> personas = new Dictionary<int, Persona>();

//    public bool AgregarPersona(int id, string nombre)
//    {
//        if (personas.ContainsKey(id))
//        {
//            Console.WriteLine($"Error: Ya existe una persona con ID {id}");
//            return false;
//        }

//        personas[id] = new Persona(id, nombre);
//        Console.WriteLine($"Persona {nombre} agregada con éxito.");
//        return true;
//    }

//    public bool EliminarPersona(int id)
//    {
//        if (!personas.ContainsKey(id))
//        {
//            Console.WriteLine($"Error: No existe una persona con ID {id}");
//            return false;
//        }

//        Persona persona = personas[id];

//        // Eliminar referencias como pareja
//        if (persona.Pareja != null)
//        {
//            persona.Pareja.Pareja = null;
//        }

//        // Eliminar referencias como hijo en los padres
//        foreach (var p in personas.Values)
//        {
//            p.Hijos.RemoveAll(h => h.Id == id);
//        }

//        personas.Remove(id);
//        Console.WriteLine($"Persona {persona.Nombre} eliminada con éxito.");
//        return true;
//    }

//    public bool EstablecerPareja(int id1, int id2)
//    {
//        if (!personas.ContainsKey(id1) || !personas.ContainsKey(id2))
//        {
//            Console.WriteLine("Error: Una o ambas personas no existen");
//            return false;
//        }

//        Persona persona1 = personas[id1];
//        Persona persona2 = personas[id2];

//        if (persona1.Pareja != null || persona2.Pareja != null)
//        {
//            Console.WriteLine("Error: Una o ambas personas ya tienen pareja");
//            return false;
//        }

//        persona1.Pareja = persona2;
//        persona2.Pareja = persona1;
//        Console.WriteLine($"Pareja establecida entre {persona1.Nombre} y {persona2.Nombre}");
//        return true;
//    }

//    public bool AgregarHijo(int idPadre, int idMadre, int idHijo)
//    {
//        if (!personas.ContainsKey(idPadre) || !personas.ContainsKey(idMadre) || !personas.ContainsKey(idHijo))
//        {
//            Console.WriteLine("Error: Alguna de las personas no existe");
//            return false;
//        }

//        Persona padre = personas[idPadre];
//        Persona madre = personas[idMadre];
//        Persona hijo = personas[idHijo];

//        if (padre.Pareja != madre || madre.Pareja != padre)
//        {
//            Console.WriteLine("Error: Las personas indicadas no son pareja");
//            return false;
//        }

//        padre.Hijos.Add(hijo);
//        madre.Hijos.Add(hijo);
//        Console.WriteLine($"Hijo {hijo.Nombre} agregado a {padre.Nombre} y {madre.Nombre}");
//        return true;
//    }

//    public void ImprimirArbol()
//    {
//        Console.WriteLine("\nÁrbol Genealógico de la Casa Targaryen:");
//        foreach (var persona in personas.Values)
//        {
//            string info = persona.ToString();

//            if (persona.Pareja != null)
//            {
//                info += $" está casado/a con {persona.Pareja.Nombre}";
//            }

//            if (persona.Hijos.Any())
//            {
//                info += $"\n  Hijos: {string.Join(", ", persona.Hijos.Select(h => h.Nombre))}";
//            }

//            Console.WriteLine(info);
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        ArbolGenealogico arbol = new ArbolGenealogico();

//        // Agregar personas
//        arbol.AgregarPersona(1, "Aegon I Targaryen");
//        arbol.AgregarPersona(2, "Rhaenys Targaryen");
//        arbol.AgregarPersona(3, "Visenya Targaryen");
//        arbol.AgregarPersona(4, "Aenys I Targaryen");
//        arbol.AgregarPersona(5, "Maegor I Targaryen");

//        // Establecer parejas
//        arbol.EstablecerPareja(1, 2); // Aegon y Rhaenys
//        arbol.EstablecerPareja(1, 3); // Aegon y Visenya (poligamia permitida en Targaryen)

//        // Agregar hijos
//        arbol.AgregarHijo(1, 2, 4); // Aegon y Rhaenys son padres de Aenys
//        arbol.AgregarHijo(1, 3, 5); // Aegon y Visenya son padres de Maegor

//        // Imprimir árbol
//        arbol.ImprimirArbol();

//        // Eliminar persona (ejemplo)
//        // arbol.EliminarPersona(5);
//    }
//}