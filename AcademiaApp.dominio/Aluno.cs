using System;
using System.Text.Json.Serialization;

namespace AcademiaApp.Dominio
{
    public class Aluno
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("senha")]
        public string Senha { get; set; } = string.Empty;

        [JsonPropertyName("cpf")]
        public string CPF { get; set; } = string.Empty;

        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;

        // Construtor atualizado para garantir valores não nulos
        public Aluno(string cpf, string nome, string email, string senha, DateTime dataNascimento)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;

            Console.WriteLine($"Novo aluno criado: {Nome}, {Email}, {CPF}, {DataNascimento.ToShortDateString()}");
        }

        public Aluno()
        {
            Console.WriteLine("Aluno criado sem parâmetros.");
        }

        public int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }
}