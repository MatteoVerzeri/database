using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();
            String sql1 = "select nome, cognome, auto, id from proprietario;";
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            cmd1.ExecuteNonQuery();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati = new DataTable();
            MyAdapter.Fill(dati);

            
            //List<string> list = new List<string>();
            //for (int i = 0; i<comboBox1.MaxLength; i++)
            //{
            //    list[i] = comboBox1.Items[i].ToString();
            //}
            //list.Distinct();
            //for(int i = 0; i<list.Count; i++)
            //{
            //    comboBox1.Items.Add(list[i]);
            //}
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = dati.DefaultView.ToTable(true, "nome").Copy();

            comboBox3.DisplayMember = "auto";
            comboBox3.ValueMember = "id";
            comboBox3.DataSource = dati.DefaultView.ToTable(true, "auto").Copy();

            String sql2 = "select automobile.marca, automobile.modello, automobile.prezzo, automobile.riparazioni, automobile.id from automobile;";
            cmd1 = new MySqlCommand(sql2, conn);
            cmd1.ExecuteNonQuery();
            MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati2 = new DataTable();
            MyAdapter.Fill(dati2);

            comboBox2.DisplayMember = "marca";
            comboBox2.ValueMember = "id";
            comboBox2.DataSource = dati2.DefaultView.ToTable(true, "marca").Copy();

            comboBox4.DisplayMember = "modello";
            comboBox4.ValueMember = "id";
            comboBox4.DataSource = dati2.DefaultView.ToTable(true, "modello").Copy();

            comboBox5.DisplayMember = "prezzo";
            comboBox5.ValueMember = "id";
            comboBox5.DataSource = dati2.DefaultView.ToTable(true, "prezzo").Copy();

            String sql3 = "select riparazione.descrizione from riparazione;";
            cmd1 = new MySqlCommand(sql3, conn);
            cmd1.ExecuteNonQuery();
            MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati3 = new DataTable();
            MyAdapter.Fill(dati3);


            String sql4 = "select tagliando.descrizione from tagliando;";
            cmd1 = new MySqlCommand(sql4, conn);
            cmd1.ExecuteNonQuery();
            MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati4 = new DataTable();
            MyAdapter.Fill(dati4);


            String sql5 = "select esegue.costo, esegue.data, esegue.id_macchina, esegue.id_tagliando from esegue;";
            cmd1 = new MySqlCommand(sql5, conn);
            cmd1.ExecuteNonQuery();
            MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = cmd1;
            DataTable dati5 = new DataTable();
            MyAdapter.Fill(dati5);


            dataGridView1.DataSource = dati;
            dataGridView1.Columns.RemoveAt(3);
            dataGridView2.DataSource = dati2;
            dataGridView2.Columns.RemoveAt(4);
            dataGridView3.DataSource = dati3;
            dataGridView4.DataSource = dati4;
            dataGridView5.DataSource = dati5;
            conn.Close();

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql1 = "SELECT nome, cognome, auto FROM proprietario WHERE nome = @nome";

                using (MySqlCommand cmd1 = new MySqlCommand(sql1, conn))
                {
                    cmd1.Parameters.AddWithValue("@nome", comboBox1.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati = new DataTable();
                        MyAdapter.Fill(dati);
                        dataGridView1.DataSource = dati;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql1 = "SELECT nome, cognome, auto FROM proprietario";

                using (MySqlCommand cmd1 = new MySqlCommand(sql1, conn))
                {
                    cmd1.Parameters.AddWithValue("@nome", comboBox1.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati = new DataTable();
                        MyAdapter.Fill(dati);
                        dataGridView1.DataSource = dati;
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql2 = "SELECT marca, modello, prezzo, riparazioni FROM automobile WHERE marca = @marca";

                using (MySqlCommand cmd1 = new MySqlCommand(sql2, conn))
                {
                    cmd1.Parameters.AddWithValue("@marca", comboBox2.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati2 = new DataTable();
                        MyAdapter.Fill(dati2);
                        dataGridView2.DataSource = dati2;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql2 = "SELECT marca, modello, prezzo, riparazioni FROM automobile";

                using (MySqlCommand cmd1 = new MySqlCommand(sql2, conn))
                {
                    cmd1.Parameters.AddWithValue("@marca", comboBox2.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati2 = new DataTable();
                        MyAdapter.Fill(dati2);
                        dataGridView2.DataSource = dati2;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";

            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql1 = "SELECT nome, cognome, auto FROM proprietario WHERE auto = @auto";

                using (MySqlCommand cmd1 = new MySqlCommand(sql1, conn))
                {
                    cmd1.Parameters.AddWithValue("@auto", comboBox3.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati = new DataTable();
                        MyAdapter.Fill(dati);
                        dataGridView1.DataSource = dati;
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql2 = "SELECT marca, modello, prezzo, riparazioni FROM automobile WHERE modello = @modello";

                using (MySqlCommand cmd1 = new MySqlCommand(sql2, conn))
                {
                    cmd1.Parameters.AddWithValue("@modello", comboBox4.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati2 = new DataTable();
                        MyAdapter.Fill(dati2);
                        dataGridView2.DataSource = dati2;
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ConnectionString = "server=127.0.0.1;uid=roott;pwd=roott;database=macchina";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                String sql2 = "SELECT marca, modello, prezzo, riparazioni FROM automobile WHERE prezzo = @prezzo";

                using (MySqlCommand cmd1 = new MySqlCommand(sql2, conn))
                {
                    cmd1.Parameters.AddWithValue("@prezzo", comboBox5.Text);

                    using (MySqlDataAdapter MyAdapter = new MySqlDataAdapter(cmd1))
                    {
                        DataTable dati2 = new DataTable();
                        MyAdapter.Fill(dati2);
                        dataGridView2.DataSource = dati2;
                    }
                }
            }
        }
    }
}
