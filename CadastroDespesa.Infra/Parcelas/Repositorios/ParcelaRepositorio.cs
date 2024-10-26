using CadastroDespesa.Dominio.Parcelas.Entidades;
using CadastroDespesa.Dominio.Parcelas.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.Parcelas.Repositorios
{
    public class ParcelaRepositorio : BaseRepositorio<Parcela>, IParcelaRepositorio
    {
        public ParcelaRepositorio(EntityContexto context) : base(context) { }
    }
}
