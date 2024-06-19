using System;
using System.Collections.Generic;

namespace RegistroEmpleados
{
    class Empleado
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Profesion { get; set; }
        public string Departamento { get; set; }
        public string Puesto { get; set; }
        public double Salario { get; set; }
        public double HorasExtra { get; set; }
        public double AFP { get; set; }
        public double SeguroMedico { get; set; }
        public double ISR { get; set; }
        public double Prestamo { get; set; }

        public Empleado(string nombre, string apellidos, string cedula, string direccion, string telefono, string profesion, string departamento, string puesto)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Cedula = cedula;
            Direccion = direccion;
            Telefono = telefono;
            Profesion = profesion;
            Departamento = departamento;
            Puesto = puesto;
            Salario = 0;
            HorasExtra = 0;
            AFP = 0;
            SeguroMedico = 0;
            ISR = 0;
            Prestamo = 0;
        }
    }

    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();
        static void MostrarBarraDeCarga()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\t╔════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║     Bienvenido al Sistema      ║");
            Console.WriteLine("\t\t\t\t\t╚════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.WriteLine("\n\t\t\t\t\t Cargando, por favor espere...\n\n");
           
           
            int centrar = (Console.WindowWidth - 54) / 2; // Calcula la posición para centrar la barra de carga

            for (int i = 0; i <= 100; i += 2)
            {
                Console.Write("\r".PadRight(centrar) + "[" + new string('█', i / 2) + new string(' ', 50 - i / 2) + $"] {i}%");
                Thread.Sleep(100);
            }

            Console.WriteLine();
           
            Console.WriteLine("\r\n\n\t".PadRight(centrar) + "Carga completada. Presione Enter para continuar...");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            MostrarBarraDeCarga(); // Llama a la barra de carga aquí
            bool salir = false;

            while (!salir)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; // Fondo gris oscuro
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed; // Texto en rojo

                Console.WriteLine("\t\t\t\t\t╔══════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t║    AGENDA DE EMPLEADOS   ║");
                Console.WriteLine("\t\t\t\t\t╠══════════════════════════╣");
                Console.WriteLine("\t\t\t\t\t║ 1. Registrar empleado    ║");
                Console.WriteLine("\t\t\t\t\t║ 2. Buscar empleado       ║");
                Console.WriteLine("\t\t\t\t\t║ 3. Borrar empleado       ║");
                Console.WriteLine("\t\t\t\t\t║ 4. Actualizar empleado   ║");
                Console.WriteLine("\t\t\t\t\t║ 5. Calcular nomina       ║");
                Console.WriteLine("\t\t\t\t\t║ 6. Salir                 ║");
                Console.WriteLine("\t\t\t\t\t╚══════════════════════════╝");
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tIngrese la opcion deseada: ");
                string opcion = Console.ReadLine();
               

                switch (opcion)
                {
                    case "1":
                        RegistrarEmpleado();
                        break;
                    case "2":
                        BuscarEmpleado();
                        break;
                    case "3":
                        BorrarEmpleado();
                        break;
                    case "4":
                        ActualizarEmpleado();
                        break;
                    case "5":
                        CalcularNomina();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("\t\t\t ================================================================================");
                        Console.WriteLine("\t\t\t\t\tOpcion invalida. Intente nuevamente.");
                        Console.WriteLine("\t\t\t ================================================================================");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tPresione Enter para continuar...");
                Console.WriteLine("\t\t\t ================================================================================");
                Console.ReadLine();
            }
        }

        static void RegistrarEmpleado()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
           
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║        Registrar Empleado       ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════╝");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese el nombre del empleado: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese los apellidos del empleado: ");
            string apellidos = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la cedula del empleado: ");
            string cedula = Console.ReadLine();

            // Validar si el empleado ya existe por su cédula
            if (empleados.Exists(e => e.Cedula == cedula))
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tYa existe un empleado con la misma cedula.");
                Console.WriteLine("\t\t\t ================================================================================");
                return;
            }

            // Resto del código para ingresar los demás detalles del empleado y agregarlo a la lista
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la direccion del empleado: ");
            string direccion = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese el telefono del empleado: ");
            string telefono = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la profesion del empleado: ");
            string profesion = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese el departamento del empleado: ");
            string departamento = Console.ReadLine();
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese el puesto del empleado: ");
            string puesto = Console.ReadLine();

            Empleado empleado = new Empleado(nombre, apellidos, cedula, direccion, telefono, profesion, departamento, puesto);
            empleados.Add(empleado);
            Console.WriteLine("\t\t\t ================================================================================");
            Console.WriteLine("\t\t\t\t\tEmpleado registrado exitosamente.");
            
        }

        static void BuscarEmpleado()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║        Buscar Empleado          ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════╝");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la cedula del empleado: ");
            string cedula = Console.ReadLine();

            Empleado empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tNombre: " + empleado.Nombre);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tApellidos: " + empleado.Apellidos);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tDireccion: " + empleado.Direccion);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tTeléfono: " + empleado.Telefono);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tProfesión: " + empleado.Profesion);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tDepartamento: " + empleado.Departamento);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tPuesto: " + empleado.Puesto);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tSalario: " + empleado.Salario);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tHoras Extras: " + empleado.HorasExtra);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tAFP: " + empleado.AFP);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tSeguro Médico: " + empleado.SeguroMedico);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tISR: " + empleado.ISR);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tPrestamo: " + empleado.Prestamo);
                Console.WriteLine("\t\t\t ================================================================================");
            }
            else
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado no encontrado.");
            }
        }

        static void BorrarEmpleado()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║        Borrar Empleado          ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════╝");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la cedula del empleado a borrar: ");
            string cedula = Console.ReadLine();

            Empleado empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado borrado exitosamente.");
            }
            else
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado no encontrado.");
            }
        }

        static void ActualizarEmpleado()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║       Actualizar Empleado       ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════╝");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la cedula del empleado a actualizar: ");
            string cedula = Console.ReadLine();

            Empleado empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tNombre: " + empleado.Nombre);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tApellidos: " + empleado.Apellidos);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tDireccion: " + empleado.Direccion);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tTelefono: " + empleado.Telefono);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tProfesion: " + empleado.Profesion);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tDepartamento: " + empleado.Departamento);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tPuesto: " + empleado.Puesto);

                Console.WriteLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tIngrese los nuevos datos:");
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tNombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tApellidos: ");
                empleado.Apellidos = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tDireccion: ");
                empleado.Direccion = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tTelefono: ");
                empleado.Telefono = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tProfesion: ");
                empleado.Profesion = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tDepartamento: ");
                empleado.Departamento = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tPuesto: ");
                empleado.Puesto = Console.ReadLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado no encontrado.");
            }
        }

        static void CalcularNomina()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();  // Limpia la consola con el nuevo color de fondo
            Console.ForegroundColor = ConsoleColor.DarkBlue;  // Establece el color de texto en amarillo


            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║        Calcular Nomina          ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════╝");
            Console.WriteLine("\t\t\t ================================================================================");
            Console.Write("\t\t\t\t\tIngrese la cedula del empleado: ");
            string cedula = Console.ReadLine();

            Empleado empleado = empleados.Find(e => e.Cedula == cedula);

            if (empleado != null)
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tNombre: " + empleado.Nombre);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tApellidos: " + empleado.Apellidos);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tDepartamento: " + empleado.Departamento);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tPuesto: " + empleado.Puesto);

                Console.WriteLine();
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tIngrese el salario base del empleado: ");
                double salarioBase = Convert.ToDouble(Console.ReadLine());

                empleado.Salario = salarioBase;
                Console.WriteLine("\t\t\t ================================================================================");
                Console.Write("\t\t\t\t\tIngrese las horas extras trabajadas: ");
                double horasExtra = Convert.ToDouble(Console.ReadLine());

                empleado.HorasExtra = horasExtra;

                // Calcular los descuentos
                double afp = salarioBase * 0.0287;  // Porcentaje de AFP en República Dominicana
                empleado.AFP = afp;

                double seguroMedico = salarioBase * 0.0304;  // Porcentaje de Seguro Médico en República Dominicana
                empleado.SeguroMedico = seguroMedico;

                // Calcular el ISR (Impuesto sobre la Renta) según las tablas y rangos establecidos
                double isr = CalcularISR(empleado.Salario, empleado.HorasExtra);
                empleado.ISR = isr;

                // Aquí podrías incluir el cálculo de otros descuentos, como préstamos a los empleados

                // Calcular el salario neto
                double salarioNeto = salarioBase + horasExtra - afp - seguroMedico - isr;
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tSalario Neto: " + salarioNeto);
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tNomina calculada exitosamente.");
            }
            else
            {
                Console.WriteLine("\t\t\t ================================================================================");
                Console.WriteLine("\t\t\t\t\tEmpleado no encontrado.");
            }
        }

        static double CalcularISR(double salarioBase, double horasExtra)
        {

            // Aquí hay un ejemplo básico para calcular el ISR utilizando una tasa fija del 10%:
            double tasaISR = 0.10;  // Tasa fija del 10%
            double salarioTotal = salarioBase + horasExtra;
            double isr = salarioTotal * tasaISR;

            return isr;
        }
    }
}