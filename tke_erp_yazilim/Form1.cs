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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tke_erp_yazilim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }


        StokTakip stk = new StokTakip();
        SiparisListesi sprs = new SiparisListesi();
        private SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-L3BQSPA\\SQLEXPRESS;Initial Catalog=Tke_erp;Integrated Security=True");


        private void DataGridViewDoldur()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            string query = "SELECT evrak_no, tarih, SUM(ara_toplam) AS ToplamTutar FROM Tbl_siparis GROUP BY evrak_no, tarih";
            SqlDataAdapter adapter = new SqlDataAdapter(query, baglanti);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            baglanti.Close();
        }

      

        private void btnsiparis_Click(object sender, EventArgs e)
        {


            sprs.Show(); this.Hide();
            sprs.FormClosed += (s, args) => this.Close();

        }

        private void butonstok_Click(object sender, EventArgs e)
        {
            {
                stk.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewDoldur();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Çift tıklanan satırın evrak_no değerini al
            string evrakNo = dataGridView1.Rows[e.RowIndex].Cells["evrak_no"].Value.ToString();

            // Call the SetEvrakNo method in SiparisListesi form
            sprs.SetEvrakNo(evrakNo);

            sprs.Show();
            this.Hide();
            sprs.FormClosed += (s, args) => this.Close();
        }

        
    }
}

