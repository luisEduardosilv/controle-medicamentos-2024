namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos
{
    public class TelaMedicamento
    {
        public RepositorioMedicamento repositorioMedicamento;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
        }

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar Medicamento");
            Console.WriteLine("2 - Editar Medicamento");
            Console.WriteLine("3 - Excluir Medicamento");
            Console.WriteLine("4 - Visualizar Medicamentos");
            Console.WriteLine("5 - Visualizar Medicamentos com baixa quantidade");
            Console.WriteLine("6 - Visualizar Medicamentos em Falta");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public void CadastrarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Cadastrando Medicamento...");

            Console.WriteLine();

            Console.WriteLine("Digite o nome do medicamento:");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade);

            repositorioMedicamento.CadastrarMedicamento(medicamento);

            Program.ExibirMensagem("O medicamento foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void EditarMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Editando Medicamento...");

            Console.WriteLine();

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja editar: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorioMedicamento.ExisteMedicamento(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o nome do medicamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição do medicamento: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade do medicamento: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Medicamento novoMedicamento = new Medicamento(nome, descricao, quantidade);

            bool conseguiuEditar = repositorioMedicamento.EditarMedicamento(idMedicamentoEscolhido, novoMedicamento);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição do medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirMedicamento()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Excluindo Medicamentos...");

            Console.WriteLine();

            VisualizarMedicamentos(false);

            Console.Write("Digite o ID do medicamento que deseja excluir: ");
            int idMedicamentoEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorioMedicamento.ExisteMedicamento(idMedicamentoEscolhido))
            {
                Program.ExibirMensagem("O medicamento mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorioMedicamento.ExcluirMedicamento(idMedicamentoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do medicamento", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O medicamento foi excluído com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarMedicamentos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();

                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|       Controle de Medicamentos       |");
                Console.WriteLine("----------------------------------------");

                Console.WriteLine();

                Console.WriteLine("Visualizando Medicamentos...");
            }
            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                "Id", "Nome", "Descrição", "Quantidade"
                );

            Medicamento[] medicamentosCadastrados = repositorioMedicamento.SelecionarMedicamento();

            for (int i = 0; i < medicamentosCadastrados.Length; i++)
            {
                Medicamento m = medicamentosCadastrados[i];

                if (m == null)
                    continue;

                Console.WriteLine(
                    "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                    m.Id, m.Nome, m.Descricao, m.Quantidade
                    );
            }
            Console.ReadLine();
        }

        public void MedicamentosPoucaQuantidade()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Visualizando medicamentos com baixa quantidade...");

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                "Id", "Nome", "Descrição", "Quantidade"
                );

            Medicamento[] medicamentosPoucaQuantidade = repositorioMedicamento.MedicamentosPoucaQuantidade(10);

            if (medicamentosPoucaQuantidade.Length == 0)
            {
                Program.ExibirMensagem("Nenhum medicamento com pouca quantidade encontrado.", ConsoleColor.Red);
            }
            else
            {
                foreach (Medicamento m in medicamentosPoucaQuantidade)
                {
                    Console.WriteLine(
                        "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                        m.Id, m.Nome, m.Descricao, m.Quantidade
                        );
                }
            }

            Console.ReadLine();
        }

        public void MedicamentosEmFalta()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|       Controle de Medicamentos       |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("Visualizando medicamentos em falta...");

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                "Id", "Nome", "Descrição", "Quantidade"
                );

            Medicamento[] medicamentosEmFalta = repositorioMedicamento.MedicamentosEmFalta();

            if (medicamentosEmFalta.Length == 0)
            {
                Program.ExibirMensagem("Nenhum medicamento em falta encontrado.", ConsoleColor.Red);
            }
            else
            {
                foreach (Medicamento m in medicamentosEmFalta)
                {
                    Console.WriteLine(
                        "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                        m.Id, m.Nome, m.Descricao, m.Quantidade
                        );
                }
            }

            Console.ReadLine();
        }
    }
}
