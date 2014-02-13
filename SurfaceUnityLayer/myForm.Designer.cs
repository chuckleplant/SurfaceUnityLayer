namespace SurfaceUnityLayer
{
    partial class myForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myForm));
            this.axUnityWebPlayer1 = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axUnityWebPlayer1
            // 
            this.axUnityWebPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axUnityWebPlayer1.Enabled = true;
            this.axUnityWebPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axUnityWebPlayer1.Name = "axUnityWebPlayer1";
            this.axUnityWebPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axUnityWebPlayer1.OcxState")));
            this.axUnityWebPlayer1.Size = new System.Drawing.Size(284, 261);
            this.axUnityWebPlayer1.TabIndex = 0;
            // 
            // myForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.axUnityWebPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "myForm";
            this.Text = "myForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxUnityWebPlayerAXLib.AxUnityWebPlayer axUnityWebPlayer1;
    }
}