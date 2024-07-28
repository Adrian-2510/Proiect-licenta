using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{
    public partial class FormIntraInAplicatie : Form
    {
        public FormIntraInAplicatie()
        {
            InitializeComponent();
            
        }

        private  void buttonIntraPaginaLogare_Click(object sender, EventArgs e)
        {
           
            pictureBoxLoading.Visible = true;

            Form1 logare = new Form1();
            this.Hide();
            logare.ShowDialog();
        }

     
    }
}
