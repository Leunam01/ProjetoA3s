using System;
using Xunit;
using ProjetoA3s.Model;

namespace ProjetoA3s.Tests1
{
    public class TutorTests
    {
        [Fact]
        public void Tutor_Idade_DeveRetornarIdadeCorreta()
        {
            // Arrange
            var dataNascimento = new DateTime(1990, 6, 5);
            var tutor = new Tutor(1, "João", "123.456.789-00", dataNascimento, "Masculino");

            // Act
            var idade = tutor.Idade;

            // Assert
            var expectedAge = DateTime.Today.Year - 1990;
            if (DateTime.Today < new DateTime(DateTime.Today.Year, 6, 5))
            {
                expectedAge--;
            }
            Assert.Equal(expectedAge, idade);
        }

        [Fact]
        public void Tutor_Construtor_DeveInicializarPropriedadesCorretamente()
        {
            // Arrange
            var id = 1;
            var nome = "João";
            var cpf = "123.456.789-00";
            var dataNascimento = new DateTime(1990, 6, 5);
            var genero = "Masculino";

            // Act
            var tutor = new Tutor(id, nome, cpf, dataNascimento, genero);

            // Assert
            Assert.Equal(id, tutor.Id);
            Assert.Equal(nome, tutor.Nome);
            Assert.Equal(cpf, tutor.CPF);
            Assert.Equal(dataNascimento, tutor.DataNascimento);
            Assert.Equal(genero, tutor.Genero);
        }
    }
}
