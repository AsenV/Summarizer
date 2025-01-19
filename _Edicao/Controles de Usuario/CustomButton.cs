using System;
using System.Drawing;
using System.Windows.Forms;

namespace Summarizer
{
    public partial class CustomButton : UserControl
    {
        private Color buttonBackColor;
        private Color buttonForeColor;
        private Color buttonBorderColor;

        public bool ButtonHighlight { get; set; }
        public bool ButtonBorderClickable { get; set; }

        public string ButtonText
        { get { return buttonLabel.Text; } set { buttonLabel.Text = value; } }
        public Font ButtonFont
        { get { return buttonLabel.Font; } set { buttonLabel.Font = value; } }
        public ContentAlignment ButtonTextAlign
        { get { return buttonLabel.TextAlign; } set { buttonLabel.TextAlign = value; } }
        public Color ButtonBackColor
        { get { return buttonLabel.BackColor; } set { buttonLabel.BackColor = value; } }
        public Color ButtonForeColor
        { get { return buttonLabel.ForeColor; } set { buttonLabel.ForeColor = value; } }

        public Color ButtonHighlightBackColor { get; set; }
        public Color ButtonHighlightForeColor { get; set; }

        public Image ButtonBackgroundImage
        { get { return buttonLabel.BackgroundImage; } set { buttonLabel.BackgroundImage = value; } }
        public ImageLayout ButtonBackgroundImageLayout
        { get { return buttonLabel.BackgroundImageLayout; } set { buttonLabel.BackgroundImageLayout = value; } }

        public Padding ButtonBorderWidth
        { get { return buttonBorder.Padding; } set { buttonBorder.Padding = value; } }
        public Color ButtonBorderColor
        { get { return buttonBorder.BackColor; } set { buttonBorder.BackColor = value; } }
        public Color ButtonBorderHighlightColor { get; set; }

        public CustomButton()
        {
            InitializeComponent();
            InitializeEvents();
            StandardProperties();
        }

        private void InitializeEvents()
        {
            buttonLabel.Click += (sender, e) => OnClick(e);
            buttonLabel.DoubleClick += (sender, e) => OnDoubleClick(e);
            buttonLabel.MouseDown += (sender, e) => OnMouseDown(e);
            buttonLabel.MouseUp += (sender, e) => OnMouseUp(e);
            buttonLabel.MouseEnter += (sender, e) =>
            {
                mouseEnterHighlight();
                OnMouseEnter(e);
            };
            buttonLabel.MouseLeave += (sender, e) =>
            {
                mouseLeaveHighlight();
                OnMouseLeave(e);
            };
            if (ButtonBorderClickable)
            {
                buttonBorder.Click += (sender, e) => OnClick(e);
                buttonBorder.DoubleClick += (sender, e) => OnDoubleClick(e);
                buttonBorder.MouseDown += (sender, e) => OnMouseDown(e);
                buttonBorder.MouseUp += (sender, e) => OnMouseUp(e);
                buttonBorder.MouseEnter += (sender, e) =>
                {
                    mouseEnterHighlight();
                    OnMouseEnter(e);
                };
                buttonBorder.MouseLeave += (sender, e) =>
                {
                    mouseLeaveHighlight();
                    OnMouseLeave(e);
                };
            }
        }

        private void StandardProperties()
        {
            buttonLabel.Text = "CustomButton";
            buttonLabel.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
            buttonLabel.TextAlign = ContentAlignment.MiddleCenter;
            buttonLabel.BackColor = Color.White;
            buttonLabel.ForeColor = Color.Black;
            buttonLabel.BackgroundImageLayout = ImageLayout.Zoom;

            buttonBorder.Padding = new Padding(1, 1, 1, 1);
            buttonBorder.BackColor = Color.Black;
        }

        private void mouseEnterHighlight()
        {
            if (ButtonHighlight)
            {
                buttonBackColor = ButtonBackColor;
                buttonForeColor = ButtonForeColor;
                buttonBorderColor = ButtonBorderColor;
                buttonLabel.BackColor = ButtonHighlightBackColor;
                buttonLabel.ForeColor = ButtonHighlightForeColor;
                buttonBorder.BackColor = ButtonBorderHighlightColor;
            }
        }

        private void mouseLeaveHighlight()
        {
            if (ButtonHighlight)
            {
                buttonLabel.BackColor = buttonBackColor;
                buttonLabel.ForeColor = buttonForeColor;
                buttonBorder.BackColor = buttonBorderColor;
            }
        }

        public void PerformClick()
        {
            OnClick(EventArgs.Empty);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

    }
}
