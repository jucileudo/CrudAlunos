namespace CrudAlunos.Models
{
    public class Turma
    {
        public Guid Id { get; set; } = new Guid();
        public int NumeroTurma { get; set; }
        public int AnoLetivo { get; set; }
        public List<Alunos> Alunos { get; set; }
    }
}
