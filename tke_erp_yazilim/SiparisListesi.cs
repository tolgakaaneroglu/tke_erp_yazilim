using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tke_erp_yazilim
{
    public partial class SiparisListesi : Form
    {
        private int satirSiraNo = 1;
        private SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L3BQSPA\\SQLEXPRESS;Initial Catalog=Tke_erp;Integrated Security=True");

        public SiparisListesi()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public void SetEvrakNo(string evrakNo)
        {
            txtevrakno.Text = evrakNo;
        }
        public SiparisListesi(DataTable siparisData) : this()
        {
            foreach (DataRow row in siparisData.Rows)
            {
                string[] rowValues = {
                            satirSiraNo.ToString(),
                            row["stok_adi"].ToString(),
                            row["stok_kodu"].ToString(),
                            row["birim_fiyat"].ToString(),
                            row["miktar"].ToString(),
                            row["ara_toplam"].ToString()
                        };

                dataGridView1.Rows.Add(rowValues);
                satirSiraNo++;
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Sıra";
            dataGridView1.Columns[1].Name = "Stok Adı";
            dataGridView1.Columns[2].Name = "Stok Kodu";
            dataGridView1.Columns[3].Name = "Birim Fiyat";
            dataGridView1.Columns[4].Name = "Miktar";
            dataGridView1.Columns[5].Name = "Ara Toplam";

            dataGridView1.CellEndEdit += DataGridView_CellEndEdit;
            dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
        }

        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != dataGridView1.Columns["Stok Kodu"].Index && e.ColumnIndex != dataGridView1.Columns["Miktar"].Index)
            {
                e.Cancel = true;
            }
        }


        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            if (e.ColumnIndex == dataGridView1.Columns["Stok Kodu"].Index)
            {
                string secilenDeger = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                if (!string.IsNullOrEmpty(secilenDeger))
                {
                    string query = "SELECT stok_adi, birim_fiyat FROM Tbl_stok WHERE stok_kodu = @SecilenDeger ";
                    using (SqlCommand command = new SqlCommand(query, baglanti))
                    {
                        command.Parameters.AddWithValue("@secilenDeger", secilenDeger);

                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            if (read.Read())
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[1].Value = read["stok_adi"].ToString();
                                dataGridView1.Rows[e.RowIndex].Cells[3].Value = read["birim_fiyat"].ToString();
                            }
                        }
                    }
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Birim Fiyat"].Index || e.ColumnIndex == dataGridView1.Columns["Miktar"].Index)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (double.TryParse(row.Cells["Birim Fiyat"].Value?.ToString(), out double birimFiyat) &&
                        double.TryParse(row.Cells["Miktar"].Value?.ToString(), out double miktar))
                    {
                        row.Cells["Ara Toplam"].Value = birimFiyat * miktar;
                    }
                }

                double toplamAraToplam = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (double.TryParse(row.Cells["Ara Toplam"].Value?.ToString(), out double araToplam))
                    {
                        toplamAraToplam += araToplam;
                    }
                }

                lbltoplam.Text = toplamAraToplam.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] rowValues = { satirSiraNo.ToString(), string.Empty, string.Empty, string.Empty, "0", "0" };
            dataGridView1.Rows.Add(rowValues);
            satirSiraNo++;
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_siparis (evrak_no, tarih, stok_kodu,stok_adi, miktar, Sira, birim_fiyat, ara_toplam,toplam) VALUES (@evrak_no, @tarih, @stok_kodu,@stok_adi, @miktar, @sira, @birim_fiyat, @ara_toplam,@toplam)", baglanti))
                    {
                        cmd.Parameters.AddWithValue("@evrak_no", txtevrakno.Text);
                        cmd.Parameters.AddWithValue("@tarih", txtdate.Value);
                        cmd.Parameters.AddWithValue("@stok_kodu", row.Cells["Stok Kodu"].Value?.ToString());
                        cmd.Parameters.AddWithValue("@stok_adi", row.Cells["Stok Adı"].Value?.ToString());
                        cmd.Parameters.AddWithValue("@miktar", int.Parse(row.Cells["Miktar"].Value?.ToString()));
                        cmd.Parameters.AddWithValue("@sira", row.Cells["Sıra"].Value?.ToString());
                        cmd.Parameters.AddWithValue("@birim_fiyat", double.Parse(row.Cells["Birim Fiyat"].Value?.ToString()));
                        cmd.Parameters.AddWithValue("@ara_toplam", double.Parse(row.Cells["Ara Toplam"].Value?.ToString()));
                        cmd.Parameters.AddWithValue("@toplam", lbltoplam.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Sipariş başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

            this.Hide();
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void txtevrakno_TextChanged(object sender, EventArgs e)
        {
            string evrakNo = "SELECT stok_adi, stok_kodu, birim_fiyat, miktar, ara_toplam FROM Tbl_siparis WHERE evrak_no=@p1";
            SqlCommand cmd = new SqlCommand(evrakNo, baglanti);
            cmd.Parameters.AddWithValue("@p1", txtevrakno.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dataGridView1.Rows.Clear();


            foreach (DataRow row in dt.Rows)
            {
                string[] rowValues = {
            satirSiraNo.ToString(),
            row["stok_adi"].ToString(),
            row["stok_kodu"].ToString(),
            row["birim_fiyat"].ToString(),
            row["miktar"].ToString(),
            row["ara_toplam"].ToString()

        };

                dataGridView1.Rows.Add(rowValues);
                satirSiraNo++;
                lbltoplam.Text = row["ara_toplam"].ToString();
            }
        }
    }
}






