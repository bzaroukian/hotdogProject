using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Hotdog_Stand
{
    public partial class Form1 : Form
    {
        int price = 0;
        int itemNumber = 0;
        string[] myArray;
        int size; 
        
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists("HotdogOrder.txt"))
            {
                using (StreamWriter sw = File.CreateText("HotdogOrder.txt"))
                {

                    sw.WriteLine("Start of Order");

                }
            }
        }

        private void HotdoButton_Click(object sender, EventArgs e)
        {
            string hotdog = "$1 hotdog";
            string path = @"HotdogOrder.txt";
            int quanity = 0;



            if (ketchupCheckBox.Checked == true)
            {
                hotdog = hotdog + " With Ketchup";
            }
            if (mustardCheckBox.Checked == true)
            {
                hotdog = hotdog + " With Mustard";
            }

            

            quanity = quanity + 1;
            price = price + 1;
            totalLabel.Text = price.ToString();
            ketchupCheckBox.Checked = false;
            mustardCheckBox.Checked = false;

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine(hotdog);

                }
            }

            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path,true))
                {

                    sw.WriteLine(hotdog);

                }
            }

            //myArray = new string[size];
            //myArray[itemNumber] = hotdog;
            //StreamReader inputFile;

            //inputFile = File.OpenText("HotdogOrder.txt");
            //string item = "";
            //while (!inputFile.EndOfStream)
            //{
            //    for (int i = 0; i < myArray.Length; i++)
            //    {
            //        item = inputFile.ReadLine();
            //        myArray[i]=item;


            //    }
            //}
            //orderDetails.Add(inputFile.ReadLine(itemNumber));

            //orderListBox.Items.Add(myArray[itemNumber]);
            orderListBox.Items.Clear();
            StreamReader inputFile = new StreamReader("HotdogOrder.txt");
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                orderListBox.Items.Add(line);
            }
            inputFile.Close();

            itemNumber++;
            size = size + 1; 
            
        }

        private void SideButton_Click(object sender, EventArgs e)
        {
            string chips = "";
            string path = @"HotdogOrder.txt";
            int quanity = 0;

            if (planChipsCheckBox.Checked == true)
            {
                chips = "$1 Plain BBQ Chips";
            }

            if (bbqChipsCheckBox2.Checked == true)
            {
                chips = "$1 BBQ Chips";
            }
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine(chips);

                }
            }

            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path,true))
                {

                    sw.WriteLine(chips);

                }
            }


            quanity = quanity + 1;
            planChipsCheckBox.Checked = false;
            bbqChipsCheckBox2.Checked = false;
            price = price + 1;
            totalLabel.Text = price.ToString();

            orderListBox.Items.Clear();
            StreamReader inputFile = new StreamReader("HotdogOrder.txt");
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                orderListBox.Items.Add(line);
            }
            inputFile.Close();

            //StreamReader inputFile;

            // inputFile = File.OpenText("HotdogOrder.txt");
            //orderListBox.Items.Add(itemNumber);
            itemNumber++;
        }

        private void DrinkButton_Click(object sender, EventArgs e)
        {
            string drink = "";
            string path = @"HotdogOrder.txt";
            int quanity = 0;

            if (dietPopCheckBox.Checked == true)
            {
                drink = "$1 Diet";
            }

            if (regularCheckBox.Checked == true)
            {
                drink = "$1 Regular";
            }

            if (spriteCheckBox1.Checked == true)
            {
                drink = "$1 Sprite";
            }

            if (waterCheckBox.Checked == true)
            {
                drink = "$1 Water";
            }

            if (File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {

                    sw.WriteLine(drink);

                }
            }

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine(drink);

                }
            }

            

            quanity = quanity + 1;
            dietPopCheckBox.Checked = false;
            regularCheckBox.Checked = false;
            spriteCheckBox1.Checked = false;
            waterCheckBox.Checked = false;
            price = price + 1;
            totalLabel.Text = "$" + price.ToString();

            orderListBox.Items.Clear();
            StreamReader inputFile = new StreamReader("HotdogOrder.txt");
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                orderListBox.Items.Add(line);
            }
            inputFile.Close();

            //StreamReader inputFile;

            //inputFile = File.OpenText("HotdogOrder.txt");
            //orderListBox.Items.Add(itemNumber);
            itemNumber++;
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            string path = @"HotdogOrder.txt";
            string newPath = @"HotdogOrder" + DateTime.Now.ToFileTime() + ".txt";
            string location = locationTextBox.Text;
            if (File.Exists(path))
            {
                using (StreamWriter sw = new  StreamWriter(path,true))
                {

                    sw.WriteLine("Please delvier this to " + location);
                    sw.WriteLine("The order total is: " + price.ToString());

                }
            }

            MessageBox.Show("The Total is $ " + price);
            

            StreamReader inputFile = new StreamReader("HotdogOrder.txt");
            string line;
            orderListBox.Items.Clear();
            while ((line = inputFile.ReadLine()) !=null)
            {
                orderListBox.Items.Add(line);
            }
              
            MessageBox.Show("Press OK when order is complete to start new transaction.");
            inputFile.Close();
            orderListBox.Items.Clear();
            totalLabel.Text = "";
            try
            {
               
                System.IO.File.Move(path, newPath);

            }
            catch
            {

                GC.Collect();
            }
            




        }
    }
}
