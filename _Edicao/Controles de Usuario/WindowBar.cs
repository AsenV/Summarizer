using MetroFramework;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Summarizer
{
    public partial class WindowBar : UserControl
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private const int normalHeight = 30;
        private const int maximizedHeight = 30;//25
        private int _parentFormWidth;
        private bool windowfading = false;
        private bool mouseup = true;
        private Point startPoint = new(0, 0);
        private bool _isContextMenuOpen = false;
        private double contextmenu_opacity = 0;
        private bool appearenceupdated = false;
        private bool dragging = true;
        private bool formclosing = false;
        private Color HeaderBackColor, ThemeBackColor, ThemeForeColor;

        public bool FixExtraWidth { get; set; } = false;
        public string Title { get; set; } = "Title";
        public Point FixedPos { get; set; } = new(0, 0);
        public bool CloseButton { get; set; } = true;
        public bool MinimizeButton { get; set; } = true;
        public bool MaximizeButton { get; set; } = true;
        public bool ShowIcon { get; set; } = true;

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

            closeButton.MouseEnter += (s, e) => closeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_dark_close;
            closeButton.MouseLeave += (s, e) => closeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_light_close;

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

        private Form _parentForm;
        public Form Owner { get { return _parentForm; } set { _parentForm = value; } }

        public WindowBar()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void WindowBar_Load(object sender, EventArgs e)
        {
            UpdateTheme();
        }

        private void InitializeEvents()
        {
            metroPanel1.MouseDown += pictureBox1_MouseDown;
            metroPanel1.MouseEnter += pictureBox1_MouseEnter;
            closeButton.MouseEnter += (s, e) => closeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_dark_close;
            closeButton.MouseLeave += (s, e) => closeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_light_close;
        }

        private void WindowBar_ParentChanged(object sender, EventArgs e)
        {
            _parentForm ??= this.ParentForm;
            if (_parentForm != null) ParentForm.Activated += ParentForm_Activated;
            if (_parentForm != null) ParentForm.SizeChanged += ParentForm_SizeChanged;
            if (_parentForm != null) ParentForm.FormClosing += ParentForm_Closing;
            if (_parentForm != null) ParentForm.Deactivate += ParentForm_Deactivated;
        }

        private void WindowBar_Layout(object sender, LayoutEventArgs e)
        {
            if (this.Parent != null && this.Parent is Form)
            {
                this.Location = FixedPos;
                this.Width = this.Parent.ClientSize.Width;
                this.pictureBox1.BackgroundImage = _parentForm.Icon.ToBitmap();
                label1.Text = Title;
            }
        }

        private void ParentForm_Activated(object sender, EventArgs e)
        {
            UpdateThisAppearence();
        }

        private void ParentForm_SizeChanged(object sender, EventArgs e)
        {
            this.Height = _parentForm.WindowState == FormWindowState.Normal ? normalHeight : maximizedHeight;
            _parentFormWidth = ((Form)sender).Width;
            SetWidthToParentFormWidth();
        }

        private void ParentForm_Closing(object sender, EventArgs e)
        {
            formclosing = true;
        }

        private void ParentForm_Deactivated(object sender, EventArgs e)
        {
            if (!formclosing)
            {
                label1.Focus(); // fix bug ao mudar foco da janela o maximizar ficar selecionado
            }
        }

        private void UpdateThisAppearence()
        {
            if (_parentForm == null || appearenceupdated) return;
            appearenceupdated = true;
            _parentFormWidth = 0;
            this.ParentChanged += (s, e) =>
            {
                _parentForm.SizeChanged += ParentForm_SizeChanged;
                _parentFormWidth = _parentForm.Width;
                SetWidthToParentFormWidth();
            };

            this.Height = _parentForm.WindowState == FormWindowState.Normal ? normalHeight : maximizedHeight;
            this.Location = FixedPos;
            //this.Dock = DockStyle.Top;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            this.TabStop = false;

            closeButton.Visible = CloseButton;
            minimizeButton.Visible = MinimizeButton;
            maximizeRestoreButton.Visible = MaximizeButton;
            metroPanel1.Visible = ShowIcon;
            if (!CloseButton)
            {
                tableLayoutPanel1.Width += closeButton.Width;
            }
            if (!MinimizeButton)
            {
                tableLayoutPanel1.Width += minimizeButton.Width;
            }
            if (!MaximizeButton)
            {
                tableLayoutPanel1.Width += maximizeRestoreButton.Width;
            }
            if (!ShowIcon)
            {
                tableLayoutPanel1.Location = new Point(0, 0);
                tableLayoutPanel1.Width += metroPanel1.Width;
            }

            this.pictureBox1.BackgroundImage = _parentForm.Icon.ToBitmap();
            label1.Text = Title;
            MetroTheme = _isDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light; //_metroTheme;
            MetroStyle = _metroStyle;
            UpdateTheme();
            this.BringToFront();
        }

        private void SetWidthToParentFormWidth()
        {
            if (_parentFormWidth > 0)
            {
                this.Width = FixExtraWidth ? _parentFormWidth - 16 : _parentFormWidth;
            }
        }

        private void UpdateTheme()
        {
            if (_parentForm == null) return;
            HeaderBackColor = _isDarkMode ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
            ThemeBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(225, 225, 225);
            ThemeForeColor = _isDarkMode ? Color.FromArgb(225, 225, 225) : Color.FromArgb(17, 17, 17);
            this.BackColor = HeaderBackColor;
            metroPanel1.BackColor = HeaderBackColor;
            pictureBox1.BackColor = HeaderBackColor;
            label1.BackColor = HeaderBackColor;
            label1.ForeColor = ThemeForeColor;

            closeButton.ButtonBackColor = HeaderBackColor;
            closeButton.ButtonBorderColor = HeaderBackColor;
            minimizeButton.ButtonBackColor = HeaderBackColor;
            minimizeButton.ButtonBorderColor = HeaderBackColor;
            maximizeRestoreButton.ButtonBackColor = HeaderBackColor;
            maximizeRestoreButton.ButtonBorderColor = HeaderBackColor;
            closeButton.ButtonHighlightBackColor = Color.FromArgb(255, 20, 20);
            closeButton.ButtonBorderHighlightColor = Color.FromArgb(255, 20, 20);
            minimizeButton.ButtonHighlightBackColor = _isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
            minimizeButton.ButtonBorderHighlightColor = _isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
            maximizeRestoreButton.ButtonHighlightBackColor = _isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;
            maximizeRestoreButton.ButtonBorderHighlightColor = _isDarkMode ? Color.FromArgb(60, 60, 60) : Color.LightGray;

            closeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_light_close;
            minimizeButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_minimize : Properties.Resources.icon_light_minimize;
            if (_parentForm.WindowState == FormWindowState.Normal)
            {
                maximizeRestoreButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_maximize : Properties.Resources.icon_light_maximize;
            }
            else { maximizeRestoreButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_restore : Properties.Resources.icon_light_restore; }

            RestaureItem.Image = _isDarkMode ? Properties.Resources.icon_dark_restore : Properties.Resources.icon_light_restore;
            MinimizeItem.Image = _isDarkMode ? Properties.Resources.icon_dark_minimize : Properties.Resources.icon_light_minimize;
            MaximizeItem.Image = _isDarkMode ? Properties.Resources.icon_dark_maximize : Properties.Resources.icon_light_maximize;
            CloseItem.Image = _isDarkMode ? Properties.Resources.icon_dark_close : Properties.Resources.icon_light_close;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _parentForm.Close();//Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (_parentForm != null) FadeWindowState(FormWindowState.Minimized);
        }

        private void maximizeRestoreButton_Click(object sender, EventArgs e)
        {
            if (_parentForm != null)
            {
                if (_parentForm.WindowState == FormWindowState.Normal)
                {
                    FadeWindowState(FormWindowState.Maximized);
                }
                else
                {
                    FadeWindowState(FormWindowState.Normal);
                }
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (_parentForm != null && !dragging && MaximizeButton)
            {
                if (_parentForm.WindowState == FormWindowState.Normal)
                {
                    FadeWindowState(FormWindowState.Maximized);
                }
                else
                {
                    FadeWindowState(FormWindowState.Normal);
                }
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X, e.Y);
            mouseup = false; // define mouseup como false
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_parentForm != null)
            {
                if (!mouseup)
                {
                    dragging = true;
                    if (_parentForm.WindowState == FormWindowState.Maximized)
                    {
                        FadeWindowState(FormWindowState.Normal);
                        startPoint = new Point(label1.Width / 2, label1.Height / 2);
                    }
                    Point p = PointToScreen(e.Location);
                    _parentForm.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            }
        }

        private void FadeWindowState(FormWindowState state)
        {
            if (!windowfading) // iniciando o Timer somente se ele ainda não foi iniciado
            {
                windowfading = true;
                _parentForm.Opacity = 0;
                windowInvisible.Start();
            }
            if (state == FormWindowState.Normal)
            {
                _parentForm.WindowState = FormWindowState.Normal;
                maximizeRestoreButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_maximize : Properties.Resources.icon_light_maximize;
                this.Focus(); // fix bug botao maximizar ficar selecionado
                MaximizeItem.Enabled = true;
                RestaureItem.Enabled = false;
            }
            else if (state == FormWindowState.Maximized)
            {
                _parentForm.WindowState = FormWindowState.Maximized;
                maximizeRestoreButton.ButtonBackgroundImage = _isDarkMode ? Properties.Resources.icon_dark_restore : Properties.Resources.icon_light_restore;
                MaximizeItem.Enabled = false;
                RestaureItem.Enabled = true;
            }
            else if (state == FormWindowState.Minimized)
            {
                _parentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_parentForm != null)
            {
                dragging = false;
                mouseup = true; // define mouseup como true
                _parentForm.Capture = false;
            }
        }

        private void windowInvisible_Tick(object sender, EventArgs e)
        {
            windowInvisible.Stop(); // depois do primeiro loop de 100ms, o timer é encerrado.
            windowOpacity.Start();
        }

        private void windowOpacity_Tick(object sender, EventArgs e)
        {
            _parentForm.Opacity += 0.1;

            if (_parentForm.Opacity >= 1)
            {
                windowOpacity.Stop();
                _parentForm.Opacity = 1;
                windowfading = false;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (ShowIcon)
            {
                if (!_isContextMenuOpen)
                {
                    _isContextMenuOpen = true;
                    contextmenu_opacity = 0;
                    metroContextMenu1.Opacity = contextmenu_opacity;
                    metroContextMenu1.Show(pictureBox1, new Point(0, pictureBox1.Height));
                    contextOpacity.Start();
                }
                else
                {
                    _isContextMenuOpen = false;
                    contextOpacity.Start();
                }
            }
        }

        private void contextOpacity_Tick(object sender, EventArgs e)
        {
            // Se o menu estiver aberto, aumenta a opacidade gradualmente
            if (_isContextMenuOpen && contextmenu_opacity < 1)
            {
                contextmenu_opacity += 0.10;
                metroContextMenu1.Opacity = contextmenu_opacity;
                if (contextmenu_opacity >= 1) contextOpacity.Stop(); // Para o timer quando a opacidade for igual a 1
            }
            // Se o menu estiver fechado, diminui a opacidade gradualmente
            else if (!_isContextMenuOpen && contextmenu_opacity > 0)
            {
                contextmenu_opacity -= 0.10;
                metroContextMenu1.Opacity = contextmenu_opacity;
                if (contextmenu_opacity <= 0) // Para o timer quando a opacidade for igual a 0 e esconde o menu
                {
                    contextOpacity.Stop();
                    metroContextMenu1.Hide();
                }
            }
        }

        private void metroContextMenu1_Opening(object sender, CancelEventArgs e)
        {
            // Verifica se a janela está maximizada
            bool isMaximized = (this.FindForm().WindowState == FormWindowState.Maximized);

            // Habilita ou desabilita o botão de restaurar e o botão de maximizar conforme necessário
            metroContextMenu1.Items["RestaureItem"].Enabled = isMaximized;
            metroContextMenu1.Items["MaximizeItem"].Enabled = !isMaximized;
        }

        private void RestaureItem_Click(object sender, EventArgs e)
        {
            if (_parentForm.WindowState == FormWindowState.Maximized)
            {
                FadeWindowState(FormWindowState.Normal);
                MaximizeItem.Enabled = true;
                RestaureItem.Enabled = false;
            }
        }

        private void MinimizeItem_Click(object sender, EventArgs e)
        {
            if (_parentForm != null) FadeWindowState(FormWindowState.Minimized);
        }

        private void MaximizeItem_Click(object sender, EventArgs e)
        {
            if (_parentForm.WindowState == FormWindowState.Normal)
            {
                FadeWindowState(FormWindowState.Maximized);
                MaximizeItem.Enabled = false;
                RestaureItem.Enabled = true;
            }
        }

        private void CloseItem_Click(object sender, EventArgs e)
        {
            _parentForm.Close();//Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!metroContextMenu1.Visible) _isContextMenuOpen = false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show();
        }
    }
}