using evaluarea_studentilor_in_sesiune.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace evaluarea_studentilor_in_sesiune
{
    public class utility
    {
        public static bool verificaString(string sirText)
        {
            
            for (int i = 0; i < sirText.Length; i++)
            {
                
                if (!char.IsLetter(sirText[i]) && string.IsNullOrWhiteSpace(sirText) )
                {
                    return false;
                }
               
            }
            return true;

        }
        
        public static bool verificaDoarLitere(string sirText)
        {

            for (int i = 0; i < sirText.Length; i++)
            {

                if (!char.IsLetter(sirText[i]))
                {
                    return false;
                }

            }
            return true;

        }
        public static bool VerifCNP(string sir)
        {
            if (string.IsNullOrEmpty(sir) || sir.Length != 13)
            {
                return false;
            }

            foreach (char cifra in sir)
            {
                if (!char.IsDigit(cifra))
                {
                    return false;
                }
            }

            char primaCifra = sir[0];
            if (primaCifra != '1' && primaCifra != '2' && primaCifra != '5' && primaCifra != '6')
            {
                return false;
            }

            return true;
        }


        public static bool verificaIntreg(string sirText)
        {
            int numar;
            if (!int.TryParse(sirText, out numar))
            {
                return false;
            }

            return true;
        }
        public static bool verificaNote(string sirText)
        {
            int numar;
            if (!int.TryParse(sirText, out numar))
            {
                return false;
            }
            if (numar > 10 || numar < 1)
            {
                return false;
            }
            return true;
        }
        public static bool VerificareParola(string sir)
        {
            bool contineCifra = false;
            foreach (char caracater in sir)
            {
                if (char.IsDigit(caracater))
                {
                    contineCifra = true;
                    break;
                }
            }
 
            if(sir.Length>=6)
            {
                if(contineCifra)
                {
                    return true;
                }
               
            }
            else
            {
                return false;
            }
            return false;
          
            
            

        }

        public static string CripteazaParola(string parola)
        {
            using (SHA256 sha256 = SHA256.Create())
            {

               byte[] bytesParola = Encoding.UTF8.GetBytes(parola);


                byte[] hashBytes = sha256.ComputeHash(bytesParola);

                StringBuilder stringBuilder = new StringBuilder();
                int c = 0;
                foreach (byte b in hashBytes)
                {

                    stringBuilder.Append(b.ToString());
                    c = c + 1;
                    if (c == 15)
                    {

                        return stringBuilder.ToString(); 
                    }
                }
                return string.Empty;

            }
        }
         public static bool Decriptare(string parolaIntrodusa, string hashStocat)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                
                byte[] bytesParolaIntrodusa = Encoding.UTF8.GetBytes(parolaIntrodusa);

               
                byte[] hashBytesIntrodus = sha256.ComputeHash(bytesParolaIntrodusa);

               
                StringBuilder stringBuilderIntrodus = new StringBuilder();
                int c = 0;
                foreach (byte b in hashBytesIntrodus)
                {
                    stringBuilderIntrodus.Append(b.ToString());
                    c = c + 1;
                    if (c == 15)
                    {
                        return stringBuilderIntrodus.ToString() == hashStocat;

                    }
                }

                return false;
            }
        }
       public static int CalculateNeededHeight(TextBox textBox)
        {
            // Calculează înălțimea necesară bazată pe numărul de linii și înălțimea liniei
            int lineCount = textBox.GetLineFromCharIndex(textBox.TextLength) + 2;
            int lineHeight = TextRenderer.MeasureText("A", textBox.Font).Height;  // Înălțimea aproximativă a unei linii
            int neededHeight = lineCount * lineHeight;

            return neededHeight;
        }
        public static string FormatString(string text)
        {
            if (!string.IsNullOrWhiteSpace(text) && !text.StartsWith(" "))
            {
                // Transformă textul în litere mici și îl împarte în cuvinte
                string[] words = text.ToLower().Split(' ');

                // Parcurge fiecare cuvânt și transformă prima literă în majusculă
                for (int i = 0; i < words.Length; i++)
                {
                    if (!string.IsNullOrEmpty(words[i]))
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                    }
                }

                // Unește cuvintele înapoi într-un singur șir și îl returnează
                return string.Join(" ", words);
            }
            else
            {
                return text;
            }

        }



    }
}
