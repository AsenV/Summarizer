namespace Tielapse
{
    partial class ListViewSelector
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Item1");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Item2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Item3");
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.autoHeightListView1 = new Tielapse.AutoHeightListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.Color.PaleGreen;
            this.metroPanel1.Controls.Add(this.autoHeightListView1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = false;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(300, 300);
            this.metroPanel1.TabIndex = 11;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = false;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 15;
            // 
            // autoHeightListView1
            // 
            this.autoHeightListView1.AllowSorting = true;
            this.autoHeightListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.autoHeightListView1.CheckBoxes = true;
            this.autoHeightListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.autoHeightListView1.ColumnsNumbers = 5;
            this.autoHeightListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.autoHeightListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.autoHeightListView1.FullRowSelect = true;
            this.autoHeightListView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.autoHeightListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.autoHeightListView1.Location = new System.Drawing.Point(0, 0);
            this.autoHeightListView1.Margin = new System.Windows.Forms.Padding(0);
            this.autoHeightListView1.MinimumSize = new System.Drawing.Size(0, 50);
            this.autoHeightListView1.MultiSelect = false;
            this.autoHeightListView1.Name = "autoHeightListView1";
            this.autoHeightListView1.OwnerDraw = true;
            this.autoHeightListView1.Scrollable = false;
            this.autoHeightListView1.Size = new System.Drawing.Size(270, 100);
            this.autoHeightListView1.TabIndex = 10;
            this.autoHeightListView1.UseCompatibleStateImageBehavior = false;
            this.autoHeightListView1.UseSelectable = true;
            this.autoHeightListView1.View = System.Windows.Forms.View.Details;
            this.autoHeightListView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.autoHeightListView1_DrawColumnHeader);
            this.autoHeightListView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.autoHeightListView1_ItemCheck);
            this.autoHeightListView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.autoHeightListView1_ItemChecked);
            this.autoHeightListView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.autoHeightListView1_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 55;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 55;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 55;
            // 
            // mStyleManager
            // 
            this.mStyleManager.Owner = this;
            // 
            // ListViewSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.metroPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ListViewSelector";
            this.Size = new System.Drawing.Size(300, 300);
            this.Load += new System.EventHandler(this.ListViewSelector_Load);
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AutoHeightListView autoHeightListView1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private MetroFramework.Components.MetroStyleManager mStyleManager;
    }
}
