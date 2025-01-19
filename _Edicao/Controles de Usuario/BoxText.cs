using System;
using System.Windows.Forms;

namespace Tielapse._Edicao.Controles_de_Usuario
{
    public partial class BoxText : UserControl
    {
        public BoxText()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int lineHeight = richTextBox1.GetPositionFromCharIndex(richTextBox1.GetFirstCharIndexFromLine(1)).Y - richTextBox1.GetPositionFromCharIndex(0).Y;
            int lineCount = richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 3;
            int newHeight = lineCount * lineHeight;

            int minHeight = 31;
            if (newHeight < minHeight)
            {
                newHeight = minHeight;
            }

            //richTextBox1.Height = newHeight;
            this.Height = newHeight;

            // Role para a última linha (nova linha) para garantir que ela seja visível
            //richTextBox1.SelectionStart = richTextBox1.TextLength;
            //richTextBox1.ScrollToCaret();
        }


    }
}
