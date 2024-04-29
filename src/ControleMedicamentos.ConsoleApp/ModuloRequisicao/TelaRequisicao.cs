using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Globalization;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao
    {
        private RepositorioRequisicao repositorioRequisicao;
        private RepositorioMedicamento repositorioMedicamento;
        private RepositorioPaciente repositorioPaciente;
        private TelaMedicamento telaMedicamento;
        public TelaPaciente telaPaciente;

        public TelaRequisicao(RepositorioMedicamento repositorioMedicamento, RepositorioPaciente repositorioPaciente, TelaMedicamento telaMedicamento, TelaPaciente telaPaciente)
        {
            this.repositorioRequisicao = new RepositorioRequisicao(repositorioMedicamento);
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioPaciente = repositorioPaciente;
            this.telaMedicamento = telaMedicamento;
            this.telaPaciente = telaPaciente;
        }

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Requisição");
            Console.WriteLine("2 - Editar Requisição");
            Console.WriteLine("3 - Excluir Requisição");
            Console.WriteLine("4 - Visualizar Requisiçãos");

            Console.WriteLine("S - Voltar");


            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Console.ReadLine()[0];

            return operacaoEscolhida;
        }

        public void CadastrarRequisicao()
        {
            Console.WriteLine("Cadastrando Requisição...");

            Console.WriteLine();

            telaMedicamento.VisualizarMedicamentos(false);

            Console.Write("Digite o nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine();

            Medicamento medicamento = repositorioMedicamento.SelecionarMedicamentoPorNome(nomeMedicamento);
            if (medicamento == null)
            {
                Console.WriteLine("medicamento não encontrado.");
                return;
            }

            if (medicamento.Quantidade <= 0)
            {
                Console.WriteLine("Não há estoque disponível para este medicamento.");
                return;
            }

            telaPaciente.VisualizarPacientes(false);

            Console.Write("Digite o nome do paciente: ");
            string nomePaciente = Console.ReadLine();

            Paciente paciente = repositorioPaciente.SelecionarPacientePorNome(nomePaciente);
            if (paciente == null)
            {
                Console.WriteLine("paciente não encontrado.");
                return;
            }

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade > medicamento.Quantidade)
            {
                Console.WriteLine("Quantidade solicitada maior do que a disponível em estoque.");
                return;
            }

            Console.Write("Digite a data de validade (DD/MM/AAAA): ");
            DateOnly dataValidade = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);


            Requisicao requisicao = new Requisicao(medicamento, paciente, quantidade, dataValidade);

            repositorioRequisicao.CadastrarRequisicoes(requisicao, medicamento);

            Program.ExibirMensagem("A requisição foi cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarRequisicoes()
        {
            Console.WriteLine("{0, -15} | {1, -15} | {2, -15} | {3, -15} | {4, -10} |",
                "Medicamento", "Paciente", "CPF", "Endereço", "Quantidade");

            Requisicao[] requisicoes = repositorioRequisicao.SelecionarRequisicoes();

            foreach (Requisicao requisicao in requisicoes)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine("{0, -15} | {1, -15} | {2, -15} | {3, -15} | {4, -10} |",
                    requisicao.Medicamento.Nome, requisicao.Paciente.Nome, requisicao.Paciente.Cpf,
                    requisicao.Paciente.Endereco, requisicao.Quantidade);
            }

            Console.ReadLine();
        }

        public void EditarRequisicao()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Requisições        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Requisição...");

            Console.WriteLine();

            VisualizarRequisicoes();

            Console.Write("Digite o ID da requisição que deseja editar: ");
            int idRequisicaoEscolhida = Convert.ToInt32(Console.ReadLine());

            if (!repositorioRequisicao.ExisteRequisicao(idRequisicaoEscolhida))
            {
                Program.ExibirMensagem("A requisição mencionada não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            telaMedicamento.VisualizarMedicamentos(false);

            Console.Write("Digite o nome do medicamento: ");
            string nomeMedicamento = Console.ReadLine();

            Medicamento medicamento = repositorioMedicamento.SelecionarMedicamentoPorNome(nomeMedicamento);
            if (medicamento == null)
            {
                Console.WriteLine("medicamento não encontrado.");
                return;
            }
            Medicamento medicamentoSelecionado = telaMedicamento.repositorioMedicamento.SelecionarMedicamentoPorNome(nomeMedicamento);



            telaPaciente.VisualizarPacientes(false);

            Console.Write("Digite o nome do paciente: ");
            string nomePaciente = Console.ReadLine();

            Paciente paciente = repositorioPaciente.SelecionarPacientePorNome(nomePaciente);
            if (paciente == null)
            {
                Console.WriteLine("paciente não encontrado.");
                return;
            }
            Paciente pacienteSelecionado = telaPaciente.repositorioPaciente.SelecionarPacientePorNome(nomePaciente);

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de validade (DD/MM/AAAA): ");
            DateOnly dataValidade = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Requisicao novaRequisicao = new Requisicao(medicamentoSelecionado, pacienteSelecionado, quantidade, dataValidade);

            bool conseguiuEditar = repositorioRequisicao.EditarRequisicao(idRequisicaoEscolhida, novaRequisicao);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição da requisição", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("A requisição foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Requisições...");

            Console.WriteLine();

            VisualizarRequisicoes();

            Console.Write("Digite o ID da requisição que deseja excluir: ");
            int idRequisicaoEscolhida = Convert.ToInt32(Console.ReadLine());

            if (!repositorioRequisicao.ExisteRequisicao(idRequisicaoEscolhida))
            {
                Program.ExibirMensagem("A requisição mencionada não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorioRequisicao.ExcluirRequisicao(idRequisicaoEscolhida);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão da requisição", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("A requisição foi excluída com sucesso!", ConsoleColor.Green);
        }
    }

}