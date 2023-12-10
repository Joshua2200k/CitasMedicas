using System;
using System.Collections.Generic;

/*
Sistema gestionador de citas medicas
*/
class Program
{
    static List<CitaMedica> citasMedicas = new List<CitaMedica>();

    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de control de citas médicas");

        while (true)
        {
            MostrarMenu();
            ProcesarOpcion();
        }
        
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("***********************************************************************************************");
        Console.WriteLine("\nBienvenido al sistema de control de citas médicas");
        Console.WriteLine("\nMenú:");
        Console.WriteLine("1. Agregar cita médica");
        Console.WriteLine("2. Ver citas médicas");
        Console.WriteLine("3. Salir");
    }

    static void ProcesarOpcion()
    {
        Console.Write("Seleccione una opción: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                AgregarCitaMedica();
                break;
            case "2":
                VerCitasMedicas();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                break;
        }
    }

    static void AgregarCitaMedica()
    {
        Console.Write("Ingrese el nombre del paciente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la fecha y hora de la cita (dd/mm/yyyy hh:mm): ");
        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
        {
            CitaMedica nuevaCita = new CitaMedica(nombre, fecha);
            citasMedicas.Add(nuevaCita);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nCita médica agregada con éxito.");
            Console.ResetColor();
            Console.Write("\nprima una tecla para continuar");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Formato de fecha incorrecto.");
        }
    }

    static void VerCitasMedicas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nCitas Médicas Registradas:");
        Console.ResetColor();

        foreach (var cita in citasMedicas)
        {
            Console.WriteLine($"Paciente: {cita.Nombre}, Fecha: {cita.Fecha.ToString("dd/MM/yyyy HH:mm")}");
        }
        Console.Write("");
        Console.ReadKey();
    }
}

class CitaMedica
{
    public string Nombre { get; set; }
    public DateTime Fecha { get; set; }

    public CitaMedica(string nombre, DateTime fecha)
    {
        Nombre = nombre;
        Fecha = fecha;
    }
}
