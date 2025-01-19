using System.Windows.Forms;

namespace Tielapse._Edicao.Controles_de_Usuario
{
    public partial class BoxAudio : UserControl
    {
        public BoxAudio()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "C:\\___tests\\MTG - MALDICAO ETERNA 1.0-iEmQ2uDxllo.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}
