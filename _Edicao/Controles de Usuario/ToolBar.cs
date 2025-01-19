using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Summarizer
{
    /* no construtor: Application.AddMessageFilter(new ToolbarMessageFilter(toolBar1)); // mousedown unfocus
     * Adicione esse metodo ao formulario:
    private void InitializeToolBar()
    {
        // Adicione botões à barra de ferramentas (use "-" como separador)
        toolBar1.AddButton("Arquivo", new List<string> { "Novo", "Abrir", "Salvar", "-", "Fechar" }, index =>
        {
            if (index == 0) { }
            else if (index == 1) { }
            else if (index == 2) { }
            else if (index == 4) { Application.Exit(); }
        });
        toolBar1.AddButton("Sobre", new List<string> { "Dicas", "-", "Sobre" }, index =>
        { });
    }
    */
    public partial class ToolBar : UserControl
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private bool appearenceupdated = false;
        private bool _isButtonMenuOpen = false;
        private double contextmenu_opacity = 0;
        private Color HeaderBackColor;
        private Color ThemeBackColor;
        private Color ThemeForeColor;
        private Color HighlightButton;
        private readonly List<ToolBarButton> _buttons = new();
        private MetroContextMenu contextMenu;
        private ToolBarButton _clickedButton;
        private ToolBarButton _lastClickedButton;

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

        private Point _fixedPos = new(0, 30);
        public Point FixedPos { get { return _fixedPos; } set { _fixedPos = value; } }

        public bool FixExtraWidth { get; set; } = false;

        private Form _parentForm;
        public Form Owner { get { return _parentForm; } set { _parentForm = value; } }

        public ToolBar()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void TookBar_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();
        }

        private void InitializeEvents() { }

        private void TookBar_ParentChanged(object sender, EventArgs e)
        {
            _parentForm ??= this.ParentForm;
        }

        private void TookBar_Layout(object sender, LayoutEventArgs e)
        {
            if (_parentForm != null)
            {
                this.Location = _fixedPos;
                this.Width = _parentForm.ClientSize.Width;
            }
        }

        private void UpdateThisAppearence()
        {
            if (_parentForm == null || appearenceupdated) return;
            appearenceupdated = true;

            this.Location = _fixedPos;
            //this.Dock = DockStyle.Top;
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            //this.TabStop = false;

            MetroTheme = _isDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light; //_metroTheme;
            MetroStyle = _metroStyle;
            UpdateTheme();
            this.BringToFront();
        }

        private void UpdateTheme()
        {
            if (_parentForm == null) return;
            HeaderBackColor = _isDarkMode ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
            ThemeBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(225, 225, 225);
            ThemeForeColor = _isDarkMode ? Color.FromArgb(225, 225, 225) : Color.FromArgb(17, 17, 17);
            HighlightButton = _isDarkMode ? Color.FromArgb(75, 75, 75) : Color.FromArgb(175, 175, 175);
            this.BackColor = HeaderBackColor;
            this.ForeColor = ThemeForeColor;
            flowLayoutPanel1.BackColor = HeaderBackColor;
            flowLayoutPanel1.ForeColor = ThemeForeColor;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CustomButton button)
                {
                    button.ButtonBackColor = HeaderBackColor;
                    button.ButtonForeColor = ThemeForeColor;
                }
            }
        }

        private void SetupButtonAppearance(ToolBarButton button)
        {
            var btn = button.Button;

            btn.Name = $"btn{btn.Text}";
            btn.Height = 25;
            btn.Width = TextRenderer.MeasureText(button.Text, btn.Font).Width + 10;
            btn.ButtonFont = new System.Drawing.Font("Segoe UI", 9F);
            btn.ButtonTextAlign = ContentAlignment.MiddleCenter;
            btn.ButtonBorderWidth = new Padding(0);
            btn.ButtonBackColor = HeaderBackColor;
            btn.ButtonForeColor = ThemeForeColor;
            btn.Margin = new Padding(0, 0, 1, 0); // espaçamento a direita
        }

        public void AddButton(string buttonText, IEnumerable<string> menuItemTexts, Action<int> menuItemClicked)
        {
            var button = new ToolBarButton(buttonText, menuItemTexts, menuItemClicked);
            button.Button.ButtonText = buttonText;

            SetupButtonAppearance(button);
            SetupButtonEvents(button, menuItemClicked);

            flowLayoutPanel1.Controls.Add(button.Button);
            _buttons.Add(button);
        }

        private void SetupButtonEvents(ToolBarButton button, Action<int> menuItemClicked)
        {
            var btn = button.Button;
            if (btn.Tag != null) return; // Verifica se o botão já tem eventos associados
            contextMenu = new MetroContextMenu(this.Container);
            ContextMenuStrip = contextMenu;
            contextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            contextMenu.StyleManager = mStyleManager;

            if (button.Items != null && button.Items.Count > 0)
                btn.Tag = CreateToolStripItems(button);

            // adiciona verificação para evitar a mudança de cor se o menu estiver sendo aberto ou fechado
            btn.MouseEnter += (sender, e) =>
            {
                if (!contextMenu.Visible) _isButtonMenuOpen = false;
                if (!_isButtonMenuOpen) btn.ButtonBackColor = HighlightButton;
            };
            btn.MouseLeave += (sender, e) =>
            {
                if (!_isButtonMenuOpen) btn.ButtonBackColor = HeaderBackColor;
            };
            btn.LostFocus += (sender, e) => btn.ButtonBackColor = HeaderBackColor;

            btn.MouseDown += (sender, e) =>
            {
                _clickedButton = button;

                if (_lastClickedButton != null && _lastClickedButton != button)
                {
                    _lastClickedButton.Button.ButtonBackColor = HeaderBackColor;
                    _isButtonMenuOpen = false;
                }

                _lastClickedButton = button;

                //Console.WriteLine($"isopen: {_isButtonMenuOpen}");
                if (btn.Tag == null) // Verifica se o menu suspenso não tem itens
                {
                    menuItemClicked?.Invoke(-1); // Executa o comando passando o índice -1
                }
                else if (_isButtonMenuOpen)
                {
                    btn.ButtonBackColor = HeaderBackColor;
                    _isButtonMenuOpen = false;
                    contextMenu.Hide();
                }
                else
                {
                    _isButtonMenuOpen = true;
                    contextMenu.Items.Clear();
                    contextMenu.Items.AddRange(((List<ToolStripItem>)btn.Tag).ToArray());

                    btn.ButtonBackColor = HighlightButton;
                    contextmenu_opacity = 0;
                    contextMenu.Opacity = contextmenu_opacity;
                    contextMenu.Show(btn, new Point(0, btn.Height));
                    contextOpacity.Start();
                }
                //Console.WriteLine($"isopen: {_isButtonMenuOpen}");
                //Console.WriteLine($"-");
            };
        }

        public void HideContextMenu()
        {
            if (_clickedButton != null)
            {
                _clickedButton.Button.ButtonBackColor = HeaderBackColor;
                _isButtonMenuOpen = false;
                contextMenu.Hide();
            }
        }

        private void contextOpacity_Tick(object sender, EventArgs e)
        {
            if (_isButtonMenuOpen && contextmenu_opacity < 1)
            {
                contextmenu_opacity += 0.10;
                contextMenu.Opacity = contextmenu_opacity;
                if (contextmenu_opacity >= 1) contextOpacity.Stop();
            }
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            HideContextMenu();
        }

        private List<ToolStripItem> CreateToolStripItems(ToolBarButton button)
        {
            var items = button.Items;
            var toolStripItems = new List<ToolStripItem>();

            foreach (var menuItem in items)
            {
                ToolStripItem toolStripItem;

                if (menuItem.Text == "-")
                {
                    var toolStripSeparator = new ToolStripSeparator()
                    {
                        Tag = menuItem
                    };
                    toolStripItem = toolStripSeparator;
                }
                else
                {
                    var toolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = menuItem.Text,
                        Tag = menuItem // adiciona a propriedade Tag ao ToolStripMenuItem
                    };
                    toolStripMenuItem.Click += (sender, e) =>
                    {
                        var clickedItem = (ToolStripMenuItem)sender;
                        var item = (MenuItem)clickedItem.Tag; // obtém o item de menu associado ao ToolStripMenuItem
                        int index = button.Items.IndexOf(item); // obtém o índice do item de menu na lista
                        button.MenuItemClicked?.Invoke(index);
                        HideContextMenu();
                    };
                    toolStripItem = toolStripMenuItem;
                }

                toolStripItems.Add(toolStripItem);
            }

            return toolStripItems;
        }

        public class ToolBarButton
        {
            public CustomButton Button { get; set; }
            public string Text { get; set; }
            public List<MenuItem> Items { get; set; }
            public List<Action> ItemClickEvents { get; set; }
            public Action<int> MenuItemClicked { get; set; }

            public ToolBarButton(string text, IEnumerable<string> menuItemTexts, Action<int> menuItemClicked)
            {
                Button = new CustomButton();
                Text = text;
                Items = new List<MenuItem>();
                //ItemClickEvents = new List<Action>(itemClickEvents);
                MenuItemClicked = menuItemClicked;

                if (menuItemTexts != null)
                {
                    foreach (var menuItemText in menuItemTexts)
                    {
                        var item = new MenuItem(menuItemText, (sender, e) =>
                        {
                            int index = Items.FindIndex(i => i == sender);
                            if (index >= 0 && index < ItemClickEvents.Count)
                            {
                                ItemClickEvents[index]?.Invoke();
                                MenuItemClicked?.Invoke(index);
                            }
                        });
                        Items.Add(item);
                    }
                }
            }

            public void AddItem(string text, EventHandler handler)
            {
                var item = new MenuItem(text, handler);
                Items.Add(item);
            }
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            int lines = flowLayoutPanel1.Height / 25;
            this.Height = lines > 1 ? flowLayoutPanel1.Height : 25;
        }
    }

    public class ToolbarMessageFilter : IMessageFilter
    {
        private readonly ToolBar toolBar;

        public ToolbarMessageFilter(ToolBar toolBar)
        {
            this.toolBar = toolBar;
        }

        public bool PreFilterMessage(ref Message m)
        {
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_LBUTTONDOWN = 0x201;
            const int WM_RBUTTONDOWN = 0x204;
            const int WM_MBUTTONDOWN = 0x207;
            const int WM_NCLBUTTONDOWN = 0x0A1;
            const int WM_NCRBUTTONDOWN = 0x0A4;
            const int WM_NCMBUTTONDOWN = 0x0A7;
            const int WM_MOUSEWHEEL = 0x020A;

            if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN || m.Msg == WM_MBUTTONDOWN
                || m.Msg == WM_NCLBUTTONDOWN || m.Msg == WM_NCRBUTTONDOWN || m.Msg == WM_NCMBUTTONDOWN
                || m.Msg == WM_MOUSEWHEEL || (m.Msg == WM_MOUSEMOVE && (Control.MouseButtons & MouseButtons.Left) != 0))
            {
                if (!toolBar.RectangleToScreen(toolBar.ClientRectangle).Contains(Cursor.Position))
                {
                    // Verifica se o mouse está dentro do menu de contexto antes de fechá-lo
                    if (toolBar.ContextMenuStrip != null && toolBar.ContextMenuStrip.Visible &&
                        toolBar.ContextMenuStrip.Bounds.Contains(Cursor.Position))
                    {
                        return true;
                    }
                    toolBar.HideContextMenu();
                }
            }

            return false;
        }
    }

}
