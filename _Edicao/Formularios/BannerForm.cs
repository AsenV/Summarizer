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

namespace Tielapse
{
    public enum Position
    {
        None, // Valor "não válido"
        TopLeft,
        Top,
        TopRight,
        Left,
        Middle,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }


    public partial class BannerForm : MetroFramework.Forms.MetroForm
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private int minWidth, minHeight, maxWidth, maxHeight;
        private Color HeaderBackColor, ThemeBackColor, ThemeForeColor;

        private string caminhoArquivoAtual = null;
        public Position SelectedPosition { get; set; } = Position.Middle;
        public bool IsConfirmed { get; set; } = false; // Inicia como falso
        private CustomButton ultimoBotaoClicado;

        private string imagemEscolhida;
        private string jogoId;
        private int posicaoJogo;
        private Image imagemOriginal;
        private bool isSteam;
        private string caminhoImagem;

        // Mapeamento de jogos e seus respectivos IDs
        private Dictionary<string, string> jogosSteam = new Dictionary<string, string>
    {
        { "Counter-Strike 2", "730" },
        { "Dota 2", "570" },
        { "Team Fortress 2", "440" }
        // Adicione outros jogos e seus IDs conforme necessário
    };

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

        public BannerForm(string getCaminhoArquivoAtual, string getJogoID, int getPosicaoJogo, string getImagemSelecionada, bool getIsSteam)
        {
            InitializeComponent();
            InitializeEvents();
            
            caminhoArquivoAtual = getCaminhoArquivoAtual;
            jogoId = getJogoID;
            posicaoJogo = getPosicaoJogo;
            //imagemOriginal = Image.FromFile(getImagemSelecionada);
            isSteam = getIsSteam;

            // Diferenciar isSteam de Local
            btnUpdate.ButtonText = (isSteam) ? "OK" : "Select";
            lbInput.Text = (isSteam) ? "App ID:" : "Imagem:";
            txtInput.ReadOnly = (isSteam) ? false : true;
            lytInputs.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, (isSteam) ? 63 : 260);
            lytInputs.ColumnStyles[2] = new ColumnStyle(SizeType.Absolute, (isSteam) ? 40 : 60);

            if (isSteam && !string.IsNullOrEmpty(jogoId))
            {
                txtInput.Text = jogoId;
                caminhoImagem = BaixarImagemPorId();

                if (caminhoImagem != null)
                {
                    imagemOriginal = Image.FromFile(caminhoImagem);
                    picBanner.Image = imagemOriginal;
                    AtualizarImagemRecortada();
                }
            }
        }

        private void Banner_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();

            // Adiciona o evento MouseDown a cada botão
            btnTopLeft.MouseDown += Botao_MouseDown;
            btnTop.MouseDown += Botao_MouseDown;
            btnTopRight.MouseDown += Botao_MouseDown;
            btnLeft.MouseDown += Botao_MouseDown;
            btnMiddle.MouseDown += Botao_MouseDown;
            btnRight.MouseDown += Botao_MouseDown;
            btnBottomLeft.MouseDown += Botao_MouseDown;
            btnBottom.MouseDown += Botao_MouseDown;
            btnBottomRight.MouseDown += Botao_MouseDown;
        }

        private void InitializeEvents()
        {
            this.StyleManager = mStyleManager;
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

        private void Sobre_SizeChanged(object sender, EventArgs e)
        {
            // Desabilitar redimensionamento estando maximizado
            this.Resizable = false;// WindowState != FormWindowState.Maximized;
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

            windowBar1.DarkMode = _isDarkMode;
            lbInput.ForeColor = ThemeForeColor;
            picBanner.SizeMode = PictureBoxSizeMode.Zoom;

            ApplyButtomTheme(btnTopLeft, false);
            ApplyButtomTheme(btnTop, false);
            ApplyButtomTheme(btnTopRight, false);
            ApplyButtomTheme(btnLeft, false);
            ApplyButtomTheme(btnMiddle, false);
            ApplyButtomTheme(btnRight, false);
            ApplyButtomTheme(btnBottomLeft, false);
            ApplyButtomTheme(btnBottom, false);
            ApplyButtomTheme(btnBottomRight, false);
            ApplyButtomTheme(btnConfirm, true);
            ApplyButtomTheme(btnUpdate, true);
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

        private void Botao_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is CustomButton button)
            {
                // Define a posição com base no botão clicado
                switch (button.Name)
                {
                    case "btnTopLeft":
                        SelectedPosition = Position.TopLeft;
                        break;
                    case "btnTop":
                        SelectedPosition = Position.Top;
                        break;
                    case "btnTopRight":
                        SelectedPosition = Position.TopRight;
                        break;
                    case "btnLeft":
                        SelectedPosition = Position.Left;
                        break;
                    case "btnMiddle":
                        SelectedPosition = Position.Middle;
                        break;
                    case "btnRight":
                        SelectedPosition = Position.Right;
                        break;
                    case "btnBottomLeft":
                        SelectedPosition = Position.BottomLeft;
                        break;
                    case "btnBottom":
                        SelectedPosition = Position.Bottom;
                        break;
                    case "btnBottomRight":
                        SelectedPosition = Position.BottomRight;
                        break;
                }
                DestacarBotao(button);
                AtualizarImagemRecortada();
            }
        }

        private void DestacarBotao(CustomButton button)
        {
            // Restaura a cor do último botão clicado, se houver
            if (ultimoBotaoClicado != null && ultimoBotaoClicado != button)
            {
                ultimoBotaoClicado.ButtonForeColor = ThemeForeColor;
                ultimoBotaoClicado.ButtonBorderColor = ThemeForeColor;
            }

            // Define a cor do botão atual
            button.ButtonForeColor = Color.OrangeRed;
            button.ButtonBorderColor = Color.OrangeRed;

            // Atualiza o último botão clicado para o botão atual
            ultimoBotaoClicado = button;
        }

        private void AtualizarImagemRecortada()
        {
            if ((SelectedPosition != Position.None) && imagemOriginal != null)
            {
                Image imagemRecortada = RedimensionarECortarImagem(imagemOriginal, 420, 170, SelectedPosition);
                picBanner.Image = imagemRecortada;
            }
        }

        private void btnUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            if (isSteam)
            {
                try
                {
                    if (picBanner.Image != null)
                    {
                        picBanner.Image.Dispose();
                        picBanner.Image = null;
                    }
                    if (imagemOriginal != null)
                    {
                        imagemOriginal.Dispose();
                    }

                    // Verifica se o ID inserido não é nulo ou vazio
                    if (string.IsNullOrEmpty(txtInput.Text))
                    {
                        MessageBox.Show("Por favor, insira um ID válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    jogoId = txtInput.Text; // Obtém o ID inserido no txtInput

                    // Baixa a imagem do jogo correspondente ao ID
                    caminhoImagem = BaixarImagemPorId();

                    if (!string.IsNullOrEmpty(caminhoImagem))
                    {
                        // Exibe a imagem no picBanner
                        imagemOriginal = Image.FromFile(caminhoImagem);
                        picBanner.Image = imagemOriginal;
                        AtualizarImagemRecortada();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (picBanner.Image != null)
                    {
                        picBanner.Image.Dispose();
                        picBanner.Image = null;
                    }
                    if (imagemOriginal != null)
                    {
                        imagemOriginal.Dispose();
                    }

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp"; // Filtra os tipos de arquivos de imagem
                    openFileDialog.Title = "Escolha uma imagem";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imagemEscolhida = openFileDialog.FileName;
                        caminhoImagem = SalvarImagemSelecionada();

                        if (!string.IsNullOrEmpty(caminhoImagem))
                        {
                            imagemOriginal = Image.FromFile(caminhoImagem);
                            picBanner.Image = imagemOriginal; // Exibe a imagem no PictureBox
                            txtInput.Text = imagemEscolhida;   
                            AtualizarImagemRecortada();                             
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string BaixarImagemPorId()
        {
            try
            {
                // URL de exemplo para baixar a imagem do Steam
                string urlImagem = $"https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/{jogoId}/library_hero.jpg";
                string caminhoBanners = Path.Combine(caminhoArquivoAtual, "@Resources", "User", "Banners");
                string caminhoTemp = Path.Combine(caminhoBanners, "@Temp");

                if (File.Exists(caminhoImagem))
                {
                    File.Delete(caminhoImagem);
                }
                if (Directory.Exists(caminhoTemp))
                {
                    Directory.Delete(caminhoTemp, true);
                }

                if (!Directory.Exists(caminhoTemp))
                {
                    Directory.CreateDirectory(caminhoTemp);
                }

                caminhoImagem = Path.Combine(caminhoTemp, $"{jogoId}_temp.jpg");

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(urlImagem, caminhoImagem); // Baixa a imagem
                }

                return caminhoImagem; // Retorna o caminho da imagem baixada
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao baixar a imagem do jogo {jogoId}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private string SalvarImagemSelecionada()
        {
            try
            {
                string caminhoBanners = Path.Combine(caminhoArquivoAtual, "@Resources", "User", "Banners");
                string caminhoTemp = Path.Combine(caminhoBanners, "@Temp");

                if (File.Exists(caminhoImagem))
                {
                    File.Delete(caminhoImagem);
                }
                if (Directory.Exists(caminhoTemp))
                {
                    Directory.Delete(caminhoTemp, true);
                }

                if (!Directory.Exists(caminhoTemp))
                {
                    Directory.CreateDirectory(caminhoTemp);
                }

                caminhoImagem = Path.Combine(caminhoTemp, $"@{Path.GetFileNameWithoutExtension(imagemEscolhida)}_temp.jpg");

                // Copia a imagem selecionada para o diretório de banners
                File.Copy(imagemEscolhida, caminhoImagem, true);  // 'true' sobrescreve se o arquivo já existir

                return caminhoImagem;  // Retorna o caminho da imagem salva
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar a imagem selecionada: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnConfirm_MouseDown(object sender, MouseEventArgs e)
        {
            string caminhoBanners = Path.Combine(caminhoArquivoAtual, "@Resources", "User", "Banners");
            string caminhoTemp = Path.Combine(caminhoBanners, "@Temp");
            string caminhoSalvarImagem = Path.Combine(caminhoArquivoAtual, "@Resources", "User", "Banners");
            try
            {
                // Verifica se uma posição válida foi selecionada
                if (imagemOriginal == null)
                {
                    return;
                }
                if (picBanner.Image != null)
                {
                    picBanner.Image.Dispose();
                    picBanner.Image = null;
                }

                // Redimensiona e recorta a imagem com base na posição escolhida
                Image imagemRedimensionada = RedimensionarECortarImagem(imagemOriginal, 420, 170, SelectedPosition);

                if (imagemOriginal != null)
                {
                    imagemOriginal.Dispose();
                }
                // Gera o nome do arquivo com base no número do jogo na lista (exemplo: banner1.jpg)
                string caminhoImagemFinal = Path.Combine(caminhoBanners, $"banner{posicaoJogo}.jpg");

                if (File.Exists(caminhoImagemFinal))
                {
                    File.Delete(caminhoImagemFinal);
                }
                // Salva a imagem final com o nome baseado no número
                imagemRedimensionada.Save(caminhoImagemFinal, ImageFormat.Jpeg);
                imagemRedimensionada.Dispose();

                // Confirma a operação
                IsConfirmed = true;
                if (imagemOriginal != null)
                {
                    imagemOriginal.Dispose();
                }
                if (File.Exists(caminhoImagem))
                {
                    File.Delete(caminhoImagem);
                }
                if (Directory.Exists(caminhoTemp))
                {
                    Directory.Delete(caminhoTemp, true);
                }
                MessageBox.Show($"O banner foi atualizado com sucesso!",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                if (picBanner.Image != null)
                {
                    picBanner.Image.Dispose();
                    picBanner.Image = null;
                }
                if (imagemOriginal != null)
                {
                    imagemOriginal.Dispose();
                }
                if (File.Exists(caminhoImagem))
                {
                    File.Delete(caminhoImagem);
                }
                if (Directory.Exists(caminhoTemp))
                {
                    Directory.Delete(caminhoTemp, true);
                }
                MessageBox.Show($"Erro ao confirmar a atualização: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BannerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string caminhoBanners = Path.Combine(caminhoArquivoAtual, "@Resources", "User", "Banners");
            string caminhoTemp = Path.Combine(caminhoBanners, "@Temp");

            if (!IsConfirmed)
            {
                if (imagemOriginal != null)
                {
                    imagemOriginal.Dispose();
                }
                if (File.Exists(caminhoImagem))
                {
                    File.Delete(caminhoImagem);
                }
                if (Directory.Exists(caminhoTemp))
                {
                    Directory.Delete(caminhoTemp, true);
                }
            }
        }

        private Image RedimensionarECortarImagem(Image imagemOriginal, int larguraFinal, int alturaFinal, Position posicao)
        {
            // Calcula a proporção necessária para atingir as dimensões mínimas
            float proporcaoLargura = (float)larguraFinal / imagemOriginal.Width;
            float proporcaoAltura = (float)alturaFinal / imagemOriginal.Height;
            float proporcao = Math.Max(proporcaoLargura, proporcaoAltura);

            // Calcula as novas dimensões mantendo a proporção original
            int novaLargura = (int)(imagemOriginal.Width * proporcao);
            int novaAltura = (int)(imagemOriginal.Height * proporcao);

            // Redimensiona a imagem para garantir que ambas as dimensões sejam maiores que o tamanho final
            Bitmap imagemRedimensionada = new Bitmap(novaLargura, novaAltura);
            imagemRedimensionada.SetResolution(imagemOriginal.HorizontalResolution, imagemOriginal.VerticalResolution);

            using (Graphics g = Graphics.FromImage(imagemRedimensionada))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // Desenha a imagem redimensionada no novo bitmap
                g.DrawImage(imagemOriginal, 0, 0, novaLargura, novaAltura);
            }

            // Calcula as coordenadas para o corte baseado na posição
            int posX = 0, posY = 0;

            // Ajuste do corte conforme a posição selecionada
            switch (posicao)
            {
                case Position.TopLeft:
                    posX = 0;
                    posY = 0;
                    break;
                case Position.Top:
                    posX = (novaLargura - larguraFinal) / 2;
                    posY = 0;
                    break;
                case Position.TopRight:
                    posX = novaLargura - larguraFinal;
                    posY = 0;
                    break;
                case Position.Left:
                    posX = 0;
                    posY = (novaAltura - alturaFinal) / 2;
                    break;
                case Position.Middle:
                    posX = (novaLargura - larguraFinal) / 2;
                    posY = (novaAltura - alturaFinal) / 2;
                    break;
                case Position.Right:
                    posX = novaLargura - larguraFinal;
                    posY = (novaAltura - alturaFinal) / 2;
                    break;
                case Position.BottomLeft:
                    posX = 0;
                    posY = novaAltura - alturaFinal;
                    break;
                case Position.Bottom:
                    posX = (novaLargura - larguraFinal) / 2;
                    posY = novaAltura - alturaFinal;
                    break;
                case Position.BottomRight:
                    posX = novaLargura - larguraFinal;
                    posY = novaAltura - alturaFinal;
                    break;
            }

            // Cria a imagem final com as dimensões exatas
            Bitmap imagemFinal = new Bitmap(larguraFinal, alturaFinal);
            imagemFinal.SetResolution(imagemOriginal.HorizontalResolution, imagemOriginal.VerticalResolution);

            using (Graphics g = Graphics.FromImage(imagemFinal))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;

                // Desenha a área recortada da imagem redimensionada no bitmap final
                g.DrawImage(imagemRedimensionada, new Rectangle(0, 0, larguraFinal, alturaFinal),
                            new Rectangle(posX, posY, larguraFinal, alturaFinal), GraphicsUnit.Pixel);
            }

            imagemRedimensionada.Dispose(); // Libera a imagem redimensionada temporária da memória
            return imagemFinal;
        }
    }
}
