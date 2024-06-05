using ProjetoA3s.Model;
using ProjetoA3s.Data;
using System.Collections.Generic;


namespace ProjetoA3s.Controller
{
    public class AgendamentoController
    {
        private readonly Banco banco;

        public AgendamentoController()
        {
            banco = new Banco();
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            // Aqui você pode adicionar lógica de validação, se necessário
            banco.AdicionarAgendamento(agendamento);
        }

        public void AtualizarAgendamento(Agendamento agendamento)
        {
            banco.AtualizarAgendamento(agendamento);
        }

        public void ExcluirAgendamento(string Tutor)
        {
            banco.ExcluirAgendamento(Tutor);
        }

        public List<Agendamento> ObterTodosAgendamentos()
        {
            return banco.ObterTodosAgendamentos();
        }
    }
}