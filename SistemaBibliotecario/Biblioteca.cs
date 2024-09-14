using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBibliotecario
{
    public class Biblioteca
    {
        bool usuarioVerificado = false;
        bool usuarioDocenteVerificado = false;
        bool usuarioEstudianteVerificado = false;

        //Libros
        List<string> librosTitulos = new List<string> {"Harry Potter y la piedra filosofal"};
        List<string> librosAutor = new List<string> {"JK. Rowling" };
        List<string> librosISBN = new List<string> { "0000000001" };
        List<int> librosprecios = new List<int> { 2000 };
        List<int> libroscantidad = new List<int> { 3 };

        //Matrices de usuarios Clientes
        private string[] identidadCliente = { "2024001", "2024002", "2024003" };
        private string[] nombresIdentidadClientes = { "anna_101", "marcelo_102", "catalina_103" };

        //matrices de usuarios Docentes
        private string[] identidadDocente = { "2024004", "2024005", "2024006" };
        private string[] nombresIdentidadDocentes = { "reina_104", "andres_105", "simon_106" };

        //matrices de usuarios estudiantes
        private string[] identidadEstudiante = { "2024007", "2024008", "2024009" };
        private string[] nombresIdentidadEstudiantes = { "nilo_107", "carmen_108", "pankesitosabroso_109" };

        public void VerificarUsuario(string pDatoNombreUsuario, string pDatoID, byte pOpcionInicioSesion)
        {
            if(pOpcionInicioSesion == 1) 
            {
                usuarioVerificado = true;
            }
            else if(pOpcionInicioSesion == 2)
            {
                for (int i = 0; i <identidadDocente.Length; i++)
                {
                    if (nombresIdentidadDocentes[i] == pDatoNombreUsuario && identidadDocente[i] == pDatoID)
                    {
                        usuarioVerificado = true;
                        usuarioDocenteVerificado = true;
                        i = identidadDocente.Length - 1;
                    }
                    else{_MensajeError("Error! datos ingresados invalidos"); break; }
                }
            }
            else if (pOpcionInicioSesion == 3)
            {
                for (int i = 0; i < identidadEstudiante.Length; i++)
                {
                    if (nombresIdentidadEstudiantes[i] == pDatoNombreUsuario && identidadEstudiante[i] == pDatoID)
                    {
                        usuarioVerificado = true;
                        usuarioEstudianteVerificado = true;
                        i = identidadDocente.Length - 1;
                    }
                    else{_MensajeError("Error! datos ingresados invalidos"); break; }
                }
            }
            _VentaAlquilerLibros();
        }
        private void _VentaAlquilerLibros()
        {
            bool salirMenu = false;
            if(usuarioVerificado == true)
            {
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("[1]\n    -Seleccione una opcion-    ");
                        Console.WriteLine("1. Comprar Libro");
                        if(usuarioDocenteVerificado == true || usuarioEstudianteVerificado == true)
                        {
                            Console.WriteLine("2. Alquilar Libro");
                        }
                        Console.WriteLine("0. Salir");
                        byte opc2 = Convert.ToByte(Console.ReadLine());
                        if(opc2 == 0)
                        {
                            usuarioVerificado = false;
                            salirMenu = true;
                        }
                        else if(opc2 == 1)
                        {
                            _ImprimirInventarioDeLibros();
                        }
                        else if(opc2 == 2 && usuarioDocenteVerificado == true || usuarioEstudianteVerificado == true)
                        {
                            Console.WriteLine("pepepepeppepeppe");
                            Console.ReadKey();
                        }
                    }
                    catch (FormatException) { _MensajeError("Error! "); }
                    catch (IndexOutOfRangeException) { _MensajeError("Error! "); }
                    catch (OverflowException) { _MensajeError("Error! "); }
                } while (!salirMenu);
            }
        }
        private void _ImprimirInventarioDeLibros()
        {
            if(librosTitulos.Count != 0)
            {
                for (int i = 0; i < librosTitulos.Count; i++)
                {
                    if (libroscantidad[i] == 0)
                    {
                        librosTitulos.RemoveAt(i);
                    }
                }
                for (int i = 0; i < librosTitulos.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine("{0}. {1} [{2}]", i + 1, librosTitulos[i], libroscantidad[i]);
                }
                Console.WriteLine("\nSeleccione un libro para ver la informacion");
                byte opc3 = Convert.ToByte(Console.ReadLine());
                _ImprimirLibro(opc3);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("inventario vacio");
                Console.ReadKey();
            }
        }
        private void _ImprimirLibro(byte pOpcion)
        {
            Console.Clear();
            Console.WriteLine(librosTitulos[pOpcion - 1]);
            Console.WriteLine("By {0}\n", librosAutor[pOpcion - 1]);
            Console.WriteLine("ISBN .. {0}", librosISBN[pOpcion - 1]);
            Console.WriteLine("Cantidad disponible .. {0}", libroscantidad[pOpcion - 1]);
            Console.WriteLine("Precio .. $ {0}", librosprecios[pOpcion - 1]);
            Console.ReadKey();
            libroscantidad[pOpcion - 1] -= 1;
        }
        public void _MensajeError(string pMensaje)
        {
            Console.Clear();
            Console.WriteLine(pMensaje);
            Console.ReadKey();
        }
    }
}
