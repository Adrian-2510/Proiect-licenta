using System.Windows.Forms;
namespace evaluarea_studentilor_in_sesiune
{
    public class CreeazaControale
    {
        public static RadioButton creareRb(string sir, int leftP, int topP)
        {
            RadioButton buttonFF = new RadioButton();

            buttonFF.AutoSize = true;
            buttonFF.Location = new System.Drawing.Point(leftP, topP);

            buttonFF.Text = sir;
            return buttonFF;

        }

    }
}
    


                    
                
    



    

