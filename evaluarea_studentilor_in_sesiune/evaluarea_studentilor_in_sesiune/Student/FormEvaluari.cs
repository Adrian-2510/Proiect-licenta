using evaluarea_studentilor_in_sesiune.Properties;
using evaluarea_studentilor_in_sesiune.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace evaluarea_studentilor_in_sesiune
{

    public partial class FormEvaluari : Form
    {

        List<int> listaIntrebari = new List<int>();
        List<Itemi> listaItemi = ConexiuneBazaDeDate.ExtragereItemi();
        List<int> itemiAnteriori = new List<int>();
        List<AsociereStudentContGrupa> listaasociereStudentContGrupa = ConexiuneBazaDeDate.ExtragereasociereStudentContGrupa();
        List<Student> listaStudent = ConexiuneBazaDeDate.ExtragereStudenti();
        List<Grupa> listGrupa = ConexiuneBazaDeDate.ExtragereGrupa();
        List<Specializare> listSpecializare = ConexiuneBazaDeDate.ExtrageSpecializari();
        List<int> intrebariRaspunseMaiTârziu = new List<int>();
        List<Itemi> intrebariRaspuns = new List<Itemi>();
        List<Itemi> listaRaspundeMaiTarziu = new List<Itemi>();
        List<RezultateEvaluare> listaRezultateEvaluare = ConexiuneBazaDeDate.ExtrageRezultateEvaluare();
        List<Evaluare> lisaEvaluare = ConexiuneBazaDeDate.ExtragereEvaluare();
        List<IEREI> listaIntrebariRspunsI = new List<IEREI>();
        List<Cont> listaCont = ConexiuneBazaDeDate.ExtragereConturi();
        List<Catalog> listaCatalog = ConexiuneBazaDeDate.ExtragereCatalog();
        List<string> raspunsuriSelectate = new List<string>();
        Itemi itemRT;
        Itemi itemRaspuns;
        int idE;
        int idEvaluare;
        string raspunsCorect1;
        string raspunsCorect2;
        string raspunsCorect3;
        float punctaj = 1;
        const float nota9 = 9;
        int idRezultat;
        int idItem;
        int timpRamas = 0;
        string userName = Form1.UserName1;
        int itemAnterior = 0;
        string matr = "";
        int x = 1;
        string raspuns;
        int k = 1;
        //
        float nrItemi;
        float punctajIntrbare = 0;
        int idRezC;
        int tipItem = 0;  //tip item 0-radioButton 1-checkBox
        int douaRaspunsuri = 0;
        int treiRaspuns = 0;
        int itemInCurs;
        string raspunsSelectat1 = null;
        string raspunsSelectat2 = null;
        string raspunsSelectat3 = null;
        int incrementare = 0;
        int intrebariUlterioare;
        int c = 0;
        public FormEvaluari(List<IEREI> listaIntrebariRspunsI, int idE, string nrMat)
        {
            InitializeComponent();
            this.listaIntrebariRspunsI = listaIntrebariRspunsI;
            this.idE = idE;
            int timpEvaluat = lisaEvaluare.Where(i => i.IdEvaluare == idE).Select(t => t.TimpEvaluare).First();
            float nota1 = listaRezultateEvaluare.Where(i => i.IdEvaluare == idE).Select(n => n.NotaEvaluare).First();
            matr = nrMat;
            activitateControale();
            CompletareNume();
            labelNota.Text = "Nota: " + nota1;
            labelTimpRamas.Text = "Timpul acordat a fost de: " + timpEvaluat + " minute";
            string denumireEv = lisaEvaluare.Where(i => i.IdEvaluare == idE).Select(d => d.DenumireEvaluare).First();
            labelDenumireEvalure.Text = denumireEv.ToUpper();
            labelNota.Visible = true;
            label3Slash.Visible = true;
            label3NrItemi.Visible = true;

            label3NrItemi.Text = listaIntrebariRspunsI.Count().ToString();
            AfiseazaIntrebari();

        }
        public FormEvaluari(List<int> listaIntrebari, int idEvaluare)
        {

            InitializeComponent();
            string userName = Form1.UserName1;
            CompletareNume();

            // ItoarcereRaspuns();
            this.idEvaluare = idEvaluare;
            this.listaIntrebari = listaIntrebari;

            nrItemi = listaIntrebari.Count();

            punctajIntrbare = nota9 / nrItemi;

            intrebari();
            creareRezultatEvalure();
            label3NrItemi.Visible = true;
            label3NrItemi.Text = nrItemi.ToString();
            label3Slash.Visible = true;
            loadTimp();
        }

        int pozitieCurenta = 0;
        int pozitiaCurenta1 = 0;
        // pozitieCurentaI reprezinta varibila care parcurge intrebarile la care s-a raspuns;
        int pozitieCurentaI = 0;

        public void AfiseazaIntrebari()
        {

            douaRaspunsuri = 0;
            treiRaspuns = 0;
            pictureBoxAtasareItem.Image = null;

            if (pozitiaCurenta1 < listaIntrebariRspunsI.Count())
            {
                foreach (Control c in groupBoxRaspunsuri.Controls)
                {
                    if (c is RadioButton)
                    {
                        RadioButton rb = c as RadioButton;
                        rb.BackColor = Color.Transparent;
                        rb.Checked = false;
                    }
                    if (c is CheckBox)
                    {
                        CheckBox ch = c as CheckBox;
                        ch.BackColor = Color.Transparent;
                        ch.Checked = false;
                    }
                }

                int idIntrebareCurenta = listaIntrebariRspunsI[pozitieCurentaI].IdItem;
                IEREI itemActual = listaIntrebariRspunsI.FirstOrDefault(item => item.IdItem == idIntrebareCurenta);
                if (itemActual.RaspunsCorect1 != null && itemActual.RaspunsCorect2 != null && itemActual.RaspunsCorect3 == null)
                {
                    douaRaspunsuri = 1;
                }
                else if (itemActual.RaspunsCorect1 != null && itemActual.RaspunsCorect2 != null && itemActual.RaspunsCorect3 != null)
                {
                    treiRaspuns = 1;
                }
                //if (itemActual.TipItem == 0)
                //{
                //    tipItem = 0;
                //    foreach (Control c in groupBoxRaspunsuri.Controls)
                //    {
                //        if (c is CheckBox)
                //        {
                //            CheckBox ch = c as CheckBox;
                //            if (ch.Visible == true)
                //            {
                //                ch.Visible = false;
                //            }
                //        }
                //    }
                //    radioButtonRaspuns1.Visible = true;
                //    radioButtonRaspuns2.Visible = true;
                //    radioButtonRaspuns3.Visible = true;
                //    if (itemActual != null)
                //    {
                //        labelNrItem.Text = $"{pozitieCurentaI + 1}";
                //        richTextBoxEnuntItem.Text = itemActual.EnuntItem;
                //        radioButtonRaspuns1.Text = itemActual.Raspuns1;
                //        radioButtonRaspuns2.Text = itemActual.Raspuns2;
                //        radioButtonRaspuns3.Text = itemActual.Raspuns3;
                //        if (itemActual.Raspuns4 != null && itemActual.Raspuns5 == null)
                //        {
                //            radioButtonRaspuns4.Text = itemActual.Raspuns4;
                //            radioButtonRaspuns4.Visible = true;
                //        }
                //        if (itemActual.Raspuns4 != null && itemActual.Raspuns5 != null)
                //        {
                //            radioButtonRaspuns4.Text = itemActual.Raspuns4;
                //            radioButtonRaspuns5.Text = itemActual.Raspuns5;
                //            radioButtonRaspuns4.Visible = true;
                //            radioButtonRaspuns5.Visible = true;
                //        }
                //        if(itemActual.Raspuns4 == null && itemActual.Raspuns5 == null)
                //        {
                //            radioButtonRaspuns4.Visible = false;
                //            radioButtonRaspuns5.Visible = false;
                //        }
                //        raspunsCorect1 = itemActual.RaspunsCorect1;
                //        foreach (IEREI iEREI in listaIntrebariRspunsI)
                //        {
                //            if (iEREI.IdItem == itemActual.IdItem)
                //            {
                //                foreach (Control c in groupBoxRaspunsuri.Controls)
                //                {
                //                    if (c is RadioButton)
                //                    {
                //                        RadioButton radioButton = c as RadioButton;

                //                        if (radioButton.Text == iEREI.RaspunsAles1)
                //                        {
                //                            radioButton.Checked = true;

                //                            if (iEREI.RaspunsAles1 == raspunsCorect1)
                //                            {
                //                                radioButton.BackColor = Color.FromName("Green");


                //                            }
                //                            else if (iEREI.RaspunsAles1 != raspunsCorect1)
                //                            {
                //                                radioButton.BackColor = Color.FromName("Red");
                //                            }
                //                        }
                //                        if (radioButton.Text == raspunsCorect1)
                //                        {
                //                            radioButton.BackColor = Color.FromName("Green");

                //                        }
                //                    }

                //                }

                //            }
                //        }
                //        if (itemActual.PozaIten != null)
                //        {
                //            pictureBoxAtasareItem.Image = Image.FromFile(itemActual.PozaIten);
                //        }
                //        pozitieCurentaI++;
                //    }
                //    if (pozitieCurentaI == listaIntrebariRspunsI.Count())
                //    {
                //        pozitieCurentaI = 0;
                //    }
                //}
                if (itemActual.TipItem == 0)
                {

                    tipItem = 0;
                    foreach (Control c in groupBoxRaspunsuri.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox ch = c as CheckBox;
                            ch.Visible = false;
                        }
                    }
                    radioButtonRaspuns1.Visible = true;
                    radioButtonRaspuns2.Visible = true;
                    radioButtonRaspuns3.Visible = true;
                    if (itemActual != null)
                    {
                        labelNrItem.Text = $"{pozitieCurentaI + 1}";
                        richTextBoxEnuntItem.Text = itemActual.EnuntItem;
                        radioButtonRaspuns1.Text = itemActual.Raspuns1;
                        radioButtonRaspuns2.Text = itemActual.Raspuns2;
                        radioButtonRaspuns3.Text = itemActual.Raspuns3;
                        if (!string.IsNullOrEmpty(itemActual.Raspuns4))
                        {
                            radioButtonRaspuns4.Text = itemActual.Raspuns4;
                            radioButtonRaspuns4.Visible = true;
                        }
                        else
                        {
                            radioButtonRaspuns4.Visible = false;
                        }
                        if (!string.IsNullOrEmpty(itemActual.Raspuns5))
                        {
                            radioButtonRaspuns5.Text = itemActual.Raspuns5;
                            radioButtonRaspuns5.Visible = true;
                        }
                        else
                        {
                            radioButtonRaspuns5.Visible = false;
                        }
                        raspunsCorect1 = itemActual.RaspunsCorect1;
                        foreach (IEREI iEREI in listaIntrebariRspunsI)
                        {
                            if (iEREI.IdItem == itemActual.IdItem)
                            {
                                foreach (Control c in groupBoxRaspunsuri.Controls)
                                {
                                    if (c is RadioButton)
                                    {
                                        RadioButton radioButton = c as RadioButton;

                                        if (radioButton.Text == iEREI.RaspunsAles1 || radioButton.Text == iEREI.RaspunsAles2)
                                        {
                                            radioButton.Checked = true;

                                            if (iEREI.RaspunsAles1 == raspunsCorect1)
                                            {
                                                radioButton.BackColor = Color.FromName("Green");
                                            }
                                            else if (iEREI.RaspunsAles1 != raspunsCorect1)
                                            {
                                                radioButton.BackColor = Color.FromName("Red");
                                            }
                                        }
                                        if (radioButton.Text == raspunsCorect1)
                                        {
                                            radioButton.BackColor = Color.FromName("Green");
                                        }
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(itemActual.PozaItem))
                        {
                            pictureBoxAtasareItem.Image = Image.FromFile(itemActual.PozaItem);
                        }
                        pozitieCurentaI++;
                    }
                    if (pozitieCurentaI == listaIntrebariRspunsI.Count())
                    {
                        pozitieCurentaI = 0;
                    }
                }

                //else if (itemActual.TipItem == 1)
                //{

                //    tipItem = 1;
                //    foreach (Control c in groupBoxRaspunsuri.Controls)
                //    {
                //        if (c is RadioButton)
                //        {
                //            RadioButton rb = c as RadioButton;
                //            if (rb.Visible == true)
                //            {
                //                rb.Visible = false;
                //            }
                //        }
                //    }
                //    checkBox1.Visible = true;
                //    checkBox2.Visible = true;
                //    checkBox3.Visible = true;
                //    if (itemActual != null)
                //    {
                //        labelNrItem.Text = $"{pozitieCurentaI + 1}";
                //        richTextBoxEnuntItem.Text = itemActual.EnuntItem;
                //        checkBox1.Text = itemActual.Raspuns1;
                //        checkBox2.Text = itemActual.Raspuns2;
                //        checkBox3.Text = itemActual.Raspuns3;
                //        if (itemActual.Raspuns4 != "" && itemActual.Raspuns5 == "")
                //        {
                //            checkBox4.Text = itemActual.Raspuns4;
                //            checkBox4.Visible = true;
                //        }
                //        if (itemActual.Raspuns4 != "" && itemActual.Raspuns5 != "")
                //        {
                //            checkBox4.Text = itemActual.Raspuns4;
                //            checkBox5.Text = itemActual.Raspuns5;
                //            checkBox4.Visible = true;
                //            checkBox5.Visible = true;
                //        }
                //        raspunsCorect1 = itemActual.RaspunsCorect1;
                //        raspunsCorect2 = itemActual.RaspunsCorect2;
                //        raspunsCorect3 = itemActual.RaspunsCorect3;
                //        foreach (IEREI iEREI in listaIntrebariRspunsI)
                //        {
                //            if (iEREI.IdItem == itemActual.IdItem)
                //            {
                //                foreach (Control c in groupBoxRaspunsuri.Controls)
                //                {
                //                    if (c is CheckBox)
                //                    {
                //                        CheckBox checkBox = c as CheckBox;
                //                        if (douaRaspunsuri == 1)
                //                        {
                //                            if (checkBox.Text == iEREI.RaspunsAles1 && checkBox.Text == iEREI.RaspunsAles2)
                //                            {
                //                                checkBox.Checked = true;

                //                                if (iEREI.RaspunsAles1 == raspunsCorect1 && iEREI.RaspunsAles2 == raspunsCorect2)
                //                                {
                //                                    checkBox.BackColor = Color.FromName("Green");


                //                                }
                //                                if (iEREI.RaspunsAles1 != raspunsCorect1 && iEREI.RaspunsAles2 != raspunsCorect2)
                //                                {
                //                                    checkBox.BackColor = Color.FromName("Red");
                //                                }
                //                                if (iEREI.RaspunsAles1 == raspunsCorect1)
                //                                {
                //                                    checkBox.BackColor = Color.FromName("Green");
                //                                }
                //                                if (iEREI.RaspunsAles1 != raspunsCorect1)
                //                                {
                //                                    checkBox.BackColor = Color.FromName("Red");
                //                                }
                //                                if (iEREI.RaspunsAles1 == raspunsCorect1 && iEREI.RaspunsAles2 == raspunsCorect2)
                //                                {
                //                                    checkBox.BackColor = Color.FromName("Green");
                //                                }
                //                            }

                //                            if (iEREI.RaspunsAles1 != raspunsCorect1 && iEREI.RaspunsAles2 != raspunsCorect2)
                //                            {
                //                                checkBox.BackColor = Color.FromName("Red");
                //                            }
                //                            if (iEREI.RaspunsAles1 == raspunsCorect1)
                //                            {
                //                                checkBox.BackColor = Color.FromName("Green");
                //                            }
                //                            if (iEREI.RaspunsAles1 != raspunsCorect1)
                //                            {
                //                                checkBox.BackColor = Color.FromName("Red");
                //                            }
                //                            if (iEREI.RaspunsAles1 == raspunsCorect1 && iEREI.RaspunsAles2 == raspunsCorect2)
                //                            {
                //                                checkBox.BackColor = Color.FromName("Green");
                //                            }

                //                        }
                //                    }

                //                }

                //            }
                //        }
                //        if (itemActual.PozaIten != null)
                //        {
                //            pictureBoxAtasareItem.Image = Image.FromFile(itemActual.PozaIten);
                //        }
                //        pozitieCurentaI++;
                //    }
                //    if (pozitieCurentaI == listaIntrebariRspunsI.Count())
                //    {
                //        pozitieCurentaI = 0;
                //    }
                //}
                if (itemActual.TipItem == 1)
                {
                    tipItem = 1;
                    foreach (Control c in groupBoxRaspunsuri.Controls)
                    {
                        if (c is RadioButton)
                        {
                            RadioButton rb = c as RadioButton;
                            if (rb.Visible == true)
                            {
                                rb.Visible = false;
                            }
                        }
                    }

                    checkBox1.Visible = true;
                    checkBox2.Visible = true;
                    checkBox3.Visible = true;
                    if (itemActual != null)
                    {
                        labelNrItem.Text = $"{pozitieCurentaI + 1}";
                        richTextBoxEnuntItem.Text = itemActual.EnuntItem;
                        checkBox1.Text = itemActual.Raspuns1;
                        checkBox2.Text = itemActual.Raspuns2;
                        checkBox3.Text = itemActual.Raspuns3;
                        if (!string.IsNullOrEmpty(itemActual.Raspuns4))
                        {
                            checkBox4.Text = itemActual.Raspuns4;
                            checkBox4.Visible = true;
                        }
                        if (!string.IsNullOrEmpty(itemActual.Raspuns5))
                        {
                            checkBox5.Text = itemActual.Raspuns5;
                            checkBox5.Visible = true;
                        }
                        raspunsCorect1 = itemActual.RaspunsCorect1;
                        raspunsCorect2 = itemActual.RaspunsCorect2;
                        raspunsCorect3 = itemActual.RaspunsCorect3;
                        foreach (IEREI iEREI in listaIntrebariRspunsI)
                        {

                            if (iEREI.IdItem == itemActual.IdItem)
                            {
                                foreach (Control c in groupBoxRaspunsuri.Controls)
                                {
                                    if (c is CheckBox)
                                    {
                                        CheckBox checkBox = c as CheckBox;
                                        // Resetăm starea "checked" pentru toate CheckBox-urile
                                        checkBox.Checked = false;
                                        // Verificăm dacă textul CheckBox-ului este în concordanță cu răspunsul ales
                                        if (checkBox.Text == iEREI.RaspunsAles1 || checkBox.Text == iEREI.RaspunsAles2 || checkBox.Text == iEREI.RaspunsAles3)
                                        {
                                            checkBox.Checked = true;
                                            if (checkBox.Text == raspunsCorect1 || checkBox.Text == raspunsCorect2 || checkBox.Text == raspunsCorect3)
                                            {
                                                checkBox.BackColor = Color.Green;
                                            }
                                            else if (checkBox.Checked)
                                            {

                                                checkBox.BackColor = Color.Red;
                                            }
                                        }
                                        else
                                        {
                                            if (checkBox.Text == raspunsCorect1 || checkBox.Text == raspunsCorect2 || checkBox.Text == raspunsCorect3)
                                            {
                                                checkBox.BackColor = Color.Green;
                                            }
                                            else
                                            {
                                                checkBox.BackColor = Color.White;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(itemActual.PozaItem))
                        {
                            pictureBoxAtasareItem.Image = Image.FromFile(itemActual.PozaItem);
                        }
                        pozitieCurentaI++;
                    }
                    if (pozitieCurentaI == listaIntrebariRspunsI.Count())
                    {
                        pozitieCurentaI = 0;
                    }
                }


            }
        }
        void loadTimp()
        {
            timpRamas = lisaEvaluare.Where(i => i.IdEvaluare == idEvaluare).Select(t => t.TimpEvaluare).First();
            timerTimpRamas.Start();
            string denumireEvaluare = lisaEvaluare.Where(i => i.IdEvaluare == idEvaluare).Select(d => d.DenumireEvaluare).First();
            labelDenumireEvalure.Text = denumireEvaluare.ToUpper();
            labelTimpRamas.Text = "Timp ramas:" + timpRamas;
        }
        //public void intrebari()
        //{
        //    if (pozitieCurenta < listaIntrebari.Count)
        //    {
        //        int idIntrebareCurenta = listaIntrebari[pozitieCurenta];
        //        Itemi itemCurent = listaItemi.FirstOrDefault(item => item.IdItem == idIntrebareCurenta);
        //        itemInCurs = itemCurent.IdItem;
        //        if (itemCurent.RaspunsCorect1 != "" && itemCurent.RaspunsCorect2 != "" && itemCurent.RaspunsCorect3 == "")
        //        {
        //            douaRaspunsuri = 1;
        //        }
        //        else if (itemCurent.RaspunsCorect1 != "" && itemCurent.RaspunsCorect2 != "" && itemCurent.RaspunsCorect3 != "")
        //        {
        //            treiRaspuns = 1;
        //        }
        //        if (itemCurent.TipItem == 0)
        //        {
        //            tipItem = 0;
        //            if (itemCurent != null)
        //            {
        //                radioButtonRaspuns1.Visible = true;
        //                radioButtonRaspuns2.Visible = true;
        //                radioButtonRaspuns3.Visible = true;
        //                itemAnterior = idIntrebareCurenta;
        //                labelNrItem.Text = $"{pozitieCurenta + 1}";
        //                richTextBoxEnuntItem.Text = itemCurent.EnuntItem;
        //                radioButtonRaspuns1.Text = itemCurent.Raspuns1;
        //                radioButtonRaspuns2.Text = itemCurent.Raspuns2;
        //                radioButtonRaspuns3.Text = itemCurent.Raspuns3;

        //                if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 == "")
        //                {
        //                    radioButtonRaspuns4.Text = itemCurent.Raspuns4;
        //                    radioButtonRaspuns4.Visible = true;
        //                }
        //                if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 != "")
        //                {
        //                    radioButtonRaspuns4.Text = itemCurent.Raspuns4;
        //                    radioButtonRaspuns5.Text = itemCurent.Raspuns5;
        //                    radioButtonRaspuns4.Visible = true;
        //                    radioButtonRaspuns5.Visible = true;
        //                }
        //                //   raspunsCorect = itemCurent.RaspunsCorect;
        //                if (itemCurent.PozaItem != null)
        //                {
        //                    pictureBoxAtasareItem.Image = Image.FromFile(itemCurent.PozaItem);

        //                }
        //                raspunsCorect1 = itemCurent.RaspunsCorect1;

        //                intrebariRaspuns.Add(itemCurent);
        //                itemiAnteriori.Add(itemAnterior);

        //                pozitieCurenta++; // Incrementați poziția pentru a trece la următoarea întrebare
        //            }

        //            if (pozitieCurenta > listaIntrebari.Count)
        //            {
        //                if (pozitiaCurenta1 <= listaRaspundeMaiTarziu.Count + 1)
        //                {
        //                    if (listaRaspundeMaiTarziu.Count == 0)
        //                    {
        //                        return;
        //                    }
        //                    label3NrItemi.Visible = false;
        //                    label3Slash.Visible = false;
        //                    Itemi intreabreCurentaRaspundeMaiTarziu = listaRaspundeMaiTarziu[pozitiaCurenta1];
        //                    Itemi itemRaspundeT = listaItemi.FirstOrDefault(item => item.IdItem == intreabreCurentaRaspundeMaiTarziu.IdItem);
        //                    itemRT = itemRaspundeT;

        //                    if (itemRaspundeT != null)
        //                    {
        //                        itemAnterior = intreabreCurentaRaspundeMaiTarziu.IdItem;
        //                        labelNrItem.Text = $"{pozitiaCurenta1 + 1}";
        //                        richTextBoxEnuntItem.Text = itemRaspundeT.EnuntItem;
        //                        radioButtonRaspuns1.Text = itemRaspundeT.Raspuns1;
        //                        radioButtonRaspuns2.Text = itemRaspundeT.Raspuns2;
        //                        radioButtonRaspuns3.Text = itemRaspundeT.Raspuns3;
        //                        radioButtonRaspuns4.Text = itemRaspundeT.Raspuns4;
        //                        radioButtonRaspuns5.Text = itemRaspundeT.Raspuns5;
        //                        //   raspunsCorect = itemRaspundeT.RaspunsCorect;
        //                        if (itemRaspundeT.PozaItem != null)
        //                        {
        //                            pictureBoxAtasareItem.Image = Image.FromFile(itemRaspundeT.PozaItem);
        //                        }
        //                    }
        //                    pozitiaCurenta1++;
        //                }

        //            }
        //        }
        //        else if (itemCurent.TipItem == 1)
        //        {
        //            tipItem = 1;
        //            if (itemCurent != null)
        //            {
        //                itemAnterior = idIntrebareCurenta;
        //                labelNrItem.Text = $"{pozitieCurenta + 1}";
        //                richTextBoxEnuntItem.Text = itemCurent.EnuntItem;
        //                checkBox1.Text = itemCurent.Raspuns1;
        //                checkBox2.Text = itemCurent.Raspuns2;
        //                checkBox3.Text = itemCurent.Raspuns3;

        //                if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 == "")
        //                {
        //                    checkBox4.Text = itemCurent.Raspuns4;
        //                    checkBox4.Visible = true;
        //                }
        //                if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 != "")
        //                {
        //                    checkBox4.Text = itemCurent.Raspuns4;
        //                    checkBox5.Text = itemCurent.Raspuns5;
        //                    checkBox4.Visible = true;
        //                    checkBox5.Visible = true;
        //                }
        //                //   raspunsCorect = itemCurent.RaspunsCorect;
        //                if (itemCurent.PozaItem != null)
        //                {
        //                    pictureBoxAtasareItem.Image = Image.FromFile(itemCurent.PozaItem);

        //                }
        //                raspunsCorect1 = itemCurent.RaspunsCorect1;
        //                raspunsCorect2 = itemCurent.RaspunsCorect2;
        //                raspunsCorect3 = itemCurent.RaspunsCorect3;
        //                intrebariRaspuns.Add(itemCurent);
        //                itemiAnteriori.Add(itemAnterior);

        //                pozitieCurenta++; // Incrementați poziția pentru a trece la următoarea întrebare
        //            }

        //            if (pozitieCurenta > listaIntrebari.Count)
        //            {
        //                if (pozitiaCurenta1 <= listaRaspundeMaiTarziu.Count + 1)
        //                {
        //                    if (listaRaspundeMaiTarziu.Count == 0)
        //                    {
        //                        return;
        //                    }
        //                    label3NrItemi.Visible = false;
        //                    label3Slash.Visible = false;
        //                    Itemi intreabreCurentaRaspundeMaiTarziu = listaRaspundeMaiTarziu[pozitiaCurenta1];
        //                    Itemi itemRaspundeT = listaItemi.FirstOrDefault(item => item.IdItem == intreabreCurentaRaspundeMaiTarziu.IdItem);
        //                    itemRT = itemRaspundeT;

        //                    if (itemRaspundeT != null)
        //                    {
        //                        itemAnterior = intreabreCurentaRaspundeMaiTarziu.IdItem;
        //                        labelNrItem.Text = $"{pozitiaCurenta1 + 1}";
        //                        richTextBoxEnuntItem.Text = itemRaspundeT.EnuntItem;
        //                        checkBox1.Text = itemCurent.Raspuns1;
        //                        checkBox2.Text = itemCurent.Raspuns2;
        //                        checkBox3.Text = itemCurent.Raspuns3;

        //                        if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 == "")
        //                        {
        //                            checkBox4.Text = itemCurent.Raspuns4;
        //                            checkBox4.Visible = true;
        //                        }
        //                        if (itemCurent.Raspuns4 != "" && itemCurent.Raspuns5 != "")
        //                        {
        //                            checkBox4.Text = itemCurent.Raspuns4;
        //                            checkBox5.Text = itemCurent.Raspuns5;
        //                            checkBox4.Visible = true;
        //                            checkBox5.Visible = true;
        //                        }
        //                        //   raspunsCorect = itemRaspundeT.RaspunsCorect;
        //                        if (itemRaspundeT.PozaItem != null)
        //                        {
        //                            pictureBoxAtasareItem.Image = Image.FromFile(itemRaspundeT.PozaItem);
        //                        }
        //                    }
        //                    pozitiaCurenta1++;
        //                }

        //            }

        //        }
        //    }


        //}




        void CompletareNume()
        {

            int idGrupa = 0;
            string codSpec = "";
            string numeSpec = "";
            string numeComplet = "";
            userName = Form1.UserName1;
            foreach (AsociereStudentContGrupa asociereStudentContGrupa in listaasociereStudentContGrupa)
            {
                if (asociereStudentContGrupa.UserName == userName)
                {
                    matr = asociereStudentContGrupa.NrMatricol;
                    idGrupa = asociereStudentContGrupa.IdGrupa;
                }
                if (asociereStudentContGrupa.NrMatricol == matr)
                {
                    idGrupa = asociereStudentContGrupa.IdGrupa;
                }
                foreach (Student student in listaStudent)
                {
                    if (student.NrMatricol == matr)
                    {

                        numeComplet = student.NumeStudent + " " + student.PrenumeStudent;

                        labelNume.Text = numeComplet;

                    }

                }
            }
            foreach (Grupa grupa in listGrupa)
            {
                if (idGrupa == grupa.IdGrupa)
                {
                    codSpec = grupa.CodSpecializare;
                }
            }
            foreach (Specializare specializare in listSpecializare)
            {
                if (specializare.CodSpecializare.Trim().ToUpper() == codSpec.Trim().ToUpper())
                {
                    numeSpec = specializare.NumeSpecializare;
                    labelSpecializare.Text = $"{numeSpec}";
                }
            }

        }
        void creareRezultatEvalure()
        {
            if (listaRezultateEvaluare.Count == 0)
            {
                idRezultat = 1;
                idRezC = 1;
            }
            else
            {
                idRezultat = listaRezultateEvaluare.Max(i => i.IdRezultat) + 1;
                idRezC = idRezultat;
            }

            RezultateEvaluare rezultateEvaluare = new RezultateEvaluare()
            {
                IdRezultat = idRezultat,
                IdEvaluare = idEvaluare,
                NrMatricol = matr,
                NotaEvaluare = 0

            };


            ConexiuneBazaDeDate.InsereazaRezultateEvaluare(rezultateEvaluare);



        }
        void ascundeControale()
        {
            richTextBoxEnuntItem.Visible = false;
            groupBoxRaspunsuri.Visible = false;
            buttonRaspundeMaiTarziu.Visible = false;
            buttonRaspuns.Visible = false;
            labelItemNr.Visible = false;
            labelNrItem.Visible = false;

        }
        private void buttonRaspuns_Click(object sender, EventArgs e)
        {
            int n = 0;
            alegeRaspunsCorect();
            pictureBoxAtasareItem.Image = null;
            if (tipItem == 0)
            {
                foreach (Control rb in groupBoxRaspunsuri.Controls)
                {

                    if (rb is RadioButton)
                    {
                        if (((RadioButton)rb).Checked == true)
                        {
                            n = 1;

                        }
                    }
                }
                if (n == 0)
                {
                    MessageBox.Show("Alege un  raspuns");
                    raspunsuriSelectate.Clear();
                    return;
                }
            }
            else if (tipItem == 1)
            {
                foreach (Control ch in groupBoxRaspunsuri.Controls)
                {

                    if (ch is CheckBox)
                    {
                        if (((CheckBox)ch).Checked == true)
                        {
                            n++;

                        }
                    }
                }
                if (n == 0 || n < 2)
                {
                    MessageBox.Show("Alege cel putin 2 raspunsuri ");
                    raspunsuriSelectate.Clear();
                    return;
                }
            }
            if (pozitieCurenta == listaIntrebari.Count())
            {
                pozitieCurenta = listaIntrebari.Count() + 1;
            }
            idItem = listaItemi.Where(i => i.IdItem == itemInCurs).Select(i => i.IdItem).First();
            if (tipItem == 0)
            {
                if (raspunsCorect1 == raspunsuriSelectate[0])
                {
                    punctaj += punctajIntrbare;
                }

            }
            if (tipItem == 1)
            {
                if (douaRaspunsuri == 1)
                {
                    if (raspunsuriSelectate.Count == 2 && (raspunsCorect1 == raspunsuriSelectate[0] || raspunsCorect1 == raspunsuriSelectate[1]) &&
                       (raspunsCorect2 == raspunsuriSelectate[0] || raspunsCorect2 == raspunsuriSelectate[1]))

                    {
                        punctaj += punctajIntrbare;
                    }
                }
                if (treiRaspuns == 1)
                {
                    if (raspunsuriSelectate.Count == 3 && (raspunsCorect1 == raspunsuriSelectate[0] || raspunsCorect1 == raspunsuriSelectate[1] || raspunsCorect1 == raspunsuriSelectate[1]) && (raspunsCorect2 == raspunsuriSelectate[0] || raspunsCorect2 == raspunsuriSelectate[1] || raspunsCorect2 == raspunsuriSelectate[2])
                        && (raspunsCorect3 == raspunsuriSelectate[0] || raspunsCorect3 == raspunsuriSelectate[1] || raspunsCorect3 == raspunsuriSelectate[2]))
                    {
                        punctaj += punctajIntrbare;
                    }
                }
            }


            ///////////////

            ItemiEvaluare itemiEvaluare = new ItemiEvaluare()
            {
                IdRezultat = idRezultat,
                IdItem = idItem,
                RaspunsAles1 = raspunsSelectat1,
                RaspunsAles2 = raspunsSelectat2,
                RaspunsAles3 = raspunsSelectat3


            };


            ConexiuneBazaDeDate.InserareItemEvluare(itemiEvaluare);


            //if (pozitiaCurenta1 == listaRaspundeMaiTarziu.Count)
            //{
            //    labelItemNr.Text = $"{Math.Round(punctaj, 1)}";
            //}
            if (itemRT != null && listaRaspundeMaiTarziu.Contains(itemRT))
            {

                listaRaspundeMaiTarziu.Remove(itemRT);
                if (pozitiaCurenta1 + 1 >= listaRaspundeMaiTarziu.Count)
                {
                    pozitiaCurenta1 = 0;
                }
            }
            int idE = idEvaluare;

            if (listaIntrebari.Count == x)
            {
                int blocat = 0;
                ascundeControale();
                buttonTerminat.Visible = true;
                labelT.Visible = true;
                labelF.Visible = true;
                label3Slash.Visible = false;
                label3NrItemi.Visible = false;
                pictureBoxAnunt.Visible = false;
                if (punctaj >= 5)
                {
                    blocat = 1;
                }

                ConexiuneBazaDeDate.UpdateNota((float)Math.Round(punctaj,2), idE);
                int idNotaCatalog = 0;
                if (listaCatalog.Count() < 1)
                {
                    idNotaCatalog = 0;

                }
                else
                {
                    idNotaCatalog = listaCatalog.Max(i => i.IdNotaCatalog) + 1;
                }
                Catalog catalog = new Catalog()
                {
                    IdNotaCatalog = idNotaCatalog,
                    IdRezultat = idRezC,
                    Blocat = blocat,
                    NotaCatalog = (float)Math.Round(punctaj, MidpointRounding.AwayFromZero)
                };
                ConexiuneBazaDeDate.InserareNotaCatalog(catalog);
            }
            x++;

            if (listaRaspundeMaiTarziu == null)
            {
                return;
            }
            raspunsuriSelectate.Clear();
            intrebari();
            curatareCntroale();
            
        }

        //void ItoarcereRaspuns()
        //{
        //    foreach(Control control in groupBoxRaspunsuri.Controls)
        //    {
        //        if(control is RadioButton radioButton)
        //        {
        //            radioButton.CheckedChanged += RadioButton_CheckedChanged;
        //        }    
        //    }
        //}

        //private void RadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rbr = (RadioButton)sender;
        //    if(rbr.Checked)
        //    {
        //        raspuns = rbr.Text;
        //    }
        //}
        void curatareCntroale()
        {
            foreach (Control c in groupBoxRaspunsuri.Controls)
            {
                if (c is RadioButton)
                {
                    ((RadioButton)c).Checked = false;
                }
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }
        List<string> alegeRaspunsCorect()
        {
            if (tipItem == 0)
            {

                if (radioButtonRaspuns1.Checked)
                {
                    raspunsSelectat1 = radioButtonRaspuns1.Text;
                }
                else if (radioButtonRaspuns2.Checked)
                {
                    raspunsSelectat1 = radioButtonRaspuns2.Text;
                }
                else if (radioButtonRaspuns3.Checked)
                {
                    raspunsSelectat1 = radioButtonRaspuns3.Text;
                }
                else if (radioButtonRaspuns4.Checked)
                {
                    raspunsSelectat1 = radioButtonRaspuns4.Text;
                }
                else if (radioButtonRaspuns5.Checked)
                {
                    raspunsSelectat1 = radioButtonRaspuns5.Text;
                }
                raspunsuriSelectate.Add(raspunsSelectat1);

            }

            else if (tipItem == 1)
            {


                foreach (Control c in groupBoxRaspunsuri.Controls)
                {

                    {

                        CheckBox checkBox = c as CheckBox;

                        if (checkBox != null && checkBox.Checked)
                        {
                            raspunsuriSelectate.Add(checkBox.Text);
                        }
                    }
                }

                raspunsSelectat1 = raspunsuriSelectate.Count > 0 ? raspunsuriSelectate[0] : null;
                raspunsSelectat2 = raspunsuriSelectate.Count > 1 ? raspunsuriSelectate[1] : null;
                raspunsSelectat3 = raspunsuriSelectate.Count > 2 ? raspunsuriSelectate[2] : null;


            }
            return raspunsuriSelectate;


        }

        private void buttonRaspundeMaiTarziu_Click(object sender, EventArgs e)
        {
            raspundeMaiTarziu();
            curatareCntroale();
        }
        void raspundeMaiTarziu()
        {
            int idIntrebareCurenta = 0;
            pictureBoxAtasareItem.Image = null;
            if (pozitiaCurenta1 == listaRaspundeMaiTarziu.Count)
            {
                pozitiaCurenta1 = 0;
            }

            if (listaIntrebari.Count() >= pozitieCurenta)
            {
                idIntrebareCurenta = listaIntrebari[pozitieCurenta - 1];
            }
            else
            {
                idIntrebareCurenta = Convert.ToInt32(listaRaspundeMaiTarziu[pozitiaCurenta1].IdItem);
            }
            if (pozitieCurenta == listaIntrebari.Count)
            {
                pozitieCurenta = listaIntrebari.Count() + 1;
            }
            Itemi itemCurent = listaItemi.FirstOrDefault(item => item.IdItem == idIntrebareCurenta);
            if (!listaRaspundeMaiTarziu.Contains(itemCurent))
            {
                listaRaspundeMaiTarziu.Add(itemCurent);
            }
            else
            {
                listaRaspundeMaiTarziu.Remove(itemCurent);
                listaRaspundeMaiTarziu.Add(itemCurent);
                incrementare--;

            }
            intrebari();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormLogareS_P fls = new FormLogareS_P();
            this.Hide();
            fls.ShowDialog();
        }

        private void FormEvaluari_Load(object sender, EventArgs e)
        {


        }



        private void timerTimpRamas_Tick(object sender, EventArgs e)
        {
            timpRamas--;

            labelTimpRamas.Text = "Timp ramas:" + timpRamas;

            if (timpRamas == 2)
            {
                MessageBox.Show("M-ai aveti putin timp pana cand evaluarea v-a lua sfarsit");
                pictureBoxAnunt.Visible = true;
            }
            if (timpRamas == 0)
            {
                timerTimpRamas.Stop();
                MessageBox.Show("Evluarea a luat sfarsit.\nRaspunsurile salvate vor fi cele la care s-a raspuns pana" +
                    " in momentul de fata.");
                ConexiuneBazaDeDate.UpdateNota(punctaj, idEvaluare);
                FormVizualizareEvaluari fve = new FormVizualizareEvaluari();
                this.Hide();
                fve.ShowDialog();

            }
        }

        private void buttonInainte_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBoxRaspunsuri.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = c as CheckBox;
                    ch.Visible = false;

                }
            }
            AfiseazaIntrebari();

        }

        private void buttonIesire_Click(object sender, EventArgs e)
        {
            int tipCont = -1;
            foreach (Cont cont in listaCont)
            {
                if (cont.UserName == userName)
                {
                    tipCont = cont.TipCont;
                }
            }
            if (tipCont == 2)
            {
                FormVizualizareEvaluari fve = new FormVizualizareEvaluari();
                this.Hide();
                fve.ShowDialog();
            }
            else if (tipCont == 1)
            {
                FormEvaluariEleviP feep = new FormEvaluariEleviP();
                this.Hide();
                feep.ShowDialog();
            }
        }

        private void buttonInapo_Click(object sender, EventArgs e)
        {

            foreach (Control c in groupBoxRaspunsuri.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox ch = c as CheckBox;
                    ch.Visible = false;

                }
            }
            if (pozitieCurentaI == 0)
            {
                pozitieCurentaI = listaIntrebariRspunsI.Count();
            }

            if (pozitieCurentaI == 1)
            {
                MessageBox.Show("Nu exista intrebare cu index negativ");
                return;
            }
            else
            {
                pozitieCurentaI = pozitieCurentaI - 2;
            }

            AfiseazaIntrebari();

        }
        private void activitateControale()
        {
            buttonRaspundeMaiTarziu.Visible = false;
            buttonRaspuns.Visible = false;
            buttonInainte.Visible = true;
            buttonInapo.Visible = true;
            buttonIesire.Visible = true;
            labelNota.Visible = true;
            groupBoxRaspunsuri.Enabled = false;
        }
        public void intrebari()
        {

            foreach (Control c in groupBoxRaspunsuri.Controls)
            {
                if (c is RadioButton)
                {
                    ((RadioButton)c).Visible = false;
                }
                if (c is CheckBox)
                {
                    ((CheckBox)c).Visible = false;
                }
            }
            if (pozitieCurenta <= listaIntrebari.Count())
            {
                douaRaspunsuri = 0;
                treiRaspuns = 0;
                int idIntrebareCurenta = listaIntrebari[pozitieCurenta];
                Itemi itemCurent = listaItemi.FirstOrDefault(item => item.IdItem == idIntrebareCurenta);

                if (itemCurent != null)
                {
                    itemInCurs = itemCurent.IdItem;
                    if (!string.IsNullOrEmpty(itemCurent.RaspunsCorect1) && !string.IsNullOrEmpty(itemCurent.RaspunsCorect2) && string.IsNullOrEmpty(itemCurent.RaspunsCorect3))
                    {
                        douaRaspunsuri = 1;
                    }
                    else if (!string.IsNullOrEmpty(itemCurent.RaspunsCorect1) && !string.IsNullOrEmpty(itemCurent.RaspunsCorect2) && !string.IsNullOrEmpty(itemCurent.RaspunsCorect3))
                    {
                        treiRaspuns = 1;
                    }

                    itemAnterior = idIntrebareCurenta;
                    labelNrItem.Text = $"{pozitieCurenta + 1}";
                    richTextBoxEnuntItem.Text = itemCurent.EnuntItem;

                    if (itemCurent.TipItem == 0) // un singur raspuns
                    {
                        tipItem = 0;
                        SetRadioButtons(itemCurent);
                        foreach (Control c in groupBoxRaspunsuri.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox ch = c as CheckBox;
                                if (ch.Visible == true)
                                {
                                    ch.Visible = false;
                                }

                            }
                        }
                    }
                    else if (itemCurent.TipItem == 1) // raspuns multiplu
                    {
                        tipItem = 1;
                        foreach (Control c in groupBoxRaspunsuri.Controls)
                        {
                            if (c is RadioButton)
                            {
                                RadioButton rb = c as RadioButton;
                                if (rb.Visible == true)
                                {
                                    rb.Visible = false;
                                }
                            }
                        }
                        SetCheckBoxes(itemCurent);
                    }

                    if (!string.IsNullOrEmpty(itemCurent.PozaItem))
                    {
                        pictureBoxAtasareItem.Image = Image.FromFile(itemCurent.PozaItem);
                    }

                    raspunsCorect1 = itemCurent.RaspunsCorect1;
                    raspunsCorect2 = itemCurent.RaspunsCorect2;
                    raspunsCorect3 = itemCurent.RaspunsCorect3;

                    intrebariRaspuns.Add(itemCurent);
                    itemiAnteriori.Add(itemAnterior);

                    pozitieCurenta++; // Incrementam poziția pentru a trece la următoarea întrebare

                    // Verificăm dacă am ajuns la sfârșitul listei de întrebări


                }
            }
            if (pozitieCurenta > listaIntrebari.Count() && listaRaspundeMaiTarziu.Count > 0)
            {

                c++;
                if (listaRaspundeMaiTarziu.Count == 0)
                {
                    return;
                }
                if (c == 1)
                {
                    intrebariUlterioare = listaRaspundeMaiTarziu.Count();
                }

                pozitiaCurenta1 = 0; // Resetăm poziția pentru răspunsurile întârziate
                label3NrItemi.Visible = false;
                label3Slash.Visible = false;
                douaRaspunsuri = 0;
                treiRaspuns = 0;
                Itemi intrebareCurentaRaspundeMaiTarziu = listaRaspundeMaiTarziu[pozitiaCurenta1];
                Itemi itemRaspundeT = listaItemi.FirstOrDefault(item => item.IdItem == intrebareCurentaRaspundeMaiTarziu.IdItem);
                int idIntrebareCurenta = listaIntrebari[pozitiaCurenta1];
                Itemi itemCurent = listaItemi.FirstOrDefault(item => item.IdItem == idIntrebareCurenta);
                if (!string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect1) && !string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect2) && string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect3))
                {
                    douaRaspunsuri = 1;
                }
                else if (!string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect1) && !string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect2) && !string.IsNullOrEmpty(itemRaspundeT.RaspunsCorect3))
                {
                    treiRaspuns = 1;
                }

                raspunsCorect1 = itemRaspundeT.RaspunsCorect1;
                raspunsCorect2 = itemRaspundeT.RaspunsCorect2;
                raspunsCorect3 = itemCurent.RaspunsCorect3;
                itemRT = intrebareCurentaRaspundeMaiTarziu;
                itemInCurs = itemRaspundeT.IdItem;
                if (itemRaspundeT != null)
                {
                    SetItemForLaterResponse(itemRaspundeT);
                }
                // pozitiaCurenta1++;


            }
        }

        private void SetRadioButtons(Itemi item)
        {
            radioButtonRaspuns1.Visible = true;
            radioButtonRaspuns2.Visible = true;
            radioButtonRaspuns3.Visible = true;

            radioButtonRaspuns1.Text = item.Raspuns1;
            radioButtonRaspuns2.Text = item.Raspuns2;
            radioButtonRaspuns3.Text = item.Raspuns3;

            if (!string.IsNullOrEmpty(item.Raspuns4) && string.IsNullOrEmpty(item.Raspuns5))
            {
                radioButtonRaspuns4.Text = item.Raspuns4;
                radioButtonRaspuns4.Visible = true;
            }
            else if (!string.IsNullOrEmpty(item.Raspuns4) && !string.IsNullOrEmpty(item.Raspuns5))
            {
                radioButtonRaspuns4.Text = item.Raspuns4;
                radioButtonRaspuns5.Text = item.Raspuns5;
                radioButtonRaspuns4.Visible = true;
                radioButtonRaspuns5.Visible = true;
            }
        }

        private void SetCheckBoxes(Itemi item)
        {
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;

            checkBox1.Text = item.Raspuns1;
            checkBox2.Text = item.Raspuns2;
            checkBox3.Text = item.Raspuns3;

            if (!string.IsNullOrEmpty(item.Raspuns4) && string.IsNullOrEmpty(item.Raspuns5))
            {
                checkBox4.Text = item.Raspuns4;
                checkBox4.Visible = true;
            }
            else if (!string.IsNullOrEmpty(item.Raspuns4) && !string.IsNullOrEmpty(item.Raspuns5))
            {
                checkBox4.Text = item.Raspuns4;
                checkBox5.Text = item.Raspuns5;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
            }
        }

        private void SetItemForLaterResponse(Itemi item)
        {


            incrementare++;
            itemAnterior = item.IdItem;
            labelNrItem.Text = $"{incrementare}/{intrebariUlterioare}";
            richTextBoxEnuntItem.Text = item.EnuntItem;

            if (item.TipItem == 0) // o singura optiune
            {
                tipItem = 0;
                SetRadioButtons(item);
            }
            else if (item.TipItem == 1) // optiuni multiple
            {
                tipItem = 1;
                SetCheckBoxes(item);
            }

            if (!string.IsNullOrEmpty(item.PozaItem))
            {
                pictureBoxAtasareItem.Image = Image.FromFile(item.PozaItem);
            }
        }
    }
}














