using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamentos;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente
    {
        private Paciente[] pacientes = new Paciente[100];

        public void CadastrarPaciente(Paciente novoPaciente)
        {
            novoPaciente.Id = GeradorId.GerarIdPaciente();

            RegistrarPaciente(novoPaciente);
        }

        private void RegistrarPaciente(Paciente paciente)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] != null)
                    continue;

                else
                {
                    pacientes[i] = paciente;
                    break;
                }
            }
        }

        public bool EditarPaciente(int id, Paciente novoPaciente)
        {
            novoPaciente.Id = id;

            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                    continue;

                else if (pacientes[i].Id == id)
                {
                    pacientes[i] = novoPaciente;

                    return true;
                }
            }

            return false;
        }

        public bool ExistePaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                Paciente p = pacientes[i];

                if (p == null)
                    continue;

                else if (p.Id == id)
                    return true;
            }

            return false;
        }

        public Paciente[] SelecionarPacientes()
        {
            return pacientes;
        }

        public Paciente SelecionarPacientePorId(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                Paciente p = pacientes[i];

                if (p == null)
                    continue;

                else if (p.Id == id)
                    return p;
            }

            return null;
        }

        public bool ExcluirPaciente(int id)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                    continue;

                else if (pacientes[i].Id == id)
                {
                    pacientes[i] = null;
                    return true;
                }
            }

            return false;
        }
        public Paciente SelecionarPacientePorNome(string nomePaciente)
        {
            foreach (Paciente paciente in pacientes)
            {
                if (paciente != null && paciente.Nome == nomePaciente)
                {
                    return paciente;
                }
            }

            return null;
        }
    }
}