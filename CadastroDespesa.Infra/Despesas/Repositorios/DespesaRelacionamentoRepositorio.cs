using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CadastroDespesa.Infra.Despesas.Repositorios
{
    public class DespesaRelacionamentoRepositorio : BaseRepositorio<DespesaRelacionamento>, IDespesaRelacionamentoRepositorio
    {
        public DespesaRelacionamentoRepositorio(EntityContexto contexto) : base(contexto)
        {
        }

        public async Task<DespesaRelacionamento> CriarDespesaRetornando(DespesaRelacionamento despesa)
        {
            await contexto.GetDbSet<DespesaRelacionamento>().AddAsync(despesa);
            await contexto.SaveChangesAsync();

            return await contexto.GetDbSet<DespesaRelacionamento>()
                            .Include(dr => dr.Despesa)
                                .ThenInclude(d => d.Categoria)
                            
                            .Include(dr => dr.Despesa)
                                .ThenInclude(d => d.Recorrencia)
                            .Include(dr => dr.Despesa)
                                .ThenInclude(d => d.Usuario)
                            .FirstOrDefaultAsync(dr => dr.Id == despesa.Id);

            //.Include(dr => dr.Despesa)
            //                    .ThenInclude(d => d.Fatura)

        }

        public async Task<DespesaRelacionamento> CriarDespesasRetornandoPrimeira(IList<DespesaRelacionamento> despesaRelacionada)
        {
            await contexto.GetDbSet<DespesaRelacionamento>().AddRangeAsync(despesaRelacionada);
            await contexto.SaveChangesAsync();

            return await contexto.GetDbSet<DespesaRelacionamento>()
                             .Include(dr => dr.Despesa)
                                 .ThenInclude(d => d.Categoria)
                           
                             .Include(dr => dr.Despesa)
                                 .ThenInclude(d => d.Recorrencia)
                             .Include(dr => dr.Despesa)
                                 .ThenInclude(d => d.Usuario)
                             .FirstOrDefaultAsync(dr => dr.Id == despesaRelacionada.First().Id);

              //.Include(dr => dr.Despesa)
              //                   .ThenInclude(d => d.Fatura)
        }

        public async Task<IEnumerable<DespesaRelacionamento>> Listardireito(Expression<Func<DespesaRelacionamento, bool>> predicate)
        {
            var qq = await contexto.GetDbSet<DespesaRelacionamento>()
                              .Include(dr => dr.Fatura)
                               .ThenInclude(d => d.Cartao)
                              .Include(dr => dr.Despesa)
                                  .ThenInclude(d => d.Categoria)
                              .Include(dr => dr.Despesa)
                                  .ThenInclude(d => d.Recorrencia)
                              .Include(dr => dr.Despesa)
                                  .ThenInclude(d => d.Usuario)
                              .Where(predicate).ToListAsync();
            return qq;
        }
    }
}
