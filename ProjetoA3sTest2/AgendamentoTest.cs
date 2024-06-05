using System;
using ProjetoA3s.Model;
using Xunit;

namespace ProjetoA3s.Tests2
{
    public class AgendamentoTests
    {
        [Fact]
        public void Agendamento_Constructor_WithAllParameters_ShouldSetProperties()
        {
            // Arrange
            int id = 1;
            string nomeTutor = "João Silva";
            int animalId = 101;
            string nomeAnimal = "Rex";
            DateTime dataHora = new DateTime(2024, 6, 5, 10, 30, 0);
            string observacao = "Vacinação";

            // Act
            var agendamento = new Agendamento(id, nomeTutor, animalId, nomeAnimal, dataHora, observacao);

            // Assert
            Assert.Equal(id, agendamento.Id);
            Assert.Equal(nomeTutor, agendamento.NomeTutor);
            Assert.Equal(animalId, agendamento.AnimalId);
            Assert.Equal(nomeAnimal, agendamento.NomeAnimal);
            Assert.Equal(dataHora, agendamento.DataHora);
            Assert.Equal(observacao, agendamento.Observacao);
        }

        [Fact]
        public void Agendamento_Constructor_WithoutId_ShouldSetProperties()
        {
            // Arrange
            string nomeTutor = "Maria Santos";
            string nomeAnimal = "Bobby";
            DateTime dataHora = new DateTime(2024, 6, 6, 14, 45, 0);
            string observacao = "Consulta de rotina";

            // Act
            var agendamento = new Agendamento(nomeTutor, nomeAnimal, dataHora, observacao);

            // Assert
            Assert.Equal(nomeTutor, agendamento.NomeTutor);
            Assert.Equal(nomeAnimal, agendamento.NomeAnimal);
            Assert.Equal(dataHora, agendamento.DataHora);
            Assert.Equal(observacao, agendamento.Observacao);
        }

        [Fact]
        public void Agendamento_ParameterlessConstructor_ShouldInitializeProperties()
        {
            // Act
            var agendamento = new Agendamento();

            // Assert
            Assert.Equal(0, agendamento.Id);
            Assert.Null(agendamento.NomeTutor);
            Assert.Equal(0, agendamento.AnimalId);
            Assert.Null(agendamento.NomeAnimal);
            Assert.Equal(default(DateTime), agendamento.DataHora);
            Assert.Null(agendamento.Observacao);
        }
    }
}
