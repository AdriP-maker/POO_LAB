namespace Calculadora_Basic
{
    partial class Form1
    {
        // Variable requerida por el diseñador
        private System.ComponentModel.IContainer components = null;

        // Controles de la interfaz
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btnPunto;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btnResta;
        private System.Windows.Forms.Button btnMultiplicar;
        private System.Windows.Forms.Button btnDividir;
        private System.Windows.Forms.Button btnIgual;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBackspace;

        // Limpiar los recursos que se estén usando
        // Parametro disposing: true si los recursos administrados se deben desechar; false en caso contrario
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        // Método necesario para admitir el Diseñador. No se puede modificar
        // el contenido de este método con el editor de código
        private void InitializeComponent()
        {
            txtDisplay = new TextBox();
            lblTitulo = new Label();
            lblEstado = new Label();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn0 = new Button();
            btnPunto = new Button();
            btnSuma = new Button();
            btnResta = new Button();
            btnMultiplicar = new Button();
            btnDividir = new Button();
            btnIgual = new Button();
            btnClear = new Button();
            btnBackspace = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            txtDisplay.Location = new Point(20, 70);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(340, 47);
            txtDisplay.TabIndex = 0;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.TextChanged += txtDisplay_TextChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(90, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(227, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Calculadora Basica";
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.Location = new Point(20, 115);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(340, 20);
            lblEstado.TabIndex = 2;
            lblEstado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI", 14F);
            btn7.Location = new Point(20, 150);
            btn7.Name = "btn7";
            btn7.Size = new Size(70, 50);
            btn7.TabIndex = 3;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += BtnNumero_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI", 14F);
            btn8.Location = new Point(100, 150);
            btn8.Name = "btn8";
            btn8.Size = new Size(70, 50);
            btn8.TabIndex = 4;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += BtnNumero_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI", 14F);
            btn9.Location = new Point(180, 150);
            btn9.Name = "btn9";
            btn9.Size = new Size(70, 50);
            btn9.TabIndex = 5;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += BtnNumero_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI", 14F);
            btn4.Location = new Point(20, 210);
            btn4.Name = "btn4";
            btn4.Size = new Size(70, 50);
            btn4.TabIndex = 6;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += BtnNumero_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI", 14F);
            btn5.Location = new Point(100, 210);
            btn5.Name = "btn5";
            btn5.Size = new Size(70, 50);
            btn5.TabIndex = 7;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += BtnNumero_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI", 14F);
            btn6.Location = new Point(180, 210);
            btn6.Name = "btn6";
            btn6.Size = new Size(70, 50);
            btn6.TabIndex = 8;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += BtnNumero_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI", 14F);
            btn1.Location = new Point(20, 270);
            btn1.Name = "btn1";
            btn1.Size = new Size(70, 50);
            btn1.TabIndex = 9;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += BtnNumero_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI", 14F);
            btn2.Location = new Point(100, 270);
            btn2.Name = "btn2";
            btn2.Size = new Size(70, 50);
            btn2.TabIndex = 10;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += BtnNumero_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI", 14F);
            btn3.Location = new Point(180, 270);
            btn3.Name = "btn3";
            btn3.Size = new Size(70, 50);
            btn3.TabIndex = 11;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += BtnNumero_Click;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI", 14F);
            btn0.Location = new Point(20, 330);
            btn0.Name = "btn0";
            btn0.Size = new Size(150, 50);
            btn0.TabIndex = 12;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += BtnNumero_Click;
            // 
            // btnPunto
            // 
            btnPunto.Font = new Font("Segoe UI", 14F);
            btnPunto.Location = new Point(180, 330);
            btnPunto.Name = "btnPunto";
            btnPunto.Size = new Size(70, 50);
            btnPunto.TabIndex = 13;
            btnPunto.Text = ".";
            btnPunto.UseVisualStyleBackColor = true;
            btnPunto.Click += BtnPunto_Click;
            // 
            // btnSuma
            // 
            btnSuma.Font = new Font("Segoe UI", 14F);
            btnSuma.Location = new Point(260, 330);
            btnSuma.Name = "btnSuma";
            btnSuma.Size = new Size(50, 50);
            btnSuma.TabIndex = 17;
            btnSuma.Text = "+";
            btnSuma.UseVisualStyleBackColor = true;
            btnSuma.Click += BtnOperador_Click;
            // 
            // btnResta
            // 
            btnResta.Font = new Font("Segoe UI", 14F);
            btnResta.Location = new Point(260, 270);
            btnResta.Name = "btnResta";
            btnResta.Size = new Size(50, 50);
            btnResta.TabIndex = 16;
            btnResta.Text = "-";
            btnResta.UseVisualStyleBackColor = true;
            btnResta.Click += BtnOperador_Click;
            // 
            // btnMultiplicar
            // 
            btnMultiplicar.Font = new Font("Segoe UI", 14F);
            btnMultiplicar.Location = new Point(260, 210);
            btnMultiplicar.Name = "btnMultiplicar";
            btnMultiplicar.Size = new Size(50, 50);
            btnMultiplicar.TabIndex = 15;
            btnMultiplicar.Text = "×";
            btnMultiplicar.UseVisualStyleBackColor = true;
            btnMultiplicar.Click += BtnOperador_Click;
            // 
            // btnDividir
            // 
            btnDividir.Font = new Font("Segoe UI", 14F);
            btnDividir.Location = new Point(260, 150);
            btnDividir.Name = "btnDividir";
            btnDividir.Size = new Size(50, 50);
            btnDividir.TabIndex = 14;
            btnDividir.Text = "÷";
            btnDividir.UseVisualStyleBackColor = true;
            btnDividir.Click += BtnOperador_Click;
            // 
            // btnIgual
            // 
            btnIgual.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnIgual.Location = new Point(20, 390);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(230, 50);
            btnIgual.TabIndex = 18;
            btnIgual.Text = "=";
            btnIgual.UseVisualStyleBackColor = true;
            btnIgual.Click += BtnIgual_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F);
            btnClear.Location = new Point(260, 390);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 50);
            btnClear.TabIndex = 19;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnBackspace
            // 
            btnBackspace.Font = new Font("Segoe UI", 12F);
            btnBackspace.Location = new Point(320, 150);
            btnBackspace.Name = "btnBackspace";
            btnBackspace.Size = new Size(40, 290);
            btnBackspace.TabIndex = 20;
            btnBackspace.Text = "←";
            btnBackspace.UseVisualStyleBackColor = true;
            btnBackspace.Click += BtnBackspace_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 460);
            Controls.Add(btnBackspace);
            Controls.Add(btnClear);
            Controls.Add(btnIgual);
            Controls.Add(btnSuma);
            Controls.Add(btnResta);
            Controls.Add(btnMultiplicar);
            Controls.Add(btnDividir);
            Controls.Add(btnPunto);
            Controls.Add(btn0);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(lblEstado);
            Controls.Add(lblTitulo);
            Controls.Add(txtDisplay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora Basica";
            Load += Form1_Load;
            KeyPress += Form1_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
