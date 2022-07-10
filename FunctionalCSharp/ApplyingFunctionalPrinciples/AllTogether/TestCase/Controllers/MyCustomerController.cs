using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.TestCase;
using FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
{
    public class customerOrNothingController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IEmailGateway _emailGateway;
        private readonly IndustryRepository _industryRepository;

        public customerOrNothingController(UnitOfWork uow, IEmailGateway emailGateway) : base(uow)
        {
            _customerRepository = new CustomerRepository(uow);
            _industryRepository = new IndustryRepository(uow);
            _emailGateway = emailGateway;
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateCustomerModel model)
        {
            var customerName = MyCustomerName.Create(model.Name);
            if (customerName.IsFailure) return BadRequest(customerName.Error);

            var primaryEmail = MyEmail.Create(model.PrimaryEmail);
            if (primaryEmail.IsFailure) return BadRequest(primaryEmail.Error);

            if (model.SecondaryEmail != null)
            {
                var secondaryEmail = MyEmail.Create(model.SecondaryEmail);
                if (secondaryEmail.IsFailure) return BadRequest(secondaryEmail.Error);
            }

            var industry = _industryRepository.GetByName(model.Industry);
            if (industry.HasNoValue) return BadRequest("Industry name is invalid: " + model.Industry);

            var secondEmail = model.SecondaryEmail == null ? null : (MyEmail)model.SecondaryEmail;
            var customer = new MyCustomer(customerName.Type, primaryEmail.Type, secondEmail, industry.Type);
            _customerRepository.Save(customer);

            return Ok();
        }


        public HttpResponseMessage Update(UpdateCustomerModel model)
        {
            var customerOrNothing = _customerRepository.GetById(model.Id);
            if (customerOrNothing.HasNoValue) return BadRequest("Customer with such Id is not found: " + model.Id);

            var industry = _industryRepository.GetByName(model.Industry);
            if (industry.HasNoValue) return BadRequest("Industry name is invalid: " + model.Industry);

            customerOrNothing.Type.UpdateIndustry(industry.Type);

            return Ok();
        }

        public HttpResponseMessage DisableEmailing(long id)
        {
            var customerOrNothing = _customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue) return BadRequest("Customer with such Id is not found: " + id);

            customerOrNothing.Type.DisableEmailing();

            return Ok();
        }

        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            var customerOrNothing = _customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue) return BadRequest("Customer with such Id is not found: " + id);

            return Ok(new
            {
                customerOrNothing.Type.Id,
                Name = customerOrNothing.Type.Name.Value,
                PrimaryEmail = customerOrNothing.Type.PrimaryMyEmail.Value,
                SecondaryEmail = customerOrNothing.Type.SecondaryEmail.Type,
                customerOrNothing.Type.Status
            });
        }

        [HttpPost]
        public HttpResponseMessage Promote(long id)
        {
            var customerOrNothing = _customerRepository.GetById(id);
            if (customerOrNothing.HasNoValue) return BadRequest("Customer with such Id is not found: " + id);

            if (!customerOrNothing.Type.CanBePromoted())
                return BadRequest("The customer has the highest status possible");

            customerOrNothing.Type.Promote();

            var emailSent = _emailGateway.SendPromotionNotification(customerOrNothing.Type.PrimaryMyEmail,
                customerOrNothing.Type.Status);
            return emailSent.IsSuccess ? Ok() : BadRequest("Unable to send a notification mail");
        }
    }
}