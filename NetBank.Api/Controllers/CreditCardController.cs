using Microsoft.AspNetCore.Mvc;
using NetBank.Application.Services;
using NetBank.Domain;
using NetBank.Domain.Interfaces;
using NetBank.Infrastructure.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetBank.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CreditCardController : ControllerBase
{

    private readonly CreditCardService _service;

    CreditCardService CreateService()
    {
        CreditCardRepository creditCardRepository = new CreditCardRepository();
        CreditCardService service = new CreditCardService(creditCardRepository);
        return service;
    }

    public CreditCardController()
    {
        _service = CreateService();
    }

    // GET: api/<CreditCardController>/{creditcardNumber}
    [HttpGet("{creditcardNumber}")]
    [ProducesResponseType(typeof(CreditCard), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(CreditCard), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CreditCard), StatusCodes.Status400BadRequest)]
    public ActionResult<CreditCard> Get(string creditcardNumber)
    {
        CreditCard creditCard = new CreditCard(creditcardNumber);

        try
        {
            
            creditCard = _service.Validate(creditCard);
            return Ok(creditCard);

        }
        catch  (KeyNotFoundException exception) {

            creditCard.IsValid = false;
            creditCard.IssuingNetwork = exception.Message;
            return NotFound(creditCard);
        } catch (FormatException exception)
        {
            creditCard.IsValid = false;
            creditCard.IssuingNetwork = exception.Message;
            return BadRequest(creditCard);
        }

    }
}
