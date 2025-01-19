namespace Summarizer
{
    partial class ComboCheckBox
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
            this.button1 = new System.Windows.Forms.Button();
            this.dropDown_panel1 = new System.Windows.Forms.Panel();
            this.dropDownBG_metroListView1 = new MetroFramework.Controls.MetroListView();
            this.dropDownColumn_columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonArrowBG_panel2 = new System.Windows.Forms.Panel();
            this.buttonArrow_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.dropDown_panel1.SuspendLayout();
            this.buttonArrowBG_panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonArrow_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 29);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // dropDown_panel1
            // 
            this.dropDown_panel1.Controls.Add(this.dropDownBG_metroListView1);
            this.dropDown_panel1.Location = new System.Drawing.Point(0, 29);
            this.dropDown_panel1.Margin = new System.Windows.Forms.Padding(0);
            this.dropDown_panel1.Name = "dropDown_panel1";
            this.dropDown_panel1.Size = new System.Drawing.Size(146, 552);
            this.dropDown_panel1.TabIndex = 1;
            this.dropDown_panel1.Visible = false;
            // 
            // dropDownBG_metroListView1
            // 
            this.dropDownBG_metroListView1.BackColor = System.Drawing.Color.White;
            this.dropDownBG_metroListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dropDownBG_metroListView1.CheckBoxes = true;
            this.dropDownBG_metroListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dropDownColumn_columnHeader1});
            this.dropDownBG_metroListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropDownBG_metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dropDownBG_metroListView1.FullRowSelect = true;
            this.dropDownBG_metroListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dropDownBG_metroListView1.HideSelection = false;
            this.dropDownBG_metroListView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dropDownBG_metroListView1.Location = new System.Drawing.Point(0, 0);
            this.dropDownBG_metroListView1.MultiSelect = false;
            this.dropDownBG_metroListView1.Name = "dropDownBG_metroListView1";
            this.dropDownBG_metroListView1.OwnerDraw = true;
            this.dropDownBG_metroListView1.Scrollable = false;
            this.dropDownBG_metroListView1.Size = new System.Drawing.Size(146, 552);
            this.dropDownBG_metroListView1.TabIndex = 7;
            this.dropDownBG_metroListView1.UseCompatibleStateImageBehavior = false;
            this.dropDownBG_metroListView1.UseCustomBackColor = true;
            this.dropDownBG_metroListView1.UseCustomForeColor = true;
            this.dropDownBG_metroListView1.UseSelectable = true;
            this.dropDownBG_metroListView1.View = System.Windows.Forms.View.Details;
            this.dropDownBG_metroListView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.dropDownBG_metroListView1_ItemCheck);
            this.dropDownBG_metroListView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.dropDownBG_metroListView1_ItemChecked);
            this.dropDownBG_metroListView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dropDownBG_metroListView1_MouseDown);
            // 
            // dropDownColumn_columnHeader1
            // 
            this.dropDownColumn_columnHeader1.Text = "Coluna";
            this.dropDownColumn_columnHeader1.Width = 300;
            // 
            // buttonArrowBG_panel2
            // 
            this.buttonArrowBG_panel2.Controls.Add(this.buttonArrow_pictureBox1);
            this.buttonArrowBG_panel2.Location = new System.Drawing.Point(119, 3);
            this.buttonArrowBG_panel2.Name = "buttonArrowBG_panel2";
            this.buttonArrowBG_panel2.Size = new System.Drawing.Size(23, 23);
            this.buttonArrowBG_panel2.TabIndex = 8;
            // 
            // buttonArrow_pictureBox1
            // 
            this.buttonArrow_pictureBox1.BackColor = System.Drawing.Color.Blue;
            this.buttonArrow_pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonArrow_pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonArrow_pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.buttonArrow_pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonArrow_pictureBox1.Name = "buttonArrow_pictureBox1";
            this.buttonArrow_pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.buttonArrow_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.buttonArrow_pictureBox1.TabIndex = 7;
            this.buttonArrow_pictureBox1.TabStop = false;
            this.buttonArrow_pictureBox1.MouseEnter += new System.EventHandler(this.buttonArrow_pictureBox1_MouseEnter);
            this.buttonArrow_pictureBox1.MouseLeave += new System.EventHandler(this.buttonArrow_pictureBox1_MouseLeave);
            // 
            // mStyleManager
            // 
            this.mStyleManager.Owner = this;
            // 
            // ComboCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonArrowBG_panel2);
            this.Controls.Add(this.dropDown_panel1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ComboCheckBox";
            this.Size = new System.Drawing.Size(146, 30);
            this.Load += new System.EventHandler(this.ComboCheckBox_Load);
            this.Enter += new System.EventHandler(this.ComboCheckBox_Enter);
            this.Leave += new System.EventHandler(this.ComboCheckBox_Leave);
            this.ParentChanged += new System.EventHandler(this.ComboCheckBox_ParentChanged);
            this.dropDown_panel1.ResumeLayout(false);
            this.buttonArrowBG_panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonArrow_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel dropDown_panel1;
        private System.Windows.Forms.PictureBox buttonArrow_pictureBox1;
        private System.Windows.Forms.Panel buttonArrowBG_panel2;
        private MetroFramework.Controls.MetroListView dropDownBG_metroListView1;
        private System.Windows.Forms.ColumnHeader dropDownColumn_columnHeader1;
        private MetroFramework.Components.MetroStyleManager mStyleManager;
    }
}
