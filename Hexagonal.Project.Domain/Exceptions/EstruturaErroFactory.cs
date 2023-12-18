namespace Hexagonal.Project.Domain.Exceptions
{
    public class EstruturaErroFactory
    {
        public EstruturaErroException ObterEstruturaErro(int codigoErro, string message)
        {
            return new EstruturaErroException()
            {
                EstruturaErro = new EstruturaErro()
                {
                    CodigoErro = codigoErro,
                    DescricaoErro = message
                }
            };
        }

        public EstruturaErroException ObterEstruturaErroNaoTratado(string message)
        {
            return new EstruturaErroException()
            {
                EstruturaErro = new EstruturaErro()
                {
                    CodigoErro = 999,
                    DescricaoErro = message
                }
            };
        }
    }
}
