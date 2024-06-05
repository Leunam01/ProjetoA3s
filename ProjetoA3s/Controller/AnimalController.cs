using System.Collections.Generic;
using ProjetoA3s.Model;
using ProjetoA3s.Data;


namespace ProjetoA3s.Controller
{
    public class AnimalController
    {
        private readonly Banco banco;

        public AnimalController()
        {
            banco = new Banco();
        }

        public void AdicionarAnimal(Animal animal)
        {
            banco.AdicionarAnimal(animal);
        }

        public void AtualizarAnimal(Animal animal)
        {
            banco.AtualizarAnimal(animal);
        }

        public void ExcluirAnimal(int animalId)
        {
            banco.ExcluirAnimal(animalId);
        }

        public List<Animal> ObterTodosAnimais()
        {
            return banco.ObterTodosAnimais();
        }

        public List<Animal> ObterAnimaisPorTutor(string CpfTutor)
        {
            return banco.ObterAnimaisPorTutor(CpfTutor);
        }

        public string ObterNomeTutorPorCpf(string CpfTutor)
        {
            return banco.ObterNomeTutorPorCpf(CpfTutor);
        }

        // Implemente outros métodos conforme necessário, como ObterAnimalPorId, etc.
    }
}
