using APICEP.Classes;
using APICEP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APICEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CarregarGrid()
        {
            ContatoDAO contatoDAO = new ContatoDAO();
            DataTable dataTable = contatoDAO.GetContatos();

            dgvAgenda.DataSource = dataTable;
            dgvAgenda.Refresh();

            CarregarStatusStrip();
        }


        private void CarregarStatusStrip()
        {
            ContatoDAO contatoDAO = new ContatoDAO();
            string qt = contatoDAO.ContarUsuarios();

            /*validacao se existe dados*/
            if(qt != "")
            {
                statusStrip1.Items[0].Text = qt.ToString() + " - Contatos(s)";
            }
            else
            {
                statusStrip1.Items[0].Text = qt.ToString() + "0 - Contatos(s)";
            }
            
        }

        /*botao adicionar*/
        private void btnAdcinar_Click(object sender, EventArgs e)
        {
            frmIncluirAlterarContato form = new frmIncluirAlterarContato();
            form.ShowDialog();
            CarregarGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = (int)dgvAgenda.CurrentRow.Cells[0].Value;
            ContatoDAO contatoDAO = new ContatoDAO();
            contatoDAO.Excluir(id);

            CarregarGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string Cep = dgvAgenda.CurrentRow.Cells[4].Value == DBNull.Value ? "" : (string)dgvAgenda.CurrentRow.Cells[4].Value;
            string Rua = dgvAgenda.CurrentRow.Cells[5].Value == DBNull.Value ? "" : (string)dgvAgenda.CurrentRow.Cells[5].Value;
            string Cidade = dgvAgenda.CurrentRow.Cells[6].Value == DBNull.Value ? "" : (string)dgvAgenda.CurrentRow.Cells[6].Value;
            string Bairro = dgvAgenda.CurrentRow.Cells[7].Value == DBNull.Value ? "" : (string)dgvAgenda.CurrentRow.Cells[7].Value;
            string Estado = dgvAgenda.CurrentRow.Cells[8].Value == DBNull.Value ? "" : (string)dgvAgenda.CurrentRow.Cells[8].Value;

            Contato contato = new Contato
            {
                Id = (int)dgvAgenda.CurrentRow.Cells[0].Value,
                Nome = (string)dgvAgenda.CurrentRow.Cells[1].Value,
                Email = (string)dgvAgenda.CurrentRow.Cells[2].Value,
                Telefone = (string)dgvAgenda.CurrentRow.Cells[3].Value,

                Cep = Cep,
                Rua = Rua,
                Cidade = Cidade,
                Bairro = Bairro,
                Estado = Estado,
            };

            frmIncluirAlterarContato form = new frmIncluirAlterarContato(contato);
            form.ShowDialog();
            CarregarGrid();

        }
    }
}
