using System.Net;
using System.Text.RegularExpressions;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model;
using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.TestCase;
using FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
{
    public class ControllerBase : ApiController
    {
        protected readonly UnitOfWork Uow;

        protected ControllerBase(UnitOfWork uow) => Uow = uow;

        protected HttpResponseMessage BadRequest(string errorMessage)
            => Request.CreateResponse(HttpStatusCode.BadRequest, Envelope.Error(errorMessage));

        protected HttpResponseMessage Ok()
        {
            Uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok());
        }

        protected HttpResponseMessage Ok<T>(T result)
        {
            Uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok(result));
        }
    }

    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IEmailGateway _emailGateway;
        private readonly IndustryRepository _industryRepository;

        public CustomerController(UnitOfWork uow, IEmailGateway emailGateway) : base(uow)
        {
            _customerRepository = new CustomerRepository(uow);
            _industryRepository = new IndustryRepository(uow);
            _emailGateway = emailGateway;
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateCustomerModel model)
        {
            var nameError = ValidateName(model.Name);
            if (nameError != string.Empty) return BadRequest(nameError);

            var email1Error = ValidateEmail(model.PrimaryEmail, "Primary email");
            if (email1Error != string.Empty) return BadRequest(email1Error);

            if (model.SecondaryEmail != null)
            {
                var email2Error = ValidateEmail(model.PrimaryEmail, "Secondary email");
                if (email2Error != string.Empty) return BadRequest(email2Error);
            }

            var industry = _industryRepository.GetByName(model.Industry);
            if (industry == null) return BadRequest("Industry name is invalid: " + model.Industry);


            var customer = new Customer(model.Name, model.PrimaryEmail, model.SecondaryEmail, industry);
            _customerRepository.Save(customer);

            return Ok();
        }

        private string ValidateEmail(string email, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(email)) return fieldName + " should not be empty";
            if (email.Length > 256) return fieldName + " is too long";
            if (!Regex.IsMatch(email, @"^(.+)@(.+)$")) return fieldName + " is invalid";
            return string.Empty;
        }

        private string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "Customer name should not be empty";
            if (name.Length > 200) return "Customer name is too long";
            return string.Empty;
        }


        public HttpResponseMessage Update(UpdateCustomerModel model)
        {
            Customer customer = _customerRepository.GetById(model.Id);
            if (customer == null)
                return BadRequest("Customer with such Id is not found: " + model.Id);

            Industry industry = _industryRepository.GetByName(model.Industry);
            if (industry == null)
                return BadRequest("Industry name is invalid: " + model.Industry);

            customer.UpdateIndustry(industry);

            return Ok();
        }

        public HttpResponseMessage DisableEmailing(long id)
        {
            Customer customer = _customerRepository.GetById(id);
            if (customer == null) return BadRequest("Customer with such Id is not found: " + id);

            customer.DisableEmailing();

            return Ok();
        }

        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            var customer = _customerRepository.GetById(id);
            return customer == null
                ? BadRequest("Customer with such Id is not found: " + id)
                : Ok(customer);
        }

        [HttpPost]
        public HttpResponseMessage Promote(long id)
        {
            Customer customer = _customerRepository.GetById(id);
            if (customer == null) return BadRequest("Customer with such Id is not found: " + id);

            if (!customer.CanBePromoted()) return BadRequest("The customer has the highest status possible");

            customer.Promote();
            
            var emailSent = _emailGateway.SendPromotionNotification(customer.PrimaryEmail, customer.Status);
            return emailSent ? Ok() : BadRequest("Unable to send a notification mail");
        }
    }

    public class Request
    {
        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope<Customer> error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse<T>(HttpStatusCode internalServerError, Envelope<T> error)
        {
            throw new NotImplementedException();
        }
    }

    public class ApiController

    {
    }
}