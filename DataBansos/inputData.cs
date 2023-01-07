using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace DataBansos
{
    public partial class inputData : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=(local);Initial Catalog=bansosDesa;Integrated Security=True");
        public inputData()
        {
            InitializeComponent();
        }

        string jenis_kelamin;
        string imglocation = "";
        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home panggil = new Home();
            panggil.Show();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            images = brs.ReadBytes((int)stream.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [penerima] (namaPenerima,noKK,NIK,alamat,jenisKelamin,tempatLahir,tanggalLahir,noTelp,foto) values('" + txtNama.Text + "','" + txtKK.Text + "','" + txtNIK.Text + "','" + txtAlamat.Text + "','" + jenis_kelamin + "','" + txtTempat.Text + "','" + dateTimePicker1.Text + "','" + txtNoTelp + "',@images) ";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            txtKK.Text = "";
            txtNIK.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            rbPria.Checked = false;
            rbWanita.Checked = false;
            txtTempat.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtNoTelp.Text = "";
            Foto.ImageLocation = null;
            display_data();
            MessageBox.Show("Data Insert Successfully");
        }

        private void rbPria_CheckedChanged(object sender, EventArgs e)
        {
            jenis_kelamin = "Pria";
        }

        private void rbWanita_CheckedChanged(object sender, EventArgs e)
        {
            jenis_kelamin = "Wanita";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png) |*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                Foto.ImageLocation = imglocation;
            }
        }

        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [penerima]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dgvBansos.DataSource = dta;
            koneksi.Close();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKK.Text = "";
            txtNIK.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            rbPria.Checked = false;
            rbWanita.Checked = false;
            txtTempat.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtNoTelp.Text = "";
            Foto.ImageLocation = null;
        }
    }
}
