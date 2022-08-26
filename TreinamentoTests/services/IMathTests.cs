using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.services;

namespace TreinamentoTests.services
{
    [TestClass]
    public class IMathTests
    {

        private IMath NewService() {

            AppDomain domain = AppDomain.CurrentDomain;
            System.Reflection.Assembly[] assemblyList = domain.GetAssemblies();
            foreach (var item in assemblyList)
            {
                if (item.FullName.Contains("Treinamento"))
                {
                    foreach (var type in item.ExportedTypes)
                    {
                        if (type.IsAssignableTo(typeof(IMath) ) && type.IsClass )
                        {
                            return Activator.CreateInstance(type) as IMath;
                        }
                    }
                }

            }
            return null;
        }

        [DataRow(1,3,5,7, false, false, false, false, DisplayName = "Somente numeros impáres")]
        [DataRow(2,4, 6, 8, true, true, true, true, DisplayName = "Somente numeros pares")]
        [DataRow(1, 4, 7, 9, false, true, false, false, DisplayName = "Impáres e pares")]
        [TestMethod]
        public void QuandoInsereValoresValidos(int arg1, int arg2, int arg3, int arg4, bool arg5, bool arg6, bool arg7, bool arg8  ) {

            //Arrange
            var service = NewService();

            //Act
            var result = service.GetResults( new List<int>() { arg1, arg2, arg3, arg4 });

            //Assert
            Assert.AreEqual(arg5, result[0]);
            Assert.AreEqual(arg6, result[1]);
            Assert.AreEqual(arg7, result[2]);
            Assert.AreEqual(arg8, result[3]);
        }

        [DataRow(0,0,0,0, DisplayName = "Somente com zeros")]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void QuandoInsereValoresInválidos(int arg1, int arg2, int arg3, int arg4)
        {
            //Arrange
            var service = NewService();

            //Act
            var result = service.GetResults(new List<int>() { arg1, arg2, arg3, arg4 });

            //Assert
            Assert.AreEqual(arg1, result[0]);
            Assert.AreEqual(arg2, result[1]);
            Assert.AreEqual(arg3, result[2]);
            Assert.AreEqual(arg4, result[3]);
        }


    }
}
