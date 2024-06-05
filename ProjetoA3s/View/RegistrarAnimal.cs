using ProjetoA3s.Controller;
using ProjetoA3s.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoA3s.View
{
    public partial class RegistrarAnimal : Form
    {
        AnimalController animalController = new AnimalController();
        public RegistrarAnimal()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimparControles()
        {
            txtNome.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            txtRaca.Text = string.Empty;
            numIdade.Text = string.Empty;
            cbGenero.SelectedIndex = 1;
            txtCPFTutor.Text = string.Empty;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            LimparControles();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Obter os dados inseridos pelo usuário nos controles do formulário
            string nome = txtNome.Text;
            string especie = txtEspecie.Text;
            string raca = txtRaca.Text;
            int idade = int.Parse(numIdade.Text);
            string genero = cbGenero.Text;
            string cpfTutor = txtCPFTutor.Text;
            string nomeTutor = animalController.ObterNomeTutorPorCpf(cpfTutor);

            if(nome == "" || especie == "" || raca == "" || cbGenero.SelectedIndex == -1 || cpfTutor == "")
            {
                MessageBox.Show("Preencha todos os campos");
            }
            else if (nomeTutor != null)
            {
                // Criar um novo objeto Animal com os dados inseridos
                // Inicializa o id com 0 ou outro valor padrão
                Animal animal = new Animal(0, nome, especie, raca, idade, genero, nomeTutor);

                // Adicionar o novo animal ao banco de dados usando o AnimalController
                animalController.AdicionarAnimal(animal);

                // Mostrar uma mensagem de sucesso ou realizar outras ações após o registro do animal
                MessageBox.Show("Animal registrado com sucesso!");

                // Limpar os controles do formulário após o registro
                LimparControles();
            }
            else
            {
                MessageBox.Show("Tutor não encontrado. Verifique o CPF");
            }
        }
    }
}
