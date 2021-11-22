using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPersediaaanBarang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Enabled = true;
                txtNamaBarang.Focus();
                this.betamartData.Barang.AddBarangRow(this.betamartData.Barang.NewBarangRow());
                barangBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                barangBindingSource.ResetBindings(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'betamartData.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.betamartData.Barang);
            barangBindingSource1.DataSource = this.betamartData.Barang;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNamaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                barangBindingSource.EndEdit();
                barangTableAdapter.Update(this.betamartData.Barang);
                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                barangBindingSource.ResetBindings(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            barangBindingSource.ResetBindings(false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            txtNamaBarang.Focus();
            txtNomerBarang.Focus();
            txtJumlahBarang.Focus();
            txtJenisBarang.Focus();
            txtHargaBarang.Focus();
            txtDeskripsiBarang.Focus();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("apakah kamu yakin ingin menghapus Barang ini ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    barangBindingSource.RemoveCurrent();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    dataGridView1.DataSource = barangBindingSource;
                else
                {
                    var query = from o in this.betamartData.Barang
                                where o.Nama_Barang.Contains(txtSearch.Text) || o.Nomer_Barang == txtSearch.Text || o.Jumlah_Barang == txtSearch.Text || o.Jenis_Barang == txtSearch.Text || o.Harga_Barang == txtSearch.Text || o.Deskripsi_Barang.Contains(txtSearch.Text)
                                select o;
                    dataGridView1.DataSource = query.ToList();
                }
            }
        }

        private void txtJumlahBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void barangBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
