using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Entidades;
using CadastroDespesa.Dominio.ConfiguracoesFinanceira.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;

namespace CadastroDespesa.Infra.ConfiguracoesFinanceiras.Repositorios
{
    public class ConfiguracaoFinanceiraRepositorio: BaseRepositorio<ConfiguracaoFinanceira>, IConfiguracaoFinanceiraRepositorio
    {
        public ConfiguracaoFinanceiraRepositorio(EntityContexto contexto) : base(contexto)
        {
        }
    }
}
