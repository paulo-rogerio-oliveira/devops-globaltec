using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.services
{
    public interface IMath
    {
        /// <summary>
        /// Retorna uma lista de resultados true pra par e false pra 
        /// impar caso seja zero retorna erro
        /// </summary>
        /// <param name="valores"></param>
        /// <returns></returns>
        List<bool> GetResults(List<int> valores);
    }
}
