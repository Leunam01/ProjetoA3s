using ProjetoA3s.Model;
using Xunit;

namespace ProjetoA3s.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void Criar_animal_com_as_propriedades()
        {
            // Arrange
            int id = 1;
            string nome = "Bobby";
            string especie = "Cão";
            string raca = "Labrador";
            int idade = 5;
            string genero = "Macho";
            string cpfTutor = "12345678900";

            // Act
            Animal animal = new Animal(id, nome, especie, raca, idade, genero, cpfTutor);

            // Assert
            Assert.Equal(id, animal.Id);
            Assert.Equal(nome, animal.Nome);
            Assert.Equal(especie, animal.Especie);
            Assert.Equal(raca, animal.Raca);
            Assert.Equal(idade, animal.Idade);
            Assert.Equal(genero, animal.Genero);
            Assert.Equal(cpfTutor, animal.CpfTutor);
        }

        [Fact]
        public void IDdoanimaldeveestarcorreta()
        {
            // Arrange
            int expectedId = 2;

            // Act
            Animal animal = new Animal(expectedId, "Rex", "Cão", "Bulldog", 3, "Macho", "98765432100");

            // Assert
            Assert.Equal(expectedId, animal.Id);
        }

        [Fact]
        public void Nomedoanimaldeveestarcerto()
        {
            // Arrange
            string expectedNome = "Rex";

            // Act
            Animal animal = new Animal(2, expectedNome, "Cão", "Bulldog", 3, "Macho", "98765432100");

            // Assert
            Assert.Equal(expectedNome, animal.Nome);
        }

    }
}