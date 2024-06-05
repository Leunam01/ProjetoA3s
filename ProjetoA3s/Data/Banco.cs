using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows.Forms;
using ProjetoA3s.Model;

namespace ProjetoA3s.Data
{
    public class Banco
    {
        private string connectionString = "Data Source=Clinica.db;Version=3;";

        public void CriarTabelas()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sqlTutores = @"CREATE TABLE IF NOT EXISTS Tutores (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Nome TEXT,
                                        CPF TEXT,
                                        DataNascimento TEXT,
                                        Genero TEXT
                                    )";
                using (var command = new SQLiteCommand(sqlTutores, connection))
                {
                    command.ExecuteNonQuery();
                }

                string sqlAnimais = @"CREATE TABLE IF NOT EXISTS Animais (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nome TEXT,
                                Especie TEXT,
                                Raca TEXT,
                                Idade INTEGER,
                                Genero TEXT,
                                CpfTutor TEXT,
                                FOREIGN KEY(CpfTutor) REFERENCES Tutores(CPF)
                                )";
                using (var command = new SQLiteCommand(sqlAnimais, connection))
                {
                    command.ExecuteNonQuery();
                }

                string sqlAgendamentos = @"CREATE TABLE IF NOT EXISTS Agendamentos (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Tutor TEXT,
                                AnimalId INTEGER,
                                NomeAnimal TEXT,
                                DataHora TEXT,
                                Observacao TEXT,
                                FOREIGN KEY(AnimalId) REFERENCES Animais(Id)
                            )";
                using (var command = new SQLiteCommand(sqlAgendamentos, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void AdicionarAnimal(Animal animal)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"INSERT INTO Animais (Nome, Especie, Raca, Idade, Genero, CpfTutor) 
                                    VALUES (@Nome, @Especie, @Raca, @Idade, @Genero, @CpfTutor)";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", animal.Nome);
                        command.Parameters.AddWithValue("@Especie", animal.Especie);
                        command.Parameters.AddWithValue("@Raca", animal.Raca);
                        command.Parameters.AddWithValue("@Idade", animal.Idade);
                        command.Parameters.AddWithValue("@Genero", animal.Genero);
                        command.Parameters.AddWithValue("@CpfTutor", animal.CpfTutor);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarAnimal(Animal animal)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"UPDATE Animais SET 
                                Nome = @Nome,
                                Especie = @Especie,
                                Raca = @Raca,
                                Idade = @Idade,
                                Genero = @Genero,
                                CpfTutor = @CpfTutor
                                WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", animal.Nome);
                        command.Parameters.AddWithValue("@Especie", animal.Especie);
                        command.Parameters.AddWithValue("@Raca", animal.Raca);
                        command.Parameters.AddWithValue("@Idade", animal.Idade);
                        command.Parameters.AddWithValue("@Genero", animal.Genero);
                        command.Parameters.AddWithValue("@CpfTutor", animal.CpfTutor);
                        command.Parameters.AddWithValue("@Id", animal.Id);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExcluirAnimal(int animalId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM Animais WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", animalId);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Animal ObterAnimalPorId(int animalId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Animais WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", animalId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Animal animal = new Animal(
                                   Convert.ToInt32(reader["Id"]),
                                   reader["Nome"].ToString(),
                                   reader["Especie"].ToString(),
                                   reader["Raca"].ToString(),
                                   Convert.ToInt32(reader["Idade"]),
                                   reader["Genero"].ToString(),
                                   reader["CpfTutor"].ToString()
                               );
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }

        public List<Animal> ObterTodosAnimais()
        {
            List<Animal> animais = new List<Animal>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Animais";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //Tutor tutor = new Tutor(
                                Animal animal = new Animal(
                                   Convert.ToInt32(reader["Id"]),
                                   reader["Nome"].ToString(),
                                   reader["Especie"].ToString(),
                                   reader["Raca"].ToString(),
                                   Convert.ToInt32(reader["Idade"]),
                                   reader["Genero"].ToString(),
                                   reader["CpfTutor"].ToString()
                               );
                                animais.Add(animal);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return animais;
        }

        public List<Animal> ObterAnimaisPorTutor(string CpfTutor)
        {
            List<Animal> animais = new List<Animal>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Animais WHERE CpfTutor = @CpfTutor";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CpfTutor", CpfTutor);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Animal animal = new Animal(
                                    Convert.ToInt32(reader["Id"]),
                                    reader["Nome"].ToString(),
                                    reader["Especie"].ToString(),
                                    reader["Raca"].ToString(),
                                    Convert.ToInt32(reader["Idade"]),
                                    reader["Genero"].ToString(),
                                    reader["CpfTutor"].ToString()
                                );
                                animais.Add(animal);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return animais;
        }

        public string ObterNomeTutorPorCpf(string cpfTutor)
        {
            string nomeTutor = null;

            string query = "SELECT Nome FROM Tutores WHERE CPF = @CpfTutor";

            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CpfTutor", cpfTutor);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nomeTutor = reader.GetString(0);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return nomeTutor;
        }

        public void AdicionarTutor(Tutor tutor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"INSERT INTO Tutores (Nome, CPF, DataNascimento, Genero) 
                            VALUES (@Nome, @CPF, @DataNascimento, @Genero)";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", tutor.Nome);
                        command.Parameters.AddWithValue("@CPF", tutor.CPF);
                        command.Parameters.AddWithValue("@DataNascimento", tutor.DataNascimento.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Genero", tutor.Genero);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarTutor(Tutor tutor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"UPDATE Tutores SET 
                            Nome = @Nome,
                            CPF = @CPF,
                            DataNascimento = @DataNascimento,
                            Genero = @Genero
                            WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", tutor.Nome);
                        command.Parameters.AddWithValue("@CPF", tutor.CPF);
                        command.Parameters.AddWithValue("@DataNascimento", tutor.DataNascimento.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Genero", tutor.Genero);
                        command.Parameters.AddWithValue("@Id", tutor.Id);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExcluirTutor(int tutorId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM Tutores WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", tutorId);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Tutor ObterTutorPorId(int tutorId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Tutores WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", tutorId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Tutor(
                                    Convert.ToInt32(reader["Id"]),
                                    reader["Nome"].ToString(),
                                    reader["CPF"].ToString(),
                                    Convert.ToDateTime(reader["DataNascimento"]),
                                    reader["Genero"].ToString()
                                );
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }

        public List<Tutor> ObterTodosTutores()
        {
            List<Tutor> tutores = new List<Tutor>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Tutores";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tutor tutor = new Tutor(
                                    Convert.ToInt32(reader["Id"]),
                                    reader["Nome"].ToString(),
                                    reader["CPF"].ToString(),
                                    Convert.ToDateTime(reader["DataNascimento"]),
                                    reader["Genero"].ToString()
                                );
                                tutores.Add(tutor);
                            }
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return tutores;
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"INSERT INTO Agendamentos (Tutor, AnimalId, NomeAnimal, DataHora, Observacao) 
                        VALUES (@Tutor, @AnimalId, @NomeAnimal, @DataHora, @Observacao)";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tutor", agendamento.NomeTutor);
                        command.Parameters.AddWithValue("@AnimalId", agendamento.AnimalId);
                        command.Parameters.AddWithValue("@NomeAnimal", agendamento.NomeAnimal);
                        command.Parameters.AddWithValue("@DataHora", agendamento.DataHora);
                        command.Parameters.AddWithValue("@Observacao", agendamento.Observacao);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarAgendamento(Agendamento agendamento)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = @"UPDATE Agendamentos SET 
                        Tutor = @Tutor,
                        NomeAnimal = @NomeAnimal,
                        DataHora = @DataHora,
                        Observacao = @Observacao
                        WHERE Id = @Id";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tutor", agendamento.NomeTutor);
                        command.Parameters.AddWithValue("@NomeAnimal", agendamento.NomeAnimal);
                        command.Parameters.AddWithValue("@DataHora", agendamento.DataHora);
                        command.Parameters.AddWithValue("@Observacao", agendamento.Observacao);
                        command.Parameters.AddWithValue("@Id", agendamento.Id);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExcluirAgendamento(string tutor)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "DELETE FROM Agendamentos WHERE Tutor = @Tutor";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Tutor", tutor);
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Agendamento> ObterTodosAgendamentos()
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM Agendamentos";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Certifique-se de passar todos os parâmetros necessários para o construtor
                                Agendamento agendamento = new Agendamento(
                                    Convert.ToInt32(reader["Id"]),
                                    reader["Tutor"].ToString(),
                                    Convert.ToInt32(reader["AnimalId"]),
                                    reader["NomeAnimal"].ToString(),
                                    Convert.ToDateTime(reader["DataHora"]),
                                    reader["Observacao"].ToString()
                                );
                                agendamentos.Add(agendamento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter os agendamentos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return agendamentos;
        }

        public List<Agendamento> ObterTodosAgendamentosSemAnimalId()
        {
            List<Agendamento> agendamentos = new List<Agendamento>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT Id, Tutor, NomeAnimal, DataHora, Observacao FROM Agendamentos";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Agendamento agendamento = new Agendamento(
                                    reader["Tutor"].ToString(),
                                    reader["NomeAnimal"].ToString(),
                                    Convert.ToDateTime(reader["DataHora"]),
                                    reader["Observacao"].ToString()
                                );
                                agendamentos.Add(agendamento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao obter os agendamentos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return agendamentos;
        }

        public void ComboBoxTutor(ComboBox comboBox)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Nome FROM Tutores"; // Ajuste a consulta conforme necessário
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear(); // Limpa o ComboBox antes de adicionar novos itens
                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["Nome"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void ComboBoxAnimal(ComboBox comboBox)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Nome FROM Animais"; // Ajuste a consulta conforme necessário
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            comboBox.Items.Clear(); // Limpa o ComboBox antes de adicionar novos itens
                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader["Nome"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int ObterIdAnimalPorNome(string nomeAnimal)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id FROM Animais WHERE Nome = @Nome";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", nomeAnimal);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Animal não encontrado.");
                            return -1; // ou outro valor que indique que o animal não foi encontrado
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar o ID do animal: " + ex.Message);
                    return -1; // ou outro valor que indique um erro
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
    
