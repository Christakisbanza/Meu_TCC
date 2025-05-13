namespace TCC
{
    partial class Form1
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
            txtInicial = new Label();
            panelFlutuante = new Panel();
            btnCriarConta = new Button();
            btnEntrar = new Button();
            panelOverlay = new Panel();
            panelOverlay.SuspendLayout();
            SuspendLayout();
            // 
            // txtInicial
            // 
            txtInicial.AutoSize = true;
            txtInicial.Font = new Font("Baskerville Old Face", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtInicial.Location = new Point(196, 39);
            txtInicial.Name = "txtInicial";
            txtInicial.Size = new Size(555, 82);
            txtInicial.TabIndex = 0;
            txtInicial.Text = "Gerência o estoque da sua empresa\r\n                com facilidade";
            // 
            // panelFlutuante
            // 
            panelFlutuante.BackColor = Color.WhiteSmoke;
            panelFlutuante.BorderStyle = BorderStyle.FixedSingle;
            panelFlutuante.Location = new Point(196, 141);
            panelFlutuante.Name = "panelFlutuante";
            panelFlutuante.Size = new Size(555, 300);
            panelFlutuante.TabIndex = 1;
            panelFlutuante.Visible = false;
            // 
            // btnCriarConta
            // 
            btnCriarConta.BackColor = Color.FromArgb(0, 0, 192);
            btnCriarConta.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCriarConta.ForeColor = Color.Transparent;
            btnCriarConta.Location = new Point(576, 298);
            btnCriarConta.Name = "btnCriarConta";
            btnCriarConta.Size = new Size(138, 65);
            btnCriarConta.TabIndex = 3;
            btnCriarConta.Text = "Criar Conta";
            btnCriarConta.UseVisualStyleBackColor = false;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.LimeGreen;
            btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.Transparent;
            btnEntrar.Location = new Point(256, 298);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(141, 65);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // panelOverlay
            // 
            panelOverlay.Controls.Add(panelFlutuante);
            panelOverlay.Dock = DockStyle.Fill;
            panelOverlay.Location = new Point(0, 0);
            panelOverlay.Name = "panelOverlay";
            panelOverlay.Size = new Size(954, 592);
            panelOverlay.TabIndex = 4;
            panelOverlay.Visible = false;
            panelOverlay.MouseClick += panelOverlay_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(954, 592);
            Controls.Add(txtInicial);
            Controls.Add(panelOverlay);
            Controls.Add(btnEntrar);
            Controls.Add(btnCriarConta);
            Name = "Form1";
            Text = "Form1";
            panelOverlay.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtInicial;
        private Panel panelFlutuante;
        private Button btnEntrar;
        private Button btnCriarConta;
        private Panel panelOverlay;
    }
}
