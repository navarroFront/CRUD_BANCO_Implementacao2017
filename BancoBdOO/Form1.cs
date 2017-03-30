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

namespace BancoBdOO
{
    public partial class Form1 : Form
    {
        public List<Conta> Contas { get; set; }

        public Form1()
        {
            Contas = new List<Conta>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var stringConexao = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conexao = new SqlConnection(stringConexao);

            conexao.Open();

            SqlCommand comando = new SqlCommand("Select * from Contas", conexao);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Conta conta = new Conta();
                conta.Id = Convert.ToInt32(reader["Id"]);
                conta.Numero = reader["Numero"].ToString();
                conta.Agencia = reader["Agencia"].ToString();
                conta.Saldo = Convert.ToDecimal(reader["Saldo"]);
                conta.Tipo = reader["Tipo"].ToString();
                Contas.Add(conta);
            }

            dataGridView1.DataSource = Contas;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Conta linha = dataGridView1.SelectedRows[0].DataBoundItem as Conta;

            FrmEditConta frmEdit = new FrmEditConta(linha);
            frmEdit.Show();



        }
    }
}
