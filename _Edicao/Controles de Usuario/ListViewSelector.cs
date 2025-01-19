using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Tielapse
{
    public partial class ListViewSelector : UserControl
    {
        //private readonly bool _isDarkMode = DarkModeHelper.IsDarkModeEnabled();
        private bool firstClick = false;

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

        public int ColumnsNumbers
        {
            get { return autoHeightListView1.ColumnsNumbers; }
            set { autoHeightListView1.ColumnsNumbers = value; }
        }

        public string[] ColumnsText
        {
            get
            {
                List<string> columnsText = new List<string>();
                foreach (ColumnHeader column in autoHeightListView1.Columns)
                {
                    columnsText.Add(column.Text);
                }
                return columnsText.ToArray();
            }
            set
            {
                int columnIndex = 0;
                foreach (string columnText in value)
                {
                    autoHeightListView1.Columns[columnIndex].Text = columnText;
                    columnIndex++;
                }
            }
        }

        /*public string[] GroupsText
        {
            get
            {
                List<string> groupsText = new List<string>();
                foreach (ListViewGroup group in autoHeightListView1.Groups)
                {
                    groupsText.Add(group.Header);
                }
                return groupsText.ToArray();
            }
            set
            {
                int groupIndex = 0;
                foreach (string groupText in value)
                {
                    autoHeightListView1.Groups[groupIndex].Header = groupText;
                    groupIndex++;
                }
            }
        }*/

        public ListViewItem[] Items
        {
            get { return autoHeightListView1.Items.Cast<ListViewItem>().ToArray(); }
            set
            {
                autoHeightListView1.Items.Clear();

                foreach (ListViewItem item in value)
                {
                    MetroCheckBox checkBox = new();
                    checkBox.AutoSize = true;
                    checkBox.Text = item.Text == "" ? "Item" : item.Text;
                    checkBox.Checked = item.Checked;

                    ListViewItem listViewItem = new(checkBox.Text);
                    listViewItem.Checked = checkBox.Checked;
                    listViewItem.Tag = checkBox;

                    // adiciona subitens ao ListViewItem existente
                    for (int i = 0; i < (autoHeightListView1.Columns.Count == 0 ? 4 : autoHeightListView1.Columns.Count); i++)
                    {
                        listViewItem.SubItems.Add("");
                    }
                    if (item.SubItems.Count > 1) listViewItem.SubItems[1].Text = item.SubItems[1].Text;
                    if (item.SubItems.Count > 2) listViewItem.SubItems[2].Text = item.SubItems[2].Text;
                    if (item.SubItems.Count > 3) listViewItem.SubItems[3].Text = item.SubItems[3].Text;
                    if (item.SubItems.Count > 4) listViewItem.SubItems[4].Text = item.SubItems[4].Text;

                    autoHeightListView1.Items.Add(listViewItem);
                }

                autoHeightListView1.UpdateHeight();
            }
        }

        public void AddItem(string text, bool isChecked = false, string subItemText1 = "", string subItemText2 = "", string subItemText3 = "", string subItemText4 = "")
        {
            CustomCheckListItem item = new CustomCheckListItem(text, isChecked, autoHeightListView1.Columns.Count, subItemText1, subItemText2, subItemText3, subItemText4);
            autoHeightListView1.Items.Add(item);
            autoHeightListView1.UpdateHeight();
        }

        public void RemoveItem(string text)
        {
            foreach (ListViewItem item in autoHeightListView1.Items)
            {
                if (item.Text == text)
                {
                    autoHeightListView1.Items.Remove(item);
                    autoHeightListView1.UpdateHeight();
                    break;
                }
            }
        }

        public List<string> GetCheckedItems()
        {
            List<string> checkedItems = new();

            foreach (ListViewItem item in autoHeightListView1.Items)
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
            autoHeightListView1.Items.Clear();
        }

        public void RefreshItems()
        {
            foreach (ListViewItem item in autoHeightListView1.Items)
            {
                MetroCheckBox checkBox = (MetroCheckBox)item.Tag;
                checkBox.Checked = item.Checked && !checkBox.Checked ? true : false;
            }
        }

        public ListViewSelector()
        {
            InitializeComponent();
            autoHeightListView1.MouseWheel += autoHeightListView1_MouseWheel;
        }

        private void ListViewSelector_Load(object sender, EventArgs e)
        {
            UpdateThisAppearence();
        }

        private void UpdateThisAppearence()
        {
            MetroTheme = _isDarkMode ? MetroThemeStyle.Dark : MetroThemeStyle.Light; //_metroTheme;
            MetroStyle = _metroStyle;
            UpdateTheme();
        }

        private void UpdateTheme()
        {
            autoHeightListView1.BackColor = _isDarkMode ? Color.FromArgb(17, 17, 17) : Color.FromArgb(255, 255, 255);
            autoHeightListView1.ForeColor = _isDarkMode ? Color.FromArgb(255, 255, 255) : Color.FromArgb(17, 17, 17);
            metroPanel1.BackColor = autoHeightListView1.BackColor;
        }

        private void autoHeightListView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (firstClick)
            {
                if (!autoHeightListView1.Items[e.Index].Selected)
                {
                    // ao clicar na checkbox, se o item não estiver selecionado, seleciona o item
                    autoHeightListView1.SelectedIndices.Add(e.Index);
                    firstClick = true;
                }
            }
        }

        private void autoHeightListView1_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = autoHeightListView1.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                Rectangle checkBoxRect = clickedItem.Bounds;
                checkBoxRect.Width = 20; // ajuste a largura da caixa de seleção conforme necessário

                // o usuario clicou fora da checkbox, mas na caixa do item.
                if (!checkBoxRect.Contains(e.Location))
                {
                    clickedItem.Checked = clickedItem.Checked ? false : true;
                    firstClick = true;
                }
            }
        }

        public void autoHeightListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //atualizar texto depois que estado de marcacao foi alterado
        }

        private void autoHeightListView1_MouseWheel(object sender, MouseEventArgs e)
        {
            var listView = sender as AutoHeightListView;
            if (listView == null) return;

            if (e.Delta > 0)
            {
                int newIndex = Math.Max(listView.TopItem.Index - 1, 0);
                listView.TopItem = listView.Items[newIndex];
                listView.EnsureVisible(listView.TopItem.Index);
            }
            else
            {
                int newIndex = Math.Min(listView.TopItem.Index + 1, listView.Items.Count - 1);
                listView.TopItem = listView.Items[newIndex];
                listView.EnsureVisible(listView.TopItem.Index);
            }

            var childControl = listView.GetChildAtPoint(listView.PointToClient(Cursor.Position)) ?? listView;

            if (childControl is AutoHeightListView)
            {
                if (childControl.Parent is MetroPanel panel)
                {
                    panel.GetType().GetMethod("OnMouseWheel", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(panel, new object[] { e });
                }
            }
        }

        private void autoHeightListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Color grayishBlack = Color.FromArgb(17, 17, 17);
            Color grayishWhite = Color.FromArgb(230, 230, 230);
            Font headerFont = new Font("Segoe UI", 8); // Criando a fonte personalizada
            if (_isDarkMode)
            {
                e.Graphics.FillRectangle(new SolidBrush(grayishBlack), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, grayishWhite, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(grayishWhite), e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, headerFont, e.Bounds, grayishBlack, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
            }
        }
    }

    public class AutoHeightListView : MetroListView
    {
        // TODO: fazer com que cada item criado já tenha X subitems criados junto, sendo X equivalente a ColumnsNumbers.
        private readonly int vsBarWidth = 30;

        private int columnsNumbers = 0;

        public int ColumnsNumbers
        {
            get { return columnsNumbers; }
            set
            {
                columnsNumbers = value;
                UpdateColumnsWidth();
            }
        }

        public AutoHeightListView()
        {
            DoubleBuffered = true;
            MinimumSize = new Size(0, 25);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateHeight();
        }

        public void UpdateItems()
        {
            base.Update();
            UpdateHeight();
        }

        public void UpdateHeight()
        {
            int itemHeight = this.Font.Height + 3;
            int totalHeight = this.Items.Count * itemHeight;

            if (this.Columns.Count > 0)
            {
                totalHeight += 25;
            }

            foreach (ListViewGroup group in this.Groups)
            {
                totalHeight += 25;
            }

            this.Height = this.Items.Count == 0 ? 25 : totalHeight;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateWidth();
            UpdateColumnsWidth();
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            base.OnColumnWidthChanging(e);
            e.Cancel = true;
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            UpdateColumnsWidth();
        }

        private void UpdateWidth()
        {
            if (this.Parent is MetroPanel parentPanel)
            {
                int clientRightWidth = parentPanel.ClientSize.Width - (this.Left + parentPanel.Padding.Right);
                this.Width = clientRightWidth - vsBarWidth;
            }
        }

        private void UpdateColumnsWidth()
        {
            if (columnsNumbers == 0) return;
            int totalWidth = this.Width + 5;
            int columnWidth = totalWidth / columnsNumbers;
            foreach (ColumnHeader column in this.Columns)
            {
                if (column.Width < columnWidth || column.Width > columnWidth)
                {
                    column.Width = columnWidth;
                }
            }
        }
    }
    public class CustomCheckListItem : ListViewItem
    {
        public CustomCheckListItem(string text, bool isChecked = false, int columnCount = 0, params string[] subItemTexts) : base(text)
        {
            Checked = isChecked;
            Tag = new MetroCheckBox()
            {
                AutoSize = true,
                Text = text == "" ? "Item" : text,
                Checked = isChecked
            };

            for (int i = 0; i < subItemTexts.Length; i++)
            {
                SubItems.Add(new ListViewSubItem(this, subItemTexts[i]));
            }

            int remainingSubItems = columnCount > 0 ? columnCount - subItemTexts.Length : 4;
            for (int i = 0; i < remainingSubItems; i++)
            {
                SubItems.Add(new ListViewSubItem(this, ""));
            }
        }

        public ListViewItem ToListViewItem()
        {
            return this;
        }
    }

}