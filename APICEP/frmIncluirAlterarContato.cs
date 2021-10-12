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
    public partial class frmIncluirAlterarContato : Form
    {
        private Contato contato;

        public frmIncluirAlterarContato(Contato contato = null)
        {
            InitializeComponent();
            this.contato = contato;
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            ContatoDAO contatoDao = new ContatoDAO();

            if (this.contato == null)
            {
                Contato contato = new Contato
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,

                    Cep = txtCep.Text,
                    Rua = txtRua.Text,
                    Cidade = txtCidade.Text,
                    Bairro = txtBairro.Text,
                    Estado = txtEstado.Text
                };

                contatoDao.Inserir(contato);
            }
            else
            {
                this.contato.Nome = txtNome.Text;
                this.contato.Email = txtEmail.Text;
                this.contato.Telefone = txtTelefone.Text;

                this.contato.Cep = txtCep.Text;
                this.contato.Rua = txtRua.Text;
                this.contato.Cidade = txtCidade.Text;
                this.contato.Bairro = txtBairro.Text;
                this.contato.Estado = txtEstado.Text;

                contatoDao.Atualizar(this.contato);
            }

            this.Close();
        }

        private void LocalizarCEP()
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var resultado = ws.consultaCEP(txtCep.Text);
                        txtRua.Text = resultado.end;
                        txtCidade.Text = resultado.cidade;
                        txtBairro.Text = resultado.bairro;
                        txtEstado.Text = resultado.uf;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

            }
            else
            {
                MessageBox.Show("Informe um CEP válido");
            }
        }


        private void txtCep_Leave(object sender, EventArgs e)
        {
            LocalizarCEP();
        }

        private void frmIncluirAlterarContato_Load(object sender, EventArgs e)
        {
            if (this.contato != null)
            {
                txtNome.Text = this.contato.Nome;
                txtEmail.Text = this.contato.Email;
                txtTelefone.Text = this.contato.Telefone.ToString();

                txtCep.Text = this.contato.Cep;
                txtRua.Text = this.contato.Rua;
                txtCidade.Text = this.contato.Cidade;
                txtBairro.Text = this.contato.Bairro;
                txtEstado.Text = this.contato.Estado;

            }
            else
            {
                txtNome.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefone.Text = string.Empty;

                txtCep.Text = string.Empty;
                txtRua.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtBairro.Text = string.Empty;
                txtEstado.Text = string.Empty;
            }

            txtNome.Focus();
        }
    }
}
