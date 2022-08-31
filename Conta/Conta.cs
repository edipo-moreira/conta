using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using ContaEntity = Conta.Entities.Conta;

namespace Conta
{
    public partial class Conta : Form
    {
        public BindingList<ContaEntity> listaContas = new BindingList<ContaEntity> ();

        public Conta()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var conta = new ContaEntity();
            conta.NomeTitular = txtTitular.Text;
            conta.NumeroConta = int.Parse(txtConta.Text);
            conta.PrimeiroDeposito = double.Parse(txtPrimeiroDeposito.Text);
            conta.Depositar(double.Parse(txtPrimeiroDeposito.Text));
            addDgvData(conta);
            updateDgvDataSource();
        }

        private void updateDgvDataSource()
        {
            dgv.DataSource = listaContas;
            dgv.Refresh();
        }

        private void addDgvData(ContaEntity conta)
        {
            listaContas.Add(conta);
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            int i = dgv.CurrentRow.Index;
            
            if (listaContas[i].Saldo > 0 && listaContas[i].Saldo >= double.Parse(txtValor.Text))
            {
                listaContas[i].Sacar(double.Parse(txtValor.Text));
                updateDgvDataSource();
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            int i = dgv.CurrentRow.Index;
            listaContas[i].Depositar(double.Parse(txtValor.Text));
            updateDgvDataSource();
        }
    }
}