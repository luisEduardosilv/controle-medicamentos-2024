using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public int CartaoSUS { get; set; }
        public Requisicao[] Historico { get; set; }

        public Paciente(string nome, string cpf, string endereco, int cartaoSUS)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            CartaoSUS = cartaoSUS;
        }

    }
}