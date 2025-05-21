﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademiaApp.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AcademiaApp.Repositorio
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> ObterPorIdAsync(int id);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
        Task AdicionarAsync(Aluno aluno);
        Task AtualizarAsync(Aluno aluno);
        Task RemoverAsync(int id);
    }

    public class AlunoRepository : IAlunoRepositorio
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno> ObterPorIdAsync(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task AdicionarAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
