using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamentos
{
    public class RepositorioMedicamento
    {
        public Medicamento[] medicamentos = new Medicamento[100];
        
        public void CadastrarMedicamento(Medicamento novoMedicamento)
        {
            novoMedicamento.Id = GeradorId.GerarIdMedicamento();

            RegistrarMedicamento(novoMedicamento);
        }

        public void RegistrarMedicamento(Medicamento medicamento)
        {
            // Verifica se o medicamento já está cadastrado
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] != null && medicamentos[i].Nome == medicamento.Nome)
                {
                    // Se estiver cadastrado, atualiza a quantidade
                    medicamentos[i].Quantidade += medicamento.Quantidade;
                    return;
                }
            }

            // Se o medicamento não estiver cadastrado, procura a primeira posição disponível e cadastra
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                {
                    medicamentos[i] = medicamento;
                    return;
                }
            }
        }

        public bool EditarMedicamento(int id, Medicamento novoMedicamento)
        {
            novoMedicamento.Id = id;

            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;

                else if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = novoMedicamento;

                    return true;
                }
            }

            return false;
        }

        public Medicamento[] SelecionarMedicamento()
        {
            Medicamento[] medicamentosExistentes = new Medicamento[100];

            int contadorElementosExistentes = 0;

            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;
                else
                {
                    medicamentosExistentes[i] = medicamentos[i];
                    contadorElementosExistentes++;
                }
            }

            return medicamentos;
        }

        public bool ExcluirMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                    continue;

                else if (medicamentos[i].Id == id)
                {
                    medicamentos[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Medicamento[] MedicamentosPoucaQuantidade(int limite)
        {
            int contador = 0;

            // Contar quantos medicamentos têm quantidade abaixo do limite
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento != null && medicamento.Quantidade > 0 && medicamento.Quantidade < limite)
                    contador++;
            }

            // Criar um array com o tamanho do contador
            Medicamento[] medicamentosPoucaQuantidade = new Medicamento[contador];
            int index = 0;

            // Preencher o array com os medicamentos com pouca quantidade
            foreach (Medicamento medicamento in medicamentos) 
            {
                if (medicamento != null && medicamento.Quantidade < limite)
                {
                    medicamentosPoucaQuantidade[index] = medicamento;
                    index++;
                }
            }

            return medicamentosPoucaQuantidade;
        }

        public Medicamento[] MedicamentosEmFalta()
        {
            int contador = 0;

            // Contar quantos medicamentos têm quantidade zero
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento != null && medicamento.Quantidade == 0)
                {
                    contador++;
                }
            }

            // Criar um array com o tamanho do contador
            Medicamento[] medicamentosEmFalta = new Medicamento[contador];
            int index = 0;

            // Preencher o array com os medicamentos em falta
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento != null && medicamento.Quantidade == 0)
                {
                    medicamentosEmFalta[index] = medicamento;
                    index++;
                }
            }

            return medicamentosEmFalta;
        }

        public bool ExisteMedicamento(int id)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                Medicamento m = medicamentos[i];

                if (m == null)
                    continue;

                else if (m.Id == id)
                    return true;
            }

            return false;
        }

        public Medicamento SelecionarMedicamentoPorNome(string nomeMedicamento)
        {
            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento != null && medicamento.Nome == nomeMedicamento)
                {
                    return medicamento;
                }
            }
            return null;
        }

    }
}
