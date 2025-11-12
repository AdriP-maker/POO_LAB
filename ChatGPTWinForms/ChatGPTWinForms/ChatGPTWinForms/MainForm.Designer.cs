namespace ChatGPTWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblEstado = new Label();
            txtChat = new TextBox();
            txtPrompt = new TextBox();
            btnEnviar = new Button();
            btnLimpiar = new Button();
            btnCopiar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(339, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ChatGPT – Cliente WinForms";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.ForeColor = Color.Green;
            lblEstado.Location = new Point(12, 678);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(40, 20);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Listo";
            // 
            // txtChat
            // 
            txtChat.BackColor = SystemColors.Window;
            txtChat.Font = new Font("Consolas", 9F);
            txtChat.Location = new Point(12, 50);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.ScrollBars = ScrollBars.Vertical;
            txtChat.Size = new Size(1004, 508);
            txtChat.TabIndex = 1;
            txtChat.TabStop = false;
            // 
            // txtPrompt
            // 
            txtPrompt.Font = new Font("Segoe UI", 9F);
            txtPrompt.Location = new Point(12, 574);
            txtPrompt.MaxLength = 1000;
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.ScrollBars = ScrollBars.Vertical;
            txtPrompt.Size = new Size(1004, 60);
            txtPrompt.TabIndex = 2;
            // 
            // btnEnviar
            // 
            btnEnviar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEnviar.Location = new Point(12, 640);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(120, 35);
            btnEnviar.TabIndex = 3;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(138, 640);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(264, 640);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(120, 35);
            btnCopiar.TabIndex = 5;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 707);
            Controls.Add(btnCopiar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEnviar);
            Controls.Add(txtPrompt);
            Controls.Add(txtChat);
            Controls.Add(lblEstado);
            Controls.Add(lblTitulo);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatGPT WinForms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblEstado;
        private TextBox txtChat;
        private TextBox txtPrompt;
        private Button btnEnviar;
        private Button btnLimpiar;
        private Button btnCopiar;
    }
}