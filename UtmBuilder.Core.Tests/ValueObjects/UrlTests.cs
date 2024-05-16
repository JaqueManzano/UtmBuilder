using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        [TestMethod("Deve retornar uma exceção quando a url for inválida")]
        [TestCategory("Testes de URL")]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            #region Opção de Test
            //try
            //{
            //    new Url("urlInvalida");
            //    Assert.Fail();
            //}
            //catch (InvalidUrlException)
            //{

            //    Assert.IsTrue(true);
            //}
            #endregion

            new Url("urlInvalida");

        }

        [TestMethod("Não deve retornar uma exceção quando a url for válida")]
        [TestCategory("Testes de URL")]
        public void ShouldNotReturnExceptionWhenUrlIsValid()
        {
            new Url("https://balta.io");
            Assert.IsTrue(true);
        }
    }
}
