using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    class Welcome
    {
        public static void Entry()
        {
            // Sets Básicos
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "BookShop ITLA";
            Console.WriteLine("            [# ~~~~~~~~~~~~~~~ Bienvenido al BookShop del ITLA ~~~~~~~~~~~~~~~ #]");
            Console.WriteLine("            [# ~~~~~~~~~~~~~~~~~~~~ " + DateTime.Now + " ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                  ~-----------------------------------------------------~");
            Console.WriteLine("                 | 1. Iniciar Sesión ∞ 2. Registrarse ∞ 3. Cerrar la App |");
            Console.WriteLine("                  ~-----------------------------------------------------~");
            Console.Write("                  > ");
            double Op = double.Parse(Console.ReadLine());
            try
            {
                switch (Op)
                {
                    case 1:
                        Console.Clear();
                        Login.Log();
                        break;
                    case 2:
                        Console.Clear();
                        Registry.Reg();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Entry();
                        File.WriteAllText(Books.path, String.Empty);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
            }
            // Seguro en contra de errores en la seleccion de opciones
            catch (Exception)
            {
                Console.Clear();
                Entry();
                /*Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s") Console.WriteLine("Test"); */
            }
        }
    }
}
