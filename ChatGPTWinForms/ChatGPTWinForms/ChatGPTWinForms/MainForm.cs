using OpenAI;
using OpenAI.Chat;
using System.ClientModel;
using System.Net;

namespace ChatGPTWinForms
{
    public partial class MainForm : Form
    {
        private ChatClient chatClient;
        private List<ChatMessage> history = new List<ChatMessage>();
        private string apiKey;
        private string ultimoMensajeAsistente = string.Empty;
        private bool enviandoMensaje = false;

        public MainForm()
        {
            InitializeComponent();

            // Leer API key desde variable de entorno
            apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                // Si no hay variable de entorno, solicitar al usuario
                using (var keyForm = new ApiKeyForm())
                {
                    if (keyForm.ShowDialog() == DialogResult.OK)
                    {
                        apiKey = keyForm.ApiKey;
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar una API Key para continuar.\n\nAlternativamente, configure la variable de entorno OPENAI_API_KEY.",
                            "API Key Requerida",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                }
            }

            // Crear ChatClient con el modelo gpt-4o-mini
            chatClient = new ChatClient("gpt-4o-mini", apiKey);

            // Configurar eventos
            txtPrompt.KeyDown += txtPrompt_KeyDown;
            btnEnviar.Click += btnEnviar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnCopiar.Click += btnCopiar_Click;

            // Mensaje de bienvenida
            txtChat.Text = "=== ChatGPT Cliente WinForms ===" + Environment.NewLine +
                          "Escribe tu mensaje y presiona Enviar o Enter." + Environment.NewLine +
                          Environment.NewLine;

            // Establecer foco en el campo de entrada
            txtPrompt.Focus();
        }

        private async void txtPrompt_KeyDown(object sender, KeyEventArgs e)
        {
            // Permitir Shift+Enter para nueva línea, solo Enter envía
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                await EnviarMensajeAsync();
            }
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            await EnviarMensajeAsync();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            history.Clear();
            txtPrompt.Clear();
            ultimoMensajeAsistente = string.Empty;

            txtChat.Text = "=== Historial limpiado ===" + Environment.NewLine + Environment.NewLine;
            ActualizarEstado("Listo", Color.Green);
            txtPrompt.Focus();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ultimoMensajeAsistente))
            {
                try
                {
                    Clipboard.SetText(ultimoMensajeAsistente);
                    ActualizarEstado("Copiado al portapapeles", Color.Blue);

                    // Restaurar estado después de 2 segundos
                    Task.Delay(2000).ContinueWith(_ =>
                    {
                        if (InvokeRequired)
                            Invoke(() => ActualizarEstado("Listo", Color.Green));
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al copiar: {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay ningún mensaje del asistente para copiar.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private async Task EnviarMensajeAsync()
        {
            // Evitar envíos duplicados
            if (enviandoMensaje)
            {
                return;
            }

            string prompt = txtPrompt.Text.Trim();

            // Validación: entrada vacía
            if (string.IsNullOrWhiteSpace(prompt))
            {
                MessageBox.Show("El mensaje no puede estar vacío o contener solo espacios.",
                    "Entrada Inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPrompt.Focus();
                return;
            }

            // Validación: longitud máxima
            if (prompt.Length > 1000)
            {
                MessageBox.Show("El mensaje es demasiado largo (máximo 1000 caracteres).\n" +
                               $"Longitud actual: {prompt.Length} caracteres.",
                    "Mensaje Muy Largo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Normalizar saltos de línea para envío
            prompt = prompt.Replace("\r\n", "\n").Replace("\r", "\n");

            // Deshabilitar controles y actualizar estado
            enviandoMensaje = true;
            btnEnviar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnCopiar.Enabled = false;
            ActualizarEstado("Enviando…", Color.Orange);

            // Agregar mensaje del usuario al historial visual
            txtChat.AppendText($"Tú: {prompt}{Environment.NewLine}");
            txtChat.ScrollToCaret();

            // Agregar a la historia de conversación
            history.Add(ChatMessage.CreateUserMessage(prompt));

            try
            {
                // Llamar a la API de OpenAI
                ChatCompletion completion = await chatClient.CompleteChatAsync(history);

                // Obtener respuesta
                string reply = completion.Content[0].Text;
                ultimoMensajeAsistente = reply;

                // Mostrar respuesta del asistente
                txtChat.AppendText($"Asistente: {reply}{Environment.NewLine}{Environment.NewLine}");
                txtChat.ScrollToCaret();

                // Agregar respuesta a la historia
                history.Add(ChatMessage.CreateAssistantMessage(reply));

                // Mantener solo los últimos 10 mensajes (5 pares de usuario-asistente)
                while (history.Count > 10)
                {
                    history.RemoveAt(0);
                }

                ActualizarEstado("Listo", Color.Green);
            }
            catch (ClientResultException ex) when (ex.Status == (int)HttpStatusCode.Unauthorized)
            {
                // 401: Credenciales inválidas
                MessageBox.Show("API key inválida o ausente.\n\n" +
                               "Verifique que su API key sea correcta y esté activa en su cuenta de OpenAI.",
                    "Error de Autenticación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ActualizarEstado("Error: API key inválida", Color.Red);
            }
            catch (ClientResultException ex) when (ex.Status == 429)
            {
                // 429: Rate limit
                MessageBox.Show("Límite de solicitudes alcanzado.\n\n" +
                               "Por favor, espera unos segundos antes de intentar nuevamente.",
                    "Límite Alcanzado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                ActualizarEstado("Error: Límite alcanzado", Color.Orange);
            }
            catch (ClientResultException ex) when (ex.Status >= 500 && ex.Status < 600)
            {
                // 5xx: Error del servidor
                MessageBox.Show("El servicio de OpenAI está temporalmente ocupado o no disponible.\n\n" +
                               "Por favor, reintenta en unos momentos.",
                    "Servicio No Disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                ActualizarEstado("Error: Servicio ocupado", Color.Orange);
            }
            catch (HttpRequestException ex)
            {
                // Error de red/timeout
                MessageBox.Show("No se pudo conectar al servidor.\n\n" +
                               "Verifica tu conexión a internet e intenta de nuevo.\n\n" +
                               $"Detalle: {ex.Message}",
                    "Error de Conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ActualizarEstado("Error: Sin conexión", Color.Red);
            }
            catch (TaskCanceledException)
            {
                // Timeout
                MessageBox.Show("La solicitud tardó demasiado tiempo.\n\n" +
                               "Por favor, intenta de nuevo.",
                    "Tiempo Agotado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                ActualizarEstado("Error: Timeout", Color.Orange);
            }
            catch (Exception ex)
            {
                // Error genérico
                MessageBox.Show($"Ocurrió un error inesperado:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                ActualizarEstado("Error inesperado", Color.Red);
            }
            finally
            {
                // Rehabilitar controles
                btnEnviar.Enabled = true;
                btnLimpiar.Enabled = true;
                btnCopiar.Enabled = true;
                enviandoMensaje = false;
                txtPrompt.Clear();
                txtPrompt.Focus();
            }
        }

        private void ActualizarEstado(string mensaje, Color color)
        {
            lblEstado.Text = mensaje;
            lblEstado.ForeColor = color;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}