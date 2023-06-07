using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class AritmetickyPrumer : Form
    {
        public AritmetickyPrumer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pocet = 0;
            double soucet = 0;

            for(int i = 0; i< textBox1.Lines.Length;i++)
            {
                try
                {
                    if (int.Parse(textBox1.Lines[i]) < 0)
                    {
                        int cislo = int.Parse(textBox1.Lines[i]);
                        checked { soucet += cislo; }
                        pocet++;
                    }
                }
                catch(FormatException a)
                {
                    if(checkBox1.Checked)MessageBox.Show("Na Řádku " + (i + 1) + " se vyskytla tady ta chyba : " + a.Message);
                }
                catch (OverflowException a)
                {
                    if (checkBox1.Checked) MessageBox.Show("Na Řádku " + (i + 1) + " se vyskytla tady ta chyba : " + a.Message);
                }
                catch (ArithmeticException a) // double je moc velky takze se tato vyjimka nejspis nikdy nespusti :)
                {
                    if (checkBox1.Checked) MessageBox.Show(a.Message); 
                    pocet--;
                }
            }

            try
            {
                if(pocet == 0)
                {
                    MessageBox.Show("Aritmeticky prumer : 0");
                }
                else
                {
                    double aritmeticky = checked(soucet / pocet);
                    MessageBox.Show("Aritmeticky prumer :" + aritmeticky);
                }
            }
            catch(DivideByZeroException a) // u double se deleni nulou vypise jako NaN takze se tato vyjimka nikdy nespusti :)
            {
                if (checkBox1.Checked) MessageBox.Show(a.Message); 
            }
        }
    }
}
