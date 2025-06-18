using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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

        public static TextBox CriarTxtBox(int x, int y, Panel panelFlutuante)
        {
            TextBox textBox = new TextBox();
            textBox.Size = new Size(220, 200);
            textBox.Location = new Point(x, y);
            //textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.ForeColor = Color.Gray;

            panelFlutuante.Controls.Add(textBox);

            return textBox;
        }

        public static Button CriarBtn(string txt, int x, int y, int width, int height, int fontSize, Panel panelFlutuante, Action eventoClick)
        {
            Button btn = new Button();
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            btn.Text = txt;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Black;
            btn.Font = new Font(btn.Font.FontFamily, fontSize, FontStyle.Bold);
            btn.Click += (s, e) =>
            {
                eventoClick();
            };
            panelFlutuante.Controls.Add(btn);
            return btn;
        }


        public static Panel CriarPanelEntrar(Form1 form)
        {
            Panel meuPanel = new Panel();
            meuPanel.BackColor = Color.LightBlue;
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
            meuPanel.Size = new Size(800, 400);
            meuPanel.Visible = true;
            form.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }
        public static Panel CriarPanelContainer(Panel p, int x, int y)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(700, 500);
            meuPanel.Location = new Point(x, y);
            meuPanel.BackColor = Color.White;
            meuPanel.BorderStyle = BorderStyle.Fixed3D;
            meuPanel.Visible = true;
            p.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }

        public static Panel CriarPanelContainer(Panel p, int x, int y, int width, int height)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(width, height);
            meuPanel.Location = new Point(x, y);
            meuPanel.BackColor = Color.White;
            meuPanel.BorderStyle = BorderStyle.Fixed3D;
            meuPanel.Visible = true;
            p.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }

        public static Panel CriarPanelContainerBtnsIniciais(Panel panelDeFundo, List<Button> btns)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(400, 575);
            meuPanel.Location = new Point(150, 290);
            Color cor = AjustarCor(Color.Gray, 1.7f);
            meuPanel.BackColor = cor;
            meuPanel.BorderStyle = BorderStyle.Fixed3D;
            meuPanel.Visible = true;
            panelDeFundo.Controls.Add(meuPanel);
            foreach (var btn in btns)
            {
                meuPanel.Controls.Add(btn);
            }
            meuPanel.BringToFront();
            return meuPanel;
        }

        public static Panel CriarPanelPrincipal(Panel panelDeFundo)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(1200, 900);
            meuPanel.Location = new Point(650, 40);
            meuPanel.BackColor = Color.White;
            meuPanel.BorderStyle= BorderStyle.FixedSingle;
            meuPanel.Visible = false;
            panelDeFundo.Controls.Add(meuPanel);
            meuPanel.BringToFront();
            return meuPanel;
        }

        public static void CriarPanelMargin(Panel p, int xPanel)
        {
            Panel meuPanel = new Panel();
            meuPanel.Size = new Size(25, 25);
            meuPanel.Location = new Point(xPanel, 250);
            meuPanel.BackColor = Color.LightGray;
            p.Controls.Add(meuPanel); 
        }


        public static Color AjustarCor(Color color, float factor)
        {
            
            int r = (int)(color.R * factor);
            int g = (int)(color.G * factor);
            int b = (int)(color.B * factor);

            r = Math.Min(255, Math.Max(0, r));
            g = Math.Min(255, Math.Max(0, g));
            b = Math.Min(255, Math.Max(0, b));

            return Color.FromArgb(color.A, r, g, b);
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

        public static Label CriarLbl(string texto, int x, int y, int size)
        {

            Label novoLabel = new Label();

            novoLabel.Text = texto;
            novoLabel.Location = new Point(x, y);
            novoLabel.AutoSize = true;
            novoLabel.ForeColor = Color.Black;
            novoLabel.Font = new Font(novoLabel.Font.FontFamily, size, FontStyle.Bold);


            return novoLabel;
        }
        public static Label CriarLblRegular(string texto, int x, int y, int size)
        {

            Label novoLabel = new Label();

            novoLabel.Text = texto;
            novoLabel.Location = new Point(x, y);
            novoLabel.AutoSize = true;
            novoLabel.ForeColor = Color.Black;
            novoLabel.Font = new Font(novoLabel.Font.FontFamily, size, FontStyle.Regular);

            return novoLabel;
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

        public static ListBox CriarListBox(Panel paneDeFunfo)
        {
            ListBox listBox = new ListBox();

            listBox.Name = "Categorias";
            listBox.Location = new Point(705, 750);
            listBox.Size = new Size(465,165);     

            listBox.SelectedIndexChanged += (sender, e) =>
            {
                
            };

            paneDeFunfo.Controls.Add(listBox);

            return listBox;
        }

        public static ComboBox CriarComboBox(Panel paneDeFunfo) 
        {
            ComboBox comboBox = new ComboBox();

            comboBox.Name = "Filtrar por Quantidade";
            comboBox.Location = new Point(970, 700);
            comboBox.Size = new Size(200, 50);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                MessageBox.Show($"Selecionado: {comboBox.SelectedItem}");
            };

            paneDeFunfo.Controls.Add(comboBox);

            return comboBox;
        }

        public static void CriarImgPerfil(int x, int y, Panel panelDeFundo, Action eventoClick)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(150, 150);
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = Properties.Resources.usuario;
            pictureBox.Click += (s, e) =>
            {
                eventoClick();
            };
            panelDeFundo.Controls.Add(pictureBox);
        }

        public static void CriarImgDeletar(int x, int y, Panel p, Action eventoClick)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(40, 40);
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = Properties.Resources.deletar;
            pictureBox.Click += (s, e) =>
            {
                eventoClick();
            };
            p.Controls.Add(pictureBox);
        }

        public static void CriarImgEditar(int x, int y, Panel p, Action eventoClick)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(40, 40);
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = Properties.Resources.edit;
            pictureBox.Click += (s, e) =>
            {
                eventoClick();
            };
            p.Controls.Add(pictureBox);
        }

        public static PictureBox CriarImgSearch(int x, int y, Panel p)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(25, 25);
            pictureBox.BackColor = Color.LightGray;
            pictureBox.Location = new Point(x, y);
            pictureBox.Image = Properties.Resources.search;
            p.Controls.Add(pictureBox);

            return pictureBox;
        }




    }
}
