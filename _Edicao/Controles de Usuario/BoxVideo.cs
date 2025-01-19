using System;
using System.Windows.Forms;

namespace Tielapse._Edicao.Controles_de_Usuario
{
    public partial class BoxVideo : UserControl
    {
        private int _maxHeight = 790;

        public BoxVideo()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "C:\\___tests\\Coronavirus Hazmat Suit Dancing Party Extended Edit.mp4";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void BoxVideo_SizeChanged(object sender, EventArgs e)
        {
            int novaLargura = this.Width;
            int novaAltura = (novaLargura * 240) / 426; // Proporção da altura em relação à largura original (426x240)

            // Define o novo tamanho do controle
            this.Size = novaAltura > _maxHeight ? this.Size : new System.Drawing.Size(novaLargura, novaAltura);
        }
    }
}
