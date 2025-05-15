using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TCC.elementos
{
    public class Elementos
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        
        public static void CriarTxtBox(string placeholder, int x, int y, Panel panelFlutuante)
        {
            TextBox textBox = new TextBox();
            textBox.Size = new Size(250, 35);
            textBox.Location = new Point(x, y);
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
            textBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox.Width, textBox.Height, 12, 12));
            
            panelFlutuante.Controls.Add(textBox);
        }

        public static void CriarBtn(string txt, int x, int y, int width, int height, Panel panelFlutuante, Action eventoClick)
        {
            Button btn = new Button();
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            btn.Text = txt;
            btn.ForeColor = Color.Black;
            btn.Font = new Font(btn.Font, FontStyle.Bold);
            btn.Click += (s, e) =>
            {
                eventoClick();
            };
            panelFlutuante.Controls.Add(btn);
        }


        public static Panel CriarPanel()
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(300, 300);  
            meuPanel.Location = new Point(50, 50);
            meuPanel.AutoScroll = true;
            meuPanel.Visible = true;
            return meuPanel; 
        }

       
        public static void CriarLbl(string texto, int x, int y, Panel panelFlutuante)
        {
          
            Label novoLabel = new Label();

            novoLabel.Text = texto;
            novoLabel.Location = new Point(x, y); 
            novoLabel.AutoSize = true; 
            novoLabel.ForeColor = Color.Black;
            novoLabel.Font = new Font(novoLabel.Font.FontFamily, 17, FontStyle.Bold);


            panelFlutuante.Controls.Add(novoLabel);
        }





    }
}
