using System;
using System.Globalization;

namespace exercicio_fixacao_pensao
{
    class Estudante
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Estudante(string name, string email) 
        {
            Name = name;
            Email = email;        
        }
        public override string ToString() 
        {
            return Name + ", " + Email;
        }
    }
}
