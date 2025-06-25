using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSBusinessLogic;
using POSCommon;

namespace POSGui
{
    public partial class Form1 : Form
    {
        private POSManager manager = new POSManager();

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;
            btnCheckout.Click += btnCheckout_Click;
            btnExit.Click += btnExit_Click;

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await ShowTemporaryMessage("Item name cannot be empty.");
                return;
            }

            if (!double.TryParse(txtPrice.Text.Trim(), out double price))
            {
                await ShowTemporaryMessage("Invalid price. Please enter a number.");
                return;
            }

            manager.AddItem(name, price);
            UpdateListView();
            await ShowTemporaryMessage("Item added!");
            txtName.Clear();
            txtPrice.Clear();
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstView.SelectedItems.Count == 0)
            {
                await ShowTemporaryMessage("Please select an item to remove.");
                return;
            }

            string name = lstView.SelectedItems[0].SubItems[0].Text;
            bool success = manager.RemoveItem(name);

            if (success)
            {
                UpdateListView();
                await ShowTemporaryMessage("Item removed.");
            }
            else
            {
                await ShowTemporaryMessage("Item not found or already removed.");
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            List<CartItems> items = manager.ViewItems();
            if (items.Count == 0)
            {
                await ShowTemporaryMessage("Cart is empty.");
                return;
            }

            DialogResult result = MessageBox.Show("Proceed to checkout?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                manager.Checkout();
                UpdateListView();
                await ShowTemporaryMessage("Checkout complete!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateListView()
        {
            lstView.Items.Clear();
            List<CartItems> items = manager.ViewItems();
            double total = 0;

            foreach (var item in items)
            {
                ListViewItem lvi = new ListViewItem(item.ItemName);
                lvi.SubItems.Add($"Php {item.Price:F2}");
                lstView.Items.Add(lvi);
                total += item.Price;
            }

            lblAmount.Text = $"Php {total:F2}";
        }

        private async Task ShowTemporaryMessage(string message)
        {
            Label msg = new Label();
            msg.Text = message;
            msg.BackColor = Color.LightYellow;
            msg.ForeColor = Color.Black;
            msg.Padding = new Padding(10);
            msg.AutoSize = true;
            msg.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            msg.BorderStyle = BorderStyle.FixedSingle;
            msg.BringToFront();

            int centerX = lstView.Left + (lstView.Width - msg.PreferredWidth) / 2;
            int centerY = lstView.Top + (lstView.Height - msg.PreferredHeight) / 2;
            msg.Location = new Point(centerX, centerY);

            this.Controls.Add(msg);
            msg.BringToFront();

            await Task.Delay(2000);
            this.Controls.Remove(msg);
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {
        }
    }
}
