using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;
using System;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class RepositorioRequisicao
    {
        private Requisicao[] requisicoes = new Requisicao[100];
        private RepositorioMedicamento repositorioMedicamento;

        public RepositorioRequisicao(RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
        }

        public void CadastrarRequisicoes(Requisicao novaRequisicao, Medicamento medicamento)
        {
            novaRequisicao.Id = GeradorId.GerarIdRequisicoes(); 
            Registrar(novaRequisicao, medicamento);
            AtualizarEstoque(novaRequisicao.Medicamento, novaRequisicao.Quantidade);
        }

        public void Registrar(Requisicao requisicao, Medicamento medicamento)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] != null)
                    continue;
                else if (medicamento != null && medicamento.Quantidade > 0)
                {
                    requisicoes[i] = requisicao;
                    break;
                }
            }
        }

        public void AtualizarEstoque(Medicamento medicamento, int quantidade)
        {
            medicamento.Quantidade -= quantidade;
        }

        public Requisicao[] SelecionarRequisicoes()
        {
            Requisicao[] requisicoesExistentes = new Requisicao[100];
            int contadorElementosExistentes = 0;

            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;
                else
                {
                    requisicoesExistentes[i] = requisicoes[i];
                    contadorElementosExistentes++;
                }
            }

            return requisicoesExistentes;
        }

        public bool EditarRequisicao(int id, Requisicao novaRequisicao)
        {
            novaRequisicao.Id = id;

            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;

                else if (requisicoes[i].Id == id)
                {
                    requisicoes[i] = novaRequisicao;

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirRequisicao(int id)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                if (requisicoes[i] == null)
                    continue;

                else if (requisicoes[i].Id == id)
                {
                    requisicoes[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool ExisteRequisicao(int id)
        {
            for (int i = 0; i < requisicoes.Length; i++)
            {
                Requisicao r = requisicoes[i];

                if (r == null)
                    continue;

                else if (r.Id == id)
                    return true;
            }

            return false;
        }
    }
}