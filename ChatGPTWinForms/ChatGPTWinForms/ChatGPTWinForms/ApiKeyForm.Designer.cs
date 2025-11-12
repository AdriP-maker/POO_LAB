namespace ChatGPTWinForms
{
    partial class ApiKeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl = new Label();
            txtKey = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(69, 170);
            lbl.Name = "lbl";
            lbl.Size = new Size(221, 20);
            lbl.TabIndex = 0;
            lbl.Text = "Introduce tu API Key de OpenAI:";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(296, 113);
            txtKey.Multiline = true;
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(472, 128);
            txtKey.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(196, 378);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 2;
            btnOk.Text = "Aceptar";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(515, 378);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ApiKeyForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtKey);
            Controls.Add(lbl);
            Name = "ApiKeyForm";
            Text = "ApiKeyForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl;
        private TextBox txtKey;
        private Button btnOk;
        private Button btnCancel;
    }
}