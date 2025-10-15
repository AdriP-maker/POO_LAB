using System;

public class Calificacion : IMostrable
{
    // Atributos privados
    private Estudiante estudiante;
    private Materia materia;
    private double nota;

    // Propiedades con validación
    public Estudiante Estudiante
    {
        get { return estudiante; }
        set { estudiante = value; }
    }

    public Materia Materia
    {
        get { return materia; }
        set { materia = value; }
    }

    public double Nota
    {
        get { return nota; }
        set
        {
            if (value >= 0 && value <= 100)
                nota = value;
            else
                throw new ArgumentException("La nota debe estar entre 0 y 100");
        }
    }

    // Constructor
    public Calificacion(Estudiante estudiante, Materia materia, double nota)
    {
        this.estudiante = estudiante;
        this.materia = materia;
        this.Nota = nota; // Usa la propiedad para validar
    }

    // Método aritmético - retorna double
    public double CalcularPuntos()
    {
        return Nota * Materia.Creditos;
    }

    // Método de salida - retorna void
    public void MostrarDatos()
    {
        Console.WriteLine($"--- CALIFICACIÓN ---");
        Console.WriteLine($"Estudiante: {Estudiante.Nombre}");
        Console.WriteLine($"Materia: {Materia.Nombre}");
        Console.WriteLine($"Nota: {Nota:F2}");
        Console.WriteLine();
    }
}