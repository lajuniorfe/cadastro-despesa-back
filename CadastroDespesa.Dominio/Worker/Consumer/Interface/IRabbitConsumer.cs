using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Dominio.Worker.Consumer.Interface
{
    public interface IRabbitConsumer
    {
        Task OuvirFilaPersistenciaDespesa(CancellationToken cancellationToken);
    }
}
