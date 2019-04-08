using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    class Login
    {
        static bool Admin;
        public static void Log()
        {
            try
            {
                Console.WriteLine("                        [# ~~~~~~~~~~~~~~~~~~~~ Inicie Sesión ~~~~~~~~~~~~~~~~~~~~ #]\n");
                Console.WriteLine("                                   ~-------------------------------~");
                Console.WriteLine("                                  | Ingrese a su Cuenta:");
                Console.WriteLine("                                  |                                ");
                Console.Write("                                  | Usuario: ");
                string UserID = Console.ReadLine();
                Console.WriteLine("                                  |                                ");
                Console.Write("                                  | Clave: ");
                string PassID = Console.ReadLine();
                Console.WriteLine("                                   ~-------------------------------~");
                // Aqui se declara el usuario Admin (Proposito: Pruebas de Funciones)
                if (UserID == "doeJohn" && PassID == "11aa")
                {
                    Admin = true;
                    Registry.NombresEst = "John Doe";
                    Registry.MatEst = "1001";
                    Registry.FechaEst = new DateTime(1992, 1, 1, 8, 30, 52);
                    Menu.Selec();
                }
                else
                {
                    //LoggedIn = false;
                    Console.WriteLine("");
                }
                string readText = File.ReadAllText(Registry.direc);
                if (readText.Contains(UserID) || Admin == true)
                {
                    Menu.Selec();
                }
                else
                {
                    Console.Write("                                  ~ Su usuario no esta registrado. Desea reintentar? ");
                    string rptFunc = Console.ReadLine();
                    if (rptFunc.ToString() == "si" || rptFunc == "s")
                        Console.Clear();
                        Log();
                    Welcome.Entry();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Console.Clear();
                    Log();
                Welcome.Entry();
            }
            catch (FileNotFoundException)
            {
                if (Registry.ID_Est == "doeJohn" && Registry.Pass_Est == "11aa")
                {
                    Admin = true;
                    Registry.NombresEst = "John";
                    Registry.ID_Est = "doeJohn";
                    Registry.FechaEst = new DateTime(1992, 1, 1, 8, 30, 52);
                }

            }
            // Seguro en contra de errores en la seleccion de opciones
            catch (Exception)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Console.Clear();
                    Log();
                Welcome.Entry();
            }
        }
    }
}
