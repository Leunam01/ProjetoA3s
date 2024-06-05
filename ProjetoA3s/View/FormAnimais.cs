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
    public partial class FormAnimais : Form
    {
        // Criar uma instância de AnimalController
        AnimalController animalController = new AnimalController();
        public FormAnimais()
        {
            InitializeComponent();
        }

        private void FormAnimais_Load(object sender, EventArgs e)
        {

            // Obter os tutores registrados
            List<Animal> animais = animalController.ObterTodosAnimais();

            // Preencher o DataGridView com os dados dos tutores
            foreach (var animal in animais)
            {
                dataGridViewAnimais.Rows.Add(animal.Id, animal.Nome, animal.Especie, animal.Raca, animal.Idade, animal.Genero, animal.CpfTutor);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se alguma linha está selecionada na DataGridView
            if (dataGridViewAnimais.SelectedRows.Count > 0)
            {
                // Obtém o ID do tutor da linha selecionada
                int id = Convert.ToInt32(dataGridViewAnimais.SelectedRows[0].Cells["Id"].Value);

                // Remove a linha selecionada da DataGridView
                dataGridViewAnimais.Rows.RemoveAt(dataGridViewAnimais.SelectedRows[0].Index);

                // Remove o tutor do banco de dados usando o TutorController
                animalController.ExcluirAnimal(id);

                MessageBox.Show("Animal excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, selecione um animal para excluir.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewAnimais.Rows)
            {
                // Verifica se a linha não é uma linha de cabeçalho
                if (!row.IsNewRow)
                {
                    // Recupera os dados da linha
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string nome = Convert.ToString(row.Cells["Nome"].Value);
                    string especie = Convert.ToString(row.Cells["Especie"].Value);
                    string raca = Convert.ToString(row.Cells["Raca"].Value);
                    int idade = Convert.ToInt32(row.Cells["Idade"].Value);
                    string genero = Convert.ToString(row.Cells["Genero"].Value);
                    string tutor = Convert.ToString(row.Cells["Tutor"].Value);

                    if (idade > 100)
                    {
                        MessageBox.Show($"Idade inválida na linha {row.Index + 1}: Idade {idade}. Animal deve ter no máximo 100 anos.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Interrompe a execução do método se a data de nascimento for inválida
                    }
                    // Atualiza o tutor no banco de dados
                    animalController.AtualizarAnimal(new Animal(id, nome, especie, raca, idade, genero, tutor));
                }
            }

            MessageBox.Show("Alterações salvas com sucesso!"); // Exibe uma mensagem de sucesso
        }
    }
    
}
