using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistyka2
{
    public partial class Form1 : Form
    {
        int conditions_iteration = 0;
        public int product_iteration = 0;
        public int stock_iteration = 0;
        int set_price_iteration = 0;
        Conditions conditions;
        Set_Price set_price;
        public List<Stock> stock= new List<Stock>();
        public List<Data> data = new List<Data>();
        List<TextBox> amount = new List<TextBox>();
        public List<string> condition = new List<string>();
        public List<string> condition1 = new List<string>();
        public List<string> condition2 = new List<string>();
        public List<double> condition3 = new List<double>();



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //dodanie produktu
        {

            if (product_iteration == 10)
            {
                MessageBox.Show("nie można dodać więcej produktów");
            }
            else
            {

                Label multi1 = new Label();
                multi1.Text = "produkt" + (product_iteration + 1);
                multi1.Height = 26;
                flowLayoutPanel2.Controls.Add(multi1);
               
                //tworzenie nowego obiektu Data
                Data tmp = new Data();
                tmp.id = product_iteration;
                data.Add(tmp);
                product_iteration++;



                //rysowanie na panelu3
                flowLayoutPanel3.Controls.Clear();
                amount.Clear();
                flowLayoutPanel3.Width = 110 * stock_iteration;
                flowLayoutPanel3.Height = 200 * product_iteration;
                for (int i = 0; i < product_iteration; i++)
                    for (int j = 0; j < stock_iteration; j++)
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = "0";
                        amount.Add(textBox);
                        flowLayoutPanel3.Controls.Add(textBox);
                    }
                
            }

         
        }

        private void button2_Click(object sender, EventArgs e)  //dodanie surowców
        {

            if (stock_iteration == 6)
            {
                MessageBox.Show("nie można dodać więcej surowców");
            }
            else
            {
                Label multi1 = new Label();
                multi1.Text = "surowiec" + (stock_iteration + 1);
                flowLayoutPanel1.Controls.Add(multi1);

                Stock tmp = new Stock();
                tmp.id = stock_iteration;
                stock.Add(tmp);
                stock_iteration++;

                //rysowanie na panelu3
                flowLayoutPanel3.Controls.Clear();
                amount.Clear();
                flowLayoutPanel3.Width = 110 * stock_iteration;
                flowLayoutPanel3.Height = 200 * product_iteration;
                for (int i = 0; i < product_iteration; i++)
                    for (int j = 0; j < stock_iteration; j++)
                    {
                        TextBox textBox = new TextBox();
                        textBox.Text = "0";
                        amount.Add(textBox);
                        flowLayoutPanel3.Controls.Add(textBox);
                    }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (conditions_iteration == 0)
            {
                conditions = new Conditions(this);
                conditions.ShowDialog();
                conditions_iteration++;
            }
            else
            {
                conditions.Show();
            }
        }



        private void button5_Click(object sender, EventArgs e)  //przycisk do obliczania
        {
              int x = 0;
            for(int i = 0; i<product_iteration; i++)
                  for(int j = 0; j< stock_iteration; j++)
                  {
                    //  System.Console.WriteLine(i);
                      data[i].stock.Add(0);
                      data[i].stock[j] = double.Parse(amount[x].Text, System.Globalization.CultureInfo.InvariantCulture);
                      x++;

                  }


            //Wyświetlanie wszystkich danych
            System.Console.WriteLine("Warunki:");
            foreach (string tmp in condition)
            {
                System.Console.WriteLine(tmp);
            }

            System.Console.WriteLine("Ceny:");
            {
                foreach (Data tmp in data)
                {
                    System.Console.WriteLine("Cena Produktu"+(tmp.id+1)+":"+tmp.product_price);
                }

                foreach (Stock tmp in stock)
                {
                    System.Console.WriteLine("Cena Surowca" + (tmp.id + 1) + ":" + tmp.price);
                }
            }


              foreach(Data tmp in data)
              {
                  System.Console.WriteLine("\nProdukt"+(tmp.id+1));
                  for(int i =0; i<stock_iteration; i++)
                {
                    System.Console.Write("Surowiec"+(i+1)+":"+tmp.stock[i]+" ");
                }
              }
            System.Console.WriteLine();

            int xD = 1;
            System.Console.Write("funkcja celu: ");
              foreach (Data tmp in data)
            {
                if(xD!=1)
                System.Console.Write(" + ");
                System.Console.Write("x"+xD+" * "+tmp.product_price);
                xD++;
            }

               System.Console.WriteLine();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e) //panel zawierający produkty
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)  //panel zawierajacy surowce
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)  //rysowanie komórek do pobrania ilości surowców
        {

        }

        private void button6_Click(object sender, EventArgs e)  //przejście do ustawień cen
        {

            if (set_price_iteration == 0)
            {
                set_price = new Set_Price(this);
                set_price.Draw();
                set_price.Visible = true;
                set_price_iteration++;
            }
            else
            {
                set_price.Draw();
                set_price.Visible=true;
            }
        }
    }
}
