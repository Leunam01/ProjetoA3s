using ProjetoA3s.Controller;
using ProjetoA3s.Model;
using ProjetoA3s.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoA3s.View
{
    public partial class RegistrarTutor : Form
    {
        public RegistrarTutor()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtCPF.Text == "" || cbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (dtpNasc.Value.Year >= 2009)
            {
                MessageBox.Show("O tutor tem que ter uma idade mínima de 15 anos", "Idade inválida");
            }
            else if (!ValidadorCPF.ValidarCPF(txtCPF.Text)) // O ! antes do ValidadorCPF, significa que se o metodo retorna false, ele vai virar true, se retornar true, vira false
            {
                MessageBox.Show("CPF inválido!");
            }
            else if (ContemNumeros(txtNome.Text)) // Verifica se o nome contém números
            {
                MessageBox.Show("O nome não pode conter números!", "Nome inválido");
            }
            else
            {
                // Obter os dados inseridos pelo usuário nos controles do formulário
                string nome = txtNome.Text;
                string cpf = txtCPF.Text;
                DateTime dataNascimento = dtpNasc.Value;
                string genero = cbGenero.SelectedItem.ToString();

                // Criar um novo objeto Tutor com os dados inseridos
                // Inicialize o id com 0 ou outro valor padrão
                Tutor novoTutor = new Tutor(0, nome, cpf, dataNascimento, genero);

                // Adicionar o novo tutor ao banco de dados usando o TutorController
                TutorController tutorController = new TutorController();
                tutorController.AdicionarTutor(novoTutor);

                // Mostrar uma mensagem de sucesso ou realizar outras ações após o registro do tutor
                MessageBox.Show("Tutor registrado com sucesso!");

                // Limpar os controles do formulário após o registro
                LimparControles();
            }
        }
        //Metodo para limpar os campos de texto do registro
        private void LimparControles()
        {
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;
            dtpNasc.Value = DateTime.Now;
            cbGenero.SelectedIndex = -1;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            LimparControles();
        }

        private bool ContemNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"\d");
        }
    }
}
