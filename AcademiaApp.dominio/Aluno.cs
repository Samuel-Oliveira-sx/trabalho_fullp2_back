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
        public string Senha { get; set; }

        [JsonPropertyName("cpf")]
        public string CPF { get; set; }

        [JsonPropertyName("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonPropertyName("dataMatricula")]
        public DateTime DataMatricula { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }

        public Aluno(string cpf, string nome, string email, string senha, DateTime dataNascimento, DateTime dataMatricula)
        {
            CPF = cpf;
            Nome = nome;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            DataMatricula = dataMatricula;
            Ativo = true;
        }

        public Aluno() { }

        public int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public void CancelarMatricula()
        {
            Ativo = false;
        }
    }
}