namespace Tielapse._Edicao.Controles_de_Usuario
{
    partial class ContextMenu
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
            this.customButton1 = new Tielapse.CustomButton();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.ButtonBackColor = System.Drawing.Color.White;
            this.customButton1.ButtonBackgroundImage = null;
            this.customButton1.ButtonBackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customButton1.ButtonBorderClickable = false;
            this.customButton1.ButtonBorderColor = System.Drawing.Color.Black;
            this.customButton1.ButtonBorderHighlightColor = System.Drawing.Color.Empty;
            this.customButton1.ButtonBorderWidth = new System.Windows.Forms.Padding(1);
            this.customButton1.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.customButton1.ButtonForeColor = System.Drawing.Color.Black;
            this.customButton1.ButtonHighlight = false;
            this.customButton1.ButtonHighlightBackColor = System.Drawing.Color.Empty;
            this.customButton1.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.customButton1.ButtonText = "ContextMenu";
            this.customButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.customButton1.Location = new System.Drawing.Point(0, 0);
            this.customButton1.Margin = new System.Windows.Forms.Padding(0);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(92, 31);
            this.customButton1.TabIndex = 0;
            // 
            // ContextMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customButton1);
            this.Name = "ContextMenu";
            this.Size = new System.Drawing.Size(92, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomButton customButton1;
    }
}
