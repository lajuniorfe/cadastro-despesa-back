using CadastroDespesa.Dominio.Despesas.Entidades;
using CadastroDespesa.Dominio.Despesas.Repositorios;
using CadastroDespesa.Dominio.Usuarios.Entidades;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;


namespace CadastroDespesa.Infra.Despesas.Repositorios;

public class DespesaRepositorio : BaseRepositorio<Despesa>, IDespesaRepositorio
{
    public DespesaRepositorio(EntityContexto context) : base(context)
    {
    }


    public async Task<Despesa> CriarDespesaRetornando(Despesa despesa)
    {
        await contexto.GetDbSet<Despesa>().AddAsync(despesa);
        await contexto.SaveChangesAsync();

        return await contexto.GetDbSet<Despesa>()
            .Include(u => u.Usuario)
              .Include(c => c.Categoria)
              .Include(r => r.Recorrencia)
              .FirstOrDefaultAsync(b => b.Id == despesa.Id);
    }

    public async Task<Despesa> CriarDespesasRetornandoPrimeira(IList<Despesa> despesas)
    {
        await contexto.GetDbSet<Despesa>().AddRangeAsync(despesas);
        await contexto.SaveChangesAsync();

        return await contexto.GetDbSet<Despesa>()
            .Include(u => u.Usuario)
            .Include(c => c.Categoria)
            .Include(r => r.Recorrencia)
            .FirstOrDefaultAsync(b => b.Id == despesas.First().Id);
    }

}
