//using System;

//public class UserSession
//{
//    // Instancia única de la clase
//    private static UserSession _instance;
//    private static readonly object _lock = new object();

//    // Datos del usuario
//    private int? _id;
//    private string _username;
//    private string _name;
//    private string _email;

//    // Constructor privado para evitar la creación de instancias fuera de la clase
//    private UserSession() { }

//    // Propiedad para acceder a la instancia única
//    public static UserSession Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                lock (_lock)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new UserSession();
//                    }
//                }
//            }
//            return _instance;
//        }
//    }

//    // Método para asignar los datos del usuario
//    public void SetUser(int id, string username, string name, string email)
//    {
//        _id = id;
//        _username = username;
//        _name = name;
//        _email = email;
//    }

//    // Método para recuperar los datos del usuario
//    public void GetUser()
//    {
//        if (_id.HasValue)
//        {
//            Console.WriteLine($"ID: {_id}, Username: {_username}, Name: {_name}, Email: {_email}");
//        }
//        else
//        {
//            Console.WriteLine("No hay usuario en la sesión.");
//        }
//    }

//    // Método para borrar los datos de la sesión
//    public void ClearUser()
//    {
//        _id = null;
//        _username = null;
//        _name = null;
//        _email = null;
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Acceso a la instancia única de UserSession
//        UserSession session = UserSession.Instance;

//        // Asignar un usuario
//        session.SetUser(1, "johndoe", "John Doe", "john.doe@example.com");

//        // Recuperar los datos del usuario
//        Console.WriteLine("Datos del usuario después de asignar:");
//        session.GetUser();

//        // Borrar los datos de la sesión
//        session.ClearUser();

//        // Verificar que los datos se han borrado
//        Console.WriteLine("\nDatos del usuario después de borrar:");
//        session.GetUser();
//    }
//}