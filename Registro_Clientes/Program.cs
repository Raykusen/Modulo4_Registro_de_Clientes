using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Clientes
{
    internal class Program
    {
        static List<Cliente> clientes = new List<Cliente>();

        static void Main()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("*** Registro de clientes del Gimnasio ***");
                Console.WriteLine("1. Dar de alta un cliente");
                Console.WriteLine("2. Mostrar detalles de un cliente");
                Console.WriteLine("3. Listar clientes");
                Console.WriteLine("4. Buscar cliente (Nombre)");
                Console.WriteLine("5. Dar de baja un cliente");
                Console.WriteLine("6. Modificar un cliente");
                Console.WriteLine("7. Salir");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: AltaCliente(); break;
                    case 2: MostrarCliente(); break;
                    case 3: ListarClientes(); break;
                    case 4: BuscarCliente(); break;
                    case 5: BajaCliente(); break;
                    case 6: ModificarCliente(); break;
                    case 7: Console.WriteLine("¡Adiós!"); break;
                    default: Console.WriteLine("Opción inválida. Intenta de nuevo."); break;
                }

                if (opcion != 7)
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 7);
        }

        static void AltaCliente()
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();

            clientes.Add(new Cliente { Nombre = nombre, Edad = edad, Email = email });
            Console.WriteLine("Cliente registrado con éxito.");
        }

        static void MostrarCliente()
        {
            Console.Write("ID del cliente: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < clientes.Count)
            {
                Cliente cliente = clientes[id];
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Edad: {cliente.Edad}");
                Console.WriteLine($"Email: {cliente.Email}");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void ListarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                Console.WriteLine("Lista de clientes:");
                for (int i = 0; i < clientes.Count; i++)
                {
                    Console.WriteLine($"{i}. {clientes[i].Nombre}");
                }
            }
        }

        static void BuscarCliente()
        {
            Console.Write("Nombre del cliente a buscar: ");
            string nombre = Console.ReadLine();

            var encontrados = clientes.FindAll(c => c.Nombre.ToLower().Contains(nombre.ToLower()));

            if (encontrados.Count > 0)
            {
                Console.WriteLine("Clientes encontrados:");
                foreach (var cliente in encontrados)
                {
                    Console.WriteLine($"Nombre: {cliente.Nombre}, Edad: {cliente.Edad}, Email: {cliente.Email}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron clientes con ese nombre.");
            }
        }

        static void BajaCliente()
        {
            Console.Write("ID del cliente a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Console.WriteLine("Cliente eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        static void ModificarCliente()
        {
            Console.Write("ID del cliente a modificar: ");
            int id = int.Parse(Console.ReadLine());

            if (id >= 0 && id < clientes.Count)
            {
                Cliente cliente = clientes[id];

                Console.Write("Nuevo nombre (deja vacío para no cambiar): ");
                string nuevoNombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoNombre))
                    cliente.Nombre = nuevoNombre;

                Console.Write("Nueva edad (deja vacío para no cambiar): ");
                string nuevaEdad = Console.ReadLine();
                if (int.TryParse(nuevaEdad, out int edad))
                    cliente.Edad = edad;

                Console.Write("Nuevo email (deja vacío para no cambiar): ");
                string nuevoEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevoEmail))
                    cliente.Email = nuevoEmail;

                Console.WriteLine("Cliente modificado con éxito.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
    class Cliente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
    }
}
