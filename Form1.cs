using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mileage_efficiency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void errorMessagePopUp()
        {
            int miles;
            int gallons;
            int results;

            string filename = @"C:\Users\arnol\Downloads\MilesperGallon.txt";
            string filename2 = @"C:\Users\arnol\Exceptionfile.txt";
            try
            {
                miles = int.Parse(txtMiles.Text);
                gallons = int.Parse(txtGallons.Text);
                results = (int)miles / (int)gallons;
                txtResults.Text = results.ToString();
               

                if (File.Exists(filename))
                {
                    StreamWriter writer = File.AppendText(filename);
                    writer.WriteLine("Miles Drive: " + miles + " Gallons used: " + gallons + " Miles per gallon: " + results);
                    writer.Close();
                }
                else
                {
                    StreamWriter writer = File.CreateText(filename);
                    writer.WriteLine("Miles Drive: " + miles + " Gallons used: " + gallons + " Miles per gallon: " + results);
                    writer.Close();
                }
            }
            catch(Exception e)
            {
                errorProvider1.SetError(txtGallons, e.Message);

                if (File.Exists(filename2))
                {
                    StreamWriter writer = File.AppendText(filename2);
                    writer.WriteLine("Error");
                    writer.Close();
                }
                else
                {
                    StreamWriter writer = File.CreateText(filename2);
                    writer.WriteLine("Exception file");
                    writer.Close();
                }
            }
            finally
            {
                MessageBox.Show("bye");
            }

        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            errorMessagePopUp();
        }
    }
}
