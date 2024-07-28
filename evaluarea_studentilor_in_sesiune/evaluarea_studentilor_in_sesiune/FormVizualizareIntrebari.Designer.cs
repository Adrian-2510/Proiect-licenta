
namespace evaluarea_studentilor_in_sesiune
{
    partial class FormVizualizareIntrebari
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
            this.listBoxIntrebari = new System.Windows.Forms.ListBox();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxIntrebari
            // 
            this.listBoxIntrebari.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxIntrebari.FormattingEnabled = true;
            this.listBoxIntrebari.HorizontalScrollbar = true;
            this.listBoxIntrebari.ItemHeight = 27;
            this.listBoxIntrebari.Location = new System.Drawing.Point(34, 204);
            this.listBoxIntrebari.Name = "listBoxIntrebari";
            this.listBoxIntrebari.Size = new System.Drawing.Size(1832, 598);
            this.listBoxIntrebari.TabIndex = 0;
            this.listBoxIntrebari.DoubleClick += new System.EventHandler(this.listBoxIntrebari_DoubleClick);
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(34, 62);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(558, 35);
            this.comboBoxDiscipline.TabIndex = 1;
            this.comboBoxDiscipline.SelectedIndexChanged += new System.EventHandler(this.comboBoxDiscipline_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Disciplina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Itemi:";
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonInapoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInapoi.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonInapoi.Location = new System.Drawing.Point(1658, 855);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(208, 75);
            this.buttonInapoi.TabIndex = 4;
            this.buttonInapoi.Text = "Inapoi";
            this.buttonInapoi.UseVisualStyleBackColor = false;
            this.buttonInapoi.Click += new System.EventHandler(this.buttonInapoi_Click);
            // 
            // FormVizualizareIntrebari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDiscipline);
            this.Controls.Add(this.listBoxIntrebari);
            this.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormVizualizareIntrebari";
            this.Text = "FormVizualizareIntrebari";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxIntrebari;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonInapoi;
    }
}