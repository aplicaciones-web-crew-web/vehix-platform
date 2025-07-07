using System.Net.Mime;
using CrewWeb.VehixPlatform.API.SAP.Domain.Model.Queries;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Resources;
using CrewWeb.VehixPlatform.API.SAP.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrewWeb.VehixPlatform.API.SAP.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Payments Endpoints")]
public class PaymentsController(
    IPaymentCommandService paymentCommandService,
    IPaymentQueryService paymentQueryService) : ControllerBase
{
    [HttpGet("{paymentId:int}")]
    [SwaggerOperation(
        Summary = "Get Payment by Id",
        Description = "Returns a payment by its unique identifier",
        OperationId = "GetPaymentById")]
    [SwaggerResponse(StatusCodes.Status200OK, "Payment found", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Payment not found")]
    public async Task<IActionResult> GetPaymentById(int paymentId)
    {
        var getPaymentByIdQuery = new GetPaymentByIdQuery(paymentId);
        var payment = await paymentQueryService.Handle(getPaymentByIdQuery);
        if (payment is null) return NotFound();
        var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(resource);
    }

    [HttpGet("payments")]
    [SwaggerOperation(
        Summary = "Get All Payments",
        Description = "Returns a list of all Payments.",
        OperationId = "GetAllPayments")]
    [SwaggerResponse(StatusCodes.Status200OK, "List of payments", typeof(IEnumerable<PaymentResource>))]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await paymentQueryService.Handle(new GetAllPaymentsQuery());
        var paymentResources = payments
            .Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Payment",
        Description = "Creates a new Payment and returns the created Payment Resource.",
        OperationId = "CreatePayment")]
    [SwaggerResponse(StatusCodes.Status201Created, "Payment created successfully", typeof(PaymentResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Payment could not be created")]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var createPaymentCommand =
            CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await paymentCommandService.Handle(createPaymentCommand);
        if (payment is null) return BadRequest("Payment could not be created.");
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return new CreatedResult(string.Empty, paymentResource);
    }
}