using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class Registry
    {
        public static string NombresEst, MatEst, ID_Est, Pass_Est, direc, Users;
        public static DateTime FechaEst;


        public static void Reg()
        {
            try
            {
                Console.WriteLine("                        [# ~~~~~~~~~~~~~~~~~~~~ Regístrate ~~~~~~~~~~~~~~~~~~~~ #]\n");
                Console.WriteLine("                                 ~------------------------------------------~");
                Console.Write("                                | Introduce tu Nombre y Apellido: ");
                NombresEst = Console.ReadLine();
                Console.WriteLine("                                |");
                Console.Write("                                | Introduce tu Matrícula: ");
                MatEst = Console.ReadLine();
                Console.WriteLine("                                |");
                Console.Write("                                | Fecha de Nacimiento: ");
                FechaEst = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("                                |");
                Console.WriteLine("                                 ~------------------------------------------~");
                Console.WriteLine("");
                Console.WriteLine("                   [#### Ahora que has registrado tus datos, debes introducir tu forma de Acceso ####]\n");
                Console.WriteLine("                                 ~-----------------------------------~");
                Console.Write("                                | Escoge un Nombre de Usuario: ");
                ID_Est = Console.ReadLine();
                Console.WriteLine("                                |");
                Console.Write("                                | Escoge una Contraseña: ");
                Pass_Est = Console.ReadLine();
                Console.WriteLine("                                 ~------------------------------------~");
                Console.WriteLine("");
                Console.WriteLine("                                 ~----------------------------~");
                Console.WriteLine("                                |*Credenciales Registradas*");
                Console.WriteLine("                                |                          ");
                Console.WriteLine("                                | Tu Usuario es: " + ID_Est);
                Console.WriteLine("                                | Tu Clave es: " + Pass_Est);
                Console.WriteLine("                                |                          ");
                Console.WriteLine("                                 ~----------------------------~\n");
                Console.WriteLine("                                 ~----------------~");
                Console.WriteLine("                                |    1. Guardar    |");
                Console.WriteLine("                                |    2. Cancelar   |");
                Console.WriteLine("                                 ~----------------~");
                Console.Write("                                  > ");
                double Ask = double.Parse(Console.ReadLine());
                if (Ask == 1)
                {
                    Console.Clear();
                    Console.WriteLine("                                   ~----------------------------------------~");
                    Console.WriteLine("                                  | Tus Datos fueron guardados con exito.    |");
                    Console.WriteLine("                                   ~----------------------------------------~\n");
                    Console.Write("                                  >> Desea ir al Menu Principal? ");
                    string Ask1 = Console.ReadLine();
                    if (Ask1.ToLower() == "si" || Ask1.ToLower() == "s")
                        Menu.Selec();
                    else
                    {
                        Welcome.Entry();
                    }
                }
                else if (Ask == 2)
                {
                    Console.Clear();
                    Console.WriteLine("                                   ~------------------------------~");
                    Console.WriteLine("                                  |  Este Registro fue cancelado.  |");
                    Console.WriteLine("                                   ~------------------------------~\n");
                    string Ask1 = Console.ReadLine();
                    Console.Write("                                  >> Desea ir al Menu Principal? ");
                    if (Ask1.ToLower() == "si")
                        Menu.Selec();
                    else
                    {
                        Welcome.Entry();
                    }
                }
                else
                {
                    Welcome.Entry();
                }
                // Forma de escribir datos en un archivo para su uso posterior
                string InfoEst = "Nombres: " + NombresEst + ", Matrícula: " + MatEst + ", Fecha Nac: " + FechaEst + ", Usuario: " + ID_Est;
                direc = $@"C:\Users\Emil\source\repos\BookShop\{ID_Est}.txt";
                Users = @"C:\Users\Emil\source\repos\BookShop\Users.txt";
                FileStream direc2 = File.Create(direc);
                StreamWriter Regs = new StreamWriter(direc, true);
                StreamWriter Regs2 = new StreamWriter(Users, true);
                Regs.Write(InfoEst);
                Regs2.Write(InfoEst);
                Regs.Write(DateTime.Now);
                Regs.Close();
                Regs2.Close();
            }
            // Seguro en contra de errores en la seleccion de opciones
            catch (Exception)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                string Ask1 = Console.ReadLine();
                Console.Write("                                  >> Desea ir al Menu Principal? ");
                if (Ask1.ToLower() == "si")
                    Menu.Selec();
                else
                {
                    Menu.Selec();
                }
            }
        }
    }
}
