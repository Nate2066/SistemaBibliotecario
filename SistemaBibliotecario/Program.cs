using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBibliotecario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca Gestion = new Biblioteca();
            bool salirSistema = false;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("[0]\n               -Inicio de sesion-               ");
                    Console.WriteLine("    Como que tipo de usuario desea ingresar?    \n");
                    Console.WriteLine(" 1. Iniciar sesion como CLIENTE");
                    Console.WriteLine(" 2. Iniciar sesion como DOCENTE");
                    Console.WriteLine(" 3. Iniciar sesion como ESTUDIANTE\n");
                    Console.WriteLine(" 0. Salir");

                    byte opc1 = Convert.ToByte(Console.ReadLine());
                    switch (opc1)
                    {
                        case 0:
                            Console.Clear();
                            salirSistema = true;
                            break;
                        case 1:
                            _IngresarDatosUsuario(opc1, "Cliente");
                            break;
                        case 2:
                            _IngresarDatosUsuario(opc1, "Docente");
                            break;
                        case 3:
                            _IngresarDatosUsuario(opc1, "Estudiante");
                            break;
                    }
                }
                catch (FormatException) { Gestion._MensajeError("Error! "); }
                catch (IndexOutOfRangeException) { Gestion._MensajeError("Error! "); }
                catch (OverflowException) { Gestion._MensajeError("Error! "); }
            } while (!salirSistema);
            void _IngresarDatosUsuario(byte pOpcion, string pTipoDeInicio)
            {
                Console.Clear();
                Console.WriteLine("   -Iniciando sesion como {0}-    ", pTipoDeInicio);
                Console.WriteLine("Ingrese su nombre de usuario");
                string nombreUsuario = Console.ReadLine();
                Console.WriteLine("\nIngrese su ID de {0}", pTipoDeInicio);
                string identidadUsuario = Console.ReadLine();
                Gestion.VerificarUsuario(nombreUsuario, identidadUsuario, pOpcion);
            }
        }
    }
}
