using System;

namespace APICEP.Classes
{
    public class Contato
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }

        public String Cep { get; set; }
        public String Rua { get; set; }
        public String Cidade { get; set; }
        public String Bairro { get; set; }
        public string Estado { get; set; }

    }
}
