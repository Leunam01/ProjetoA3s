using System;

namespace ProjetoA3s.Model
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string NomeTutor { get; set; }
        public string NomeAnimal { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacao { get; set; }
        // Você pode adicionar mais propriedades conforme necessário

        public Agendamento(int id, string nomeTutor, int animalId, string nomeAnimal, DateTime dataHora, string observacao)
        {
            Id = id;
            NomeTutor = nomeTutor;
            AnimalId = animalId;
            NomeAnimal = nomeAnimal;
            DataHora = dataHora;
            Observacao = observacao;
        }

        public Agendamento(string tutor, string animal, DateTime data, string observacao)
        {
            NomeTutor = tutor;
            NomeAnimal = animal;
            DataHora = data;
            Observacao = observacao;
        }

        public Agendamento() { }
    }
}