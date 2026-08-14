using CadastroDespesa.Dominio.Categorias.Enums;

namespace CadastroDespesa.Dominio.Categorias.Entidades
{
    public class ResumoCategoria
    {
        public TipoCategoriaEnum TipoCategoria { get; private set; }

        public decimal Gasto { get; private set; }

        public decimal Limite { get; private set; }

        public bool ExcedeuLimite { get; private set; }

        public ResumoCategoria(TipoCategoriaEnum tipoCategoria, decimal gasto, decimal limite)
        {
            TipoCategoria = tipoCategoria;
            Gasto = gasto;
            Limite = limite;
            ExcedeuLimite = gasto > limite;
        }
    }
}
