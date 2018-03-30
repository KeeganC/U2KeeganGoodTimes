/*Keegan Chan
 * 28 3 2018
 * U2KeeganGoodTimes
 * Converts 24hour time to other timezones
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U2KeeganGoodTimes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txbOutput.Text = "Ottawa\nVictoria\nEdmonton\nWinnipeg\nToronto\nHalifax\nSaint John's";

        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            //Create integer from Input
            string strInput = txbInput.Text;
            string strMinute;
            string strHour;
            int.TryParse(strInput, out int intInput);
            int intHour;
            int intMinute;

            //seperate hours and minutes
            if (strInput.Length == 3)
            {
                strHour = strInput.Substring(0, 1);
                int.TryParse(strHour, out intHour);
                strMinute = strInput.Substring(1, 2);
                int.TryParse(strMinute, out intMinute);
            }
            else if (strInput.Length == 4)
            {
                strHour = strInput.Substring(0, 2);
                int.TryParse(strHour, out intHour);
                strMinute = strInput.Substring(2, 2);
                int.TryParse(strMinute, out intMinute);
            }
            else
            {
                strHour = "0";
                int.TryParse(strHour, out intHour);
                strMinute = strInput;
                int.TryParse(strMinute, out intMinute);
            }


            //create strings for each city's time
            string strOttawaHour;
            string strVictoriaHour;
            string strEdmontenHour;
            string strWinnipegHour;
            string strTorontoHour;
            string strHalifaxHour;
            string strSaintJohnsHour;
            int intSaintJohnsHour;
            string strSaintJohnsMinute;
            int intSaintJohnsMinute;

            int tempTotalHour = intHour;

            //remove leading zeroes
            if(tempTotalHour == 0)
            {
                strOttawaHour = "";
                strTorontoHour = "";
            }
            else
            {
                strOttawaHour = tempTotalHour.ToString();
                strTorontoHour = tempTotalHour.ToString();
            }

            //add hours per timezones
            tempTotalHour = intHour + 1;

            //subtract days when needed
            if (tempTotalHour >= 24)
            {
                tempTotalHour = tempTotalHour - 24;
            }

            //keep checking to remove leading zeroes
            if (tempTotalHour == 0)
            {
                strHalifaxHour = "";
                intSaintJohnsHour = 0;
            }
            else
            {
                strHalifaxHour = tempTotalHour.ToString();
                intSaintJohnsHour = tempTotalHour;
            }

            tempTotalHour = intHour - 1;

            //add days when needed
            if (tempTotalHour < 0)
            {
                tempTotalHour = tempTotalHour + 24;
            }

            if (tempTotalHour == 0)
            {
                strWinnipegHour = "";
            }
            else
            {
                strWinnipegHour = tempTotalHour.ToString();
            }


            tempTotalHour = tempTotalHour - 1;

            if (tempTotalHour < 0)
            {
                tempTotalHour = tempTotalHour + 24;
            }

            if (tempTotalHour == 0)
            {
                strEdmontenHour = "";
            }
            else
            {
                strEdmontenHour = tempTotalHour.ToString();
            }

            tempTotalHour = tempTotalHour - 1;

            if (tempTotalHour < 0)
            {
                tempTotalHour = tempTotalHour + 24;
            }

            if (tempTotalHour == 0)
            {
                strVictoriaHour = "";
            }
            else
            {
                strVictoriaHour = tempTotalHour.ToString();
            }

            //add minutes for st John's
            intSaintJohnsMinute = intMinute + 30;

            //add hour if needed
            if (intSaintJohnsMinute >= 60)
            {
                intSaintJohnsHour = intSaintJohnsHour + 1;
                intSaintJohnsMinute = intSaintJohnsMinute - 60;
            }

            if (intSaintJohnsHour == 0)
            {
                strSaintJohnsHour = "";
            }
            else
            { 
                strSaintJohnsHour = intSaintJohnsHour.ToString();
            }

            strSaintJohnsMinute = intSaintJohnsMinute.ToString();

            strMinute = intMinute.ToString();

            //ensure correct placement of minutes
            if ((strOttawaHour == "") || (strVictoriaHour == "") || (strEdmontenHour == "") || (strWinnipegHour == "") || (strTorontoHour == "") || (strHalifaxHour == "") || (strSaintJohnsHour == ""))
            {
                Console.WriteLine("Leading zero not needed");
            }
            else
            {
                if (strMinute.Length == 1)
                {
                    strMinute = "0" + strMinute;
                }
            }

            //apply to Output textbox
            txbOutput.Text = strOttawaHour + strMinute + " in Ottawa\r\n"
                + strVictoriaHour + strMinute + " in Victoria\r\n"
                + strEdmontenHour + strMinute + " in Edmonton\r\n"
                + strWinnipegHour + strMinute + " in Winnipeg\r\n"
                + strTorontoHour + strMinute + " in Toronto\r\n"
                + strHalifaxHour + strMinute + " in Halifax\r\n"
                + strSaintJohnsHour + strSaintJohnsMinute + " in Saint John's";
        }
    }
}
