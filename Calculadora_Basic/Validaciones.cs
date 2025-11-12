using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Basic
{
    public class Validaciones
    {
        // Longitud maxima permitida para la entrada de numeros
        private const int LONGITUD_MAXIMA = 12;

        // Valida que el texto no exceda la longitud maxima permitida
        // Parametro: texto es la cadena a validar
        // Retorna: true si el texto no excede el limite, false en caso contrario
        public bool ValidarLongitudMaxima(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return true;
            }

            // Remover el punto decimal para contar solo digitos
            string textoSinPunto = texto.Replace(".", "").Replace(",", "");
            return textoSinPunto.Length < LONGITUD_MAXIMA;
        }

        // Valida que el texto no contenga mas de un punto decimal
        // Parametro: texto es la cadena a validar
        // Retorna: true si no hay punto o hay solo uno, false si ya existe un punto
        public bool ValidarPuntoDecimal(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return true;
            }

            // Verificar que no exista ya un punto decimal en el texto
            return !texto.Contains(".") && !texto.Contains(",");
        }

        // Valida que el resultado de una operacion sea un numero valido
        // Parametro: resultado es el valor a validar
        // Retorna: true si el resultado es un numero valido, false si es infinito o indefinido
        public bool ValidarResultado(double resultado)
        {
            // Verificar que el resultado no sea infinito ni NaN (Not a Number)
            return !double.IsInfinity(resultado) && !double.IsNaN(resultado);
        }

        // Valida que una cadena de texto represente un numero valido
        // Parametro: texto es la cadena a validar
        // Retorna: true si el texto puede convertirse a numero, false en caso contrario
        public bool ValidarNumeroValido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            // Intentar convertir el texto a double
            return double.TryParse(texto, out _);
        }

        // Valida que un caracter sea un digito numerico
        // Parametro: c es el caracter a validar
        // Retorna: true si es un digito del 0 al 9, false en caso contrario
        public bool ValidarCaracterNumerico(char c)
        {
            return char.IsDigit(c);
        }

        // Valida que un caracter sea un operador aritmetico valido
        // Parametro: c es el caracter a validar
        // Retorna: true si es un operador valido, false en caso contrario
        public bool ValidarOperador(char c)
        {
            return c == '+' || c == '-' || c == '×' || c == '÷' || c == '*' || c == '/';
        }

        // Valida division por cero
        // Parametros: operador es el operador actual, divisor es el segundo operando
        // Retorna: true si la operacion es segura, false si intenta dividir por cero
        public bool ValidarDivisionPorCero(string operador, double divisor)
        {
            if (operador == "÷" || operador == "/")
            {
                return divisor != 0;
            }
            return true;
        }
    
}
}
