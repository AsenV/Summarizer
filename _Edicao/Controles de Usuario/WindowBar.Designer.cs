namespace Summarizer
{
    partial class WindowBar
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;
        
        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_parentForm != null)
                {
                    _parentForm.Activated -= ParentForm_Activated;
                    _parentForm.SizeChanged -= ParentForm_SizeChanged;
                    _parentForm.FormClosing -= ParentForm_Closing;
                    _parentForm.Deactivate -= ParentForm_Deactivated;
                    _parentForm = null;
                }
            }

            base.Dispose(disposing);
        }
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.windowOpacity = new System.Windows.Forms.Timer(this.components);
            this.contextOpacity = new System.Windows.Forms.Timer(this.components);
            this.windowInvisible = new System.Windows.Forms.Timer(this.components);
            this.minimizeButton = new Summarizer.CustomButton();
            this.closeButton = new Summarizer.CustomButton();
            this.maximizeRestoreButton = new Summarizer.CustomButton();
            this.RestaureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaximizeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.mStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroContextMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(51, 30);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(51, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label1_MouseUp);
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.metroPanel1.Size = new System.Drawing.Size(30, 30);
            this.metroPanel1.TabIndex = 12;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // windowOpacity
            // 
            this.windowOpacity.Interval = 10;
            this.windowOpacity.Tick += new System.EventHandler(this.windowOpacity_Tick);
            // 
            // contextOpacity
            // 
            this.contextOpacity.Interval = 10;
            this.contextOpacity.Tick += new System.EventHandler(this.contextOpacity_Tick);
            // 
            // windowInvisible
            // 
            this.windowInvisible.Tick += new System.EventHandler(this.windowInvisible_Tick);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.ButtonBackColor = System.Drawing.Color.Silver;
            this.minimizeButton.ButtonBackgroundImage = null;
            this.minimizeButton.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimizeButton.ButtonBorderClickable = false;
            this.minimizeButton.ButtonBorderColor = System.Drawing.Color.Silver;
            this.minimizeButton.ButtonBorderHighlightColor = System.Drawing.Color.White;
            this.minimizeButton.ButtonBorderWidth = new System.Windows.Forms.Padding(0);
            this.minimizeButton.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.minimizeButton.ButtonForeColor = System.Drawing.Color.Black;
            this.minimizeButton.ButtonHighlight = true;
            this.minimizeButton.ButtonHighlightBackColor = System.Drawing.Color.Gray;
            this.minimizeButton.ButtonHighlightForeColor = System.Drawing.Color.White;
            this.minimizeButton.ButtonText = "";
            this.minimizeButton.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeButton.Location = new System.Drawing.Point(81, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(43, 30);
            this.minimizeButton.TabIndex = 10;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.ButtonBackColor = System.Drawing.Color.LightCoral;
            this.closeButton.ButtonBackgroundImage = null;
            this.closeButton.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton.ButtonBorderClickable = false;
            this.closeButton.ButtonBorderColor = System.Drawing.Color.LightCoral;
            this.closeButton.ButtonBorderHighlightColor = System.Drawing.Color.White;
            this.closeButton.ButtonBorderWidth = new System.Windows.Forms.Padding(0);
            this.closeButton.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.closeButton.ButtonForeColor = System.Drawing.Color.Black;
            this.closeButton.ButtonHighlight = true;
            this.closeButton.ButtonHighlightBackColor = System.Drawing.Color.Gray;
            this.closeButton.ButtonHighlightForeColor = System.Drawing.Color.White;
            this.closeButton.ButtonText = "";
            this.closeButton.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeButton.Location = new System.Drawing.Point(167, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(43, 30);
            this.closeButton.TabIndex = 8;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // maximizeRestoreButton
            // 
            this.maximizeRestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeRestoreButton.ButtonBackColor = System.Drawing.Color.DarkGray;
            this.maximizeRestoreButton.ButtonBackgroundImage = null;
            this.maximizeRestoreButton.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.maximizeRestoreButton.ButtonBorderClickable = false;
            this.maximizeRestoreButton.ButtonBorderColor = System.Drawing.Color.DarkGray;
            this.maximizeRestoreButton.ButtonBorderHighlightColor = System.Drawing.Color.White;
            this.maximizeRestoreButton.ButtonBorderWidth = new System.Windows.Forms.Padding(0);
            this.maximizeRestoreButton.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.maximizeRestoreButton.ButtonForeColor = System.Drawing.Color.Black;
            this.maximizeRestoreButton.ButtonHighlight = true;
            this.maximizeRestoreButton.ButtonHighlightBackColor = System.Drawing.Color.Gray;
            this.maximizeRestoreButton.ButtonHighlightForeColor = System.Drawing.Color.White;
            this.maximizeRestoreButton.ButtonText = "";
            this.maximizeRestoreButton.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maximizeRestoreButton.Location = new System.Drawing.Point(124, 0);
            this.maximizeRestoreButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeRestoreButton.Name = "maximizeRestoreButton";
            this.maximizeRestoreButton.Size = new System.Drawing.Size(43, 30);
            this.maximizeRestoreButton.TabIndex = 9;
            this.maximizeRestoreButton.Click += new System.EventHandler(this.maximizeRestoreButton_Click);
            // 
            // RestaureItem
            // 
            this.RestaureItem.Enabled = false;
            this.RestaureItem.Name = "RestaureItem";
            this.RestaureItem.Size = new System.Drawing.Size(129, 22);
            this.RestaureItem.Text = "Restaurar";
            this.RestaureItem.Click += new System.EventHandler(this.RestaureItem_Click);
            // 
            // MinimizeItem
            // 
            this.MinimizeItem.Name = "MinimizeItem";
            this.MinimizeItem.Size = new System.Drawing.Size(129, 22);
            this.MinimizeItem.Text = "Minimizar";
            this.MinimizeItem.Click += new System.EventHandler(this.MinimizeItem_Click);
            // 
            // MaximizeItem
            // 
            this.MaximizeItem.Name = "MaximizeItem";
            this.MaximizeItem.Size = new System.Drawing.Size(129, 22);
            this.MaximizeItem.Text = "Maximizar";
            this.MaximizeItem.Click += new System.EventHandler(this.MaximizeItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // CloseItem
            // 
            this.CloseItem.Name = "CloseItem";
            this.CloseItem.Size = new System.Drawing.Size(129, 22);
            this.CloseItem.Text = "Fechar";
            this.CloseItem.Click += new System.EventHandler(this.CloseItem_Click);
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestaureItem,
            this.MinimizeItem,
            this.MaximizeItem,
            this.toolStripSeparator1,
            this.CloseItem});
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.metroContextMenu1.Size = new System.Drawing.Size(130, 98);
            // 
            // mStyleManager
            // 
            this.mStyleManager.Owner = this;
            // 
            // WindowBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.maximizeRestoreButton);
            this.Controls.Add(this.metroPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WindowBar";
            this.Size = new System.Drawing.Size(210, 30);
            this.Load += new System.EventHandler(this.WindowBar_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.WindowBar_Layout);
            this.ParentChanged += new System.EventHandler(this.WindowBar_ParentChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroContextMenu1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer windowOpacity;
        private System.Windows.Forms.Timer contextOpacity;
        private System.Windows.Forms.Timer windowInvisible;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButton minimizeButton;
        private CustomButton maximizeRestoreButton;
        private CustomButton closeButton;
        private System.Windows.Forms.ToolStripMenuItem RestaureItem;
        private System.Windows.Forms.ToolStripMenuItem MinimizeItem;
        private System.Windows.Forms.ToolStripMenuItem MaximizeItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CloseItem;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Components.MetroStyleManager mStyleManager;
    }
}
