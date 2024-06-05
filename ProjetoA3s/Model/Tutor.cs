using System;

namespace ProjetoA3s.Model
{
    public class Tutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade
        {
            get
            {
                var idade = DateTime.Today.Year - DataNascimento.Year;
                if (DateTime.Today < DataNascimento.AddYears(idade)) idade--;
                return idade;
            }
        }
        public string Genero { get; set; }

        // Construtor que aceita cinco argumentos
        public Tutor(int id, string nome, string cpf, DateTime dataNascimento, string genero)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Genero = genero;
        }
    }
}
