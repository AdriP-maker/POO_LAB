// Materia.cs
using System;

public class Materia : IMostrable
{
    // Atributos privados
    private string nombre;
    private string codigo;
    private int creditos;
    private int cupos;
    private int inscritos;

    // Propiedades con validación
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Codigo
    {
        get { return codigo; }
        set { codigo = value; }
    }

    public int Creditos
    {
        get { return creditos; }
        set
        {
            if (value > 0)
                creditos = value;
            else
                throw new ArgumentException("Los créditos deben ser mayores a 0");
        }
    }

    public int Cupos
    {
        get { return cupos; }
        set
        {
            if (value >= 0)
                cupos = value;
            else
                throw new ArgumentException("Los cupos deben ser mayores o iguales a 0");
        }
    }

    public int Inscritos
    {
        get { return inscritos; }
        set
        {
            if (value >= 0 && value <= cupos)
                inscritos = value;
            else
                throw new ArgumentException($"Los inscritos deben estar entre 0 y {cupos}");
        }
    }

    // Constructores
    public Materia(string nombre, string codigo, int creditos, int cupos = 0, int inscritos = 0)
    {
        this.nombre = nombre;
        this.codigo = codigo;
        this.Creditos = creditos; // Usa la propiedad para validar
        this.Cupos = cupos;
        this.Inscritos = inscritos;
    }

    public Materia()
    {
        nombre = "";
        codigo = "";
        creditos = 1;
        cupos = 0;
        inscritos = 0;
    }

    // Método aritmético - retorna int
    public int CalcularCargaSemanal(int horasPorCredito)
    {
        return Creditos * horasPorCredito;
    }

    // Método de salida - retorna void
    public void MostrarDatos()
    {
        Console.WriteLine($"--- MATERIA ---");
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Créditos: {Creditos}");
        Console.WriteLine($"Cupos: {Inscritos}/{Cupos}");
        Console.WriteLine();
    }
}