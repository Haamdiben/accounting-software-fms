using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApplication3
{
    static class Program
    {

        public static string curdate = DateTime.Now.Date.ToString("yyyy-MM-dd");
        public static string firstday = DateTime.Now.Date.ToString("yyyy-MM-01");
        public static string converti(double chiffre)
        {
            int centaine, dizaine, unite, reste, y;
            bool dix = false;
            bool soixanteDix = false;
            string lettre = "";
            //strcpy(lettre, "");

            reste = (int)chiffre / 1;

            for (int i = 1000000000; i >= 1; i /= 1000)
            {
                y = reste / i;
                if (y != 0)
                {
                    centaine = y / 100;
                    dizaine = (y - centaine * 100) / 10;
                    unite = y - (centaine * 100) - (dizaine * 10);
                    switch (centaine)
                    {
                        case 0:
                            break;
                        case 1:
                            lettre += "cent ";
                            break;
                        case 2:
                            if ((dizaine == 0) && (unite == 0)) lettre += "deux cents ";
                            else lettre += "deux cent ";
                            break;
                        case 3:
                            if ((dizaine == 0) && (unite == 0)) lettre += "trois cents ";
                            else lettre += "trois cent ";
                            break;
                        case 4:
                            if ((dizaine == 0) && (unite == 0)) lettre += "quatre cents ";
                            else lettre += "quatre cent ";
                            break;
                        case 5:
                            if ((dizaine == 0) && (unite == 0)) lettre += "cinq cents ";
                            else lettre += "cinq cent ";
                            break;
                        case 6:
                            if ((dizaine == 0) && (unite == 0)) lettre += "six cents ";
                            else lettre += "six cent ";
                            break;
                        case 7:
                            if ((dizaine == 0) && (unite == 0)) lettre += "sept cents ";
                            else lettre += "sept cent ";
                            break;
                        case 8:
                            if ((dizaine == 0) && (unite == 0)) lettre += "huit cents ";
                            else lettre += "huit cent ";
                            break;
                        case 9:
                            if ((dizaine == 0) && (unite == 0)) lettre += "neuf cents ";
                            else lettre += "neuf cent ";
                            break;
                    }// endSwitch(centaine)

                    switch (dizaine)
                    {
                        case 0:
                            break;
                        case 1:
                            dix = true;
                            break;
                        case 2:
                            lettre += "vingt ";
                            break;
                        case 3:
                            lettre += "trente ";
                            break;
                        case 4:
                            lettre += "quarante ";
                            break;
                        case 5:
                            lettre += "cinquante ";
                            break;
                        case 6:
                            lettre += "soixante ";
                            break;
                        case 7:
                            dix = true;
                            soixanteDix = true;
                            lettre += "soixante ";
                            break;
                        case 8:
                            lettre += "quatre-vingt ";
                            break;
                        case 9:
                            dix = true;
                            lettre += "quatre-vingt ";
                            break;
                    } // endSwitch(dizaine)

                    switch (unite)
                    {
                        case 0:
                            if (dix) lettre += "dix ";
                            break;
                        case 1:
                            if (soixanteDix) lettre += "et onze ";
                            else
                                if (dix) lettre += "onze ";
                                else if ((dizaine != 1 && dizaine != 0)) lettre += "et un ";
                                else lettre += "un ";
                            break;
                        case 2:
                            if (dix) lettre += "douze ";
                            else lettre += "deux ";
                            break;
                        case 3:
                            if (dix) lettre += "treize ";
                            else lettre += "trois ";
                            break;
                        case 4:
                            if (dix) lettre += "quatorze ";
                            else lettre += "quatre ";
                            break;
                        case 5:
                            if (dix) lettre += "quinze ";
                            else lettre += "cinq ";
                            break;
                        case 6:
                            if (dix) lettre += "seize ";
                            else lettre += "six ";
                            break;
                        case 7:
                            if (dix) lettre += "dix-sept ";
                            else lettre += "sept ";
                            break;
                        case 8:
                            if (dix) lettre += "dix-huit ";
                            else lettre += "huit ";
                            break;
                        case 9:
                            if (dix) lettre += "dix-neuf ";
                            else lettre += "neuf ";
                            break;
                    } // endSwitch(unite)

                    switch (i)
                    {
                        case 1000000000:
                            if (y > 1) lettre += "milliards ";
                            else lettre += "milliard ";
                            break;
                        case 1000000:
                            if (y > 1) lettre += "millions ";
                            else lettre += "million ";
                            break;
                        case 1000:
                            lettre += "mille ";
                            break;
                    }
                } // end if(y!=0)
                reste -= y * i;
                dix = false;
                soixanteDix = false;
            } // end for
            if (lettre.Length == 0) lettre += "zero";

            // pour les chiffres apres la virgule :
            Decimal chiffre3;
            chiffre3 = (Decimal)(chiffre * 100) % 100;
            Console.WriteLine(chiffre3);

            //int chiffre2 = (int)((chiffre - (int)(chiffre/1))*100);
            //Console.WriteLine(chiffre2);
            dizaine = (int)(chiffre3) / 10;
            unite = (int)chiffre3 - (dizaine * 10);

            string lettre2 = "";
            switch (dizaine)
            {
                case 0:
                    break;
                case 1:
                    dix = true;
                    break;
                case 2:
                    lettre2 += "vingt ";
                    break;
                case 3:
                    lettre2 += "trente ";
                    break;
                case 4:
                    lettre2 += "quarante ";
                    break;
                case 5:
                    lettre2 += "cinquante ";
                    break;
                case 6:
                    lettre2 += "soixante ";
                    break;
                case 7:
                    dix = true;
                    soixanteDix = true;
                    lettre2 += "soixante ";
                    break;
                case 8:
                    lettre2 += "quatre-vingt ";
                    break;
                case 9:
                    dix = true;
                    lettre2 += "quatre-vingt ";
                    break;
            } // endSwitch(dizaine)

            switch (unite)
            {
                case 0:
                    if (dix) lettre2 += "dix ";
                    break;
                case 1:
                    if (soixanteDix) lettre2 += "et onze ";
                    else
                        if (dix) lettre2 += "onze ";
                        else if ((dizaine != 1 && dizaine != 0)) lettre2 += "et un ";
                        else lettre2 += "un ";
                    break;
                case 2:
                    if (dix) lettre2 += "douze ";
                    else lettre2 += "deux ";
                    break;
                case 3:
                    if (dix) lettre2 += "treize ";
                    else lettre2 += "trois ";
                    break;
                case 4:
                    if (dix) lettre2 += "quatorze ";
                    else lettre2 += "quatre ";
                    break;
                case 5:
                    if (dix) lettre2 += "quinze ";
                    else lettre2 += "cinq ";
                    break;
                case 6:
                    if (dix) lettre2 += "seize ";
                    else lettre2 += "six ";
                    break;
                case 7:
                    if (dix) lettre2 += "dix-sept ";
                    else lettre2 += "sept ";
                    break;
                case 8:
                    if (dix) lettre2 += "dix-huit ";
                    else lettre2 += "huit ";
                    break;
                case 9:
                    if (dix) lettre2 += "dix-neuf ";
                    else lettre2 += "neuf ";
                    break;
            }

            // on enleve le un devant le mille :
            if (lettre.StartsWith("un mille"))
            {
                //Console.WriteLine("on enleve le un devant le mille");
                lettre = lettre.Remove(0, 3);
            }

            if (lettre2.Equals(""))
                return lettre + "dinar";
            else if (dizaine.Equals(0) && unite.Equals(1))
                return lettre + "dinar et " + lettre2 + "millime";
            else
                return lettre + "dinars et " + lettre2 + "millimes";
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());



        }

    }
}
