using FluentAssertions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After;


namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions;

public class TicketControllerTests
{
    [Fact]
    public void BuyTicket_Should_Be_Success_When_Date_In_Future_And_CustomerName_Filled_In()
    {
        var ticketController = GetTicketController();
        var actionResult = ticketController.BuyTicket(DateTime.Now.AddDays(1), "bart");
        actionResult.IsValid.Should().BeTrue();
    }

    [Fact]
    public void BuyTicket_Should_Return_Error_When_Date_In_Future_And_CustomerName_Not_Filled_In()
    {
        var ticketController = GetTicketController();
        var actionResult = ticketController.BuyTicket(DateTime.Now.AddDays(1), "");
        actionResult.Error.Should().Be("Error");
    }

    [Fact]
    public void BuyTicket_Should_Return_Error_When_Date_In_Past_And_CustomerName_Filled_In()
    {
        var ticketController = GetTicketController();
        var actionResult = ticketController.BuyTicket(DateTime.Now.AddDays(-1), "Bart");
        actionResult.Error.Should().Be("Error");
    }

    [Fact]
    public void BuyTicket_Should_Return_Error_When_Date_In_Past_And_CustomerName_Not_Filled_In()
    {
        var ticketController = GetTicketController();
        var actionResult = ticketController.BuyTicket(DateTime.Now.AddDays(-1), "");
        actionResult.Error.Should().Be("Error");
    }


    private static TicketController GetTicketController()
    {
        var ticketRepository = new TicketRepository();
        var gateway = new TheaterGateway();

        var ticketController = new TicketController(ticketRepository, gateway);
        return ticketController;
    }
}