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
            label1 = new Label();
            panelFlutuante = new Panel();
            label2 = new Label();
            btnCriarConta = new Button();
            btnEntrar = new Button();
            panel1 = new Panel();
            panelFlutuante.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 46);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 0;
            label1.Text = "Bem vindo";
            
            // 
            // panelFlutuante
            // 
            panelFlutuante.BackColor = Color.WhiteSmoke;
            panelFlutuante.BorderStyle = BorderStyle.FixedSingle;
            panelFlutuante.Controls.Add(label2);
            panelFlutuante.Location = new Point(286, 219);
            panelFlutuante.Name = "panelFlutuante";
            panelFlutuante.Size = new Size(309, 192);
            panelFlutuante.TabIndex = 1;
            panelFlutuante.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 26);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // btnCriarConta
            // 
            btnCriarConta.Location = new Point(217, 126);
            btnCriarConta.Name = "btnCriarConta";
            btnCriarConta.Size = new Size(112, 34);
            btnCriarConta.TabIndex = 3;
            btnCriarConta.Text = "Criar Conta";
            btnCriarConta.UseVisualStyleBackColor = true;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(40, 67);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(112, 34);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnEntrar);
            panel1.Controls.Add(panelFlutuante);
            panel1.Controls.Add(btnCriarConta);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 568);
            panel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(954, 592);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panelFlutuante.ResumeLayout(false);
            panelFlutuante.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panelFlutuante;
        private Button btnEntrar;
        private Button btnCriarConta;
        private Label label2;
        private Panel panel1;
    }
}
