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
    public partial class FormTutores : Form
    {
        // Criar uma instância de TutorController
        TutorController tutorController = new TutorController();
        public FormTutores()
        {
            InitializeComponent();

        }

        private void FormTutores_Load(object sender, EventArgs e)
        {

            // Obter os tutores registrados
            List<Tutor> tutores = tutorController.ObterTodosTutores();

            // Preencher o DataGridView com os dados dos tutores
            foreach (var tutor in tutores)
            {
                dataGridViewTutores.Rows.Add(tutor.Id, tutor.Nome, tutor.CPF, tutor.DataNascimento, tutor.Genero);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewTutores.Rows)
            {
                // Verifica se a linha não é uma linha de cabeçalho
                if (!row.IsNewRow)
                {
                    // Recupera os dados da linha
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string nome = Convert.ToString(row.Cells["Nome"].Value);
                    string cpf = Convert.ToString(row.Cells["CPF"].Value);
                    DateTime dataNascimento = Convert.ToDateTime(row.Cells["DataNascimento"].Value);
                    string genero = Convert.ToString(row.Cells["Genero"].Value);

                    // Valida o CPF
                    if (!ValidadorCPF.ValidarCPF(cpf))
                    {
                        MessageBox.Show($"CPF inválido na linha {row.Index + 1}: {cpf}", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Interrompe a execução do método se o CPF for inválido
                    }

                    // Valida a data de nascimento
                    if (dataNascimento.Year >= 2009)
                    {
                        MessageBox.Show($"Data de nascimento inválida na linha {row.Index + 1}: {dataNascimento.ToShortDateString()}. Ano deve ser anterior a 2009.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Interrompe a execução do método se a data de nascimento for inválida
                    }

                    // Verifica se o nome contém números
                    if (ContemNumeros(nome))
                    {
                        MessageBox.Show($"Nome inválido na linha {row.Index + 1}: {nome}. O nome não pode conter números.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Interrompe a execução do método se o nome contiver números
                    }

                    // Atualiza o tutor no banco de dados
                    tutorController.AtualizarTutor(new Tutor(id, nome, cpf, dataNascimento, genero));
                }
            }

            MessageBox.Show("Alterações salvas com sucesso!"); // Exibe uma mensagem de sucesso
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se alguma linha está selecionada na DataGridView
            if (dataGridViewTutores.SelectedRows.Count > 0)
            {
                // Obtém o ID do tutor da linha selecionada
                int id = Convert.ToInt32(dataGridViewTutores.SelectedRows[0].Cells["Id"].Value);

                // Remove a linha selecionada da DataGridView
                dataGridViewTutores.Rows.RemoveAt(dataGridViewTutores.SelectedRows[0].Index);

                // Remove o tutor do banco de dados usando o TutorController
                tutorController.ExcluirTutor(id);

                MessageBox.Show("Tutor excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, selecione um tutor para excluir.");
            }
        }
        private bool ContemNumeros(string texto)
        {
            return Regex.IsMatch(texto, @"\d");
        }
    }
}


