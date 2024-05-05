using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class EditDetailForm : Form
    {
        public OrderDetail Detail { get; set; }
       

        public EditDetailForm()
        {
            InitializeComponent();
        }
        public EditDetailForm(OrderDetail detail) : this()
        {
            this.Detail = detail;
            bdsDetail.DataSource = detail;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Detail.GoodsItem = new Goods(textBox2.Text, System.Convert.ToDouble(textBox4.Text));
            bdsDetail.ResetBindings(false);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

    }
}
