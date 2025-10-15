using System;

public class EstudianteBecado : Estudiante
{
    // Atributo privado adicional
    private double porcentajeBeca;

    // Propiedad con validación
    public double PorcentajeBeca
    {
        get { return porcentajeBeca; }
        set
        {
            if (value >= 0 && value <= 100)
                porcentajeBeca = value;
            else
                throw new ArgumentException("El porcentaje de beca debe estar entre 0 y 100");
        }
    }

    // Constructor
    public EstudianteBecado(string nombre, string id, string carrera, double porcentajeBeca)
        : base(nombre, id, carrera)
    {
        this.PorcentajeBeca = porcentajeBeca; // Usa la propiedad para validar
    }

    // Método aritmético - retorna double
    public double CalcularMatriculaConDescuento(double matriculaBase)
    {
        return matriculaBase * (1 - (PorcentajeBeca / 100.0));
    }

    // Override del método de salida - retorna void
    public override void MostrarDatos()
    {
        Console.WriteLine($"--- ESTUDIANTE BECADO ---");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Carrera: {Carrera}");
        Console.WriteLine($"Promedio: {CalcularPromedio():F2}");
        Console.WriteLine($"Beca: {PorcentajeBeca}%");
        Console.WriteLine();
    }
}