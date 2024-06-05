using ProjetoA3s.Controller;
using ProjetoA3s.Data;
using ProjetoA3s.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoA3s.View
{
    public partial class FormSistema : Form
    {
        private readonly TutorController tutorController;
        private readonly AnimalController animalController;
        private readonly AgendamentoController agendamentoController;
        Banco banco = new Banco();
        public FormSistema()
        {
            InitializeComponent();
            banco.CriarTabelas();
            tutorController = new TutorController();
            animalController = new AnimalController();
            agendamentoController = new AgendamentoController();
        }


        private void btnRegistrarTutor_Click(object sender, EventArgs e)
        {
            RegistrarTutor rt = new RegistrarTutor();
            rt.ShowDialog();
        }

        private void btnVerTutores_Click(object sender, EventArgs e)
        {
            FormTutores ft = new FormTutores();
            ft.ShowDialog();
        }

        private void btnRegistrarAnimal_Click(object sender, EventArgs e)
        {
            RegistrarAnimal rA = new RegistrarAnimal();
            rA.ShowDialog();
        }

        private void btnVerAnimais_Click(object sender, EventArgs e)
        {
            FormAnimais formAnimais = new FormAnimais();
            formAnimais.ShowDialog();
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            FormAgendamento fA = new FormAgendamento();
            fA.ShowDialog();
        }

        private void FormSistema_Load(object sender, EventArgs e)
        {

            // Obter os tutores registrados
            List<Agendamento> agendas = agendamentoController.ObterTodosAgendamentos();

            // Preencher o DataGridView com os dados dos tutores
            foreach (var agenda in agendas)
            {
                dgvAgenda.Rows.Add(agenda.NomeTutor, agenda.NomeAnimal, agenda.DataHora, agenda.Observacao);
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            // Verifica se alguma linha está selecionada na DataGridView
            if (dgvAgenda.SelectedRows.Count > 0)
            {
                // Obtém a linha selecionada
                DataGridViewRow selectedRow = dgvAgenda.SelectedRows[0];

                // Obtém o valor da célula "Nome" na linha selecionada
                string tutor = Convert.ToString(selectedRow.Cells["Tutor"].Value);

                // Remove a linha selecionada da DataGridView
                dgvAgenda.Rows.RemoveAt(selectedRow.Index);

                // Remove o tutor do banco de dados usando o TutorController
                agendamentoController.ExcluirAgendamento(tutor);

                MessageBox.Show("Tutor excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Por favor, selecione um tutor para excluir.");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin fL = new FormLogin();
            fL.Show();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dgvAgenda.Rows.Clear(); // Limpa todas as linhas do DataGridView

            // Obter os agendamentos atualizados
            List<Agendamento> agendas = agendamentoController.ObterTodosAgendamentos();

            // Preencher o DataGridView com os dados dos agendamentos
            foreach (var agenda in agendas)
            {
                dgvAgenda.Rows.Add(agenda.NomeTutor, agenda.NomeAnimal, agenda.DataHora, agenda.Observacao);
            }
        }
    }
}
