using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Worker.Producer.Interface
{
    public interface IRabbitProducer
    {
        Task DispararFilaPersistenciaDespesaConcluida(string mensagem, CancellationToken cancellationToken);
    }
}
