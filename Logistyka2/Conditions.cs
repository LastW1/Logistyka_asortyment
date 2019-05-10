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
    
    
    public partial class Conditions : Form
    {

        Form1 form;


        List<ComboBox> combo1 = new List<ComboBox>();
        List<ComboBox> combo2 = new List<ComboBox>();
        List<ComboBox> condition = new List<ComboBox>();
        int combos_iteration=0;

        public Conditions(Form1 form1)
        {
            InitializeComponent();
            form = form1;

        }

        private void button3_Click(object sender, EventArgs e)    //przycisk zapisu
        {
            form.condition.Clear();
            for (int i = 0; i<combos_iteration; i++)
            {
                form.condition.Add(combo1[i].Text + " " + condition[i].Text + " " + combo2[i].Text);
            }
       
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)  //dodanie nowego warunku
        {
            ComboBox combo_item1 = new ComboBox();
            for(int i = 0; i< form.product_iteration; i++)
            {
                combo_item1.Items.Add("Produkt"+(i+1));
            }
            for (int i = 0; i < form.stock_iteration; i++)
            {
                combo_item1.Items.Add("Surowiec" + (i+1));
            }
            combo1.Add(combo_item1);
            flowLayoutPanel1.Controls.Add(combo_item1);

            ComboBox comboBox = new ComboBox();
            comboBox.Text = "warunek";
            comboBox.Items.Add("<=");
            comboBox.Items.Add("=>");
            comboBox.Items.Add("==");
            condition.Add(comboBox);
            flowLayoutPanel1.Controls.Add(comboBox);

            ComboBox combo_item2 = new ComboBox();
            for (int i = 0; i < form.product_iteration; i++)
            {
                combo_item2.Items.Add("Produkt" + (i+1));
               
            }
            for (int i = 0; i < form.stock_iteration; i++)
            {
                combo_item2.Items.Add("Surowiec" + (i+1));
            }

            combo2.Add(combo_item2);
            flowLayoutPanel1.Controls.Add(combo_item2);
            combos_iteration++;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)  //layout do wyświetlania warunków
        {

        }
    }
}
