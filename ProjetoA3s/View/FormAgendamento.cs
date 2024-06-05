using ProjetoA3s.Controller;
using ProjetoA3s.Data;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoA3s.View
{
    public partial class FormAgendamento : Form
    {
        private Banco banco;
        public FormAgendamento()
        {
            InitializeComponent();
            banco = new Banco();
            ComboBoxTutor();
            ComboBoxAnimal();
        }

        private void ComboBoxTutor()
        {
            banco.ComboBoxTutor(cbTutores);
        }
        private void ComboBoxAnimal()
        {
            banco.ComboBoxAnimal(cbAnimais);
        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            if(dtpDataHora.Value < DateTime.Now)
            {
                MessageBox.Show("Coloque uma data valida");
            }
            else if (cbAnimais.Items.Contains(cbAnimais.Text) && cbTutores.Items.Contains(cbTutores.Text))
            {
                // Capturar os dados do formulário
                string nomeAnimal = cbAnimais.Text;
                string nomeTutor = cbTutores.Text;
                DateTime dataHora = dtpDataHora.Value;
                string observacao = txtObs.Text;

                // Criar objeto Agendamento
                Agendamento agendamento = new Agendamento
                {
                    NomeTutor = nomeTutor,
                    AnimalId = banco.ObterIdAnimalPorNome(nomeAnimal),
                    NomeAnimal = nomeAnimal,
                    DataHora = dataHora,
                    Observacao = observacao
                };

                // Adicionar agendamento no banco de dados
                AgendamentoController agendamentoController = new AgendamentoController();
                agendamentoController.AdicionarAgendamento(agendamento);

                MessageBox.Show("Agendamento adicionado com sucesso!");
                limparCampos();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um item da lista.");
            }
        }
    

        private void btnApagar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limparCampos()
        {
            cbTutores.SelectedIndex = -1;
            cbAnimais.SelectedIndex = -1;
            dtpDataHora.Value = DateTime.Now;
            txtObs.Text = string.Empty;
        }
    }
}
