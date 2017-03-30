using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoBdOO
{
    public partial class FrmEditConta : Form
    {
        public Conta Conta { get; set; }

        public FrmEditConta()
        {
            InitializeComponent();
        }

        public FrmEditConta(Conta conta)
        {
            Conta = conta;
            InitializeComponent();
        }

        private void FrmEditConta_Load(object sender, EventArgs e)
        {
            textBox1.Text = Conta.Agencia;
            textBox2.Text = Conta.Saldo.ToString();
            if (Conta.Tipo.Equals("C"))
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }


        }
    }
}
