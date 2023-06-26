using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questão_5
{
    internal class DadosAluno
    {
        public class Aluno
        {
            public int id { get; set; }
            public string nome { get; set; }
            public int idade { get; set; }
            public string ra { get; set; }
        }

        public class Root
        {
            public List<Aluno> alunos { get; set; }
        }
    }
}
