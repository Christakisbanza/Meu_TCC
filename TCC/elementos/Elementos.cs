using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace TCC.elementos
{
    public class Elementos
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        
        public static TextBox CriarTxtBox(string placeholder, int x, int y, Panel panelFlutuante)
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

            return textBox;
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


        public static Panel CriarPanelEntrar(Form1 form)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new System.Drawing.Size(200, 150);
            meuPanel.Location = new System.Drawing.Point(50, 50);
            meuPanel.BackColor = System.Drawing.Color.LightBlue;
            meuPanel.Dock = DockStyle.Fill;
            meuPanel.AutoScroll = true;
            meuPanel.Visible = true;
            form.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }

        public static Panel CriarPanelContainer(Form1 form)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new System.Drawing.Size(800, 400);
            meuPanel.Visible = true;
            form.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }


        public static void CriarLbl(string texto, int x, int y, int size, Panel panelFlutuante)
        {
          
            Label novoLabel = new Label();

            novoLabel.Text = texto;
            novoLabel.Location = new Point(x, y); 
            novoLabel.AutoSize = true; 
            novoLabel.ForeColor = Color.Black;
            novoLabel.Font = new Font(novoLabel.Font.FontFamily, size, FontStyle.Bold);


            panelFlutuante.Controls.Add(novoLabel);
        }


        public static DateTimePicker CriarCalendario(int x, int y, Panel panelFlutuante) 
        {

            DateTimePicker dtpData = new DateTimePicker();
            dtpData.Name = "dtpData";
            dtpData.Format = DateTimePickerFormat.Custom;
            dtpData.CustomFormat = "dd/MM/yyyy";
            dtpData.Location = new System.Drawing.Point(x, y);
            dtpData.Width = 150;

            panelFlutuante.Controls.Add(dtpData);

            return dtpData;

        }


        public static RadioButton CriarRadioBtn(string txt,int x, int y, Panel panelFlutuante)
        {
            RadioButton radio = new RadioButton();

            radio = new RadioButton();
            radio.Text = txt;
            radio.Location = new System.Drawing.Point(x, y);
            radio.Name = "rb" + txt;

            panelFlutuante.Controls.Add(radio);

            return radio;
        }

        public static CheckBox CriarCheckBox(string txt, int x, int y, Panel panelFlutuante)
        {
            CheckBox chk = new CheckBox();
            chk.Text = txt;
            chk.Location = new System.Drawing.Point(x, y);
            chk.AutoSize = true;

            panelFlutuante.Controls.Add(chk);

            return chk;
            
        }





    }
}
