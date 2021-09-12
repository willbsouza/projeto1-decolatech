namespace DIO.CadastroSeries
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int AnoLancamento { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int anoLancamento)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = anoLancamento;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = 
            "Genero: " + this.Genero 
            + "\nTitulo: " + this.Titulo
            + "\nDescrição: " + this.Descricao
            + "\nAno de Início: " + this.AnoLancamento
            + "\nExcluido: " + this.Excluido;
            return retorno;
        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }

        public int retornarId()
        {
            return this.Id;
        }

        public bool retornarExcluido()
        {
            return this.Excluido;
        }

        public void ExcluirBoolean()
        {
            this.Excluido = true;
        }
    }
}