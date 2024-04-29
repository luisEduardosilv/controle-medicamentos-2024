using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
            
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento);
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioMedicamento, repositorioPaciente, telaMedicamento, telaPaciente);

            //TelaChamado telaChamado = new TelaChamado();
            // telaChamado.telaEquipamento = telaEquipamento;

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                char opcaoPrincipalEscolhida = ApresentarMenuPrincipal();
                char operacaoEscolhida;

                switch (opcaoPrincipalEscolhida)
                {
                    case '1':
                        operacaoEscolhida = telaMedicamento.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaMedicamento.CadastrarMedicamento();

                        else if (operacaoEscolhida == '2')
                            telaMedicamento.EditarMedicamento();

                        else if (operacaoEscolhida == '3')
                            telaMedicamento.ExcluirMedicamento();

                        else if (operacaoEscolhida == '4')
                            telaMedicamento.VisualizarMedicamentos(true);

                        else if (operacaoEscolhida == '5')
                            telaMedicamento.MedicamentosPoucaQuantidade();

                        else if (operacaoEscolhida == '6')
                            telaMedicamento.MedicamentosEmFalta();

                        break;

                    case '2':
                        operacaoEscolhida = telaPaciente.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaPaciente.CadastrarPaciente();

                        else if (operacaoEscolhida == '2')
                            telaPaciente.EditarPaciente();

                        else if (operacaoEscolhida == '3')
                            telaPaciente.ExcluirPaciente();

                        else if (operacaoEscolhida == '4')
                            telaPaciente.VisualizarPacientes(true);



                        break;

                    case '3':
                        operacaoEscolhida = telaRequisicao.ApresentarMenu();

                        if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                            break;

                        if (operacaoEscolhida == '1')
                            telaRequisicao.CadastrarRequisicao();

                        if (operacaoEscolhida == '2')
                            telaRequisicao.EditarRequisicao();

                        if (operacaoEscolhida == '3')
                            Console.WriteLine();
                        //telaRequisicao.ExcluirChamado();

                        else if (operacaoEscolhida == '4')
                            telaRequisicao.VisualizarRequisicoes();

                        break;

                    default: opcaoSairEscolhida = true; break;
                }
            }

            Console.ReadLine();

        }
        private static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerência de Medicamentos");
            Console.WriteLine("2 - Gerência de Pacientes");
            Console.WriteLine("3 - Gerência de Requisições");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }
    }
}