

namespace CursoDeIdiomas2.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public int AnoLetivo { get; set; }
        public int? Descrição { get; set; }
        public int? Status { get; set; } 
        public List<Matricula> Matriculas { get; set; }
       
    }
}