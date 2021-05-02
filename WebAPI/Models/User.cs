using System;

namespace WebAPI.Models
{
    public class User
    {  
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
