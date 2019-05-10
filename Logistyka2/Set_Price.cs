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
    public partial class Set_Price : Form
    {

        Form1 form;


        public List<TextBox> product_boxes = new List<TextBox>();
        public List<TextBox> stock_boxes = new List<TextBox>();


      

        public void Draw()
        {

            flowLayoutPanel1.Controls.Clear();
            product_boxes.Clear();
            stock_boxes.Clear();

            for (int i=0; i < form.product_iteration; i++)
            {
                Label multi1 = new Label();
                multi1.Text = "produkt" + (i + 1);
                flowLayoutPanel1.Controls.Add(multi1);

                TextBox multi2 = new TextBox();
                product_boxes.Add(multi2);
                multi2.Text = form.data[i].product_price.ToString();
                flowLayoutPanel1.Controls.Add(multi2);
            }

            for (int i = 0; i < form.stock_iteration; i++)
            {
                Label multi1 = new Label();
                multi1.Text = "surowiec" + (i + 1);
                flowLayoutPanel1.Controls.Add(multi1);

                TextBox multi2 = new TextBox();
                stock_boxes.Add(multi2);
                multi2.Text = form.stock[i].price.ToString();
                flowLayoutPanel1.Controls.Add(multi2);

            }

        }

        public Set_Price(Form1 form1)
        {
            InitializeComponent();
            form = form1;


        }

        private void button1_Click(object sender, EventArgs e)  //przycisk zapisu
        {

            int i = 0;
            foreach(TextBox tmp in product_boxes)
            {
                form.data[i].product_price = double.Parse(tmp.Text, System.Globalization.CultureInfo.InvariantCulture);
                i++;
            }

            i = 0;
            foreach (TextBox tmp in stock_boxes)
            {
                form.stock[i].price = double.Parse(tmp.Text, System.Globalization.CultureInfo.InvariantCulture);
                i++;
            }

            this.Visible = false;
            
        }

        private void Set_Price_Visible(object sender, EventArgs e)
        {
            MessageBox.Show("no siema");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
