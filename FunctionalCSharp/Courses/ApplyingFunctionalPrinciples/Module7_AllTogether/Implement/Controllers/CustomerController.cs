using FluentNHibernate.Utils;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Controllers.Base;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Controllers.HttpAttributes;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects;
using FunctionalCSharp.Functional.MaybeClass;
using FunctionalCSharp.Functional.ResultClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models.Industry;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects.
    CustomerName;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects.Email;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerRepository _repo;
        private readonly IEmailGateway _emailGateway;

        public CustomerController(UnitOfWork unitOfWork, IEmailGateway emailGateway) : base(unitOfWork)
        {
            _repo = new CustomerRepository(unitOfWork);
            _emailGateway = emailGateway;
        }

        [HttpPost]
        [Route("customers")]
        public HttpResponseMessage Create(CreateCustomerModel model)
        {
            var customerName = CreateCustomerName(model.Name);
            var primaryEmail = CreateEmail(model.PrimaryEmail);
            var secondaryEmail = GetSecondaryEmail(model.SecondaryEmail);
            var industry = GetIndustry(model.Industry);

            var combinedResult = Combine(customerName, primaryEmail, secondaryEmail, industry);
            if (combinedResult.IsFailure) return ErrorResponse(combinedResult.Error?.Message);

            var customer = new Customer(customerName.Type, primaryEmail.Type, secondaryEmail.Type, industry.Type);

            _repo.Save(customer);

            return OkResponse();
        }


        [HttpPut]
        [Route("customers/{id}")]
        public HttpResponseMessage Update(UpdateCustomerModel model)
        {
            var customer = _repo.GetById(model.Id).ToResult(new CustomerWithIdNotFoundResultError(model.Id));
            var industry = GetIndustry(model.Industry);

            return Combine(customer, industry)
                .OnSuccess(() => customer.Type.UpdateIndustry(industry.Type))
                .OnBoth(result => result.IsSuccess ? OkResponse() : ErrorResponse(result.Error?.Message));
        }

        [HttpDelete]
        [Route("customers/{id}/emailing")]
        public HttpResponseMessage DisableEmailing(long id)
        {
            var maybeCustomer = _repo.GetById(id);
            if (maybeCustomer.HasNoValue) return ErrorResponse($"Customer with such Id is not found: {id}");

            maybeCustomer.Type.DisableEmailing();

            return OkResponse();
        }


        [HttpGet]
        [Route("customers/{id}")]
        public HttpResponseMessage Get(long id)
        {
            var maybeCustomer = _repo.GetById(id);
            if (maybeCustomer.HasNoValue) return ErrorResponse($"Customer with such Id is not found: {id}");

            var customerDto = new
            {
                maybeCustomer.Type.Id,
                maybeCustomer.Type.Name,
                maybeCustomer.Type.PrimaryEmail,
                SecondaryEmail = maybeCustomer.Type.SecondaryEmail.HasValue
                    ? maybeCustomer.Type.SecondaryEmail.Type.Value
                    : null,
                Industry = maybeCustomer.Type.EmailSettings.Industry.Name,
                maybeCustomer.Type.EmailSettings.EmailCampaign
            };

            return OkResponse(customerDto);
        }


        [HttpPost]
        [Route("customers/{id}/promotion")]
        public HttpResponseMessage Promote(long id) =>
            _repo.GetById(id)
                .ToResult(new CustomerWithIdNotFoundResultError(id))
                .Ensure(customer => customer.CanBePromoted(), new CustomerCannotBePromotedResultError())
                .OnSuccess(customer => customer.Promote())
                .OnSuccess(customer => _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status))
                .OnBoth(result => result.IsSuccess ? OkResponse() : ErrorResponse(result.Error?.Message));


        private Result<Maybe<Email>> GetSecondaryEmail(string? secondaryEmail) =>
            secondaryEmail == null
                ? Ok<Maybe<Email>>(null)
                : CreateEmail(secondaryEmail).Map(email => (Maybe<Email>) email);
    }
    

    
}