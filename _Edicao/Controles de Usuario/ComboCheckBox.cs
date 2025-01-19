using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Summarizer
{
    //Application.AddMessageFilter(new DropDownMessageFilter(comboCheckBox1)); // mousedown unfocus (put on form constructor)
    public partial class ComboCheckBox : UserControl
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private bool isFocused = false;
        private bool _isDropdownVisible = false;
        public bool IsDropdownVisible { get { return _isDropdownVisible; } set { _isDropdownVisible = value; } }
        private string _nome = ""; // campo para armazenar o nome
        private const int MaxItems = 20;

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

        //private Form parentForm;
        //public Form Owner { get { return _parentForm; } set { _parentForm = value; } }

        /*private ListViewItem[] _items;
        public ListViewItem[] Items
        {
            get { return _items; }
            set { _items = value; }
        }*/

        public ListViewItem[] Items
        {
            get { return dropDownBG_metroListView1.Items.Cast<ListViewItem>().ToArray(); }
            set
            {
                dropDownBG_metroListView1.Items.Clear();

                foreach (ListViewItem item in value)
                {
                    MetroCheckBox checkBox = new()
                    {
                        AutoSize = true,
                        Text = item.Text,
                        Checked = item.Checked
                    };

                    ListViewItem listViewItem = new(checkBox.Text)
                    {
                        Checked = checkBox.Checked,
                        Tag = checkBox
                    };

                    dropDownBG_metroListView1.Items.Add(listViewItem);
                }
            }
        }

        public List<string> GetCheckedItems()
        {
            List<string> checkedItems = new();

            foreach (ListViewItem item in dropDownBG_metroListView1.Items)
            {
                if (item.Checked)
                {
                    checkedItems.Add(item.Text);
                }
            }

            return checkedItems;
        }

        public void ClearItems()
        {
            dropDownBG_metroListView1.Items.Clear();
        }

        public void AddItem(string text, bool isChecked = false)
        {
            if (dropDownBG_metroListView1.Items.Count < MaxItems)
            {
                CheckListItem item = new(text, isChecked);
                dropDownBG_metroListView1.Items.Add(item.ToListViewItem());
            }
            else
            {
                MessageBox.Show("O limite máximo de itens foi atingido.");
            }
        }

        public void RemoveItem(string text)
        {
            foreach (ListViewItem item in dropDownBG_metroListView1.Items)
            {
                if (item.Text == text)
                {
                    dropDownBG_metroListView1.Items.Remove(item);
                    break;
                }
            }
        }

        public void RefreshItems()
        {
            foreach (ListViewItem item in dropDownBG_metroListView1.Items)
            {
                MetroCheckBox checkBox = (MetroCheckBox)item.Tag;
                checkBox.Checked = item.Checked && !checkBox.Checked ? true : false;
            }
        }

        public void UpdateText(string name)
        {
            int count = dropDownBG_metroListView1.CheckedItems.Count;
            int allitems = dropDownBG_metroListView1.Items.Count;
            button1.Text = count < 1 ? "None" : count == allitems ? "All" : count + name;
            _nome = name; // armazena o nome no campo
        }

        public ComboCheckBox()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void ComboCheckBox_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();
        }

        private void InitializeEvents()
        {
            buttonArrow_pictureBox1.Click += button1_Click;
        }

        private void ComboCheckBox_ParentChanged(object sender, EventArgs e)
        {
            //parentForm ??= this.ParentForm; // se parentform for null ele muda para this
        }

        private void ParentForm_MouseDown(object sender, EventArgs e)
        {
            SetDropdownVisibility(false);
        }

        private void UpdateThisAppearence()
        {
            HighlightButtonArrow(false);
            MetroTheme = _isDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light; //_metroTheme;
            MetroStyle = _metroStyle;
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            button1.ForeColor = _isDarkMode ? Color.FromArgb(170, 170, 170) : Color.FromArgb(17, 17, 17);
            if (_isDarkMode)
            {
                button1.BackColor = Color.FromArgb(17, 17, 17);
                buttonArrow_pictureBox1.BackColor = Color.FromArgb(17, 17, 17);
                dropDownBG_metroListView1.BackColor = Color.FromArgb(17, 17, 17);
                dropDownBG_metroListView1.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                button1.BackColor = Color.FromArgb(255, 255, 255);
                buttonArrow_pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
                dropDownBG_metroListView1.BackColor = Color.FromArgb(255, 255, 255);
                dropDownBG_metroListView1.ForeColor = Color.FromArgb(17, 17, 17);
            }
        }

        private void ComboCheckBox_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            HighlightButtonArrow(true);
        }

        private void ComboCheckBox_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            HighlightButtonArrow(false);
            if (_isDropdownVisible) SetDropdownVisibility(false);
        }

        private void ReleaseButtonTheme(string str1, string str2) // a pessoa envia as propriedades do botao que ela quer que atualize.
        {
            if (str1.Contains("MouseDown") || str2.Contains("MouseDown")) // a pessoa escolheu atualizar a cor de MouseDown
            {
                button1.FlatAppearance.MouseDownBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255); // se for tema escuro a cor será escura, se for claro, será clara.
            }
            if (str1.Contains("MouseOver") || str2.Contains("MouseOver"))  // a pessoa escolheu atualizar a cor de MouseOver
            {
                button1.FlatAppearance.MouseOverBackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255); // se for tema escuro a cor será escura, se for claro, será clara.
            }
        }

        private void HighlightButtonArrow(bool isHovering)
        {
            if (isHovering)
            {
                buttonArrow_pictureBox1.Image = _isDarkMode ? Properties.Resources.downarrow_nobg_dark_2 : Properties.Resources.downarrow_nobg_light_2;
            }
            else
            {
                buttonArrow_pictureBox1.Image = _isDarkMode ? Properties.Resources.downarrow_nobg_dark_1 : Properties.Resources.downarrow_nobg_light_1;
            }
            ReleaseButtonTheme("MouseDown", "MouseOver");
        }

        public void SetDropdownVisibility(bool isVisible)
        {
            _isDropdownVisible = isVisible;
            dropDown_panel1.Visible = isVisible;
            dropDownBG_metroListView1.Visible = isVisible;
            this.BorderStyle = isVisible ? BorderStyle.FixedSingle : BorderStyle.None;
            if (dropDownBG_metroListView1.Items.Count > 0)
            {
                if (isVisible)
                {

                    int totalHeight = dropDownBG_metroListView1.Items.Count * dropDownBG_metroListView1.Items[0].Bounds.Height + 2;
                    this.Height += totalHeight;
                }
                else
                {
                    int totalHeight = dropDownBG_metroListView1.Items.Count * dropDownBG_metroListView1.Items[0].Bounds.Height + 2;
                    this.Height -= totalHeight;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool toggle = _isDropdownVisible;
            SetDropdownVisibility(!toggle);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            HighlightButtonArrow(true);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (!isFocused) HighlightButtonArrow(false);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseButtonTheme("MouseDown", "MouseOver");
        }

        private void buttonArrow_pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            HighlightButtonArrow(true);
        }

        private void buttonArrow_pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!isFocused) HighlightButtonArrow(false);
        }

        private void dropDownBG_metroListView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!dropDownBG_metroListView1.Items[e.Index].Selected)
            {
                // ao clicar na checkbox, se o item não estiver selecionado, seleciona o item
                dropDownBG_metroListView1.SelectedIndices.Add(e.Index);
            }
        }

        private void dropDownBG_metroListView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = dropDownBG_metroListView1.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                Rectangle checkBoxRect = clickedItem.Bounds;
                checkBoxRect.Width = 20; // ajuste a largura da caixa de seleção conforme necessário

                if (!checkBoxRect.Contains(e.Location))
                {
                    // o usuario clicou fora da checkbox, mas na caixa do item.
                    clickedItem.Checked = !clickedItem.Checked;
                }
            }
        }

        private void dropDownBG_metroListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateText(_nome);
        }
    }

    [Serializable]
    public class CheckListItem
    {
        public string Text { get; set; }
        public bool Checked { get; set; }

        public CheckListItem(string text, bool isChecked = false)
        {
            Text = text;
            Checked = isChecked;
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(Text) { Checked = Checked };
        }

        public CheckListItem() { }
    }

    public class DropDownMessageFilter : IMessageFilter
    {
        private readonly ComboCheckBox comboCheckBox;

        public DropDownMessageFilter(ComboCheckBox comboCheckBox)
        {
            this.comboCheckBox = comboCheckBox;
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
                // Se o controle ComboCheckBox estiver visível e o clique não foi dentro dele, esconde-o
                if (comboCheckBox.IsDropdownVisible &&
                    !comboCheckBox.RectangleToScreen(comboCheckBox.ClientRectangle).Contains(Cursor.Position))
                {
                    comboCheckBox.SetDropdownVisibility(false);
                }
            }

            return false;
        }
    }
}