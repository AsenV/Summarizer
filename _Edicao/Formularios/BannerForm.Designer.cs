namespace Tielapse
{
    partial class BannerForm
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
            this.lytMain = new System.Windows.Forms.TableLayoutPanel();
            this.lytInputs = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdate = new Tielapse.CustomButton();
            this.pnAppID = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.lytBannerSetup = new System.Windows.Forms.TableLayoutPanel();
            this.picBanner = new System.Windows.Forms.PictureBox();
            this.pnPos = new System.Windows.Forms.Panel();
            this.lytPos = new System.Windows.Forms.TableLayoutPanel();
            this.btnBottomRight = new Tielapse.CustomButton();
            this.btnBottom = new Tielapse.CustomButton();
            this.btnBottomLeft = new Tielapse.CustomButton();
            this.btnRight = new Tielapse.CustomButton();
            this.btnMiddle = new Tielapse.CustomButton();
            this.btnLeft = new Tielapse.CustomButton();
            this.btnTopRight = new Tielapse.CustomButton();
            this.btnTop = new Tielapse.CustomButton();
            this.btnTopLeft = new Tielapse.CustomButton();
            this.lytConfirm = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfirm = new Tielapse.CustomButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.windowBar1 = new Tielapse.WindowBar();
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).BeginInit();
            this.lytMain.SuspendLayout();
            this.lytInputs.SuspendLayout();
            this.pnAppID.SuspendLayout();
            this.lytBannerSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.pnPos.SuspendLayout();
            this.lytPos.SuspendLayout();
            this.lytConfirm.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mStyleManager
            // 
            this.mStyleManager.Owner = this;
            // 
            // lytMain
            // 
            this.lytMain.ColumnCount = 1;
            this.lytMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytMain.Controls.Add(this.lytInputs, 0, 0);
            this.lytMain.Controls.Add(this.lytBannerSetup, 0, 2);
            this.lytMain.Controls.Add(this.lytConfirm, 0, 4);
            this.lytMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytMain.Location = new System.Drawing.Point(10, 10);
            this.lytMain.Margin = new System.Windows.Forms.Padding(0);
            this.lytMain.Name = "lytMain";
            this.lytMain.RowCount = 5;
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63347F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.73307F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.lytMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63347F));
            this.lytMain.Size = new System.Drawing.Size(389, 163);
            this.lytMain.TabIndex = 3;
            // 
            // lytInputs
            // 
            this.lytInputs.ColumnCount = 4;
            this.lytInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.lytInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.lytInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.lytInputs.Controls.Add(this.btnUpdate, 2, 0);
            this.lytInputs.Controls.Add(this.pnAppID, 1, 0);
            this.lytInputs.Controls.Add(this.lbInput, 0, 0);
            this.lytInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytInputs.Location = new System.Drawing.Point(0, 0);
            this.lytInputs.Margin = new System.Windows.Forms.Padding(0);
            this.lytInputs.Name = "lytInputs";
            this.lytInputs.RowCount = 1;
            this.lytInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytInputs.Size = new System.Drawing.Size(389, 19);
            this.lytInputs.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ButtonBackColor = System.Drawing.Color.White;
            this.btnUpdate.ButtonBackgroundImage = null;
            this.btnUpdate.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUpdate.ButtonBorderClickable = false;
            this.btnUpdate.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnUpdate.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnUpdate.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnUpdate.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ButtonForeColor = System.Drawing.Color.Black;
            this.btnUpdate.ButtonHighlight = false;
            this.btnUpdate.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnUpdate.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnUpdate.ButtonText = "OK";
            this.btnUpdate.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdate.Location = new System.Drawing.Point(119, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(48, 19);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUpdate_MouseDown);
            // 
            // pnAppID
            // 
            this.pnAppID.Controls.Add(this.txtInput);
            this.pnAppID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAppID.Location = new System.Drawing.Point(56, 0);
            this.pnAppID.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnAppID.Name = "pnAppID";
            this.pnAppID.Size = new System.Drawing.Size(63, 18);
            this.pnAppID.TabIndex = 4;
            // 
            // txtInput
            // 
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Margin = new System.Windows.Forms.Padding(0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(63, 20);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInput.Location = new System.Drawing.Point(3, 0);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(50, 19);
            this.lbInput.TabIndex = 0;
            this.lbInput.Text = "Input:";
            this.lbInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lytBannerSetup
            // 
            this.lytBannerSetup.ColumnCount = 2;
            this.lytBannerSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.06684F));
            this.lytBannerSetup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.93316F));
            this.lytBannerSetup.Controls.Add(this.picBanner, 0, 0);
            this.lytBannerSetup.Controls.Add(this.pnPos, 1, 0);
            this.lytBannerSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytBannerSetup.Location = new System.Drawing.Point(0, 29);
            this.lytBannerSetup.Margin = new System.Windows.Forms.Padding(0);
            this.lytBannerSetup.Name = "lytBannerSetup";
            this.lytBannerSetup.RowCount = 1;
            this.lytBannerSetup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lytBannerSetup.Size = new System.Drawing.Size(389, 104);
            this.lytBannerSetup.TabIndex = 4;
            // 
            // picBanner
            // 
            this.picBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBanner.Location = new System.Drawing.Point(0, 0);
            this.picBanner.Margin = new System.Windows.Forms.Padding(0);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(257, 104);
            this.picBanner.TabIndex = 1;
            this.picBanner.TabStop = false;
            // 
            // pnPos
            // 
            this.pnPos.Controls.Add(this.lytPos);
            this.pnPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPos.Location = new System.Drawing.Point(257, 0);
            this.pnPos.Margin = new System.Windows.Forms.Padding(0);
            this.pnPos.Name = "pnPos";
            this.pnPos.Padding = new System.Windows.Forms.Padding(15);
            this.pnPos.Size = new System.Drawing.Size(132, 104);
            this.pnPos.TabIndex = 2;
            // 
            // lytPos
            // 
            this.lytPos.ColumnCount = 3;
            this.lytPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.Controls.Add(this.btnBottomRight, 2, 2);
            this.lytPos.Controls.Add(this.btnBottom, 1, 2);
            this.lytPos.Controls.Add(this.btnBottomLeft, 0, 2);
            this.lytPos.Controls.Add(this.btnRight, 2, 1);
            this.lytPos.Controls.Add(this.btnMiddle, 1, 1);
            this.lytPos.Controls.Add(this.btnLeft, 0, 1);
            this.lytPos.Controls.Add(this.btnTopRight, 2, 0);
            this.lytPos.Controls.Add(this.btnTop, 1, 0);
            this.lytPos.Controls.Add(this.btnTopLeft, 0, 0);
            this.lytPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytPos.Location = new System.Drawing.Point(15, 15);
            this.lytPos.Margin = new System.Windows.Forms.Padding(0);
            this.lytPos.Name = "lytPos";
            this.lytPos.RowCount = 3;
            this.lytPos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.lytPos.Size = new System.Drawing.Size(102, 74);
            this.lytPos.TabIndex = 0;
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.ButtonBackColor = System.Drawing.Color.White;
            this.btnBottomRight.ButtonBackgroundImage = null;
            this.btnBottomRight.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBottomRight.ButtonBorderClickable = false;
            this.btnBottomRight.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnBottomRight.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnBottomRight.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnBottomRight.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBottomRight.ButtonForeColor = System.Drawing.Color.Black;
            this.btnBottomRight.ButtonHighlight = false;
            this.btnBottomRight.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnBottomRight.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnBottomRight.ButtonText = "X";
            this.btnBottomRight.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBottomRight.Location = new System.Drawing.Point(68, 48);
            this.btnBottomRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(34, 26);
            this.btnBottomRight.TabIndex = 9;
            // 
            // btnBottom
            // 
            this.btnBottom.ButtonBackColor = System.Drawing.Color.White;
            this.btnBottom.ButtonBackgroundImage = null;
            this.btnBottom.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBottom.ButtonBorderClickable = false;
            this.btnBottom.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnBottom.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnBottom.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnBottom.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBottom.ButtonForeColor = System.Drawing.Color.Black;
            this.btnBottom.ButtonHighlight = false;
            this.btnBottom.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnBottom.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnBottom.ButtonText = "X";
            this.btnBottom.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBottom.Location = new System.Drawing.Point(34, 48);
            this.btnBottom.Margin = new System.Windows.Forms.Padding(0);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(34, 26);
            this.btnBottom.TabIndex = 8;
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.ButtonBackColor = System.Drawing.Color.White;
            this.btnBottomLeft.ButtonBackgroundImage = null;
            this.btnBottomLeft.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBottomLeft.ButtonBorderClickable = false;
            this.btnBottomLeft.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnBottomLeft.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnBottomLeft.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnBottomLeft.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBottomLeft.ButtonForeColor = System.Drawing.Color.Black;
            this.btnBottomLeft.ButtonHighlight = false;
            this.btnBottomLeft.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnBottomLeft.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnBottomLeft.ButtonText = "X";
            this.btnBottomLeft.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBottomLeft.Location = new System.Drawing.Point(0, 48);
            this.btnBottomLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(34, 26);
            this.btnBottomLeft.TabIndex = 7;
            // 
            // btnRight
            // 
            this.btnRight.ButtonBackColor = System.Drawing.Color.White;
            this.btnRight.ButtonBackgroundImage = null;
            this.btnRight.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRight.ButtonBorderClickable = false;
            this.btnRight.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnRight.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnRight.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnRight.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRight.ButtonForeColor = System.Drawing.Color.Black;
            this.btnRight.ButtonHighlight = false;
            this.btnRight.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnRight.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnRight.ButtonText = "X";
            this.btnRight.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.Location = new System.Drawing.Point(68, 24);
            this.btnRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(34, 24);
            this.btnRight.TabIndex = 6;
            // 
            // btnMiddle
            // 
            this.btnMiddle.ButtonBackColor = System.Drawing.Color.White;
            this.btnMiddle.ButtonBackgroundImage = null;
            this.btnMiddle.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMiddle.ButtonBorderClickable = false;
            this.btnMiddle.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnMiddle.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnMiddle.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnMiddle.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnMiddle.ButtonForeColor = System.Drawing.Color.Black;
            this.btnMiddle.ButtonHighlight = false;
            this.btnMiddle.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnMiddle.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnMiddle.ButtonText = "X";
            this.btnMiddle.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMiddle.Location = new System.Drawing.Point(34, 24);
            this.btnMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.btnMiddle.Name = "btnMiddle";
            this.btnMiddle.Size = new System.Drawing.Size(34, 24);
            this.btnMiddle.TabIndex = 5;
            // 
            // btnLeft
            // 
            this.btnLeft.ButtonBackColor = System.Drawing.Color.White;
            this.btnLeft.ButtonBackgroundImage = null;
            this.btnLeft.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLeft.ButtonBorderClickable = false;
            this.btnLeft.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnLeft.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnLeft.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnLeft.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLeft.ButtonForeColor = System.Drawing.Color.Black;
            this.btnLeft.ButtonHighlight = false;
            this.btnLeft.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnLeft.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnLeft.ButtonText = "X";
            this.btnLeft.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.Location = new System.Drawing.Point(0, 24);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(34, 24);
            this.btnLeft.TabIndex = 4;
            // 
            // btnTopRight
            // 
            this.btnTopRight.ButtonBackColor = System.Drawing.Color.White;
            this.btnTopRight.ButtonBackgroundImage = null;
            this.btnTopRight.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopRight.ButtonBorderClickable = false;
            this.btnTopRight.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnTopRight.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnTopRight.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnTopRight.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTopRight.ButtonForeColor = System.Drawing.Color.Black;
            this.btnTopRight.ButtonHighlight = false;
            this.btnTopRight.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnTopRight.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnTopRight.ButtonText = "X";
            this.btnTopRight.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopRight.Location = new System.Drawing.Point(68, 0);
            this.btnTopRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(34, 24);
            this.btnTopRight.TabIndex = 3;
            // 
            // btnTop
            // 
            this.btnTop.ButtonBackColor = System.Drawing.Color.White;
            this.btnTop.ButtonBackgroundImage = null;
            this.btnTop.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTop.ButtonBorderClickable = false;
            this.btnTop.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnTop.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnTop.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnTop.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTop.ButtonForeColor = System.Drawing.Color.Black;
            this.btnTop.ButtonHighlight = false;
            this.btnTop.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnTop.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnTop.ButtonText = "X";
            this.btnTop.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTop.Location = new System.Drawing.Point(34, 0);
            this.btnTop.Margin = new System.Windows.Forms.Padding(0);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(34, 24);
            this.btnTop.TabIndex = 2;
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.ButtonBackColor = System.Drawing.Color.White;
            this.btnTopLeft.ButtonBackgroundImage = null;
            this.btnTopLeft.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTopLeft.ButtonBorderClickable = false;
            this.btnTopLeft.ButtonBorderColor = System.Drawing.Color.Black;
            this.btnTopLeft.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.btnTopLeft.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.btnTopLeft.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTopLeft.ButtonForeColor = System.Drawing.Color.Black;
            this.btnTopLeft.ButtonHighlight = false;
            this.btnTopLeft.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.btnTopLeft.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnTopLeft.ButtonText = "X";
            this.btnTopLeft.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTopLeft.Location = new System.Drawing.Point(0, 0);
            this.btnTopLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(34, 24);
            this.btnTopLeft.TabIndex = 1;
            // 
            // lytConfirm
            // 
            this.lytConfirm.ColumnCount = 3;
            this.lytConfirm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.50129F));
            this.lytConfirm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.39589F));
            this.lytConfirm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.10283F));
            this.lytConfirm.Controls.Add(this.btnConfirm, 1, 0);
            this.lytConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lytConfirm.Location = new System.Drawing.Point(0, 143);
            this.lytConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.lytConfirm.Name = "lytConfirm";
            this.lytConfirm.RowCount = 1;
            this.lytConfirm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lytConfirm.Size = new System.Drawing.Size(389, 20);
            this.lytConfirm.TabIndex = 5;
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
            this.btnConfirm.ButtonText = "Confirm";
            this.btnConfirm.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.Location = new System.Drawing.Point(177, 0);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(56, 20);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnConfirm_MouseDown);
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.lytMain);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 30);
            this.pnMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnMain.Size = new System.Drawing.Size(409, 183);
            this.pnMain.TabIndex = 4;
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
            this.windowBar1.Size = new System.Drawing.Size(409, 30);
            this.windowBar1.TabIndex = 0;
            this.windowBar1.Title = "Banner Settings";
            // 
            // BannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 213);
            this.ControlBox = false;
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.windowBar1);
            this.DisplayHeader = false;
            this.Movable = false;
            this.Name = "BannerForm";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BannerForm_FormClosing);
            this.Load += new System.EventHandler(this.Banner_Load);
            this.SizeChanged += new System.EventHandler(this.Sobre_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mStyleManager)).EndInit();
            this.lytMain.ResumeLayout(false);
            this.lytInputs.ResumeLayout(false);
            this.lytInputs.PerformLayout();
            this.pnAppID.ResumeLayout(false);
            this.pnAppID.PerformLayout();
            this.lytBannerSetup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.pnPos.ResumeLayout(false);
            this.lytPos.ResumeLayout(false);
            this.lytConfirm.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager mStyleManager;
        private WindowBar windowBar1;
        private System.Windows.Forms.TableLayoutPanel lytMain;
        private System.Windows.Forms.TableLayoutPanel lytInputs;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.TableLayoutPanel lytBannerSetup;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Panel pnAppID;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel pnPos;
        private System.Windows.Forms.TableLayoutPanel lytPos;
        private CustomButton btnBottomRight;
        private CustomButton btnBottom;
        private CustomButton btnBottomLeft;
        private CustomButton btnRight;
        private CustomButton btnMiddle;
        private CustomButton btnLeft;
        private CustomButton btnTopRight;
        private CustomButton btnTop;
        private CustomButton btnTopLeft;
        private System.Windows.Forms.TableLayoutPanel lytConfirm;
        private CustomButton btnConfirm;
        private CustomButton btnUpdate;
    }
}