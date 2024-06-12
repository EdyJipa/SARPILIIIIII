namespace SARPILIIIIII
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblScor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblScor = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // timer1
            this.timer1.Interval = 100;

            // lblScor
            this.lblScor.AutoSize = true;
            this.lblScor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScor.Location = new System.Drawing.Point(12, 9);
            this.lblScor.Name = "lblScor";
            this.lblScor.Size = new System.Drawing.Size(53, 17);
            this.lblScor.TabIndex = 0;
            this.lblScor.Text = "Scor: 0";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblScor);
            this.Name = "Form1";
            this.Text = "Joc Snake";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
