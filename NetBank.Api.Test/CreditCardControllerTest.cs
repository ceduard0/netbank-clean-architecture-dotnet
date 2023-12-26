using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.Api.Controllers;
using NetBank.Domain;

namespace NetBank.Api.Test
{
    public class CreditCardControllerTest
    {
        private readonly CreditCardController _controller;

        public CreditCardControllerTest() 
        {
            _controller = new CreditCardController();
        }

        [Fact]
        public void GivenARequest_WhenCallingCreditCardController_ThenTheAPIReturnsOkIsValidResponse()
        {
            // Act
            var actionResult = _controller.Get("4929993646097648");

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var resultObject = GetObjectResultContent<CreditCard>(actionResult);
            Assert.Matches("Visa", resultObject.IssuingNetwork);
            Assert.True(resultObject.IsValid);

        }

        [Fact]
        public void GivenARequest_WhenCallingCreditCardController_ThenTheAPIReturnsOkIsNotValidResponse()
        {
            // Act
            var actionResult = _controller.Get("4929993646097641");

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var resultObject = GetObjectResultContent<CreditCard>(actionResult);
            Assert.Matches("Visa", resultObject.IssuingNetwork);
            Assert.False(resultObject.IsValid);

        }

        [Fact]
        public void GivenARequest_WhenCallingCreditCardController_ThenTheAPIReturnsNotFoundResponse()
        {
            // Act
            var actionResult = _controller.Get("1234");

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            var resultObject = GetObjectResultContent<CreditCard>(actionResult);
            Assert.Matches("Not Found", resultObject.IssuingNetwork);
        }

        [Fact]
        public void GivenARequest_WhenCallingCreditCardController_ThenTheAPIReturnsBadRequestResponse()
        {
            // Act
            var actionResult = _controller.Get("AQAQA111");

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            var resultObject = GetObjectResultContent<CreditCard>(actionResult);
            Assert.Matches("Bad Request", resultObject.IssuingNetwork);
        }

        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T)((ObjectResult)result.Result).Value;
        }
    }
}