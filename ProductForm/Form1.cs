using System;
using System.Windows.Forms;

namespace ProductForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Form Load (Para sa ComboBox ug default radio button)
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Add("Gadgets");
            cmbCategory.Items.Add("Food");
            cmbCategory.Items.Add("Clothing");
            rdoLocal.Checked = true;
        }

        // 2. Event kung mag-type sa Cost
        private void txtCost_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        // 2. Event kung mag-type sa Markup
        private void txtMarkup_TextChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        // Function para mo-calculate sa Price
        private void CalculatePrice()
        {
            if (decimal.TryParse(txtCost.Text, out decimal cost) &&
                decimal.TryParse(txtMarkup.Text, out decimal markup))
            {
                decimal price = cost + (cost * (markup / 100));
                txtPrice.Text = price.ToString("0.00");
            }
            else
            {
                txtPrice.Text = "";
            }
        }

        // 3. Event sa Clear Button
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBarcode.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtCost.Clear();
            txtPrice.Clear();
            txtMarkup.Clear();
            cmbCategory.SelectedIndex = -1;
            rdoLocal.Checked = true;
            chkActive.Checked = false;
            txtBarcode.Focus();
        }

        // 4. Event sa Save Button (Naay Validation)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please fill in the Barcode and Name fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string origin = rdoLocal.Checked ? "Local" : "Abroad";
            string status = chkActive.Checked ? "Active" : "Inactive";

            MessageBox.Show($"Product Saved Successfully!\n\nBarcode: {txtBarcode.Text}\nName: {txtName.Text}\nPrice: {txtPrice.Text}\nOrigin: {origin}\nStatus: {status}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnClear_Click(sender, e);
        }

        // 5. Event sa Cancel Button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblBarcode_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
        }

        private void txtMarkup_TextChanged_1(object sender, EventArgs e)
        {
            CalculatePrice();
        }

    }
}