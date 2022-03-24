using CrudAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAlunos
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base (options)
        {

        }

        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}
