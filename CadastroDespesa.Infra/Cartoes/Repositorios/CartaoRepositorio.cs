using CadastroDespesa.Dominio.Cartoes.Entidades;
using CadastroDespesa.Dominio.Cartoes.Repositorios;
using CadastroDespesa.Infra.Contexto;
using CadastroDespesa.Infra.Contexto.Repositorios;
using CadastroDespesa.Infra.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDespesa.Infra.Cartoes.Repositorios
{
    public class CartaoRepositorio: BaseRepositorio<Cartao>, ICartaoRepositorio
    {
        public CartaoRepositorio(EntityContexto context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {

        }
    }
}
