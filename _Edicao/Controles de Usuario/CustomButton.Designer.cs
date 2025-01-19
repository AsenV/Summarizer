namespace Summarizer
{
    partial class CustomButton
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
            this.buttonLabel = new System.Windows.Forms.Label();
            this.buttonBorder = new MetroFramework.Controls.MetroPanel();
            this.contextOpacity = new System.Windows.Forms.Timer(this.components);
            this.buttonBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLabel
            // 
            this.buttonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLabel.Location = new System.Drawing.Point(5, 5);
            this.buttonLabel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLabel.Name = "buttonLabel";
            this.buttonLabel.Size = new System.Drawing.Size(82, 21);
            this.buttonLabel.TabIndex = 0;
            this.buttonLabel.Text = "CustomButton";
            this.buttonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBorder
            // 
            this.buttonBorder.Controls.Add(this.buttonLabel);
            this.buttonBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBorder.HorizontalScrollbarBarColor = true;
            this.buttonBorder.HorizontalScrollbarHighlightOnWheel = false;
            this.buttonBorder.HorizontalScrollbarSize = 10;
            this.buttonBorder.Location = new System.Drawing.Point(0, 0);
            this.buttonBorder.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBorder.Name = "buttonBorder";
            this.buttonBorder.Padding = new System.Windows.Forms.Padding(5);
            this.buttonBorder.Size = new System.Drawing.Size(92, 31);
            this.buttonBorder.TabIndex = 1;
            this.buttonBorder.UseCustomBackColor = true;
            this.buttonBorder.UseCustomForeColor = true;
            this.buttonBorder.VerticalScrollbarBarColor = true;
            this.buttonBorder.VerticalScrollbarHighlightOnWheel = false;
            this.buttonBorder.VerticalScrollbarSize = 10;
            // 
            // contextOpacity
            // 
            this.contextOpacity.Interval = 10;
            // 
            // CustomButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBorder);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomButton";
            this.Size = new System.Drawing.Size(92, 31);
            this.buttonBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label buttonLabel;
        private MetroFramework.Controls.MetroPanel buttonBorder;
        private System.Windows.Forms.Timer contextOpacity;
    }
}
