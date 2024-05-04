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
    public partial class EditOrderForm : Form
    {
        private OrderService tempOrderService;
        public Order CurrentOrder { get; set; }

        public EditOrderForm()
        {
            InitializeComponent();
        }
        public EditOrderForm(Order order, OrderService orderService)
        {
            InitializeComponent();
            tempOrderService = orderService;
            CurrentOrder = order;
            bdsOrder.DataSource = CurrentOrder;
        }

       

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            EditDetailForm editDetailForm = new EditDetailForm(new OrderDetail());
            if (editDetailForm.ShowDialog() == DialogResult.OK)
            {
                CurrentOrder.AddItem(editDetailForm.Detail);
                bdsDetail.ResetBindings(false);
            }
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            OrderDetail detail = bdsDetail.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            EditDetailForm formDetailEdit = new EditDetailForm(detail);
            if (formDetailEdit.ShowDialog() == DialogResult.OK)
            {
                bdsDetail.ResetBindings(false);
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            OrderDetail detail = bdsDetail.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.RemoveDetail(detail);
            bdsDetail.ResetBindings(false);
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            CurrentOrder.Customer=new Customer(textBox2.Text);
        }
    }
}
