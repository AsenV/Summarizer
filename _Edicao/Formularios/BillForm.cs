using MetroFramework;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace Tielapse
{


    public partial class BillForm : MetroFramework.Forms.MetroForm
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private int minWidth, minHeight, maxWidth, maxHeight;
        private Color HeaderBackColor, ThemeBackColor, ThemeForeColor;

        //private string caminhoArquivoAtual = null;
        public Position SelectedPosition { get; set; } = Position.Middle;
        public bool IsConfirmed { get; set; } = false; // Inicia como falso

        public string BillName => txtName.Text;
        public DateTime BillDate => dtpDate.Value;
        public decimal BillValue => decimal.Parse(txtValue.Text);
        public int BillTimes => int.TryParse(cbTimes.SelectedItem?.ToString(), out var vezes) ? vezes : 0;


        public event EventHandler DarkModeChanged;
        private bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        public bool DarkMode
        {
            get { return _isDarkMode; }
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    OnDarkModeChanged();
                }
            }
        }

        protected virtual void OnDarkModeChanged()
        {
            DarkModeChanged?.Invoke(this, EventArgs.Empty);
            UpdateTheme();
        }

        private MetroThemeStyle _metroTheme;
        public MetroThemeStyle MetroTheme
        {
            get { return mStyleManager.Theme; }
            set
            {
                if (_metroTheme != value)
                {
                    mStyleManager.Theme = value;
                    _metroTheme = value;
                    mStyleManager.Update();
                }
            }
        }

        private MetroColorStyle _metroStyle;
        public MetroColorStyle MetroStyle
        {
            get { return mStyleManager.Style; }
            set
            {
                if (_metroStyle != value)
                {
                    mStyleManager.Style = value;
                    _metroStyle = value;
                    mStyleManager.Update();
                }
            }
        }

        public BillForm(string nome, DateTime data, decimal valor, int vezes)
        {
            InitializeComponent();
            InitializeEvents();

            txtName.Text = nome;
            dtpDate.Value = data;
            txtValue.Text = valor.ToString(); 
            cbTimes.SelectedItem = vezes.ToString();

            //caminhoArquivoAtual = getCaminhoArquivoAtual;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();
        }

        private void InitializeEvents()
        {
            this.StyleManager = mStyleManager;
            PreencherCbTimes();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            MinimumSize = new Size(minWidth, minHeight);
            MaximumSize = new Size(maxWidth, maxHeight);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            if (Width < minWidth) Width = minWidth;
            if (Height < minHeight) Height = minHeight;
            if (Width > maxWidth) Width = maxWidth;
            if (Height > maxHeight) Height = maxHeight;
        }

        private void Bill_SizeChanged(object sender, EventArgs e)
        {
            // Desabilitar redimensionamento estando maximizado
            this.Resizable = false;// WindowState != FormWindowState.Maximized;
        }

        private void btnConfirm_MouseDown(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void UpdateUserSettings(MetroThemeStyle theme, MetroColorStyle style)
        {
            MetroTheme = theme;
            MetroStyle = style;
        }

        private void UpdateThisAppearence()
        {
            minWidth = ClientSize.Width / 2 - (minWidth % 1); // Largura minima da janela
            minHeight = ClientSize.Height / 2 - (minHeight % 1); // Altura minima da janela
            maxWidth = ClientSize.Width;
            maxHeight = ClientSize.Height;

            MetroTheme = _metroTheme;
            _isDarkMode = (MetroTheme == MetroThemeStyle.Dark);
            MetroStyle = _metroStyle;

            Form1 formPrincipal = new Form1();
            string nomeDoProjeto = formPrincipal.NomeDoProjeto;
            string versaoDoArquivo = formPrincipal.VersaoDoArquivo;
            string nomeDaEmpresa = formPrincipal.NomeDaEmpresa;

            //label1.Text = $"{nomeDoProjeto}\r\nVersão {versaoDoArquivo}\r\n© 2024 {nomeDaEmpresa}\r\nTodos os direitos reservados.";
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            HeaderBackColor = _isDarkMode ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
            ThemeBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(225, 225, 225);
            ThemeForeColor = _isDarkMode ? Color.FromArgb(225, 225, 225) : Color.FromArgb(17, 17, 17);

            label1.ForeColor = ThemeForeColor;
            label2.ForeColor = ThemeForeColor;
            ApplyButtomTheme(btnConfirm, true);

            windowBar1.DarkMode = _isDarkMode;
        }

        private void ApplyButtomTheme(CustomButton button, bool highlight)
        {
            button.ButtonHighlight = highlight;
            button.ButtonForeColor = ThemeForeColor;
            button.ButtonBackColor = ThemeBackColor;
            button.ButtonBorderColor = ThemeForeColor;
            button.ButtonHighlightBackColor = ThemeBackColor;
            button.ButtonHighlightForeColor = ThemeForeColor;
            button.ButtonBorderHighlightColor = Color.OrangeRed;
        }

        private void PreencherCbTimes()
        {
            // Lista de valores para o ComboBox
            List<string> valoresParcelamento = new List<string>();

            // Adiciona números de 1 a 100
            for (int i = 1; i <= 100; i++)
            {
                valoresParcelamento.Add(i.ToString());
            }

            // Adiciona centenas de 200 a 1000
            for (int i = 200; i <= 1000; i += 100)
            {
                valoresParcelamento.Add(i.ToString());
            }

            // Adiciona milhares (2000 e 3000)
            valoresParcelamento.Add("2000");
            valoresParcelamento.Add("3000");

            // Preenche o ComboBox
            cbTimes.Items.Clear();
            cbTimes.Items.AddRange(valoresParcelamento.ToArray());

            // Define o item padrão (opcional)
            cbTimes.SelectedItem = "1";
        }

        private void BillForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
