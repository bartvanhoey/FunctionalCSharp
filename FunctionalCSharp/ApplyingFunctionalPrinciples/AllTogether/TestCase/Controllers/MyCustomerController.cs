using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.TestCase;
using FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
{
    public class MyCustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IEmailGateway _emailGateway;
        private readonly IndustryRepository _industryRepository;

        public MyCustomerController(UnitOfWork uow, IEmailGateway emailGateway) : base(uow)
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
            if (industry == null) return BadRequest("Industry name is invalid: " + model.Industry);


            var secondEmail = model.SecondaryEmail == null ? null : (MyEmail)model.SecondaryEmail;
            var customer = new MyCustomer(customerName.Type, primaryEmail.Type, secondEmail, industry);
            _customerRepository.Save(customer);

            return Ok();
        }


        public HttpResponseMessage Update(UpdateCustomerModel model)
        {
            var myCustomer = _customerRepository.GetById(model.Id);
            if (myCustomer == null)
                return BadRequest("Customer with such Id is not found: " + model.Id);

            var industry = _industryRepository.GetByName(model.Industry);
            if (industry == null)
                return BadRequest("Industry name is invalid: " + model.Industry);

            myCustomer.UpdateIndustry(industry);

            return Ok();
        }

        public HttpResponseMessage DisableEmailing(long id)
        {
            var myCustomer = _customerRepository.GetById(id);
            if (myCustomer == null) return BadRequest("Customer with such Id is not found: " + id);

            myCustomer.DisableEmailing();

            return Ok();
        }

        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
                return BadRequest("Customer with such Id is not found: " + id);

            return Ok(new
            {
                customer.Id,
                Name = customer.Name.Value,
                PrimaryEmail = customer.PrimaryMyEmail.Value,
                SecondaryEmail = customer.SecondaryEmail.Value,
                customer.Status
            });
        }

        [HttpPost]
        public HttpResponseMessage Promote(long id)
        {
            var myCustomer = _customerRepository.GetById(id);
            if (myCustomer == null) return BadRequest("Customer with such Id is not found: " + id);

            if (!myCustomer.CanBePromoted()) return BadRequest("The customer has the highest status possible");

            myCustomer.Promote();

            var emailSent = _emailGateway.SendPromotionNotification(myCustomer.PrimaryMyEmail, myCustomer.Status);
            return emailSent.IsSuccess ? Ok() : BadRequest("Unable to send a notification mail");
        }
    }
}