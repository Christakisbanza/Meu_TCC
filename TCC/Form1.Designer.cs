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
            btnEntrar = new Button();
            btnCriarConta = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(407, 69);
            label1.Name = "label1";
            label1.Size = new Size(97, 25);
            label1.TabIndex = 0;
            label1.Text = "Bem vindo";
            // 
            // panelFlutuante
            // 
            panelFlutuante.BackColor = Color.WhiteSmoke;
            panelFlutuante.BorderStyle = BorderStyle.FixedSingle;
            panelFlutuante.Location = new Point(313, 245);
            panelFlutuante.Name = "panelFlutuante";
            panelFlutuante.Size = new Size(309, 153);
            panelFlutuante.TabIndex = 1;
            panelFlutuante.Visible = false;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(313, 166);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(112, 34);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnCriarConta
            // 
            btnCriarConta.Location = new Point(510, 166);
            btnCriarConta.Name = "btnCriarConta";
            btnCriarConta.Size = new Size(112, 34);
            btnCriarConta.TabIndex = 3;
            btnCriarConta.Text = "Criar Conta";
            btnCriarConta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(954, 592);
            Controls.Add(btnCriarConta);
            Controls.Add(btnEntrar);
            Controls.Add(panelFlutuante);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panelFlutuante;
        private Button btnEntrar;
        private Button btnCriarConta;
    }
}
