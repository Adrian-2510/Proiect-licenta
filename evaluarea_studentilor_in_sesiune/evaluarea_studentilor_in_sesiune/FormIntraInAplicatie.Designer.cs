
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormIntraInAplicatie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIntraInAplicatie));
            this.buttonIntraPaginaLogare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonIntraPaginaLogare
            // 
            this.buttonIntraPaginaLogare.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonIntraPaginaLogare.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonIntraPaginaLogare.FlatAppearance.BorderSize = 2;
            this.buttonIntraPaginaLogare.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.buttonIntraPaginaLogare.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GrayText;
            this.buttonIntraPaginaLogare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIntraPaginaLogare.Font = new System.Drawing.Font("Bernard MT Condensed", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonIntraPaginaLogare.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonIntraPaginaLogare.Location = new System.Drawing.Point(782, 544);
            this.buttonIntraPaginaLogare.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIntraPaginaLogare.Name = "buttonIntraPaginaLogare";
            this.buttonIntraPaginaLogare.Size = new System.Drawing.Size(223, 67);
            this.buttonIntraPaginaLogare.TabIndex = 0;
            this.buttonIntraPaginaLogare.Text = "Intra";
            this.buttonIntraPaginaLogare.UseVisualStyleBackColor = false;
            this.buttonIntraPaginaLogare.Click += new System.EventHandler(this.buttonIntraPaginaLogare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(478, 232);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(853, 124);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bun venit pe platforma de evaluare\r\n a studentilor OneAcademy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.logo_dreapta;
            this.pictureBox1.Location = new System.Drawing.Point(1327, 232);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.logo_one_academy;
            this.pictureBox2.Location = new System.Drawing.Point(396, 380);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(995, 138);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.ZKZg;
            this.pictureBoxLoading.Location = new System.Drawing.Point(815, 657);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(157, 152);
            this.pictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoading.TabIndex = 4;
            this.pictureBoxLoading.TabStop = false;
            this.pictureBoxLoading.Visible = false;
            // 
            // FormIntraInAplicatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pictureBoxLoading);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonIntraPaginaLogare);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormIntraInAplicatie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormIntraInAplicatie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIntraPaginaLogare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
    }
}