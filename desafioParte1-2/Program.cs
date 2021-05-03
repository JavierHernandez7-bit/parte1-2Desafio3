using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3erDesafioPractico
{
    class Program
    {
        string contraseña;
        string usuarioN;
        int estadoA = 0;
        int estadoB = 1, f;

        public void login()//FALTA CONECTAR ESTA PARTE PARA QUE SE EJECUTE 
        {
            Console.WriteLine("Este sistema está en modo administrador, por favor: introduzca sus credenciales a continuación... "); //POSIBLE SUSTITUCION 
            Console.WriteLine("Usuario (administrador): ");
            usuarioN = Console.ReadLine();
            Console.WriteLine("Contraseña (administrador): ");
            contraseña = Console.ReadLine();
            TextWriter credencial;
            credencial = new StreamWriter("acceso.txt");
            usuarioN = Console.ReadLine();
            contraseña = Console.ReadLine();

            TextWriter archivoCred; //REVISAR ARCHIVO GENERADO
            archivoCred = new StreamWriter("credencial.txt");
            archivoCred.WriteLine(usuarioN);
            archivoCred.WriteLine(contraseña);
            archivoCred.Close();
            Console.Clear();
        }
        public void proceso_login()
        {
            for (f = 1; f >= 3;)//REVISAR EL CONTADOR (FALTANTE)   
            {
                do
                {
                    if (usuarioN == "admin" && contraseña == "admin")
                    {
                        Console.WriteLine("Acceso Aprobado");
                    }
                    else
                    {
                        Console.WriteLine("Acceso Denegado");
                    }
                } while (f >= 1);
            }

            //Console.ReadKey();
        }
            
        struct CargarEmpleado
        {
            public string nombres, apellidos, cargo;
            public double horastrabajo, bono;
        }

        struct CalcularDeducciones
        {
            static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();

                string ganamas = "ganamas", ganamenos = "ganamenos";
                double excepcion = 0, sueldobase, isss = 0.0525, afp = 0.0688, renta = 0.1, mas300 = 0, sueldoliquido, mayorsalario = 0, menorsalario = 0;

                for (int cont = 0; cont < 3; cont++)
                {
                    CargarEmpleado obj = new CargarEmpleado();
                    Console.WriteLine("Escriba sus nombres:");
                    obj.nombres = Console.ReadLine();

                    Console.WriteLine("Escriba sus apellidos:");
                    obj.apellidos = Console.ReadLine();

                    Console.WriteLine("Escriba su cargo:");
                    obj.cargo = Console.ReadLine();

                    Console.WriteLine("Escribas sus horas trabajadas durante el mes:");
                    obj.horastrabajo = Double.Parse(Console.ReadLine());



                    if (obj.horastrabajo <= 0)
                    {
                        continue;
                    }

                    if (obj.cargo == "Gerente")
                    {
                        obj.bono = 0.10;
                        if (cont == 0)
                        {
                            excepcion++;
                        }
                    }
                    else
                    {
                        if (obj.cargo == "Asistente")
                        {
                            obj.bono = 0.05;
                            if (cont == 1)
                            {
                                excepcion++;
                            }
                        }
                        else
                        {
                            if (obj.cargo == "Secretaria")
                            {
                                obj.bono = 0.03;
                                if (cont == 2)
                                {
                                    excepcion++;
                                }
                            }
                            else
                            {
                                obj.bono = 0.02;
                            }
                        }
                    }

                    if (obj.horastrabajo <= 160)
                    {
                        sueldobase = obj.horastrabajo * 9.75;
                    }
                    else
                    {
                        sueldobase = (160 * 9.75) + ((obj.horastrabajo - 160) * 11.50);
                    }

                    sueldoliquido = sueldobase - ((sueldobase * isss) + (sueldobase * afp) + (sueldobase * renta));

                    if (sueldoliquido > 300)
                    {
                        mas300++;
                    }

                    if ((sueldoliquido + (sueldoliquido * obj.bono)) > mayorsalario)
                    {
                        mayorsalario = (sueldoliquido + (sueldoliquido * obj.bono));
                        ganamas = obj.nombres + " " + obj.apellidos;
                    }

                    if (menorsalario == 0)
                    {
                        menorsalario = (sueldoliquido + (sueldoliquido * obj.bono));
                        ganamenos = obj.nombres + " " + obj.apellidos;
                    }
                    else
                    {
                        if ((sueldoliquido + (sueldoliquido * obj.bono)) < menorsalario)
                        {
                            menorsalario = (sueldoliquido + (sueldoliquido * obj.bono));
                            ganamenos = obj.nombres + " " + obj.apellidos;
                        }
                    }


                    Console.WriteLine();
                    Console.WriteLine("Empleado: " + obj.nombres + " " + obj.apellidos);
                    Console.WriteLine("Descuentos:");
                    Console.WriteLine("ISSS: " + (isss * 100) + "%");
                    Console.WriteLine("AFP: " + (afp * 100) + "%");
                    Console.WriteLine("RENTA: " + (renta * 100) + "%");
                    Console.WriteLine("Sueldo líquido a pagar: $" + sueldoliquido);
                    Console.WriteLine("Si es apto para bonos: $" + (sueldoliquido + (sueldoliquido * obj.bono)));
                    Console.WriteLine();
                }


                if (excepcion == 3)
                {
                    Console.WriteLine("NO HAY BONO");
                }


                Console.WriteLine("Empleado con mayor salario: " + ganamas);
                Console.WriteLine("Empleado con menor salario: " + ganamenos);
                Console.WriteLine("Numero de personas que ganan más de $300 = " + mas300);


                Console.WriteLine();
                Console.WriteLine("Presione tecla enter para guardar en el archivo.txt");



                TextWriter archivo;
                archivo = new StreamWriter("archivo.txt");
                string mensaje;
                mensaje = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("¡El archivo .txt se ha guardado!");

                archivo.WriteLine("Empleado con mayor salario: " + ganamas);
                archivo.WriteLine("Empleado con menor salario: " + ganamenos);
                archivo.WriteLine("Numero de personas que ganan más de $300 = " + mas300);

                archivo.WriteLine();
                archivo.Close();


                Console.ReadKey();
            }

        }
    }
}    