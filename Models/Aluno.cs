namespace CursoDeIdiomas2.Models
{
    public class Aluno
    {
        public int  Id { get; set; }
        public string Nome { get; set; }
        public string  CPF { get; set; }
        public string Email { get; set; }
        public List<Matricula> Matriculas { get; set; }
    }
}