using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6076
{
    class HerramientaCalculo
    {
        static void Main(string[] args)
        {
            //Sets Básicos
            Console.Title = "Herramienta de Cálculo";
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("<==== Calculadora Aritmética | 186076 | 13/02/2019 ====>");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\n\n Suma (+): s \n\n Resta (-): r \n\n Multiplicación (x): m \n\n División (÷): d");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("\n Puedes cerrar el programa en cualquier momento digitando 'e'.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n ------------------------------");

            //Variables
            int Num1 = 0;
            int Num2 = 0;
            Console.WriteLine("Especifica que operación deseas realizar:");
            string Ask = Console.ReadLine();
            string Resp = Ask.ToString();
            //Ejecución
            switch (Resp)
            {
                case "s":
                    Console.WriteLine("Ingrese sus dos numeros");
                    Console.Write("Valor 1: ");
                    Num1 = int.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    Num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(Num1 + Num2);
                    break;

                case "r":
                    Console.WriteLine("Ingrese sus dos numeros");
                    Console.Write("Valor 1: ");
                    Num1 = int.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    Num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(Num1 - Num2);
                    break;

                case "m":
                    Console.WriteLine("Ingrese sus dos numeros");
                    Console.Write("Valor 1: ");
                    Num1 = int.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    Num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(Num1 * Num2);
                    break;

                case "d":
                    Console.WriteLine("Ingrese sus dos numeros");
                    Console.Write("Valor 1: ");
                    Num1 = int.Parse(Console.ReadLine());
                    Console.Write("Valor 2: ");
                    Num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(Num1 / Num2);
                    break;
                case 2:
                    break;
            }
        }
    }
}
