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
    public partial class MainForm : Form
    {
        OrderService orderService = new OrderService();
        public MainForm()
        {
            InitializeComponent();
            InitOrders();
            bdsOrders.DataSource = orderService.GetAllOrders();
            this.comboBox1.SelectedIndex = 0;
        }
        private void InitOrders()
        {
            Order order = new Order(1, new Customer("1", "张三"), new List<OrderDetail>());
            order.AddItem(new OrderDetail(1, new Goods(1, "apple", 100.0), 10));
            order.AddItem(new OrderDetail(2, new Goods(2, "banana", 50.0), 61));
            orderService.AddOrder(order);
            Order order2 = new Order(2, new Customer("2", "李四"), new List<OrderDetail>());
            order2.AddItem(new OrderDetail(1, new Goods(2, "banana", 200.0), 10));
            orderService.AddOrder(order2);
        }
        private void FormParent_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditOrderForm editForm = new EditOrderForm(new Order(),  orderService);
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(editForm.CurrentOrder);
                bdsOrders.ResetBindings(false);
            }
        }

        private void btnEdt_Click(object sender, EventArgs e)
        {
            EditOrderForm editForm = new EditOrderForm(bdsOrders.Current as Order, orderService);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(editForm.CurrentOrder);
                bdsOrders.ResetBindings(false);
            }
        }
        private void btnDlt_Click(object sender, EventArgs e)
        {
            Order tempOrder = bdsOrders.Current as Order;
            orderService.RemoveOrder(tempOrder.OrderId);
            bdsOrders.ResetBindings(false);
        }
        private void btnQue_Click(object sender, EventArgs e)
        {
            string Keyword = textBox1.Text;
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        bdsOrders.DataSource = orderService.GetAllOrders();
                        break;
                    case 1:
                        int id = Convert.ToInt32(Keyword);
                        Order order = orderService.GetOrder(id);
                        List<Order> result = new List<Order>();
                        if (order != null) result.Add(order);
                        bdsOrders.DataSource = result;
                        break;
                    case 2:
                        bdsOrders.DataSource = orderService.QueryOrdersByCustomerName(Keyword);
                        break;
                    case 3:
                        bdsOrders.DataSource = orderService.QueryOrdersByGoodsName(Keyword);
                        break;
                 }
                bdsOrders.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
