using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShop
{
    class Books
    {
        // Declaracion de Variables Publicas
        public static List<Books> BookObj;
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public string Editorial { get; set; }
        public string Tipo { get; set; }
        public string Año { get; set; }
        public string Puntuacion { get; set; }
        public static string path = @"C:\Users\Emil\source\repos\BookShop\Books.txt";
        public static string recibos = @"C:\Users\Emil\source\repos\BookShop\Bills.txt";

        // Metodo Creacion de Libros (predefinidos) e Impresion de los mismos
        public static void Libs()
        {
            // Lista de "libros" que van a ser creados
            BookObj = new List<Books> {
            new Books { Nombre = "Memorias", Autor = "Rafael Vito", Año = "2016", Genero = "Ciencia Ficción", Editorial = "Prisma", Tipo = "Literario", Puntuacion = "3.7" },
            new Books { Nombre = "La Casa Blanca", Autor = "Ana Castillo", Año = "2017", Genero = "Política", Editorial = "NewsGlobal", Tipo = "Ilustrado", Puntuacion = "2.8" },
            new Books { Nombre = "La Vida de Bianca", Autor = "Jenna Ríos", Año = "2017", Genero = "Biografia", Editorial = "NewsGlobal", Tipo = "Biografico", Puntuacion = "4.7" },
            new Books { Nombre = "Vacío", Autor = "Diego Hazel", Año = "2018", Genero = "Autoayuda", Editorial = "Prisma", Tipo = "Juveniles", Puntuacion = "4.8" },
            new Books { Nombre = "Sueños de Tokyo", Autor = "Jay Nyte", Año = "2015", Genero = "Ciencia Ficción", Editorial = "Prisma", Tipo = "Literario", Puntuacion = "3.9" }
            };

            StreamWriter listaLibros = new StreamWriter(path, true);
            foreach (Books books in BookObj)
            {
                listaLibros.WriteLine("  ---------------------------------------------------------------------------------------------------------------------------------------");
                listaLibros.WriteLine($" | Nombre: {books.Nombre} | Autor: {books.Autor} | Año: {books.Año} | Genero: {books.Genero} | Editorial: {books.Editorial} | Tipo: {books.Tipo} | Calif: {books.Puntuacion} ");
            }
            listaLibros.Close();
            
            Console.Clear();
            Console.WriteLine("\n                              [# ~~~~~~~~~~~~~~ L I B R O S - D I S P O N I B L E S ~~~~~~~~~~~~~~ #]");
            Console.WriteLine("      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            foreach (Books books in BookObj)
            {
                Console.WriteLine("      ---------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"     | Nombre: {books.Nombre} | Autor: {books.Autor} | Año: {books.Año} | Genero: {books.Genero} | Editorial: {books.Editorial} | Tipo: {books.Tipo} | Calif: {books.Puntuacion} ");
            }
            Console.WriteLine("      ---------------------------------------------------------------------------------------------------------------------------------------");
            Console.Write("     > 1. Volver: ");
            double rptFunc = double.Parse(Console.ReadLine());
            if (rptFunc == 1) { Menu.Selec(); }
            else { Libs(); }
        }

        public static void Look()
        {
            Console.Clear();
            Console.WriteLine("\n                                  [# ~~~~~~~~~~~~~~ B U S Q U E D A - L I B R O S ~~~~~~~~~~~~~~ #]");
            Console.WriteLine("      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("                                            Puedes buscar por las siguientes categorias: \n");
            Console.WriteLine("                                                        ~----------------~");
            Console.WriteLine("                                                       | ~ Nombre         |");
            Console.WriteLine("                                                       | ~ Autor          |");
            Console.WriteLine("                                                       | ~ Año            |");
            Console.WriteLine("                                                       | ~ Genero         |");
            Console.WriteLine("                                                       | ~ Editorial      |");
            Console.WriteLine("                                                       | ~ Tipo           |");
            Console.WriteLine("                                                       | ~ Calificacion   |");
            Console.WriteLine("                                                        ~----------------~\n"); 
            start:
            string[] Libs = File.ReadAllLines(path);
            Console.Write("                                                  > Que desea buscar?: ");
            string searchWord = Console.ReadLine();
            bool disBool = false;
            for(int i = 0; i < Libs.Length; i++)
            {
                if(Libs[i].Contains(searchWord) == true)
                {
                    disBool = true;
                    break;
                }
                else
                {
                    disBool = false;
                }
            }
            if(disBool == true)
            {
                Console.WriteLine("{0} found!", searchWord);
            }
            else
            {
                Console.WriteLine("{0} not found!", searchWord);
            }
            goto start;
            /*
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToString() == "si" || rptFunc == "s"){ Menu.Selec(); }
            else{ Menu.Selec(); }*/
        }// Not Ready

        public static void Take()
        {
            Console.Clear();
            Console.WriteLine("\n                                 [# ~~~~~~~~~~~~~~ T O M A R - L I B R O S ~~~~~~~~~~~~~~ #]");
            Console.WriteLine("      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("                        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ ");
            Console.WriteLine("                       | Para poder utilizar este servicio, debes introducir tus datos aqui debajo:");
            Console.Write("                       |               ~ Nombre y Apellido: ");
            string Est = Console.ReadLine();
            Console.Write("                       |               ~ Matrícula: ");
            string Mat = Console.ReadLine();
            Console.Write("                       |               ~ Carrera: ");
            string Carr = Console.ReadLine();
            Console.Write("                       |               ~ Fecha de Inicio Prestamo: ");
            DateTime FechaIn = DateTime.Parse(Console.ReadLine());
            Console.Write("                       |               ~ Fecha de Fin Prestamo: ");
            DateTime FechaFin = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("                       ~ Escoge un Libro: ");
        }

        public static void Bill()
        {
            StreamWriter reciboLibros = new StreamWriter(path, true);
            foreach (Books books in BookObj)
            {
                reciboLibros.WriteLine("     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                reciboLibros.WriteLine("    |               Datos del Estudiante: ");
                reciboLibros.WriteLine("    |");
                reciboLibros.WriteLine("    |               ~ Nombre y Apellido: ");
                reciboLibros.WriteLine("    |               ~ Matrícula: ");
                reciboLibros.WriteLine("    |               ~ Carrera: ");
                reciboLibros.WriteLine("    |               ~ Libro: ");
                reciboLibros.WriteLine("    |               ~ Fecha de Inicio Prestamo: ");
                reciboLibros.WriteLine("    |               ~ Fecha de Fin Prestamo: ");
                reciboLibros.WriteLine("    |");
            }
            reciboLibros.Close();
        }

        public static void Hist()
        {
            Console.WriteLine("     ~~~~~~~~~~~~~~~~~~~~ Historial de Prestamos ~~~~~~~~~~~~~~~~~~~~~ \n");
            string[] genRecbibos = File.ReadAllLines(recibos);
            foreach (string line in genRecbibos)
            {
                Console.WriteLine("             " + line);
            }
            Console.Write("\n                                 ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
            {
                Menu.Selec();
            }
            else
            {
                Hist();
            }
        }
    }
}