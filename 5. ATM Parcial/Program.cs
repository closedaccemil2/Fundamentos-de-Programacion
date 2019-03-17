﻿using System;
using System.IO;

namespace Parcial_13042019
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
        }
        // Variables Globales para uso de los metodos
        static string Nombre, Apellido, User, Pass;
        static string Client = Nombre + " " + Apellido;
        static string ID = "Usuario: " + User + ", Clave: " + Pass;
        static long numCuenta;
        static double depBalance;
        static DateTime Nac;
        static bool LoggedIn;
        static double Op;
        static bool Admin = false;

        // Metodo de entrada: Inicio de Sesión, Registro y Cierre de la Aplicacion
        static void Welcome()
        {
            // Sets Básicos
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Cajero ITLA";
            Console.WriteLine("            [# ~~~~~~ Bienvenido al Cajero Tecnológico de Las Americas ~~~~~~ #]");
            Console.WriteLine("            [# ~~~~~~~~~~~~~~~~~~~~ " + DateTime.Now + " ~~~~~~~~~~~~~~~~~~~~ #]");
            Console.WriteLine("                            ~------------------------------------~");
            Console.WriteLine("                            |                                    |");
            Console.WriteLine("                            | 1. Iniciar Sesión                  |");
            Console.WriteLine("                            | 2. Registrarse                     |");
            Console.WriteLine("                            | 3. Salir del ATM                   |");
            Console.WriteLine("                            |                                    |");
            Console.WriteLine("                            ~------------------------------------~");
            Console.Write("                            > ");
            double Op = double.Parse(Console.ReadLine());
            try
            {
                switch (Op)
                {
                    case 1:
                        Console.Clear();
                        Login();
                        break;
                    case 2:
                        Console.Clear();
                        Reg();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("                            ~ Debe introducir un numero para escoger una opción....");
                        Console.Write("                            ~ Reintentar?: ");
                        string Ask = Console.ReadLine();
                        if (Ask.ToLower() == "si")
                        {
                            Console.Clear();
                            Welcome();
                        }
                        else Welcome();

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
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
        }
        
        // Metodo de Registro y almacenamiento temporal de los datos de un usuario
        public static void Reg()
        {
            try
            {
                Console.WriteLine("                        [# ~~~~~~~~~~~~~~~~~~~~ Regístrate ~~~~~~~~~~~~~~~~~~~~ #]\n");
                Console.WriteLine("                                  -----------------------------------------");
                Console.Write("                                  | Introduce tu Nombre: ");
                Nombre = Console.ReadLine();
                Console.WriteLine("                                  |");
                Console.Write("                                  | Introduce tu Apellido: ");
                Apellido = Console.ReadLine();
                Console.WriteLine("                                  |");
                Console.Write("                                  | Fecha de Nacimiento: ");
                Nac = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("                                  |");
                Console.Write("                                  | Deposite un Balance Inicial: ");
                depBalance = double.Parse(Console.ReadLine());
                Console.WriteLine("                                  -----------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("                        [#### Ahora que has registrado tus datos, debes introducir tu forma de Acceso ####]\n");
                Console.WriteLine("                                     ---------------------------------");
                Console.Write("                                  | Escoge un Nombre de Usuario: ");
                User = Console.ReadLine();
                Console.WriteLine("                                  |");
                Console.Write("                                  | Escoge una Contraseña: ");
                Pass = Console.ReadLine();
                Console.WriteLine("                                    ----------------------------------");
                Console.WriteLine("");
                Console.WriteLine("                                  **Generando Credenciales y Numero de Cuenta.........**");
                Random random = new Random();
                numCuenta = random.Next(32000000, 33000000);
                Console.WriteLine("\n");
                Console.WriteLine("                                   ------------------------------");
                Console.WriteLine("                                  |*Credenciales Registradas*");
                Console.WriteLine("                                  |                          ");
                Console.WriteLine("                                  | Tu Usuario es: " + User);
                Console.WriteLine("                                  | Tu Clave es: " + Pass);
                Console.WriteLine("                                  | Numero Cuenta: " + numCuenta);
                Console.WriteLine("                                  |                          ");
                Console.WriteLine("                                   ------------------------------\n");
                Console.WriteLine("                                   ~----------------~");
                Console.WriteLine("                                  |    1. Guardar    |");
                Console.WriteLine("                                  |    2. Cancelar   |");
                Console.WriteLine("                                   ~----------------~");
                Console.Write("                                  > ");
                string Ask = Console.ReadLine();
                if (Ask.ToLower() == "1")
                {
                    Console.Clear();
                    Console.WriteLine("                                   ~----------------------------------------~");
                    Console.WriteLine("                                  | Tus Datos fueron guardados con exito.    |");
                    Console.WriteLine("                                   ~----------------------------------------~\n");
                    Console.Write("                                  >> Desea ir al Menu Principal? ");
                    string Ask1 = Console.ReadLine();
                    if (Ask1.ToLower() == "si")
                        Menu();
                    else
                    {
                        Welcome();
                    }
                }
                else if (Ask.ToLower() == "2")
                {
                    Console.Clear();
                    Console.WriteLine("                                   ~------------------------------~");
                    Console.WriteLine("                                  |  Este Registro fue cancelado.  |");
                    Console.WriteLine("                                   ~------------------------------~\n");
                    string Ask1 = Console.ReadLine();
                    Console.Write("                                  >> Desea ir al Menu Principal? ");
                    if (Ask1.ToLower() == "si")
                        Menu();
                    else
                    {
                        Welcome();
                    }
                }
                // Forma de escribir datos en un archivo para su uso posterior
                StreamWriter Regs = new StreamWriter(@"C:\ATM\Login.txt", true);
                Regs.Write(User);
                Regs.Write("\n");
                Regs.WriteLine(DateTime.Now);
                Regs.Close();
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
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
        }

        // Metodo de proyeccion del Menu general, se accesa a traves del Login o despues de Registrarse
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("              [# ~~~~~~~~~~~~~~ S E R V I C I O S - D I S P O N I B L E S ~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                  ~------------------------------~");
            Console.WriteLine("                                 | Cajero Automatizado ITLA (Est) |");
            Console.WriteLine("                                 |                                |");
            Console.WriteLine("                                 | 1. Consultar Balance           |"); // Listo
            Console.WriteLine("                                 | 2. Información de Cuenta       |"); // Listo ---
            Console.WriteLine("                                 | 3. Añadir Beneficiarios        |");
            Console.WriteLine("                                 | 4. Retiro Efectivo             |"); // Listo
            Console.WriteLine("                                 | 5. Deposito Efectivo           |"); // Listo
            Console.WriteLine("                                 | 6. Transferir Efectivo         |");
            Console.WriteLine("                                 | 7. Divisas Populares           |"); // Listo
            Console.WriteLine("                                 | 8. Cambio de Divisa            |");
            Console.WriteLine("                                 | 9. Facturas Generadas          |");
            Console.WriteLine("                                 | 0. Volver al Inicio            |"); // Listo
            Console.WriteLine("                                  ~------------------------------~");
            Console.Write("                                  > ");
            Op = double.Parse(Console.ReadLine());
            try
            {
                switch (Op)
                {
                    case 1:
                        Console.Clear();
                        Money();
                        break;
                    case 2:
                         Console.Clear();
                         Account();
                        break;
                    case 3:
                        Console.Clear();
                        Benef();
                        break;
                    case 4:
                        Console.Clear();
                        retMoney();
                        break;
                    case 5:
                        Console.Clear();
                        depMoney();
                        break;
                    case 6:
                        Console.Clear();
                        Transf();
                        break;
                    case 7:
                        Console.Clear();
                        Currencies();
                        break;
                    case 8:
                        Console.Clear();
                        Exchange();
                        break;
                    case 9:
                        Recps();
                        break;
                    case 0:
                        Console.Clear();
                        Welcome();
                        break;
                    default:
                        Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                        Console.Write("                                 | Reintentar?: ");
                        string rptFunc = Console.ReadLine();
                        if (rptFunc.ToString() == "si" || rptFunc == "s")
                            Exchange();
                        Menu();
                        break;
                }
            }
            // Seguros en contra de errores en la seleccion 
            catch (FormatException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
        } // Ready

        // Metodo de Inicio de Sesion, solo el usuario admin y usuarios registrados puedes avanzar desde aqui
        static void Login()
        {
            try
            {
                Console.WriteLine("                        [# ~~~~~~~~~~~~~~~~~~~~ Inicie Sesión ~~~~~~~~~~~~~~~~~~~~ #]\n");
                Console.WriteLine("                                  ~-------------------------------~");
                Console.WriteLine("                                  | Ingrese a su Cuenta:");
                Console.WriteLine("                                  |                                ");
                Console.Write("                                  | Usuario: ");
                string UserID = Console.ReadLine();
                Console.WriteLine("                                  |                                ");
                Console.Write("                                  | Clave: ");
                string PassID = Console.ReadLine();
                Console.WriteLine("                                  ~-------------------------------~");
                // Aqui se declara el usuario Admin (Proposito: Pruebas de Funciones)
                if (UserID == "doeJohn" && PassID == "11aa")
                {
                    Admin = true;
                    Nombre = "John";
                    Apellido = "Doe";
                    User = "doeJohn";
                    Nac = new DateTime(1992, 1, 1, 8, 30, 52);
                    numCuenta = 32450720;
                    depBalance = 50000.99;
                }
                else
                {
                    LoggedIn = false;
                }
                string readText = File.ReadAllText(@"C:\ATM\Login.txt");
                if (readText.Contains(UserID) || Admin == true)
                {
                    LoggedIn = true;
                    Menu();
                }
                else
                {
                    Console.Write("                                  ~ Su usuario no esta registrado. Desea reintentar? ");
                    string rptFunc = Console.ReadLine();
                    if (rptFunc.ToString() == "si" || rptFunc == "s")
                        Console.Clear();
                    Login();
                    Welcome();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
            }
            catch (FileNotFoundException)
            {
                if (User == "doeJohn" && Pass == "11aa")
                {
                    Admin = true;
                    Nombre = "John";
                    Apellido = "Doe";
                    User = "doeJohn";
                    Nac = new DateTime(1992, 1, 1, 8, 30, 52);
                    numCuenta = 32450720;
                    depBalance = 50000.99;
                }
        
            }
            // Seguro en contra de errores en la seleccion de opciones
            catch (Exception)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Menu();
                Menu();
            }
        } // Ready

        // Metodo de Proyeccion del Balance Actual del usuario
        static void Money()
        {
            Console.WriteLine("                       [# ~~~~~~~~~~~~~~~~~~~~ Balance ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                  ~-------------------------------~");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | Balance Actual: " + depBalance);
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                  ~-------------------------------~");
            Console.Write("                                ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToString() == "si" || rptFunc == "s")
                Menu();
            Welcome();
        } // Ready

        // Metodo para Proyectar la informacion de la cuenta a partir del Registro
        static void Account()
        {
            string Client = Nombre + " " + Apellido;
            Console.WriteLine("                 [# ~~~~~~~~~~~~~~~~~~~~ Información de Cuenta ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                   ~----------------------------------~");
            Console.WriteLine("                                  | ");
            Console.WriteLine("                                  | Dueño de Cuenta: " + Client);
            Console.WriteLine("                                  | Fecha Nacimiento: " + Nac.ToString());
            Console.WriteLine("                                  | Nombre Usuario: " + User);
            Console.WriteLine("                                  | Número de Cuenta: " + numCuenta);
            Console.WriteLine("                                  | ");
            Console.WriteLine("                                   ~----------------------------------~");
            Console.Write("                                   ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
                Menu();
            Welcome();
        } // Ready

        // Metodo para añadir Beneficiarios
        static void Benef() // El usuario Admin no puede usar esta opcion...
        {
            try
            {
                string[] Benefs = new string[0];
                Console.WriteLine("                  [# ~~~~~~~~~~~~~~~~~~~~ Añadir Beneficiarios ~~~~~~~~~~~~~~~~~~~~ #]\n");
                Console.Write("");
                Console.WriteLine("                                  ~-----------------------------------~");
                Console.Write("                                  | Nombres del Beneficiario: ");
                string ben = Console.ReadLine();
                Console.WriteLine("                                  |");
                Console.Write("                                  | Numero de Cuenta: ");
                long benefNum = long.Parse(Console.ReadLine());
                Console.WriteLine("                                  |");
                Console.Write("                                  | Clave Personal: ");
                string userPin = Console.ReadLine();
                Console.WriteLine("                                  |");
                if (userPin != Pass)
                {
                    Console.WriteLine("                                  | Clave Incorrecta.");
                    Console.Write("                                  | Desea volver a añadir a un Beneficiario?: ");
                    string op1 = Console.ReadLine();
                    if (op1.ToLower() == "si")
                    {
                        Console.Clear();
                        Benef();
                    }
                    else
                    {
                        Menu();
                    }
                }
                Console.WriteLine("                      ~ Beneficiario: " + ben + ", Numero de Cuenta: " + benefNum + ". Añadido el: " + DateTime.Now);
                Console.Write("                                  | Desea volver a añadir a un Beneficiario?: ");
                string op = Console.ReadLine();
                if (op.ToLower() == "si")
                {
                    Console.Clear();
                    Benef();
                }
                else
                {
                    Menu();
                }
                string newben = "Beneficiario: " + ben + ", Numero de Cuenta: " + benefNum + ". Añadido el: " + DateTime.Now;
                StreamWriter Recps = new StreamWriter(@"C:\ATM\Benefs.txt", true);
                Recps.Write(newben);
                Recps.Close();
            }
            catch (FormatException)
            {
                Console.WriteLine("                                  | **Solo puede introducir una valores numericos**");
                Console.Write("                                ~ Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                {
                    Console.Clear();
                    Benef();
                }
                else
                {
                    Menu();
                }
                
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("                                  | **Solo puede introducir una valores numericos**");
                Console.Write("                                ~ Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Console.Clear();
                    Benef();
                Menu();
            }
        } // Ready

        // Metodo para Retirar efectivo de la cuenta, se resta del Balance Actual
        static void retMoney()
        {
            Console.WriteLine("                   [# ~~~~~~~~~~~~~~~~~~~~ Retiro Bancario ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                  ~-------------------------------~");
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Cuanto Desea Retirar?: ");
            double Ret = double.Parse(Console.ReadLine());
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Esta segur@?: ");
            string confirm = Console.ReadLine();
            double Retd;
            if (Ret > depBalance)
            {
                Console.WriteLine("                                 | ");
                Console.WriteLine("                                 | El Monto ingresado supero su Balance actual....");
                Console.WriteLine("                                 | ");
                Console.Write("                                 | Desea volver a solicitar un Retiro?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    retMoney();
                }
                else
                {
                    Menu();
                }
            }
            if (confirm.ToLower() == "si")
                Retd = depBalance - Ret;
            else
            {
                Console.WriteLine("                                 | Retiro Cancelado.");
                Console.Write("                                 | Desea volver a solicitar un Retiro?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    retMoney();
                }
                else
                {
                    Menu();
                }
            }
            Retd = depBalance - Ret;
            depBalance = Retd;
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Retiro Exitoso.** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Transaccion Generada el: " + DateTime.Now+ "** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                  ~-------------------------------~");
            string Registry = "Retiro Realizado el: " + DateTime.Now + ", Cliente: "  + Nombre + " " + Apellido +  ", Monto Retirado: " + Ret;
            StreamWriter Rets = new StreamWriter(@"C:\ATM\Recps.txt", true);
            Rets.Write(Registry);
            Rets.Write("\n");
            Rets.Close();
            Console.Write("\n                                ~ Desea imprimir su comprobante? ");
            string comp = Console.ReadLine();
            if (comp.ToLower() == "si" || comp == "s")
                Console.WriteLine("\n                   ~ " + Registry + "\n");
            else
            {
                Console.WriteLine("\n");
            }
            Console.Write("                                ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
                Menu();
            Welcome();
        } //Ready

        // Metodo para Depositar efectivo en la cuenta, se resta del Balance Actual
        static void depMoney()
        {
            Console.WriteLine("                  [# ~~~~~~~~~~~~~~~~~~~~ Deposito Bancario ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                  ~-------------------------------~");
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Cuanto Desea Depositar?: ");
            double Dep = double.Parse(Console.ReadLine());
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Esta segur@?: ");
            string confirm = Console.ReadLine();
            double Depd;
            if (Dep > 45600)
            {
                Console.WriteLine("                                 | ");
                Console.WriteLine("                                 | El Monto ingresado supero el Límite de Ingresos....");
                Console.WriteLine("                                 | ");
                Console.Write("                                 | Desea volver a hacer un Deposto?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    depMoney();
                }
                else
                {
                    Menu();
                }
            }
            if (confirm.ToLower() == "si")
                Depd = depBalance + Dep;
            else
            {
                Console.WriteLine("                                 | Retiro Cancelado.");
                Console.Write("                                 | Desea volver a solicitar un Retiro?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    retMoney();
                }
                else
                {
                    Menu();
                }
            }

            Depd = depBalance + Dep;
            depBalance = Depd;
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Deposito Exitoso.** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Transaccion Generada el: " + DateTime.Now + "** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                  ~-------------------------------~");
            string Registry =  "Deposito Realizado el: " + DateTime.Now + ", Cliente: " + Nombre + " " + Apellido + ", Monto Depositado: " + Dep;
            StreamWriter Deps = new StreamWriter(@"C:\ATM\Recps.txt", true);
            Deps.Write(Registry);
            Deps.Write("\n");
            Deps.Close();
            Console.Write("\n                                ~ Desea imprimir su comprobante? ");
            string comp = Console.ReadLine();
            if (comp.ToLower() == "si" || comp == "s")
                Console.WriteLine("\n                   ~ " + Registry + "\n");
            else
            {
                Console.WriteLine("\n");
            }
            Console.Write("                                ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
                Menu();
            Welcome();
        } // Ready

        // Metodo de Transferencia de Efectivo a un Beneficiario
        static void Transf() // Ready
        {
            Console.WriteLine("                       [# ~~~~~~~~~~~~~~~~~~~~ Transferencia de Efectivo ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.WriteLine("                                 ~------------------------------------------------~");
            Console.Write("                                 | Introduzca el beneficiario: ");
            string benTrans = Console.ReadLine();
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Introduzca el numero de cuenta: ");
            string numTrans = Console.ReadLine();
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Introduzca el monto: ");
            double amountTrans = double.Parse(Console.ReadLine());
            Console.WriteLine("                                 | ");
            Console.Write("                                 | Esta segur@?: ");
            string confirm = Console.ReadLine();
            double Transfd;
            if (amountTrans > depBalance)
            {
                Console.WriteLine("                                 | ");
                Console.WriteLine("                                 | El Monto ingresado supero su Balance actual....");
                Console.WriteLine("                                 | ");
                Console.Write("                                 | Desea volver a solicitar una Transferencia?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    Transf();
                }
            }
            if (confirm.ToLower() == "si")
                Transfd = depBalance - amountTrans;
            else
            {
                Console.WriteLine("                                 | Retiro Cancelado.");
                Console.Write("                                 | Desea volver a solicitar un Retiro?: ");
                string over = Console.ReadLine();
                if (over.ToLower() == "si" || over == "s")
                {
                    Console.Clear();
                    retMoney();
                }
                else
                {
                    Menu();
                }
            }
            Transfd = depBalance - amountTrans;
            depBalance = Transfd;
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Transferencia Exitosa.** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                 | **Transaccion Generada el: " + DateTime.Now + "** ");
            Console.WriteLine("                                 | ");
            Console.WriteLine("                                  ~-------------------------------~");
            string Registry = "Transferencia Realizada el: " + DateTime.Now  + " Beneciad@: " + benTrans + ", N. de Cuenta: " + numTrans + ", Monto Retirado: " + amountTrans;
            StreamWriter Rets = new StreamWriter(@"C:\ATM\Recps.txt", true);
            Rets.Write(Registry);
            Rets.Close();
            Console.Write("\n                                ~ Desea imprimir su comprobante? ");
            string comp = Console.ReadLine();
            if (comp.ToLower() == "si" || comp == "s")
                Console.WriteLine("\n   " + Registry + "\n");
            else
            {
                Console.WriteLine("\n");
            }
            Console.Write("                                ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
                Menu();
            Welcome();
            Console.WriteLine("                                 ~------------------------------------------------~");
        }

        // Metodo para ver las divisas mas populares y su valor en la Moneda Nacional
        static void Currencies()
                {
                    Console.WriteLine("                [# ~~~~~~~~~~~~~~~~~~~~ Divisas Mas Populares ~~~~~~~~~~~~~~~~~~~~ #]\n");
                    Console.WriteLine("                                  ~-------------------------------~");
                    Console.WriteLine("                                 |                                 |");
                    Console.WriteLine("                                 |       $USD 1 = $RD 50.63        |");
                    Console.WriteLine("                                 |       €EUR 1 = $RD 57.30        |");
                    Console.WriteLine("                                 |       ¥JPY 1 = $RD 0.45         |");
                    Console.WriteLine("                                 |                                 |");
                    Console.WriteLine("                                  ~-------------------------------~");
                    Console.Write("                                ~ Desea volver al Menu? ");
                    string rptFunc = Console.ReadLine();
                    if (rptFunc.ToString() == "si" || rptFunc == "s")
                        Menu();
                    Menu();
                } // Ready

        // Metodo para realizar conversiones entre las divisas anteriores a la Moneda Nacional
        static void Exchange() 
        {
            Console.WriteLine("                       [# ~~~~~~~~~~~~~~~~~~~~ Conversión de Divisas ~~~~~~~~~~~~~~~~~~~~ #]\n");
            Console.Write("                                 ~ Puedes convertir de las 3 Divisas mas populares a $RD: \n");
            Console.WriteLine("                                              ~------------~");
            Console.WriteLine("                                             | 1. USD => RD |");
            Console.WriteLine("                                             | 2. EUR => RD |");
            Console.WriteLine("                                             | 3. JPY => RD |");
            Console.WriteLine("                                             | 4. Volver    |");
            Console.WriteLine("                                              ~------------~\n");
            Console.Write("                                     > ");
            Op = double.Parse(Console.ReadLine());
            try
            {
                switch (Op)
                {
                    case 1:
                        Console.WriteLine("                                  ~-----------------------------------------------~");
                        Console.WriteLine("                                 |$USD Dolar Estadounidense => $RD Peso Dominicano");
                        Console.WriteLine("                                 |");
                        Console.Write("                                 | > Introduce la suma: $USD");
                        double dollar = double.Parse(Console.ReadLine());
                        double dollarToRD = 50.62;
                        double converted1 = dollarToRD * dollar;
                        Console.WriteLine("                                 |                                |");
                        Console.WriteLine("                                 | > Es igual a: $RD" + converted1 + " Pesos Domincanos");
                        Console.WriteLine("                                  ~-----------------------------------------------~");
                        break;
                    case 2:
                        Console.WriteLine("                                  ~-----------------------------------------~");
                        Console.WriteLine("                                 |€EUR Euro Europeo => $RD Peso Dominicano");
                        Console.WriteLine("                                 |");
                        Console.Write("                                 | > Introduce la suma: €EUR");
                        double euro = double.Parse(Console.ReadLine());
                        double euroToRD = 57.43;
                        double converted2 = euroToRD * euro;
                        Console.WriteLine("                                 |                                |");
                        Console.WriteLine("                                 | > Es igual a: $RD" + converted2 + " Pesos Domincanos");
                        Console.WriteLine("                                  ~-----------------------------------------~");
                        break;
                    case 3:
                        Console.WriteLine("                                  ~-----------------------------------------------~");
                        Console.WriteLine("                                 |¥JPY Yen Japonés => $RD Peso Dominicano");
                        Console.WriteLine("                                 |");
                        Console.Write("                                 | > Introduce la suma: ¥JPY");
                        double yen = double.Parse(Console.ReadLine());
                        double yenToRD = 0.45;
                        double converted3 = yenToRD * yen;
                        Console.WriteLine("                                 |                                |");
                        Console.WriteLine("                                 | > Es igual a: $RD" + converted3 + " Pesos Domincanos");
                        Console.WriteLine("                                  ~-----------------------------------------------~");
                        break;
                    case 4:
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("                                  ~ Debe introducir un numero para escoger una opción....");
                        Console.Write("                                  ~ Reintentar?: ");
                        string Ask = Console.ReadLine();
                        if (Ask.ToLower() == "si")
                        {
                            Console.Clear();
                            Welcome();
                        }
                        else Welcome();
                        break;
                }
                Console.Write("                                  >> Desea realizar otra conversión? ");
                string Ask1 = Console.ReadLine();
                if (Ask1.ToLower() == "si")
                {
                    Console.Clear();
                    Exchange();
                }
                else
                {
                    Menu();
                }
            }
            // Seguros en contra de errores
            catch (FormatException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Exchange();
                Menu();
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("                                 | **Solo puede introducir una Opción Numeral**");
                Console.Write("                                 | Reintentar?: ");
                string rptFunc = Console.ReadLine();
                if (rptFunc.ToString() == "si" || rptFunc == "s")
                    Exchange();
                Menu();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Exchange();
            }
        } // Ready
        
        // Metodo para proyectar los Recibos/Facturas generadas de: Retiros, Depositos y Tranferencias
        static void Recps()
        {
            Console.Clear();
            string[] genReceps = File.ReadAllLines(@"C:\ATM\Recps.txt");
            Console.WriteLine("                        [# ~~~~~~~~~~~~~~~~ Facturas Generadas ~~~~~~~~~~~~~~~~ #]\n");
            foreach (string line in genReceps)
            {
                Console.WriteLine("             --------------------------------------------------------------------");
                Console.WriteLine("             ~ " + line);
            }
            Console.WriteLine("             --------------------------------------------------------------------");
            Console.Write("\n                                 ~ Desea volver al Menu? ");
            string rptFunc = Console.ReadLine();
            if (rptFunc.ToLower() == "si" || rptFunc == "s")
                Menu();
            Menu();
        } // Ready
    }
}

