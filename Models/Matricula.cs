﻿namespace CursoDeIdiomas2.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        public Aluno Aluno { get; set; }
        public Turma Turma { get; set; }
    }

}
