
using System;
using System.Collections.Generic;

namespace AcademiaApp.Dominio
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public List<string> PlanosAtivos { get; set; } = new();
        public DateTime DataMatricula { get; set; }
        public bool Ativo { get; set; }

        public Aluno(string nome, string email, DateTime dataNascimento, DateTime dataMatricula)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            DataMatricula = dataMatricula;
            Ativo = true; 
        }

        public bool TemPlanoAtivo()
        {
            return PlanosAtivos.Count > 0;
        }

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
            PlanosAtivos.Clear(); 
        }
    }
}