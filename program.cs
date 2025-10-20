using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SISTEMA DE GESTIÓN ACADÉMICA ===\n");

        // ========== 1. CREACIÓN DE MATERIAS (3) ==========
        Materia matematicas = new Materia("Matemáticas", "MAT101", 4, 30, 25);
        Materia programacion = new Materia("Programación", "PRG201", 3, 25, 20);
        Materia fisica = new Materia("Física", "FIS102", 5, 35, 30);

        // ========== 2. CREACIÓN DE ESTUDIANTES (2 normales + 1 becado) ==========
        Estudiante estudiante1 = new Estudiante("Ana García", "E001", "Ingeniería");
        Estudiante estudiante2 = new Estudiante("Carlos Pérez", "E002", "Sistemas");
        EstudianteBecado estudianteBecado = new EstudianteBecado("María López", "E003", "Ingeniería", 75.0);

        // ========== 3. CREACIÓN DE CALIFICACIONES (3) ==========
        Calificacion calif1 = new Calificacion(estudiante1, matematicas, 85.5);
        Calificacion calif2 = new Calificacion(estudiante1, programacion, 92.0);
        Calificacion calif3 = new Calificacion(estudianteBecado, fisica, 88.0);

        // ========== 4. VINCULAR CALIFICACIONES A ESTUDIANTES ==========
        estudiante1.Calificaciones.Add(calif1);
        estudiante1.Calificaciones.Add(calif2);
        estudianteBecado.Calificaciones.Add(calif3);

        // ========== 5. DEMOSTRACIÓN DE OPERACIONES ARITMÉTICAS ==========
        Console.WriteLine("========== OPERACIONES ARITMÉTICAS ==========\n");

        // a) Estudiante.CalcularPromedio() -> double
        double promedio1 = estudiante1.CalcularPromedio();
        Console.WriteLine($"Promedio de {estudiante1.Nombre}: {promedio1:F2} ");

        // b) Materia.CalcularCargaSemanal(int) -> int
        int cargaMatematicas = matematicas.CalcularCargaSemanal(3);
        Console.WriteLine($"Carga semanal de {matematicas.Nombre}: {cargaMatematicas} horas ");

        // c) Calificacion.CalcularPuntos() -> double
        double puntosCalif1 = calif1.CalcularPuntos();
        Console.WriteLine($"Puntos de calificación en {calif1.Materia.Nombre}: {puntosCalif1:F2} ");

        // d) EstudianteBecado.CalcularMatriculaConDescuento(double) -> double
        double matriculaBase = 5000.0;
        double matriculaConDescuento = estudianteBecado.CalcularMatriculaConDescuento(matriculaBase);
        Console.WriteLine($"Matrícula de {estudianteBecado.Nombre}: ${matriculaConDescuento:F2} ");
        Console.WriteLine($"  (Base: ${matriculaBase}, Descuento: {estudianteBecado.PorcentajeBeca}%)\n");

        // ========== 6. POLIMORFISMO CON List<IMostrable> ==========
        Console.WriteLine("========== POLIMORFISMO - List<IMostrable> ==========\n");

        List<IMostrable> items = new List<IMostrable>();
        
        // Agregar 2 Estudiante
        items.Add(estudiante1);
        items.Add(estudiante2);
        
        // Agregar 1 EstudianteBecado
        items.Add(estudianteBecado);
        
        // Agregar 3 Materia
        items.Add(matematicas);
        items.Add(programacion);
        items.Add(fisica);
        
        // Agregar 3 Calificacion
        items.Add(calif1);
        items.Add(calif2);
        items.Add(calif3);

        // Recorrer y mostrar todos los datos polimórficamente
        foreach (IMostrable item in items)
        {
            item.MostrarDatos();
        }

        // ========== 7. DEMOSTRACIÓN DE VALIDACIONES ==========
        Console.WriteLine("========== DEMOSTRACIÓN DE VALIDACIONES ==========\n");

        // Validación 1: Nota fuera de rango
        try
        {
            Console.WriteLine("1. Intentando crear calificación con nota = 105 (debe estar entre 0-100)");
            Calificacion califInvalida = new Calificacion(estudiante1, matematicas, 105);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Nota invalida: {ex.Message}\n");
        }

        // Validación 2: Créditos negativos
        try
        {
            Console.WriteLine("2. Intentando crear materia con créditos = -3 (debe ser > 0)");
            Materia materiaInvalida = new Materia("Test", "TST001", -3);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Creditos invalidos menores o iguales a 0: {ex.Message}\n");
        }

        // Validación 3: Inscritos mayor que cupos
        try
        {
            Console.WriteLine("3. Intentando asignar 25 inscritos cuando solo hay 20 cupos");
            Materia materiaConCupos = new Materia("Test", "TST002", 3, 20);
            materiaConCupos.Inscritos = 25;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Cupos superados ya no se pueden ingresar mas estudiantes: {ex.Message}\n");
        }

        // Validación 4: Porcentaje de beca inválido
        try
        {
            Console.WriteLine("4. Intentando crear estudiante con beca del 150% (debe estar entre 0-100)");
            EstudianteBecado becadoInvalido = new EstudianteBecado("Test", "E999", "Test", 150);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Limite de porcentaje de beca excedido: {ex.Message}\n");
        }

        Console.WriteLine("Todas las validaciones funcionaron correctamente.");
        Console.WriteLine("\n=== FIN DEL PROGRAMA ===");
    }
}