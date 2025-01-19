using System;
using System.Windows.Forms;

namespace Tielapse._Edicao.Controles_de_Usuario
{
    public partial class BoxImage : UserControl
    {
        private int _maxHeight = 790;

        public BoxImage()
        {
            InitializeComponent();
        }

        private void BoxImage_Load(object sender, EventArgs e)
        {
        }

        private void BoxImage_SizeChanged(object sender, EventArgs e)
        {
            FixSize();
        }

        private void BoxImage_Layout(object sender, LayoutEventArgs e)
        {
            FixSize();
        }

        private void FixSize()
        {
            if (pictureBox1.Image != null)
            {
                double zoomRatio = (double)pictureBox1.Width / pictureBox1.Image.Width;
                int newHeight = (int)(pictureBox1.Image.Height * zoomRatio);
                this.Height = newHeight > _maxHeight ? _maxHeight : newHeight;// + 31;
            }

        }
    }
}