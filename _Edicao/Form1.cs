using MetroFramework.Controls;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Summarizer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private string programFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        private string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Asen Lab", "ASL Summarizer");
        private string ultimoTema, ultimoEstilo;
        //private readonly bool isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private int minWidth, minHeight;
        private Color HeaderBackColor, ThemeBackColor, ThemeForeColor;
        private MetroStyleManager mStyleManager = new();
        private ConfigsForm configs = new();
        private SobreForm sobre = new();
        private DicasForm dicas = new();

        public bool isPremium = true;
        public string NomeDoProjeto { get; } = "ASL Summarizer";
        public string VersaoDoArquivo { get; } = ObterVersaoDoArquivo();
        public string NomeDaEmpresa { get; } = "Asen Lab Corporation";

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

        List<string> commentTypes = new List<string> { "Line Comment", "Block Comment", "HTML Comment" };

        private readonly List<Language> supportedLanguages = new()
        {
            new CSharpLanguage(),
            //new JavaLanguage(),
        };

        public Form1()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            configs.cbThemeChanged += Configs_ThemeChanged;
            configs.cbStyleChanged += Configs_StyleChanged;
            mStyleManager.Owner = this;
            this.StyleManager = mStyleManager;
            Application.AddMessageFilter(new ToolbarMessageFilter(toolBar1)); // Desfocar ao clicar fora
            Application.AddMessageFilter(new DropDownMessageFilter(comboCheckBox1)); // mousedown unfocus
            Application.AddMessageFilter(new DropDownMessageFilter(comboCheckBox2)); // mousedown unfocus
            Application.AddMessageFilter(new DropDownMessageFilter(comboCheckBox3)); // mousedown unfocus

            configs.Icon = this.Icon;
            sobre.Icon = this.Icon;
            dicas.Icon = this.Icon;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserSettings();
            UpdateThisAppearence();
            InitializeToolBar();
            InitializeLanguages();
        }

        private void InitializeLanguages()
        {
            txtScript.ReadOnly = !isPremium;
            txtTrimInput.ReadOnly = !isPremium;
            txtNoteReInput.ReadOnly = !isPremium;

            txtScript.Text = "using System;\r\n" +
"using System.Windows.Forms;\r\n" +
"using System.Drawing;\r\n" +
"\r\n" +
"namespace WindowsFormsExample\r\n" +
"{\r\n" +
"    static class Program\r\n" +
"    {\r\n" +
"        [STAThread]\r\n" +
"        static void Main()\r\n" +
"        {\r\n" +
"            Application.EnableVisualStyles();\r\n" +
"            Application.SetCompatibleTextRenderingDefault(false);\r\n" +
"            Application.Run(new MainForm());\r\n" +
"        }\r\n" +
"    }\r\n" +
"\r\n" +
"    public class MainForm : Form\r\n" +
"    {\r\n" +
"        private TextBox inputTextBox;\r\n" +
"        private Button displayButton;\r\n" +
"\r\n" +
"        public MainForm()\r\n" +
"        {\r\n" +
"            this.Text = \"Example Windows Forms\";\r\n" +
"            this.Size = new Size(400, 200);\r\n" +
"            this.StartPosition = FormStartPosition.CenterScreen;\r\n" +
"\r\n" +
"            InitializeComponents();\r\n" +
"        }\r\n" +
"\r\n" +
"        // initialize\r\n" +
"        private void InitializeComponents()\r\n" +
"        {\r\n" +
"            inputTextBox = new TextBox();\r\n" +
"            inputTextBox.Location = new Point(20, 20);\r\n" +
"            inputTextBox.Width = 300;\r\n" +
"\r\n" +
"            displayButton = new Button();\r\n" +
"            displayButton.Text = \"Show Text\";\r\n" +
"            displayButton.Location = new Point(20, 60);\r\n" +
"            displayButton.Click += DisplayButton_Click;\r\n" +
"\r\n" +
"            this.Controls.Add(inputTextBox);\r\n" +
"            this.Controls.Add(displayButton);\r\n" +
"        }\r\n" +
"\r\n" +
"        // display the text\r\n" +
"        private void DisplayButton_Click(object sender, EventArgs e)\r\n" +
"        {\r\n" +
"            string inputText = inputTextBox.Text;\r\n" +
"            Helper.ShowMessage(inputText);\r\n" +
"        }\r\n" +
"    }\r\n" +
"\r\n" +
"    public static class Helper\r\n" +
"    {\r\n" +
"        // show message\r\n" +
"        public static void ShowMessage(string message)\r\n" +
"        {\r\n" +
"            if (string.IsNullOrWhiteSpace(message))\r\n" +
"            {\r\n" +
"                MessageBox.Show(\"Please, insert a text.\", \"Warning\", MessageBoxButtons.OK, MessageBoxIcon.Warning);\r\n" +
"            }\r\n" +
"            else\r\n" +
"            {\r\n" +
"                MessageBox.Show(message, \"Text inserted\", MessageBoxButtons.OK, MessageBoxIcon.Information);\r\n" +
"            }\r\n" +
"        }\r\n" +
"    }\r\n" +
"}";

            txtTagFind1.Text = "Of love and loss, both brave and bold.";
            txtTagReplace1.Text = "Of socks mismatched, and sandwiches cold. <-";

            txtTrimInput.Text = "Whispers of Time\r\n" +
"\r\n" +
"Beneath the sky, where dreams unfold,\r\n" +
"The stars above, a tale retold,\r\n" +
"Of love and loss, both brave and bold.\r\n" +
"\r\n" +
"The rivers sing, a gentle tune,\r\n" +
"Reflecting light from silver moon,\r\n" +
"A fleeting dance, gone all too soon.\r\n" +
"\r\n" +
"In endless fields, where echoes play,\r\n" +
"The past and present softly sway,\r\n" +
"Eternal whispers guide the way.\r\n";

            txtNoteReInput.Text = "using System;\r\n" +
            "\r\n" +
            "public class Example\r\n" +
            "{\r\n" +
            "    public void Method()\r\n" +
            "    {\r\n" +
            "        // This is a line comment\r\n" +
            "        Console.WriteLine(\"Hello, world!\");\r\n" +
            "\r\n" +
            "        /*\r\n" +
            "           This is a block comment\r\n" +
            "           It can span multiple lines\r\n" +
            "        */\r\n" +
            "\r\n" +
            "        Console.WriteLine(\"Code continues here\");\r\n" +
            "\r\n" +
            "        <!--This is an HTML comment-->\r\n" +
            "        Console.WriteLine(\"Final statement\");\r\n" +
            "    }\r\n" +
            "}";

        }

        private void LoadUserSettings()
        {
            string dataFolder = Path.Combine(appData, "Data");
            string userSettingsPath = Path.Combine(dataFolder, "user.xml");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            if (Directory.Exists(dataFolder))
            {
                if (File.Exists(userSettingsPath))
                {
                    var xml = XDocument.Load(userSettingsPath);
                    var settingsElement = xml.Element("Settings");

                    if (settingsElement != null)
                    {
                        var ultimoTemaElement = settingsElement.Element("UltimoTema");
                        var ultimoEstiloElement = settingsElement.Element("UltimoEstilo");

                        if (ultimoTemaElement != null && ultimoEstiloElement != null)
                        {
                            ultimoTema = ultimoTemaElement.Value;
                            ultimoEstilo = ultimoEstiloElement.Value;
                        }
                    }
                }
            }
        }

        private void SaveUserSettings()
        {
            string dataFolder = Path.Combine(appData, "Data");
            string userSettingsPath = Path.Combine(dataFolder, "user.xml");
            var xml = new XDocument();

            if (File.Exists(userSettingsPath))
            {
                xml = XDocument.Load(userSettingsPath);
            }
            else
            {
                xml.Add(new XElement("Settings"));
            }

            var settingsElement = xml.Element("Settings");

            if (settingsElement == null)
            {
                settingsElement = new XElement("Settings");
                xml.Add(settingsElement);
            }

            settingsElement.SetElementValue("UltimoTema", MetroTheme.ToString());
            settingsElement.SetElementValue("UltimoEstilo", MetroStyle.ToString());

            xml.Save(userSettingsPath);
        }

        public void Configs_ThemeChanged(object sender, EventArgs e)
        {
            MetroTheme = configs.SelectedTheme;
            UpdateTheme();
        }

        public void Configs_StyleChanged(object sender, EventArgs e)
        {
            MetroStyle = configs.SelectedStyle;
            UpdateTheme();
        }

        private void UpdateThisAppearence()
        {
            minWidth = ClientSize.Width; // Largura minima da janela
            minHeight = ClientSize.Height; // Altura minima da janela

            MetroThemeStyle temaConvertido;
            MetroColorStyle estiloConvertido;
            MetroTheme = Enum.TryParse(ultimoTema, out temaConvertido) ? temaConvertido : MetroThemeStyle.Dark;
            MetroStyle = Enum.TryParse(ultimoEstilo, out estiloConvertido) ? estiloConvertido : MetroColorStyle.Blue;
            UpdateTheme();

            cbLanguage.DataSource = supportedLanguages;
            cbLanguage.DisplayMember = "Name";
            cbLanguage.ValueMember = "Name";
            cbLanguage.SelectedIndex = 0;

            foreach (var option in commentTypes)
            {
                comboCheckBox3.AddItem(option.ToString(), true);
            }
            comboCheckBox3.UpdateText(" comments");

            UpdateTitle();
        }

        private void UpdateTheme()
        {
            HeaderBackColor = _isDarkMode ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
            ThemeBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(230, 230, 230);
            ThemeForeColor = _isDarkMode ? Color.FromArgb(230, 230, 230) : Color.FromArgb(17, 17, 17);
            //label1.ForeColor = ThemeForeColor;

            mStyleManager.Theme = MetroTheme;
            configs.MetroTheme = MetroTheme;
            windowBar1.MetroTheme = MetroTheme;
            toolBar1.MetroTheme = MetroTheme;
            comboCheckBox1.MetroTheme = MetroTheme;
            comboCheckBox2.MetroTheme = MetroTheme;
            comboCheckBox3.MetroTheme = MetroTheme;

            this.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            configs.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            sobre.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            dicas.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            windowBar1.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            toolBar1.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            comboCheckBox1.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            comboCheckBox2.DarkMode = (MetroTheme == MetroThemeStyle.Dark);
            comboCheckBox3.DarkMode = (MetroTheme == MetroThemeStyle.Dark);

            mStyleManager.Style = MetroStyle;
            configs.MetroStyle = MetroStyle;
            windowBar1.MetroStyle = MetroStyle;
            toolBar1.MetroStyle = MetroStyle;
            comboCheckBox1.MetroStyle = MetroStyle;
            comboCheckBox2.MetroStyle = MetroStyle;
            comboCheckBox3.MetroStyle = MetroStyle;
        }

        private void UpdateTitle()
        {
            string prev = isPremium ? "" : "(Preview)";
            this.Text = $"{NomeDoProjeto} {VersaoDoArquivo} {prev}";
            windowBar1.Title = $"{NomeDoProjeto} {VersaoDoArquivo} {prev}";

            windowBar1.Width = +1;
            windowBar1.Width = -1;
        }

        private void InitializeToolBar()
        {
            // Adicione botões à barra de ferramentas (use "-" como separador)
            toolBar1.AddButton("File", new List<string> { "Customize", "-", "Close" }, index =>
            {
                if (index == 0)
                {
                    configs.UpdateUserSettings(MetroTheme, MetroStyle);
                    configs.ShowDialog();
                }
                else if (index == 2) { Application.Exit(); }
            });
            toolBar1.AddButton("Help", new List<string> { "Tips", "-", "Website", "About" }, index =>
            {
                if (index == 0)
                {
                    dicas.UpdateUserSettings(MetroTheme, MetroStyle);
                    dicas.ShowDialog();
                }
                else if (index == 2)
                {
                    string url = "https://asxdrop.blogspot.com/p/asen-lab.html";
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                else if (index == 3)
                {
                    sobre.UpdateUserSettings(MetroTheme, MetroStyle);
                    sobre.ShowDialog();
                }
            });
            if (!isPremium)
            {
                toolBar1.AddButton("Buy on Store", null, index =>
                {
                    string url = "https://asxdrop.blogspot.com/p/asl-summarizer.html";
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                });
            }
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            MinimumSize = new Size(minWidth, minHeight);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            if (Width < minWidth) Width = minWidth;
            if (Height < minHeight) Height = minHeight;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Desabilitar redimensionamento estando maximizado
            this.Resizable = WindowState != FormWindowState.Maximized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserSettings();
        }

        private static string ObterVersaoDoArquivo()
        {
            FileVersionInfo versaoArquivo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            return versaoArquivo.FileVersion;
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLanguage = (Language)cbLanguage.SelectedItem;

            // Atualiza a cbProject com os projetos disponíveis da linguagem selecionada.
            if (selectedLanguage == null) return;
            cbProject.DataSource = selectedLanguage.Projects;
            cbProject.DisplayMember = "Name";
            cbProject.ValueMember = "Name";

            // Atualizar a comboCheckBox1 com as opções disponíveis da linguagem selecionada
            if (selectedLanguage.Projects == null) return;
            comboCheckBox1.ClearItems();
            comboCheckBox2.ClearItems();
            foreach (var option in selectedLanguage.Members)
            {
                comboCheckBox1.AddItem(option.ToString(), true);
            }
            foreach (var option in selectedLanguage.Details)
            {
                comboCheckBox2.AddItem(option.ToString(), true);
            }
            comboCheckBox1.UpdateText(" members");
            comboCheckBox2.UpdateText(" details");
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var selectedLanguage = (Language)cbLanguage.SelectedItem;
            selectedLanguage.SelectedProject = (Project)cbProject.SelectedItem;
            selectedLanguage.CheckedDetails = comboCheckBox2.GetCheckedItems();
            selectedLanguage.CheckedMembers = comboCheckBox1.GetCheckedItems();
            selectedLanguage.Script = txtScript.Text;
            selectedLanguage.Report = selectedLanguage.Analyze(selectedLanguage.SelectedProject.Name, selectedLanguage.CheckedDetails, selectedLanguage.CheckedMembers);
            var reportLines = selectedLanguage.Report.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            var reportLineCount = reportLines.Length;
            selectedLanguage.InitialInfo = selectedLanguage.GetInitialReportInfo(reportLineCount, selectedLanguage.SelectedProject.Name, selectedLanguage.CheckedDetails, selectedLanguage.CheckedMembers); ;

            var report = "";
            report += selectedLanguage.InitialInfo;
            report += selectedLanguage.Report;
            txtReport.Text = report;
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            AddNewTagPage();
        }

        private void windowBar1_Load(object sender, EventArgs e)
        {

        }

        private void btnDelTag_Click(object sender, EventArgs e)
        {
            if (TagsControl.TabCount > 1 && TagsControl.SelectedTab != null)
            {
                // Obtém o índice da página selecionada
                int selectedIndex = TagsControl.SelectedIndex;

                // Remove a página do controle de guias
                TagsControl.TabPages.Remove(TagsControl.SelectedTab);

                // Define a página selecionada para a página anterior (se existir)
                if (selectedIndex > 0)
                {
                    TagsControl.SelectedIndex = selectedIndex - 1; // voltar pra guia anterior
                }
            }
        }

        private void btnTrim_Click(object sender, EventArgs e)
        {
            // Obtém o texto da caixa de texto de entrada
            string inputText = txtTrimInput.Text;

            // Remove o texto das caixas de texto de tag das abas existentes
            foreach (TabPage tabPage in TagsControl.TabPages)
            {
                string tabPageName = tabPage.Name;
                int tabPageNumber = int.Parse(tabPageName.Replace("pgTag", ""));
                if (tabPage.Controls.ContainsKey("lytTag" + tabPageNumber))
                {
                    TableLayoutPanel tagPanel = (TableLayoutPanel)tabPage.Controls["lytTag" + tabPageNumber];
                    if (tagPanel.Controls.ContainsKey("txtTagFind" + tabPageNumber) && tagPanel.Controls.ContainsKey("txtTagReplace" + tabPageNumber))
                    {
                        MetroTextBox tagFindBox = (MetroTextBox)tagPanel.Controls["txtTagFind" + tabPageNumber];
                        MetroTextBox tagReplaceBox = (MetroTextBox)tagPanel.Controls["txtTagReplace" + tabPageNumber];
                        string tagFindText = tagFindBox.Text;
                        string tagReplaceText = tagReplaceBox.Text;
                        if (!string.IsNullOrEmpty(tagFindText))
                        {
                            inputText = inputText.Replace(tagFindText, tagReplaceText);
                        }
                    }
                }
            }

            // Define o texto resultante na caixa de texto de saída
            txtTrimOutput.Text = inputText;
        }
        private void btnNoteRemove_MouseDown(object sender, MouseEventArgs e)
        {
            // Obtém o texto da caixa de texto de entrada
            string inputText = txtNoteReInput.Text;

            // Obter os itens selecionados no comboCheckBox3
            List<string> selectedCommentTypes = comboCheckBox3.GetCheckedItems();

            // Inicializa o texto com o conteúdo original
            string resultText = inputText;

            // Se "Line Comment" foi selecionado, remove os comentários de linha
            if (selectedCommentTypes.Contains("Line Comment"))
            {
                resultText = Regex.Replace(resultText, @"^\s*//.*\n?", "", RegexOptions.Multiline);
            }

            // Se "Block Comment" foi selecionado, remove os comentários em bloco
            if (selectedCommentTypes.Contains("Block Comment"))
            {
                resultText = Regex.Replace(resultText, @"/\*.*?\*/", "", RegexOptions.Singleline);
            }

            // Se "HTML Comment" foi selecionado, remove os comentários HTML
            if (selectedCommentTypes.Contains("HTML Comment"))
            {
                resultText = Regex.Replace(resultText, @"<!--.*?-->", "", RegexOptions.Singleline);
            }

            // Remove linhas vazias consecutivas, deixando no máximo uma linha vazia entre as outras
            resultText = Regex.Replace(resultText, @"^\s*$\n?", "\r\n", RegexOptions.Multiline);

            // Define o texto resultante na caixa de texto de saída
            txtNoteReOutput.Text = resultText;
        }


        private async void btnCopy2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReport.Text))
            {
                Clipboard.SetText(txtReport.Text);
                btnCopy2.Text = "Copied!";
                txtReport.SelectAll();
                txtReport.Focus(); // Adiciona o foco na caixa de texto txtReport
                await Task.Delay(1000); // tempo
                btnCopy2.Text = "Copy";
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTrimOutput.Text))
            {
                Clipboard.SetText(txtTrimOutput.Text);
                btnCopy.Text = "Copied!";
                txtTrimOutput.SelectAll();
                txtTrimOutput.Focus(); // Adiciona o foco na caixa de texto txtTrimOutput
                await Task.Delay(1000); // tempo
                btnCopy.Text = "Copy";
            }
        }

        private async void btnNoteReCopy_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoteReOutput.Text))
            {
                Clipboard.SetText(txtNoteReOutput.Text);
                btnNoteReCopy.Text = "Copied!";
                txtNoteReOutput.SelectAll();
                txtNoteReOutput.Focus(); // Adiciona o foco na caixa de texto txtReport
                await Task.Delay(1000); // tempo
                btnNoteReCopy.Text = "Copy";
            }
        }

        private void AddNewTagPage()
        {
            // Obtém a lista de números de tags existentes
            List<int> existingTagNumbers = new List<int>();
            foreach (TabPage tabPage in TagsControl.TabPages)
            {
                string tagText = tabPage.Text;
                if (tagText.StartsWith("Tag "))
                {
                    int tagNumber;
                    if (int.TryParse(tagText.Substring(4), out tagNumber))
                    {
                        existingTagNumbers.Add(tagNumber);
                    }
                }
            }

            // Ordena a lista de números em ordem crescente
            existingTagNumbers.Sort();

            // Procura o primeiro número de tag disponível
            int newTagNumber = 1;
            foreach (int tagNumber in existingTagNumbers)
            {
                if (tagNumber == newTagNumber)
                {
                    // O número de tag já existe, incrementa o número
                    newTagNumber++;
                }
                else
                {
                    // O primeiro número de tag disponível foi encontrado
                    break;
                }
            }

            // Cria uma nova aba com o próximo número na sequência
            MetroTabPage newTabPage = new();
            newTabPage.Name = "pgTag" + newTagNumber;
            newTabPage.Text = "Tag " + newTagNumber;
            newTabPage.HorizontalScrollbarSize = 0;
            newTabPage.VerticalScrollbarSize = 0;
            newTabPage.StyleManager = mStyleManager;
            TagsControl.TabPages.Add(newTabPage);

            // cria um painel divido em dois na horizontal
            TableLayoutPanel newReplacePanel = new();
            newReplacePanel.Name = "lytTag" + newTagNumber;
            newReplacePanel.ColumnCount = 1;
            newReplacePanel.RowCount = 2;
            newReplacePanel.Dock = DockStyle.Fill;
            newReplacePanel.Margin = new Padding(0);
            newReplacePanel.BackColor = Color.Transparent;

            // Cria uma nova caixa de procura na nova aba
            MetroTextBox newFindBox = new MetroTextBox
            {
                Name = "txtTagFind" + newTagNumber,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 13),
                StyleManager = mStyleManager
            };

            // Cria uma nova caixa de substituicao na nova aba
            MetroTextBox newReplaceBox = new MetroTextBox
            {
                Name = "txtTagReplace" + newTagNumber,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Segoe UI", 13),
                StyleManager = mStyleManager
            };

            // Define o estilo da primeira linha com 50% da altura total do painel
            newReplacePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            // Adiciona um painel na primeira célula, que ocupará a primeira metade do painel
            newReplacePanel.Controls.Add(newFindBox, 0, 0);

            // Define o estilo da segunda linha com 50% da altura total do painel   
            newReplacePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            // Adiciona outro painel na segunda célula, que ocupará a segunda metade do painel
            newReplacePanel.Controls.Add(newReplaceBox, 0, 1);

            // Adiciona o TableLayoutPanel na sua aba ou controle desejado
            newTabPage.Controls.Add(newReplacePanel);

            TagsControl.SelectedIndex = TagsControl.TabCount - 1; // mostrar guia criada
        }
    }

    public class Language
    {
        public string Name { get; set; }
        public List<AvailableOption> AvailableOptions { get; set; }
        public List<Project> Projects { get; set; }
        public List<string> Details { get; set; }
        public List<string> Members { get; set; }
        public string Script { get; set; }
        public Project SelectedProject { get; set; }
        public List<string> CheckedDetails { get; set; }
        public List<string> CheckedMembers { get; set; }
        public string Report { get; set; }
        public string InitialInfo { get; set; }

        public Language(string name, List<AvailableOption> availableOptions)
        {
            Name = name;
            AvailableOptions = availableOptions ?? new List<AvailableOption>();
            Projects = new List<Project>();
            Details = new List<string>();
            Members = new List<string>();
        }

        public virtual string Analyze(string selectedProject, List<string> selectedDetails, List<string> selectedMembers)
        {
            // Implementação padrão da análise para cada linguagem
            return "";
        }

        public List<Project> GetProjects()
        {
            return Projects;
        }

        public List<string> GetDetails()
        {
            return Details;
        }

        public List<string> GetMembers()
        {
            return Members;
        }

        public virtual string GetInitialReportInfo(int linecount, string selectedProject, List<string> selectedDetails, List<string> selectedMembers)
        {
            var checkedDetails = CheckedDetails.Where(m => selectedDetails.Contains(m)).ToList();
            //var detailsText = string.Join(", ", selectedDetails);
            //var membersText = string.Join(", ", selectedMembers);
            var details = "";
            var ling = (checkedDetails.Contains("Language"));
            var proj = (checkedDetails.Contains("Project"));
            var hrdt = (checkedDetails.Contains("Hour/Date"));
            var linh = (checkedDetails.Contains("Lines"));
            var nope = string.IsNullOrEmpty;
            var line = Environment.NewLine;

            if (linh)
            {
                details += $"{"Lines"}: {linecount}";

                if (hrdt)
                {
                    details += $" | Hour: {DateTime.Now.ToString("HH:mm:ss")} | Date: {DateTime.Now.ToString("dd/MM/yyyy")}";
                }
            }
            else if (hrdt)
            {
                details += $"Hour: {DateTime.Now.ToString("HH:mm:ss")} | Date: {DateTime.Now.ToString("dd/MM/yyyy")}";
            }

            details += linh || hrdt ? $"{line}" : "";

            if (ling)
            {
                details += $"{"Language"}: {Name}";
                if (proj)
                {
                    details += $" | {"Project"}: {selectedProject}";
                }
            }
            else if (proj)
            {
                details += $"{"Project"}: {selectedProject}";
            }

            details += ling || proj ? $"{line}" : "";
            details += linh || hrdt || ling || proj ? $"{line}" : "";

            return details;
        }
    }

    public class AvailableOption
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public AvailableOption(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public AvailableOption() { }
    }

    public class Project
    {
        public string Name { get; set; }

        public Project(string name)
        {
            Name = name;
        }
    }

    public class CSharpLanguage : Language
    {
        public CSharpLanguage() : base("C#", new List<AvailableOption>())
        {
            Projects = new List<Project>() {
            new Project("Windows Forms"),
            new Project("WPF"),
            new Project("ASP.NET"),
            new Project("Unity"),
            new Project("Xamarin"),
            new Project("Outro")
        };
            Details = new List<string>() { "Hour/Date", "Lines", "Language", "Project", "Notes", "Libraries" };
            Members = new List<string>() { "Namespaces", "Classes", "Fields", "Properties", "Builder", "Methods" };
        }

        public override string Analyze(string selectedProject, List<string> selectedDetails, List<string> selectedMembers)
        {
            // Implementação da análise para C#
            var checkedDetails = CheckedDetails.Where(m => selectedDetails.Contains(m)).ToList();
            var checkedMembers = CheckedMembers.Where(m => selectedMembers.Contains(m)).ToList();
            var syntaxTree = CSharpSyntaxTree.ParseText(Script);
            var root = syntaxTree.GetCompilationUnitRoot();
            var namespaces = root.DescendantNodes().OfType<NamespaceDeclarationSyntax>();

            var report = "";

            if (checkedDetails.Contains("Libraries"))
            {
                foreach (var usingDirective in root.Usings)
                {
                    report += $"using {usingDirective.Name}{Environment.NewLine}";
                }
                report += $"{Environment.NewLine}";
            }

            if (checkedMembers.Contains("Namespaces"))
            {
                foreach (var ns in namespaces)
                {
                    var nsLine = ns.Name.ToFullString().Trim();
                    if (!string.IsNullOrWhiteSpace(nsLine))
                    {
                        report += $"Namespace: {nsLine}\r\n";

                        if (checkedMembers.Contains("Classes"))
                        {
                            GetClassesReport(ns, checkedDetails, checkedMembers, ref report);
                        }
                        else
                        {
                            GetMembersReport(ns, checkedDetails, checkedMembers, ref report);
                        }
                    }
                }
            }
            else if ((checkedMembers.Contains("Classes")) && !checkedMembers.Contains("Namespaces"))
            {
                GetClassesReport(root, checkedDetails, checkedMembers, ref report);
            }
            else if (!(checkedMembers.Contains("Classes")) && !checkedMembers.Contains("Namespaces"))
            {
                GetMembersReport(root, checkedDetails, checkedMembers, ref report);
            }
            return report.Trim();
        }

        public void GetClassesReport(SyntaxNode root, List<string> checkedDetails, List<string> checkedMembers, ref string report)
        {
            var syntaxTree = root?.SyntaxTree;

            if (root == null)
            {
                root = syntaxTree.GetCompilationUnitRoot();
            }

            var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
            foreach (var cls in classes)
            {
                var clsStart = cls.GetLocation().GetMappedLineSpan().StartLinePosition;
                var clsLine = cls.Identifier.ToFullString().Trim();
                if (!string.IsNullOrWhiteSpace(clsLine))
                {
                    report += $"Class: {clsLine}\r\n";

                    GetMembersReport(cls, checkedDetails, checkedMembers, ref report);
                }
            }
        }

        public void GetMembersReport(SyntaxNode root, List<string> checkedDetails, List<string> checkedMembers, ref string report)
        {
            var syntaxTree = root?.SyntaxTree;

            if (root == null)
            {
                root = syntaxTree.GetCompilationUnitRoot();
            }

            foreach (var member in checkedMembers)
            {
                switch (member)
                {
                    case "Fields":
                        GetDeclarations<FieldDeclarationSyntax>(root, ref report, "Field", checkedDetails);
                        break;
                    case "Properties":
                        GetDeclarations<PropertyDeclarationSyntax>(root, ref report, "Property", checkedDetails);
                        break;
                    case "Builder":
                        GetDeclarations<ConstructorDeclarationSyntax>(root, ref report, "Builder", checkedDetails);
                        break;
                    case "Methods":
                        GetDeclarations<MethodDeclarationSyntax>(root, ref report, "Method", checkedDetails);
                        break;
                    default:
                        break;
                }
            }

            report += Environment.NewLine;
        }

        private void GetDeclarations<TDeclaration>(SyntaxNode root, ref string report, string reportText, List<string> checkedDetails)
            where TDeclaration : SyntaxNode
        {
            var declarations = root.DescendantNodes().OfType<TDeclaration>();
            foreach (var declaration in declarations)
            {
                var leadingTrivia = declaration.GetLeadingTrivia();
                var comments = leadingTrivia.Where(t => t.IsKind(SyntaxKind.SingleLineCommentTrivia) || t.IsKind(SyntaxKind.MultiLineCommentTrivia))
                                            .Select(t => t.ToString().Trim()).ToList();

                var lines = declaration.ToFullString().Trim().Split('\n');
                var firstLine = lines.FirstOrDefault(line =>
                    !string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && !line.StartsWith("/"));
                if (firstLine != null)
                {
                    if (comments.Count > 0 && checkedDetails.Contains("Notes"))
                    {
                        foreach (var comment in comments)
                        {
                            report += $"{comment}\r\n";
                        }
                    }

                    report += $"{reportText}: {firstLine.Trim()}\r\n";
                }
            }
        }
    }

    public class JavaLanguage : Language
    {
        public JavaLanguage() : base("Java", new List<AvailableOption>())
        {
            Projects = new List<Project>() {
            new Project("Swing"),
            new Project("JavaFX"),
            new Project("Spring"),
            new Project("Android")
        };
            Details = new List<string>() { "Hour/Date", "Lines", "Language", "Project", "Notes", "Libraries" };
            Members = new List<string>() { "Fields", "Properties", "Builder", "Methods" };
        }

        public override string Analyze(string selectedProject, List<string> selectedDetails, List<string> selectedMembers)
        {
            // Implementação da análise para Java
            return "Relatório de análise para Java\r\nAinda não implementado.";
        }
    }
}
/*
public void GetMembersReport(SyntaxNode root, List<string> checkedDetails, List<string> checkedMembers, ref string report)
        {
            var syntaxTree = root?.SyntaxTree;

            if (root == null)
            {
                root = syntaxTree.GetCompilationUnitRoot();
            }

            if (checkedMembers.Contains("Fields"))
            {
                var fields = root.DescendantNodes().OfType<FieldDeclarationSyntax>();
                foreach (var field in fields)
                {
                    var lines = field.ToFullString().Trim().Split('\n');
                    var firstLine = lines.FirstOrDefault(line =>
                        !string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && !line.StartsWith("/"));
                    if (firstLine != null)
                    {
                        report += $"Campo: {firstLine.Trim()}\r\n";
                    }
                }
            }

            if (checkedMembers.Contains("Properties"))
            {
                var properties = root.DescendantNodes().OfType<PropertyDeclarationSyntax>();
                foreach (var prop in properties)
                {
                    var line = prop.ToString().Split('\r', '\n')[0].Trim();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        report += $"Propriedade: {line}\r\n";
                    }
                }
            }

            if (checkedMembers.Contains("Builder"))
            {
                var constructors = root.DescendantNodes().OfType<ConstructorDeclarationSyntax>();
                foreach (var ctor in constructors)
                {
                    var line = ctor.ToString().Split('\r', '\n')[0].Trim();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        report += $"Construtor: {line}\r\n";
                    }
                }
            }

            if (checkedMembers.Contains("Methods"))
            {
                var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
                foreach (var method in methods)
                {
                    var line = method.ToString().Split('\r', '\n')[0].Trim();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        report += $"Método: {line}\r\n";
                    }
                }
            }

            report += Environment.NewLine;
        }
    }
*/
