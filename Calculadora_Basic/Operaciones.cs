using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Basic
{
    public class Operaciones
    {
        // Metodo para sumar dos numeros
        // Parametros: a y b son los numeros a sumar
        // Retorna: la suma de a y b
        public double Sumar(double a, double b)
        {
            return a + b;
        }

        // Metodo para restar dos numeros
        // Parametros: a es el minuendo, b es el sustraendo
        // Retorna: la diferencia entre a y b
        public double Restar(double a, double b)
        {
            return a - b;
        }

        // Metodo para multiplicar dos numeros
        // Parametros: a y b son los factores a multiplicar
        // Retorna: el producto de a y b
        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        // Metodo para dividir dos numeros
        // Parametros: a es el dividendo, b es el divisor
        // Retorna: el cociente de a entre b
        // Nota: La validacion de division por cero se maneja en la clase Validaciones
        public double Dividir(double a, double b)
        {
            return a / b;
        }
    }
}

