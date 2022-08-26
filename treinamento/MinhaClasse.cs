using Treinamento.services;

namespace treinamento
{
    public class MinhaClasse: IMath
    {

        public List<bool> MeuMetodo(List<int> valores) {

            var result = new List<bool>();
            valores.ForEach(item =>
            {

                if (item == 0)
                {
                    throw new ArgumentException("Valor iválido");
                }

                result.Add((item % 2 == 0));

            });
            return result;

        }

        List<bool> IMath.GetResults(List<int> valores)
        {
            return MeuMetodo(valores);
        }
    }
}