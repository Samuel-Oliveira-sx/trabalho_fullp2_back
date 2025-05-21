
using System;

namespace AcademiaApp.Dominio
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int TreinadorId { get; set; }
        public DateTime DataHora { get; set; }
        public bool Confirmado { get; set; }

        public Agendamento(int alunoId, int treinadorId, DateTime dataHora)
        {
            AlunoId = alunoId;
            TreinadorId = treinadorId;
            DataHora = dataHora;
            Confirmado = false;
        }
    }
}