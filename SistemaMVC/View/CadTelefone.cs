using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Entidade;
using View.Models;

namespace View
{
    public partial class CadTelefone : Form
    {
        public CadTelefone()
        {
            InitializeComponent();
        }

        UsuarioEnt objTabela = new UsuarioEnt();

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtFone.Clear();
            txtNome.Focus();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            objTabela.Nome = txtNome.Text;
            objTabela.Telefone = txtFone.Text;

            int x = UsuarioModelo.Inserir(objTabela);

            if (x > 0)
            {
                MessageBox.Show(string.Format("Usuario {0} foi inserido!", txtNome.Text));
                ListaGrid();
            }
            else
            {
                MessageBox.Show("Não inserido!");
            }
        }

        private void ListaGrid()
        {
            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModelo().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void CadTelefone_Load(object sender, EventArgs e)
        {
            ListaGrid();
        }

        private void grid_click(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtFone.Text = grid.CurrentRow.Cells[2].Value.ToString();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                ListaGrid();
                return;
            }
            try
            {
                LimparCampos();
                txtBusca.Focus();
                objTabela.Nome = txtBusca.Text;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModelo().Consulta(objTabela);

                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar dados" + ex.Message);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                objTabela.Id = Convert.ToInt32(txtID.Text);
                objTabela.Nome = Convert.ToString(txtNome.Text);
                objTabela.Telefone = Convert.ToString(txtFone.Text);

                int x = UsuarioModelo.Editar(objTabela);
                if (x > 0)
                {
                    MessageBox.Show(string.Format("Usuario {0} foi Editado!", txtNome.Text));
                }
                else
                {
                    MessageBox.Show("Não foi alterado!");
                }
                LimparCampos();
                ListaGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                objTabela.Id = Convert.ToInt32(txtID.Text);
                objTabela.Nome = Convert.ToString(txtNome.Text);
                objTabela.Telefone = Convert.ToString(txtFone.Text);

                int x = UsuarioModelo.Excluir(objTabela);
                if (x > 0)
                {
                    MessageBox.Show("Usuario Excluido!");
                }
                else
                {
                    MessageBox.Show("Não Excluido!");
                }
                LimparCampos();
                ListaGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
