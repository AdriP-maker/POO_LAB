// Estudiante.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Estudiante : IMostrable
{
    // Atributos privados
    private string nombre;
    private string id;
    private string carrera;
    private List<Calificacion> calificaciones;

    // Propiedades
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Carrera
    {
        get { return carrera; }
        set { carrera = value; }
    }

    public List<Calificacion> Calificaciones
    {
        get { return calificaciones; }
    }

    // Constructores
    public Estudiante(string nombre, string id, string carrera)
    {
        this.nombre = nombre;
        this.id = id;
        this.carrera = carrera;
        this.calificaciones = new List<Calificacion>();
    }

    public Estudiante()
    {
        nombre = "";
        id = "";
        carrera = "";
        calificaciones = new List<Calificacion>();
    }

    // Método aritmético - retorna double
    public double CalcularPromedio()
    {
        if (calificaciones == null || calificaciones.Count == 0)
            return 0.0;

        double sumaNotasPonderadas = 0.0;
        int sumaCreditos = 0;

        foreach (Calificacion c in calificaciones)
        {
            sumaNotasPonderadas += c.Nota * c.Materia.Creditos;
            sumaCreditos += c.Materia.Creditos;
        }

        if (sumaCreditos == 0)
            return 0.0;

        return sumaNotasPonderadas / sumaCreditos;
    }

    // Método de salida - retorna void
    public virtual void MostrarDatos()
    {
        Console.WriteLine($"--- ESTUDIANTE ---");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Carrera: {Carrera}");
        Console.WriteLine($"Promedio: {CalcularPromedio():F2}");
        Console.WriteLine();
    }
}