using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    class Menu
    {
        public static void Selec()
        {
            Console.Clear();
            Console.WriteLine("\n                          [# ~~~~~~~~~~~~~~ B O O K S H O P - F U N C I O N E S ~~~~~~~~~~~~~~ #]");
            Console.WriteLine("      ~------------------------------------------------------------------------------------------------------------------------~");
            Console.WriteLine("     |                                                                                                                          |");
            Console.WriteLine("     | 1. Libros Disponibles ∞ 2. Buscar Libro ∞ 3. Tomar Libros ∞ 4. Libros Reservados ∞ 5. Actividades Realizadas ∞ 6. Volver |");
            Console.WriteLine("      ~------------------------------------------------------------------------------------------------------------------------~");
            Console.Write("                                  > ");
            double Op = double.Parse(Console.ReadLine());
            try { 
                switch (Op)
                {
                    case 1:
                        Console.Clear();
                        Books.Libs();
                        break;
                    case 2:
                        Console.Clear();
                        Books.Look();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        Welcome.Entry();
                        break;
                }
            }
            catch (FormatException)
            { 
                Console.WriteLine("\n                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Selec();
                Selec();
            }
            // Seguro en contra de errores en la seleccion de opciones
            catch (Exception)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Selec();
                Selec();
            }
        }
    }
}