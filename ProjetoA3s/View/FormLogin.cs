using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoA3s.Controller;
using ProjetoA3s.Model;
using ProjetoA3s.View;

namespace ProjetoA3s
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se você for um funcionário que tem o direito de acessar o sistema, fale com seus superiores para receber o login.", "Não sei o Login");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtUser.Text;
            string senha = txtSenha.Text;

            if(nome != "clinicavet" || senha != "acesso123")
            {
                MessageBox.Show("Nome ou senha inválidas.", "Erro");
            }
            else
            {
                MessageBox.Show("Logado com sucesso!", "Bem vindo!");
                this.Hide();
                FormSistema formS= new FormSistema();
                formS.ShowDialog();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
