namespace CadastroDespesa.Dominio.Despesas.Commands
{
    public class DespesaParceladaCommand: DespesaCommand
    {
        public int Parcela { get; set; }

        public DespesaParceladaCommand(
            int parcela,
            string descricao,
            DateTime data,
            decimal valor,
            int idCategoria,
            int idTipoDespesa,
            int idUsuario
            ): base(descricao,  data,  valor,   idCategoria, idTipoDespesa, idUsuario)
        {
            Parcela = parcela;
        }

        
    }
}
