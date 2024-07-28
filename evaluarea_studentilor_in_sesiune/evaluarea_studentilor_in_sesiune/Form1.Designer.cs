
namespace evaluarea_studentilor_in_sesiune
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxUserName = new System.Windows.Forms.PictureBox();
            this.pictureBoxParola = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelCraereCont = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.labelContDezactiva = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxUserName.Location = new System.Drawing.Point(751, 304);
            this.textBoxUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.PlaceholderText = "User name";
            this.textBoxUserName.Size = new System.Drawing.Size(332, 48);
            this.textBoxUserName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(751, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "User name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(751, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parola";
            // 
            // pictureBoxUserName
            // 
            this.pictureBoxUserName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxUserName.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.pozaUser;
            this.pictureBoxUserName.Location = new System.Drawing.Point(1020, 310);
            this.pictureBoxUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxUserName.Name = "pictureBoxUserName";
            this.pictureBoxUserName.Size = new System.Drawing.Size(60, 38);
            this.pictureBoxUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxUserName.TabIndex = 4;
            this.pictureBoxUserName.TabStop = false;
            // 
            // pictureBoxParola
            // 
            this.pictureBoxParola.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBoxParola.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.pozaParola;
            this.pictureBoxParola.Location = new System.Drawing.Point(1021, 408);
            this.pictureBoxParola.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxParola.Name = "pictureBoxParola";
            this.pictureBoxParola.Size = new System.Drawing.Size(60, 38);
            this.pictureBoxParola.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxParola.TabIndex = 5;
            this.pictureBoxParola.TabStop = false;
            this.pictureBoxParola.Click += new System.EventHandler(this.pictureBoxParola_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.SystemColors.HighlightText;
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.SystemColors.GrayText;
            this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ScrollBar;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonLogin.Location = new System.Drawing.Point(751, 467);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(332, 60);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Logare";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelCraereCont
            // 
            this.labelCraereCont.AutoSize = true;
            this.labelCraereCont.BackColor = System.Drawing.Color.Transparent;
            this.labelCraereCont.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.labelCraereCont.ForeColor = System.Drawing.Color.White;
            this.labelCraereCont.Location = new System.Drawing.Point(843, 529);
            this.labelCraereCont.Name = "labelCraereCont";
            this.labelCraereCont.Size = new System.Drawing.Size(125, 27);
            this.labelCraereCont.TabIndex = 8;
            this.labelCraereCont.Text = "Creare cont";
            this.labelCraereCont.Click += new System.EventHandler(this.labelCraereCont_Click);
            this.labelCraereCont.MouseHover += new System.EventHandler(this.labelCraereCont_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources.user_login_icon_29;
            this.pictureBox2.Location = new System.Drawing.Point(774, 94);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(306, 143);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxParola.Location = new System.Drawing.Point(751, 402);
            this.textBoxParola.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '●';
            this.textBoxParola.PlaceholderText = "Parola";
            this.textBoxParola.Size = new System.Drawing.Size(332, 48);
            this.textBoxParola.TabIndex = 1;
           
            // 
            // labelContDezactiva
            // 
            this.labelContDezactiva.AutoSize = true;
            this.labelContDezactiva.BackColor = System.Drawing.Color.Transparent;
            this.labelContDezactiva.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelContDezactiva.ForeColor = System.Drawing.Color.Red;
            this.labelContDezactiva.Location = new System.Drawing.Point(872, 170);
            this.labelContDezactiva.Name = "labelContDezactiva";
            this.labelContDezactiva.Size = new System.Drawing.Size(112, 23);
            this.labelContDezactiva.TabIndex = 11;
            this.labelContDezactiva.Text = "Cont inactiv";
            this.labelContDezactiva.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::evaluarea_studentilor_in_sesiune.Properties.Resources.hat_1674894_19202;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.labelContDezactiva);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelCraereCont);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBoxParola);
            this.Controls.Add(this.pictureBoxUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.textBoxParola);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Logare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxUserName;
        private System.Windows.Forms.PictureBox pictureBoxParola;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelCraereCont;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.Label labelContDezactiva;
    }
}

