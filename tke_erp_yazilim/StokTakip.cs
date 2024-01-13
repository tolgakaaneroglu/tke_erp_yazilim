using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tke_erp_yazilim
{
    public partial class StokTakip : Form
    {
        public StokTakip()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L3BQSPA\\SQLEXPRESS;Initial Catalog=Tke_erp;Integrated Security=True");


        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();


            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Tbl_stok WHERE stok_kodu = @p1", baglanti);
            checkCmd.Parameters.AddWithValue("@p1", txtstokkodu.Text);

            int existingRecordCount = (int)checkCmd.ExecuteScalar();

            if (existingRecordCount > 0)
            {

                MessageBox.Show("Bu stok kodu ile daha önce kayıt yapılmıştır. Lütfen farklı bir stok kodu kullanın.");
            }
            else
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_stok (stok_kodu, stok_adi, birim_fiyat) VALUES (@p1, @p2, @p3)", baglanti);
                cmd.Parameters.AddWithValue("@p1", txtstokkodu.Text);
                cmd.Parameters.AddWithValue("@p2", txtstokadi.Text);
                cmd.Parameters.AddWithValue("@p3", txtbirimfiyat.Text);
                cmd.ExecuteNonQuery();
                lststok.Items.Add(txtstokadi.Text);

                MessageBox.Show("İşlem tamamlanmıştır");
            }

            baglanti.Close();
        }

        private void StokTakip_Load(object sender, EventArgs e)
        {
            lststok.Items.Clear();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select *from Tbl_stok", baglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lststok.Items.Add((string)reader[0]);
            }
            baglanti.Close();
        }

        private void lststok_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string secilenDeger = lststok.SelectedItem.ToString();
            string query = "SELECT stok_kodu, stok_adi , birim_fiyat FROM Tbl_stok WHERE stok_adi = @secilenDeger";
            using (SqlCommand command = new SqlCommand(query, baglanti))
            {
                command.Parameters.AddWithValue("@secilenDeger", secilenDeger);

                using (SqlDataReader read = command.ExecuteReader())
                {
                    if (read.Read())
                    {
                        txtstokkodu.Text = read["stok_kodu"].ToString();
                        txtstokadi.Text = read["stok_adi"].ToString();
                        txtbirimfiyat.Text = read["birim_fiyat"].ToString();


                    }
                }
            }
            baglanti.Close();
        }
    }
}
