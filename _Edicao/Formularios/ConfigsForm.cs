using MetroFramework;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Summarizer
{
    public partial class ConfigsForm : MetroFramework.Forms.MetroForm
    {
        private int minWidth, minHeight, maxWidth, maxHeight;
        private Color HeaderBackColor, ThemeBackColor, ThemeForeColor;

        private bool firstOpened = true;
        private int cbSelectedTheme = 0;
        private int cbSelectedStyle = 0;

        private readonly List<string> temas = new() { "Light", "Dark" };
        private readonly List<string> estilos = new()
        {
        "Default", "Black", "White", "Silver", "Blue", "Green", "Lime", "Teal",
        "Orange", "Brown", "Pink", "Magenta", "Purple", "Red", "Yellow"
        };

        public MetroThemeStyle SelectedTheme { get; set; }
        public MetroColorStyle SelectedStyle { get; set; }
        public event EventHandler cbThemeChanged;
        public event EventHandler cbStyleChanged;

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

        public ConfigsForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void Configs_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();
            cbTheme.DataSource = temas;
            cbStyle.DataSource = estilos;

            cbSelectedTheme = temas.IndexOf(MetroTheme.ToString());
            cbSelectedStyle = estilos.IndexOf(MetroStyle.ToString());
            cbTheme.SelectedIndex = cbSelectedTheme;
            cbStyle.SelectedIndex = cbSelectedStyle;
            firstOpened = false;
        }

        private void InitializeEvents()
        {
            this.StyleManager = mStyleManager;
        }

        public void cbTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstOpened)
            {
                string temaSelecionado = cbTheme.SelectedItem.ToString();
                MetroThemeStyle tema = (MetroThemeStyle)Enum.Parse(typeof(MetroThemeStyle), temaSelecionado);
                SelectedTheme = tema;
                cbSelectedTheme = cbTheme.SelectedIndex;
                cbThemeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void cbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstOpened)
            {
                string estiloSelecionado = cbStyle.SelectedItem.ToString();
                MetroColorStyle estilo = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), estiloSelecionado);
                SelectedStyle = estilo;
                cbSelectedStyle = cbStyle.SelectedIndex;
                cbStyleChanged?.Invoke(this, EventArgs.Empty);
            }
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
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            HeaderBackColor = _isDarkMode ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
            ThemeBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(225, 225, 225);
            ThemeForeColor = _isDarkMode ? Color.FromArgb(225, 225, 225) : Color.FromArgb(17, 17, 17);

            windowBar1.DarkMode = _isDarkMode;
            label1.ForeColor = ThemeForeColor;
            label2.ForeColor = ThemeForeColor;
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

        private void Configs_SizeChanged(object sender, EventArgs e)
        {
            // Desabilitar redimensionamento estando maximizado
            this.Resizable = false;// WindowState != FormWindowState.Maximized;
        }

        public void UpdateUserSettings(MetroThemeStyle theme, MetroColorStyle style)
        {
            MetroTheme = theme;
            MetroStyle = style;
        }
    }
}
