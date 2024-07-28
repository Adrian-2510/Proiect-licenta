
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormVizualizareEvaluari
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
            this.labelEvaluari = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIncepeEvaluarea = new System.Windows.Forms.Button();
            this.tabControlEvaluariPredate = new System.Windows.Forms.TabControl();
            this.tabPageEvaluariFinalizate = new System.Windows.Forms.TabPage();
            this.listBoxEvaluariFinalizate = new System.Windows.Forms.ListBox();
            this.tabPageEvaluariIntarziate = new System.Windows.Forms.TabPage();
            this.listBoxEvaluariNepredate = new System.Windows.Forms.ListBox();
            this.listBoxEvaluariActive = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tabControlEvaluariPredate.SuspendLayout();
            this.tabPageEvaluariFinalizate.SuspendLayout();
            this.tabPageEvaluariIntarziate.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEvaluari
            // 
            this.labelEvaluari.AutoSize = true;
            this.labelEvaluari.BackColor = System.Drawing.Color.Transparent;
            this.labelEvaluari.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEvaluari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelEvaluari.Location = new System.Drawing.Point(876, 9);
            this.labelEvaluari.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelEvaluari.Name = "labelEvaluari";
            this.labelEvaluari.Size = new System.Drawing.Size(373, 109);
            this.labelEvaluari.TabIndex = 0;
            this.labelEvaluari.Text = "Evaluari";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImage = global::evaluarea_studentilor_in_sesiune.Properties.Resources.college_student_4369850_1920;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.buttonInapoi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonIncepeEvaluarea);
            this.panel1.Controls.Add(this.tabControlEvaluariPredate);
            this.panel1.Controls.Add(this.listBoxEvaluariActive);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 1041);
            this.panel1.TabIndex = 1;
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonInapoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonInapoi.Location = new System.Drawing.Point(1533, 920);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(329, 74);
            this.buttonInapoi.TabIndex = 5;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = false;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Evaluari active:";
            // 
            // buttonIncepeEvaluarea
            // 
            this.buttonIncepeEvaluarea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonIncepeEvaluarea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonIncepeEvaluarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIncepeEvaluarea.Location = new System.Drawing.Point(45, 844);
            this.buttonIncepeEvaluarea.Name = "buttonIncepeEvaluarea";
            this.buttonIncepeEvaluarea.Size = new System.Drawing.Size(676, 89);
            this.buttonIncepeEvaluarea.TabIndex = 3;
            this.buttonIncepeEvaluarea.Text = "Incepe evaluarea";
            this.buttonIncepeEvaluarea.UseVisualStyleBackColor = false;
            this.buttonIncepeEvaluarea.Click += new System.EventHandler(this.buttonIncepeEvaluarea_Click);
            // 
            // tabControlEvaluariPredate
            // 
            this.tabControlEvaluariPredate.Controls.Add(this.tabPageEvaluariFinalizate);
            this.tabControlEvaluariPredate.Controls.Add(this.tabPageEvaluariIntarziate);
            this.tabControlEvaluariPredate.Location = new System.Drawing.Point(1048, 267);
            this.tabControlEvaluariPredate.Name = "tabControlEvaluariPredate";
            this.tabControlEvaluariPredate.SelectedIndex = 0;
            this.tabControlEvaluariPredate.Size = new System.Drawing.Size(789, 561);
            this.tabControlEvaluariPredate.TabIndex = 2;
            // 
            // tabPageEvaluariFinalizate
            // 
            this.tabPageEvaluariFinalizate.Controls.Add(this.listBoxEvaluariFinalizate);
            this.tabPageEvaluariFinalizate.Location = new System.Drawing.Point(4, 49);
            this.tabPageEvaluariFinalizate.Name = "tabPageEvaluariFinalizate";
            this.tabPageEvaluariFinalizate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEvaluariFinalizate.Size = new System.Drawing.Size(781, 508);
            this.tabPageEvaluariFinalizate.TabIndex = 0;
            this.tabPageEvaluariFinalizate.Text = "Evaluari finalizate";
            this.tabPageEvaluariFinalizate.UseVisualStyleBackColor = true;
            // 
            // listBoxEvaluariFinalizate
            // 
            this.listBoxEvaluariFinalizate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxEvaluariFinalizate.FormattingEnabled = true;
            this.listBoxEvaluariFinalizate.HorizontalScrollbar = true;
            this.listBoxEvaluariFinalizate.ItemHeight = 40;
            this.listBoxEvaluariFinalizate.Location = new System.Drawing.Point(3, 3);
            this.listBoxEvaluariFinalizate.Name = "listBoxEvaluariFinalizate";
            this.listBoxEvaluariFinalizate.Size = new System.Drawing.Size(775, 484);
            this.listBoxEvaluariFinalizate.TabIndex = 0;
            this.listBoxEvaluariFinalizate.DoubleClick += new System.EventHandler(this.listBoxEvaluariFinalizate_DoubleClick);
            // 
            // tabPageEvaluariIntarziate
            // 
            this.tabPageEvaluariIntarziate.Controls.Add(this.listBoxEvaluariNepredate);
            this.tabPageEvaluariIntarziate.Location = new System.Drawing.Point(4, 49);
            this.tabPageEvaluariIntarziate.Name = "tabPageEvaluariIntarziate";
            this.tabPageEvaluariIntarziate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEvaluariIntarziate.Size = new System.Drawing.Size(781, 508);
            this.tabPageEvaluariIntarziate.TabIndex = 1;
            this.tabPageEvaluariIntarziate.Text = "Evaluari nepredate";
            this.tabPageEvaluariIntarziate.UseVisualStyleBackColor = true;
            // 
            // listBoxEvaluariNepredate
            // 
            this.listBoxEvaluariNepredate.FormattingEnabled = true;
            this.listBoxEvaluariNepredate.ItemHeight = 40;
            this.listBoxEvaluariNepredate.Location = new System.Drawing.Point(7, 7);
            this.listBoxEvaluariNepredate.Name = "listBoxEvaluariNepredate";
            this.listBoxEvaluariNepredate.Size = new System.Drawing.Size(768, 484);
            this.listBoxEvaluariNepredate.TabIndex = 0;
            // 
            // listBoxEvaluariActive
            // 
            this.listBoxEvaluariActive.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBoxEvaluariActive.FormattingEnabled = true;
            this.listBoxEvaluariActive.HorizontalScrollbar = true;
            this.listBoxEvaluariActive.ItemHeight = 40;
            this.listBoxEvaluariActive.Location = new System.Drawing.Point(45, 304);
            this.listBoxEvaluariActive.Name = "listBoxEvaluariActive";
            this.listBoxEvaluariActive.Size = new System.Drawing.Size(676, 524);
            this.listBoxEvaluariActive.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.labelEvaluari);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1917, 119);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._667366_measure_pencil_ruler_school_work_icon__1_;
            this.pictureBox2.Location = new System.Drawing.Point(25, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(92, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::evaluarea_studentilor_in_sesiune.Properties.Resources._1055103_brush_pencil_edit_icon;
            this.pictureBox1.Location = new System.Drawing.Point(1778, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormVizualizareEvaluari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FormVizualizareEvaluari";
            this.Tag = "1920;1080";
            this.Text = "FormVizualizareEvaluari";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVizualizareEvaluari_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlEvaluariPredate.ResumeLayout(false);
            this.tabPageEvaluariFinalizate.ResumeLayout(false);
            this.tabPageEvaluariIntarziate.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelEvaluari;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControlEvaluariPredate;
        private System.Windows.Forms.TabPage tabPageEvaluariFinalizate;
        private System.Windows.Forms.TabPage tabPageEvaluariIntarziate;
        private System.Windows.Forms.ListBox listBoxEvaluariActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIncepeEvaluarea;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.ListBox listBoxEvaluariFinalizate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxEvaluariNepredate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}