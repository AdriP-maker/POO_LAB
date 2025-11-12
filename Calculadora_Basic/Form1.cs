namespace Calculadora_Basic
{
    public partial class Form1 : Form
    {
        // Variables de estado para la calculadora
        private string operadorActual = "";
        private double operando1 = 0;
        private bool nuevaEntrada = true;
        private bool resultadoMostrado = false;

        // Instancias de las clases auxiliares
        private Operaciones operaciones;
        private Validaciones validaciones;
        public Form1()
        {
            InitializeComponent();
            operaciones = new Operaciones();
            validaciones = new Validaciones();
            InicializarCalculadora();
        }
        // Configuracion inicial de la calculadora
        private void InicializarCalculadora()
        {
            txtDisplay.Text = "0";
            lblEstado.Text = "";
            nuevaEntrada = true;
            resultadoMostrado = false;
        }

        // Manejo de eventos para botones numericos
        private void BtnNumero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string numero = btn.Text;

            // Si se mostro un resultado, limpiar para nueva operacion
            if (resultadoMostrado)
            {
                txtDisplay.Text = "0";
                resultadoMostrado = false;
                lblEstado.Text = "";
            }

            // Si es nueva entrada o el display muestra 0, reemplazar
            if (nuevaEntrada || txtDisplay.Text == "0")
            {
                txtDisplay.Text = numero;
                nuevaEntrada = false;
            }
            else
            {
                // Validar longitud maxima
                if (validaciones.ValidarLongitudMaxima(txtDisplay.Text))
                {
                    txtDisplay.Text += numero;
                }
                else
                {
                    lblEstado.Text = "Longitud maxima alcanzada";
                }
            }
        }

        // Manejo del punto decimal
        private void BtnPunto_Click(object sender, EventArgs e)
        {
            if (resultadoMostrado)
            {
                txtDisplay.Text = "0";
                resultadoMostrado = false;
                lblEstado.Text = "";
            }

            if (nuevaEntrada)
            {
                txtDisplay.Text = "0.";
                nuevaEntrada = false;
            }
            else if (validaciones.ValidarPuntoDecimal(txtDisplay.Text))
            {
                txtDisplay.Text += ".";
            }
            else
            {
                lblEstado.Text = "Solo un punto decimal permitido";
            }
        }

        // Manejo de operadores aritmeticos
        private void BtnOperador_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string operador = btn.Text;

            // Validar que hay un numero valido antes de aplicar operador
            if (string.IsNullOrWhiteSpace(txtDisplay.Text) || txtDisplay.Text == ".")
            {
                lblEstado.Text = "Ingrese un numero primero";
                return;
            }

            // Si hay un operador pendiente, calcular primero
            if (!string.IsNullOrEmpty(operadorActual) && !nuevaEntrada)
            {
                CalcularResultado();
            }

            // Guardar el operando y el operador
            if (double.TryParse(txtDisplay.Text, out operando1))
            {
                operadorActual = operador;
                lblEstado.Text = $"{operando1} {operador}";
                nuevaEntrada = true;
                resultadoMostrado = false;
            }
            else
            {
                lblEstado.Text = "Numero invalido";
            }
        }

        // Calcular y mostrar el resultado
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            CalcularResultado();
        }

        // Logica principal de calculo
        private void CalcularResultado()
        {
            if (string.IsNullOrEmpty(operadorActual))
            {
                return;
            }

            // Convertir el segundo operando
            if (!double.TryParse(txtDisplay.Text, out double operando2))
            {
                lblEstado.Text = "Error: numero invalido";
                return;
            }

            // Validar division por cero
            if (operadorActual == "÷" && operando2 == 0)
            {
                lblEstado.Text = "Error: No se puede dividir entre cero";
                txtDisplay.Text = "0";
                LimpiarEstado();
                return;
            }

            double resultado = 0;
            bool operacionExitosa = false;

            // Ejecutar la operacion correspondiente
            switch (operadorActual)
            {
                case "+":
                    resultado = operaciones.Sumar(operando1, operando2);
                    operacionExitosa = true;
                    break;
                case "-":
                    resultado = operaciones.Restar(operando1, operando2);
                    operacionExitosa = true;
                    break;
                case "×":
                    resultado = operaciones.Multiplicar(operando1, operando2);
                    operacionExitosa = true;
                    break;
                case "÷":
                    resultado = operaciones.Dividir(operando1, operando2);
                    operacionExitosa = true;
                    break;
            }

            if (operacionExitosa)
            {
                // Validar resultado valido
                if (validaciones.ValidarResultado(resultado))
                {
                    txtDisplay.Text = resultado.ToString();
                    lblEstado.Text = $"{operando1} {operadorActual} {operando2} = {resultado}";
                    operadorActual = "";
                    nuevaEntrada = true;
                    resultadoMostrado = true;
                }
                else
                {
                    lblEstado.Text = "Error: Resultado invalido";
                    txtDisplay.Text = "0";
                    LimpiarEstado();
                }
            }
        }

        // Limpiar todo el estado de la calculadora
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblEstado.Text = "";
            LimpiarEstado();
        }

        // Reiniciar variables de estado
        private void LimpiarEstado()
        {
            operadorActual = "";
            operando1 = 0;
            nuevaEntrada = true;
            resultadoMostrado = false;
        }

        // Borrar el ultimo caracter
        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
                nuevaEntrada = true;
            }
        }

        // Manejo de teclas del teclado
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Numeros
            if (char.IsDigit(e.KeyChar))
            {
                BtnNumero_Click(new Button { Text = e.KeyChar.ToString() }, EventArgs.Empty);
            }
            // Operadores
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                string operador = e.KeyChar == '*' ? "×" : (e.KeyChar == '/' ? "÷" : e.KeyChar.ToString());
                BtnOperador_Click(new Button { Text = operador }, EventArgs.Empty);
            }
            // Enter o igual
            else if (e.KeyChar == '=' || e.KeyChar == (char)Keys.Enter)
            {
                BtnIgual_Click(sender, EventArgs.Empty);
            }
            // Punto decimal
            else if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                BtnPunto_Click(sender, EventArgs.Empty);
            }
            // Backspace
            else if (e.KeyChar == (char)Keys.Back)
            {
                BtnBackspace_Click(sender, EventArgs.Empty);
            }
            // Escape para limpiar
            else if (e.KeyChar == (char)Keys.Escape)
            {
                BtnClear_Click(sender, EventArgs.Empty);
            }
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
