namespace ProjetoA3s.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public string Genero { get; set; }
        public string CpfTutor { get; set; } // Referência ao tutor do animal

        // Construtor que aceita todos os parâmetros
        public Animal(int id, string nome, string especie, string raca, int idade, string genero, string cpfTutor)
        {
            Id = id;
            Nome = nome;
            Especie = especie;
            Raca = raca;
            Idade = idade;
            Genero = genero;
            CpfTutor = cpfTutor;
        }

        public Animal()
        {
        }

        public Animal(int idade)
        {
            Idade = idade;
        }
    }
}
