using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao
    {
        public int Id { get; set; }
        public Medicamento Medicamento { get; set; }
        public Paciente Paciente { get; set; }
        public int Quantidade { get; set; }
        public DateOnly DataValidade { get; set; }

        public Requisicao(Medicamento medicamento, Paciente paciente, int quantidade, DateOnly dataValidade)
        {
            Medicamento = medicamento;
            Paciente = paciente;
            Quantidade = quantidade;
            DataValidade = dataValidade;
        }
    }
}