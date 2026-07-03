using AutoMapper;
using CadastroDespesa.Application.Faturas.Interfaces;
using CadastroDespesa.Dominio.Faturas.Repositorios;
using CadastroDespesa.DTO.Faturas.Responses;

namespace CadastroDespesa.Application.Faturas
{
    public class FaturaApp : IFaturaApp
    {
        private readonly IFaturaRepositorio faturaRepositorio;
        private readonly IMapper _mapper;


        public FaturaApp(IFaturaRepositorio faturaRepositorio, IMapper mapper)
        {
            this.faturaRepositorio = faturaRepositorio;
            _mapper = mapper;
        }

        public async Task<IList<FaturaResponse>> BuscarFaturasCartaoMesCorrespondente(int mes, int cartao)
        {
            var retorno = await faturaRepositorio.Listar(f => f.IdCartao == cartao && f.DataVencimento.Month == mes);

            return _mapper.Map<IList<FaturaResponse>>(retorno);

        }

        public async Task<IList<FaturaResponse>> BuscarFaturasMesCorrespondente(int mes)
        {
            var retorno = await faturaRepositorio.Listar(f => f.DataVencimento.Month == mes);

            return _mapper.Map<IList<FaturaResponse>>(retorno);

        }
    }
}
