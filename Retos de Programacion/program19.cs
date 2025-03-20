using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retos_de_Programacion
{

    // Enum para representar los días de la semana
enum DiasSemana
    {
        Lunes = 1,
        Martes,
        Miercoles,
        Jueves,
        Viernes,
        Sabado,
        Domingo
    }

    // Enum para representar los estados de un pedido
    enum EstadoPedido
    {
        PENDIENTE,
        ENVIADO,
        ENTREGADO,
        CANCELADO
    }

    // Clase que representa un pedido
    class Pedido
    {
        public int Id { get; }
        public EstadoPedido Estado { get; private set; }

        public Pedido(int id)
        {
            Id = id;
            Estado = EstadoPedido.PENDIENTE;
        }

        // Método para enviar el pedido
        public void Enviar()
        {
            if (Estado == EstadoPedido.PENDIENTE)
            {
                Estado = EstadoPedido.ENVIADO;
                Console.WriteLine($"Pedido {Id} ha sido enviado.");
            }
            else
            {
                Console.WriteLine($"No se puede enviar el pedido {Id} en estado {Estado}.");
            }
        }

        // Método para cancelar el pedido
        public void Cancelar()
        {
            if (Estado == EstadoPedido.PENDIENTE || Estado == EstadoPedido.ENVIADO)
            {
                Estado = EstadoPedido.CANCELADO;
                Console.WriteLine($"Pedido {Id} ha sido cancelado.");
            }
            else
            {
                Console.WriteLine($"No se puede cancelar el pedido {Id} en estado {Estado}.");
            }
        }

        // Método para entregar el pedido
        public void Entregar()
        {
            if (Estado == EstadoPedido.ENVIADO)
            {
                Estado = EstadoPedido.ENTREGADO;
                Console.WriteLine($"Pedido {Id} ha sido entregado.");
            }
            else
            {
                Console.WriteLine($"No se puede entregar el pedido {Id} en estado {Estado}.");
            }
        }

        // Método para mostrar el estado actual del pedido
        public void MostrarEstado()
        {
            Console.WriteLine($"El estado actual del pedido {Id} es: {Estado}");
        }
    }

    class Program19
    {
        static void Main()
        {
            // Ejercicio: Días de la semana
            Console.WriteLine("Introduce un número del 1 al 7:");
            int numero = int.Parse(Console.ReadLine());

            if (numero >= 1 && numero <= 7)
            {
                DiasSemana dia = (DiasSemana)numero;
                Console.WriteLine($"El día correspondiente es: {dia}");
            }
            else
            {
                Console.WriteLine("Número fuera de rango.");
            }

            // Dificultad Extra: Sistema de gestión de pedidos
            Pedido pedido1 = new Pedido(1);
            Pedido pedido2 = new Pedido(2);

            Console.WriteLine("\nGestión de Pedidos:");
            pedido1.MostrarEstado();
            pedido1.Enviar();
            pedido1.MostrarEstado();
            pedido1.Entregar();
            pedido1.MostrarEstado();

            pedido2.MostrarEstado();
            pedido2.Cancelar();
            pedido2.MostrarEstado();
        }
    }
}
