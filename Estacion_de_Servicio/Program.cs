using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estación_de_Servicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        //Método Menu()
        static void Menu()
        {
            //Variables del sistema
            //Variable tanque[3], tanques[0]: Premium - tanques[1]: Súper - tanques[2]: Gasoil
            double[] tanques = new double[] { 0, 0, 0 };
            //Precio de combustibles
            double precioSuper = 147, precioPremium = 180, precioGasoil = 148;
            //Variables litros vendidos totales por tipo de combustible
            double vendidoPremium = 0, vendidoSuper = 0, vendidoGasoil = 0;
            //Variable para la carga en $ y para la recepción de litros vendidos.
            double carga_pesos = 0, litros = 0;


            int op, error = 0;
            string contraseña = "ISFT177", ing_con;



            do
            {//Apertura del do
                Console.WriteLine("1. Vender Nafta Premium.");
                Console.WriteLine("2. Vender Nafta Súper.");
                Console.WriteLine("3. Vender Gasoil.");
                Console.WriteLine("4. Cargar Tanque de Combustible.");
                Console.WriteLine("5. Comprobar Tanques.");
                Console.WriteLine("6. Ver Ingresos.");
                Console.WriteLine("7. Salir de Sistema.");

                Console.Write("\nElija una opción: ");
                op = int.Parse(Console.ReadLine());
                while (op < 1 || op > 7)
                {
                    Console.Write("ERROR. Ingrese una opción valida: ");
                    op = int.Parse(Console.ReadLine());

                }

                switch (op)
                {
                    case 1:
                        Console.Write("Este método no esta");
                        Console.ReadKey();
                        //VentaPremium(tanques, carga_pesos, precioPremium);
                        break;

                    case 2:
                        Console.WriteLine("Venta de combustible Súper");
                        Console.Write("Ingrese el monto a cargar en $: ");
                        carga_pesos = double.Parse(Console.ReadLine());

                        litros = VentaSuper(tanques, carga_pesos, precioSuper);
                        vendidoSuper += litros;
                        break;


                    case 3:
                        VentaGasoil(tanques, carga_pesos, precioGasoil);
                        break;

                    case 4:



                        Console.Write("Ingrese la contraseña: ");
                        ing_con = Console.ReadLine();

                        while (ing_con != contraseña && error < 3)
                        {

                            Console.WriteLine("ERROR. Ingresar una nueva contraseña: ");
                            ing_con = Console.ReadLine();
                            error++;

                            if (error >= 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingreso la contraseña incorrecta más de 3 veces. Por favor elija otra opción.");
                                Console.WriteLine("");
                                Menu();

                            }
                        }
                        Console.WriteLine("Contraseña correcta");
                        Console.WriteLine("");

                        CargarTanques(tanques);


                        break;

                    case 5:
                        ConsultarTanques(tanques);
                        break;

                    case 6:

                        Console.Write("Ingrese la contraseña: ");
                        ing_con = Console.ReadLine();

                        while (ing_con != contraseña && error < 3)
                        {

                            Console.WriteLine("ERROR. Ingresar una nueva contraseña: ");
                            ing_con = Console.ReadLine();
                            error++;

                            if (error >= 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingreso la contraseña incorrecta más de 3 veces. Por favor elija otra opción.");
                                Console.WriteLine("");
                                Menu();

                            }
                        }
                        Console.WriteLine("Contraseña correcta");
                        Console.WriteLine("");
                        Ingresos(tanques,  precioPremium, precioSuper, precioGasoil, vendidoPremium, vendidoSuper, vendidoGasoil);
                        
                        break;

                    case 7:
                        char salir;

                        Console.WriteLine("¿Desea salir? [S/N]");
                        salir = char.Parse(Console.ReadLine());
                        salir = char.ToUpper(salir);
                        while (salir != 'S' && salir != 'N')
                        {
                            Console.WriteLine("Debe ingresar S = Si o N = No");
                            salir = char.Parse(Console.ReadLine());
                            salir = char.ToUpper(salir);
                        }
                        if (salir == 'S')
                        { op = 7; }
                        else { op = 8; }
                        Console.Clear();
                        break;
                        /*default:
                                   Console.Write("La opción ingresada no es valida");
                                break;*/


                }

                Console.ReadKey();
            } while (op != 7);//Llave de ciere del Do While


        }

        //Método consltar tanques
        static void ConsultarTanques(double[] tanques)//carga de vector por referencia
        {
            int P1 = 0, P2 = 0, P3 = 0, t0, t1, t2;

            t0 = Convert.ToInt32(tanques[0]);//CONVERTIMOS DOUBLES A ENTEROS PARA LUEGO TRABAJAR PORCENTAJES 
            t1 = Convert.ToInt32(tanques[1]);//CONVERTIMOS DOUBLES A ENTEROS PARA LUEGO TRABAJAR PORCENTAJES
            t2 = Convert.ToInt32(tanques[2]);//CONVERTIMOS DOUBLES A ENTEROS PARA LUEGO TRABAJAR PORCENTAJES


            P1 = (t0 * 100) / 12500;//PORCENTAJE
            P2 = (t1 * 100) / 12500;
            P3 = (t2 * 100) / 12500;
            Console.WriteLine(" Tanque de conbustible Premium " + t0 + " Litro " + " El Porcentaje del tanque es " + P1 + "%");//LEYENDAS
            Console.WriteLine(" Tanque de conmbustible super " + t1 + " Litro " + " El Porcentaje del tanque es " + P2 + "%");
            Console.WriteLine(" Tanque de combustible gasoil " + t2 + " Litro " + " El Porcentaje del tanque es " + P3 + "%");


        }
        //Método cargar tanques
        static void CargarTanques(double[] tanques)
        {
            char opcion;
            double cargaPremium, cargaSuper, cargaGasoil;
            do
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Bienvenido al menu de opciones");
                Console.WriteLine("De Cargar Combustible");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Selecciona El tanque a cargar: ");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1) Nafta Premium");
                Console.WriteLine("2) Nafta Súper");
                Console.WriteLine("3) Nafta Gasoil");
                Console.WriteLine("4) Salir");
                Console.WriteLine("----------------------------------");
                opcion = char.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case '1':
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("haz seleccionado, la carga de Nafta Premium ");
                        Console.WriteLine("¿Cuanto Litros desea cargar?: ");
                        cargaPremium = double.Parse(Console.ReadLine());
                        if ((cargaPremium + tanques[0]) <= 12500)
                        {
                            tanques[0] = tanques[0] + cargaPremium;
                            Console.WriteLine(tanques[0]);
                        }
                        else
                        {
                            Console.WriteLine("ERROR, litros EXCEDIDOS");
                            Console.WriteLine("POR FAVOR, Vuelva a ingresar (La capacidad restante es: " + (12500 - tanques[0]) + ")");
                            Console.WriteLine(tanques[0]);
                        }
                        break;
                    case '2':
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("haz seleccionado, la carga de Nafta Súper ");
                        Console.WriteLine("¿Cuanto Litros desea cargar?: ");
                        cargaSuper = double.Parse(Console.ReadLine());
                        if ((cargaSuper + tanques[1]) <= 12500)
                        {
                            tanques[1] = tanques[1] + cargaSuper;
                            Console.WriteLine(tanques[1]);
                        }
                        else
                        {
                            Console.WriteLine("ERROR, litros EXCEDIDOS");
                            Console.WriteLine("POR FAVOR, Vuelva a ingresar (La capacidad restante es: " + (12500 - tanques[1]) + ")");
                            Console.WriteLine(tanques[1]);
                        }
                        break;
                    case '3':
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("haz seleccionado, la carga de Nafta Gasoil ");
                        Console.WriteLine("¿Cuanto Litros desea cargar?: ");
                        cargaGasoil = double.Parse(Console.ReadLine());
                        if ((cargaGasoil + tanques[2]) <= 12500)
                        {
                            tanques[2] = tanques[2] + cargaGasoil;
                            Console.WriteLine(tanques[2]);
                        }
                        else
                        {
                            Console.WriteLine("ERROR, litros EXCEDIDOS");
                            Console.WriteLine("POR FAVOR, Vuelva a ingresar (La capacidad restante es: " + (12500 - tanques[2]) + ")");
                            Console.WriteLine(tanques[2]);
                        }
                        break;
                    case '4':
                        char Pregunta;
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("¿Desea salir? s/n");
                        Pregunta = char.Parse(Console.ReadLine());
                        Pregunta = char.ToLower(Pregunta);
                        while (Pregunta != 's' && Pregunta != 'n')
                        {
                            Console.WriteLine("ERROR, Vuelva a ingresar (s/n) ");
                            Pregunta = char.Parse(Console.ReadLine());
                            Pregunta = char.ToLower(Pregunta);
                        }
                        if (Pregunta == 's')
                        {
                            opcion = 's';
                        }
                        if (Pregunta == 'n')
                        {
                            Console.WriteLine("Haz decidido quedarte");
                        }
                        break;
                }
            } while (opcion != 's');
        }

        //Método ver ingresos

        static void Ingresos(double[] tanques, double precio_premium, double precio_super, double precio_gasoil, double vendido_premium, double vendido_super, double vendido_gasoil)
        {
            /*
            2022| Developed by Lucas Gonzalez and Cristian Lugo  |Todos los derechos reservados
            */


            ///////  Metodo para ver iformacion de combustibles  ////

            //Llama el metodo 
            /*Ingresos(tanques, precio_premium, precio_super, precio_gasoil, vendido_premium, vendido_super, vendido_gasoil);*/


            //variables
            double tolalPremium, totalSuper, totalGasoil, totalRecaudado, totalTanques, totalLitrosV;
            int opcion;

            //operaciones matematicas
            tolalPremium = vendido_premium * precio_premium;
            totalSuper = vendido_super * precio_super;
            totalGasoil = vendido_gasoil * precio_gasoil;
            totalRecaudado = tolalPremium + totalSuper + totalGasoil;
            totalTanques = tanques[0] + tanques[1] + tanques[2];
            totalLitrosV = vendido_premium + vendido_super + vendido_gasoil;






            while (true)
            {
                Console.Clear();
                /********* MARCO *********/
                Console.CursorVisible = false;
                for (int V = 10; V <= 100; V++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(V, 4);
                    Console.Write("#");
                    Console.SetCursorPosition(V, 30);
                    Console.Write("#");
                    for (int H = 4; H < 31; H++)
                    {
                        Console.SetCursorPosition(10, H);
                        Console.WriteLine("$");
                        Console.SetCursorPosition(100, H);
                        Console.WriteLine("$");

                    }
                }//fin marco

                //menu
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(40, 10);
                Console.WriteLine("**********************************");
                Console.SetCursorPosition(40, 11);
                Console.WriteLine("############ Ingresos ############");
                Console.SetCursorPosition(40, 12);
                Console.WriteLine("**********************************");
                Console.SetCursorPosition(40, 14);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(">>>>>>>>>>>>>> MENÚ <<<<<<<<<<<<<<");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 16);
                Console.WriteLine("[1]> Informacion de Nafta Premium");
                Console.SetCursorPosition(40, 17);
                Console.WriteLine("[2]> Informacion de Nafta Super");
                Console.SetCursorPosition(40, 18);
                Console.WriteLine("[3]> Informacion de Gasoil");
                Console.SetCursorPosition(40, 19);
                Console.WriteLine("[4]> Suma Total");
                Console.SetCursorPosition(40, 20);
                Console.WriteLine("[5]> Salir");
                Console.SetCursorPosition(40, 22);
                Console.ForegroundColor = ConsoleColor.Green;
                try
                {

                    Console.Write("> Ingrese una opción: ");
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            {
                                Console.Clear();
                                /********* MARCO *********/
                                Console.CursorVisible = false;
                                for (int V = 10; V <= 100; V++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(V, 4);
                                    Console.Write("#");
                                    Console.SetCursorPosition(V, 30);
                                    Console.Write("#");
                                    for (int H = 4; H < 31; H++)
                                    {
                                        Console.SetCursorPosition(10, H);
                                        Console.WriteLine("$");
                                        Console.SetCursorPosition(100, H);
                                        Console.WriteLine("$");
                                    }
                                }//fin marco
                                Console.SetCursorPosition(34, 13);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(">>>>>>>>>>>>>>> NAFTA PREMIUM <<<<<<<<<<<<<<<<<");
                                Console.SetCursorPosition(34, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("> Cantidad de litros en el tanque:  " + tanques[0] + " litros");
                                Console.SetCursorPosition(34, 17);
                                Console.WriteLine("> Cantidad de litros vendido:       " + vendido_premium + " litros");
                                Console.SetCursorPosition(34, 18);
                                Console.WriteLine("> Precio por litro:                $" + precio_premium);
                                Console.SetCursorPosition(34, 19);
                                Console.WriteLine("> Monto recaudado:                 $" + tolalPremium);
                                Console.SetCursorPosition(34, 21);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter para volver al MENÚ...");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                /********* MARCO *********/
                                Console.CursorVisible = false;
                                for (int V = 10; V <= 100; V++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(V, 4);
                                    Console.Write("#");
                                    Console.SetCursorPosition(V, 30);
                                    Console.Write("#");
                                    for (int H = 4; H < 31; H++)
                                    {
                                        Console.SetCursorPosition(10, H);
                                        Console.WriteLine("$");
                                        Console.SetCursorPosition(100, H);
                                        Console.WriteLine("$");
                                    }
                                }//fin marco
                                Console.SetCursorPosition(34, 13);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(">>>>>>>>>>>>>>> NAFTA SUPER <<<<<<<<<<<<<<<<<");
                                Console.SetCursorPosition(34, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("> Cantidad de litros en el tanque: " + tanques[1] + " litros");
                                Console.SetCursorPosition(34, 17);
                                Console.WriteLine("> Cantidad de litros vendido:      " + vendido_super + " litros");
                                Console.SetCursorPosition(34, 18);
                                Console.WriteLine("> Precio por litro:               $" + precio_super);
                                Console.SetCursorPosition(34, 19);
                                Console.WriteLine("> Monto recaudado:                $" + tolalPremium);
                                Console.SetCursorPosition(34, 21);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter para volver al MENÚ...");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                /********* MARCO *********/
                                Console.CursorVisible = false;
                                for (int V = 10; V <= 100; V++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(V, 4);
                                    Console.Write("#");
                                    Console.SetCursorPosition(V, 30);
                                    Console.Write("#");
                                    for (int H = 4; H < 31; H++)
                                    {
                                        Console.SetCursorPosition(10, H);
                                        Console.WriteLine("$");
                                        Console.SetCursorPosition(100, H);
                                        Console.WriteLine("$");
                                    }
                                }//fin marco
                                Console.SetCursorPosition(34, 13);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(">>>>>>>>>>>>>>>>>> GASOIL <<<<<<<<<<<<<<<<<<<");
                                Console.SetCursorPosition(34, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("> Cantidad de litros en el tanque: " + tanques[2] + " litros");
                                Console.SetCursorPosition(34, 17);
                                Console.WriteLine("> Cantidad de litros vendido:      " + vendido_gasoil + " litros");
                                Console.SetCursorPosition(34, 18);
                                Console.WriteLine("> Precio por litro:                $" + precio_gasoil);
                                Console.SetCursorPosition(34, 19);
                                Console.WriteLine("> Monto recaudado:                 $" + totalGasoil);
                                Console.SetCursorPosition(34, 21);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter para volver al MENÚ...");
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                /********* MARCO *********/
                                Console.CursorVisible = false;
                                for (int V = 10; V <= 100; V++)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(V, 4);
                                    Console.Write("#");
                                    Console.SetCursorPosition(V, 30);
                                    Console.Write("#");
                                    for (int H = 4; H < 31; H++)
                                    {
                                        Console.SetCursorPosition(10, H);
                                        Console.WriteLine("$");
                                        Console.SetCursorPosition(100, H);
                                        Console.WriteLine("$");
                                    }
                                }//fin marco
                                Console.SetCursorPosition(30, 13);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>> TOTAL <<<<<<<<<<<<<<<<<<<<<<<");
                                Console.SetCursorPosition(30, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("> Cantidad TOTAL de litros en los tanques: " + totalTanques + " litros");
                                Console.SetCursorPosition(30, 17);
                                Console.WriteLine("> Cantidad TOTAL de litros vendido:        " + totalLitrosV + " litros");
                                Console.SetCursorPosition(30, 18);
                                Console.WriteLine("> Monto TOTAL recaudado:                   $" + totalRecaudado);
                                Console.SetCursorPosition(30, 20);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter para volver al MENÚ...");
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();

                                return;
                            }
                        default:
                            {
                                Console.SetCursorPosition(40, 24);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Debes ingresar un numero >> 1, 2, 3, 4 o 5");
                                Console.SetCursorPosition(40, 25);
                                Console.WriteLine("Enter para vorlver a intentar....");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(40, 24);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Debes ingresar un numero >> 1, 2, 3, 4 o 5");
                    Console.SetCursorPosition(40, 25);
                    Console.WriteLine("Enter para vorlver a intentar....");

                    Console.ReadKey();
                }




            }
        }
        //fin metod ingresos

        //Método venta de combustible super
        static double VentaSuper(double[] tanques, double carga_pesos, double precio_por_litro)
        {
            double div = 0;

            div = carga_pesos / precio_por_litro;
            if (tanques[1] >= div)
            {
                tanques[1] = tanques[1] - div;
                return (tanques[1]);
            }

            return (0);


        }
        //Método Venta de combustible gasoil
        static double VentaGasoil(double[] tanques, double carga_pesos, double precioGasoil)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("           Venta de GASOIL");
            double carga_litros_gasoil;
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("La carga en PESOS es: " + carga_pesos);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("El precio del GASOIL es: " + precioGasoil);
            Console.WriteLine("----------------------------------------");
            carga_litros_gasoil = carga_pesos / precioGasoil;

            if (tanques[2] >= carga_litros_gasoil)
            {
                Console.Write("Se vendieron Litros: ");
                return (carga_litros_gasoil);
            }

            Console.Write("Hay faltante de stock");
            Console.ReadKey();
            return (0);

        }
    }
}