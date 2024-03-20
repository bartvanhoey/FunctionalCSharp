using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Infrastructure;
using Fupr.Functional.MaybeClass.Extensions;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ResultClass.Extensions;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory.ResultErrorFactory;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Controllers;

public class CustomerController : ControllerBase
{
    private readonly CustomerRepository _customerRepository;
    private readonly IEmailGateway _emailGateway;

    public CustomerController(UnitOfWork unitOfWork, IEmailGateway emailGateway) : base(unitOfWork)
    {
        _customerRepository = new CustomerRepository(UnitOfWork);
        _emailGateway = emailGateway;
    }

    [HttpPost]
    [Route("customers")]
    public HttpResponseMessage Create(CreateCustomerModel model)
    {
        var customerName = CustomerName.Create(model.Name);
        var industry = Industry.Get(model.Industry);
        var primaryEmail = Email.CreateEmail(model.PrimaryEmail);
        var secondaryEmail = model.GetSecondaryEmail();

        var combinedResult = Result.Combine(customerName, primaryEmail, secondaryEmail, industry);
        if (combinedResult.IsFailure) return HttpError(combinedResult.Error);

        var customer = new Customer(customerName.Value, primaryEmail.Value, secondaryEmail.Value, industry.Value);
        _customerRepository.Save(customer);

        return HttpOk();
    }

    


    [HttpPut]
    [Route("customers/{id}")]
    public HttpResponseMessage Update(UpdateCustomerModel model)
    {
        var customerResult = _customerRepository.GetById(model.Id).ToResult(CustomerByIdNotFound(model.Id));
        var industryResult = Industry.Get(model.Industry);
        
        return Result.Combine(customerResult, industryResult)
            .Tap(() => customerResult.Value.UpdateIndustry(industryResult.Value))
            .Finally(result => result.IsSuccess ? HttpOk() : HttpError(result.Error));
    }

    [HttpDelete]
    [Route("customers/{id}/emailing")]
    public HttpResponseMessage DisableEmailing(long id)
    {
        var maybeCustomer = _customerRepository.GetById(id);
        if (maybeCustomer.HasNoValue) return CustomerNotFound(id);

        maybeCustomer.Value?.DisableEmailing();

        return HttpOk();
    }

    [HttpGet]
    [Route("customers/{id}")]
    public HttpResponseMessage Get(long id)
    {
        var maybeCustomer = _customerRepository.GetById(id);
        if (maybeCustomer.HasNoValue) return CustomerNotFound(id);

        var customer = maybeCustomer.Value;

        var customerDto = new
        {
            customer!.Id,
            Name = customer.Name.Value,
            PrimaryEmail = customer.PrimaryEmail.Value,
            SecondaryEmail = customer.SecondaryEmail.Value,
            customer.EmailSettings.Industry
        };

        return HttpOk(customerDto);
    }

    [HttpPost]
    [Route("customers/{id}/promotion")]
    public HttpResponseMessage Promote(long id) =>
        _customerRepository.GetById(id)
            .ToResult(CustomerByIdNotFound(id))
            .Ensure(customer => customer.CanBePromoted(), CustomerHasHighestStatusPossible())
            .Tap(customer => customer.Promote())
            .Tap(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
            .Finally(result => result.IsSuccess ? HttpOk() : HttpError(result.Error));
}