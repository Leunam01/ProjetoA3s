// Dentro da pasta Controller

using System.Collections.Generic;
using ProjetoA3s.Model;
using ProjetoA3s.Data;

namespace ProjetoA3s.Controller
{
    public class TutorController
    {
        private readonly Banco banco;

        public TutorController()
        {
            banco = new Banco();
        }

        public void AdicionarTutor(Tutor tutor)
        {
            banco.AdicionarTutor(tutor);
        }

        public void AtualizarTutor(Tutor tutor)
        {
            banco.AtualizarTutor(tutor);
        }

        public void ExcluirTutor(int tutorId)
        {
            banco.ExcluirTutor(tutorId);
        }

        public List<Tutor> ObterTodosTutores()
        {
            return banco.ObterTodosTutores();
        }

        // Você também pode implementar outros métodos conforme necessário, como ObterTutorPorId, etc.
    }
}
