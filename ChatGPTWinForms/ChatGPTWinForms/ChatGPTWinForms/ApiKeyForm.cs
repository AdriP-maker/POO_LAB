using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatGPTWinForms
{
    public partial class ApiKeyForm : Form
    {
        public string ApiKey { get; private set; }

        public ApiKeyForm()
        {
            InitializeComponent();

            // Configurar eventos
            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
            txtKey.KeyDown += txtKey_KeyDown;

            // Configurar para que la API key se muestre como contraseña (opcional)
            txtKey.UseSystemPasswordChar = true;

            // Establecer foco
            txtKey.Focus();
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnOk_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ApiKey = txtKey.Text.Trim();

            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                MessageBox.Show("Por favor, introduce una API Key válida.\n\n" +
                               "La API Key no puede estar vacía.",
                    "API Key Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtKey.Focus();
                return;
            }

            // Validación básica del formato (las API keys de OpenAI comienzan con "sk-")
            if (!ApiKey.StartsWith("sk-"))
            {
                var result = MessageBox.Show(
                    "La API Key no tiene el formato esperado de OpenAI (debe comenzar con 'sk-').\n\n" +
                    "¿Deseas continuar de todos modos?",
                    "Formato Inusual",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    txtKey.Focus();
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}