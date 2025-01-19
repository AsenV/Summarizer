namespace Tielapse
{
    partial class BillForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pnMain = new System.Windows.Forms.Panel();
            this.lytMain = new System.Windows.Forms.TableLayoutPanel();
            this.lytName = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lytPrice = new System.Windows.Forms.TableLayoutPanel();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new Tielapse.CustomButton();
            this.windowBar1 = new Tielapse.WindowBar();
            this.cbTimes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).BeginInit();
            this.pnMain.SuspendLayout();
            this.lytMain.SuspendLayout();
            this.lytName.SuspendLayout();
            this.lytPrice.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mStyleManager
            // 
            this.mStyleManager.Owner = this;
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.lytMain);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 30);
            this.pnMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnMain.Size = new System.Drawing.Size(350, 95);
            this.pnMain.TabIndex = 4;
            // 
            // lytMain
            // 
            this.lytMain.ColumnCount = 2;
            this.lytMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.lytMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytMain.Controls.Add(this.lytName, 1, 0);
            this.lytMain.Controls.Add(this.label2, 0, 1);
            this.lytMain.Controls.Add(this.label1, 0, 0);
            this.lytMain.Controls.Add(this.lytPrice, 1, 1);
            this.lytMain.Controls.Add(this.panel1, 1, 2);
            this.lytMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytMain.Location = new System.Drawing.Point(10, 10);
            this.lytMain.Margin = new System.Windows.Forms.Padding(0);
            this.lytMain.Name = "lytMain";
            this.lytMain.RowCount = 3;
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytMain.Size = new System.Drawing.Size(330, 75);
            this.lytMain.TabIndex = 0;
            // 
            // lytName
            // 
            this.lytName.ColumnCount = 2;
            this.lytName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.lytName.Controls.Add(this.txtName, 0, 0);
            this.lytName.Controls.Add(this.dtpDate, 1, 0);
            this.lytName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytName.Location = new System.Drawing.Point(40, 0);
            this.lytName.Margin = new System.Windows.Forms.Padding(0);
            this.lytName.Name = "lytName";
            this.lytName.RowCount = 1;
            this.lytName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytName.Size = new System.Drawing.Size(290, 20);
            this.lytName.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(190, 20);
            this.txtName.TabIndex = 1;
            // 
            // dtpDate
            // 
            this.dtpDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(190, 0);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 20);
            this.dtpDate.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Valor:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lytPrice
            // 
            this.lytPrice.ColumnCount = 2;
            this.lytPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.lytPrice.Controls.Add(this.cbTimes, 1, 0);
            this.lytPrice.Controls.Add(this.txtValue, 0, 0);
            this.lytPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytPrice.Location = new System.Drawing.Point(40, 20);
            this.lytPrice.Margin = new System.Windows.Forms.Padding(0);
            this.lytPrice.Name = "lytPrice";
            this.lytPrice.RowCount = 1;
            this.lytPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytPrice.Size = new System.Drawing.Size(290, 20);
            this.lytPrice.TabIndex = 1;
            // 
            // txtValue
            // 
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Margin = new System.Windows.Forms.Padding(0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(190, 20);
            this.txtValue.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(40, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(200, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(290, 35);
            this.panel1.TabIndex = 9;
            // 
            // btnConfirm
            // 
            this.btnConfirm.ButtonBackColor = System.Drawing.Color.White;
            this.btnConfirm.ButtonBackgroundImage = null;
            this.btnConfirm.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfirm.ButtonBorderClickable = false;
            this.btnConfirm.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnConfirm.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnConfirm.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ButtonForeColor = System.Drawing.Color.Black;
            this.btnConfirm.ButtonHighlight = false;
            this.btnConfirm.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonText = "Confirmar";
            this.btnConfirm.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(200, 10);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 25);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnConfirm_MouseDown);
            // 
            // windowBar1
            // 
            this.windowBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.windowBar1.CloseButton = true;
            this.windowBar1.DarkMode = true;
            this.windowBar1.FixedPos = new System.Drawing.Point(0, 0);
            this.windowBar1.FixExtraWidth = false;
            this.windowBar1.Location = new System.Drawing.Point(0, 0);
            this.windowBar1.Margin = new System.Windows.Forms.Padding(0);
            this.windowBar1.MaximizeButton = false;
            this.windowBar1.MetroStyle = MetroFramework.MetroColorStyle.Blue;
            this.windowBar1.MetroTheme = MetroFramework.MetroThemeStyle.Light;
            this.windowBar1.MinimizeButton = false;
            this.windowBar1.Name = "windowBar1";
            this.windowBar1.Owner = this;
            this.windowBar1.ShowIcon = false;
            this.windowBar1.Size = new System.Drawing.Size(350, 30);
            this.windowBar1.TabIndex = 0;
            this.windowBar1.Title = "Conta";
            // 
            // cbTimes
            // 
            this.cbTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimes.FormattingEnabled = true;
            this.cbTimes.Location = new System.Drawing.Point(190, 0);
            this.cbTimes.Margin = new System.Windows.Forms.Padding(0);
            this.cbTimes.Name = "cbTimes";
            this.cbTimes.Size = new System.Drawing.Size(100, 21);
            this.cbTimes.TabIndex = 1;
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 125);
            this.ControlBox = false;
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.windowBar1);
            this.DisplayHeader = false;
            this.Movable = false;
            this.Name = "BillForm";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BillForm_FormClosing);
            this.Load += new System.EventHandler(this.Bill_Load);
            this.SizeChanged += new System.EventHandler(this.Bill_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).EndInit();
            this.pnMain.ResumeLayout(false);
            this.lytMain.ResumeLayout(false);
            this.lytMain.PerformLayout();
            this.lytName.ResumeLayout(false);
            this.lytName.PerformLayout();
            this.lytPrice.ResumeLayout(false);
            this.lytPrice.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager mStyleManager;
        private WindowBar windowBar1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.TableLayoutPanel lytMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel lytPrice;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TableLayoutPanel lytName;
        private CustomButton btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTimes;
    }
}