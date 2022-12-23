using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Atividade2.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string nome {get; set;}
        public string Login {get; set;}
        public string Senha {get; set;}
        public DateTime DataDeNascimento {get; set;}

    }
}