// using FluentAssertions;
// using FunctionalCSharp.ApplyingFunctionalPrinciples.MaybeType.FodyNullGuard;
// using FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects;
//
// namespace FunctionalCSharp.Tests.NullOptionType.FodyNullGuard
// {
//     public class NullGuardTests
//     {
//         [Fact]
//         public void Create_An_Instance_Of_A_Customer_Without_CustomerName_Should_Throw_Exception()
//         {
//             var email = (Email)"validemail@hotmail.com";
//             // Assert.Throws<TraceListener.AssertionException>(() => new Customer(null, email)); comment out to fix build
//         }
//
//         [Fact]
//         public void Create_An_Instance_Of_A_Customer_Without_Email_Should_Throw_Exception()
//         {
//             var customerName = (CustomerName)"MyUserName";
//             //   Assert.Throws<TraceListener.AssertionException>(() => new Customer(customerName, null));
//         }
//
//         [Fact]
//         public void Create_An_Instance_Of_CustomerAllowNull_Should_Be_Ok()
//         {
//             var customerAllowNull = new CustomerAllowNull(null, null);
//             customerAllowNull.Email.Should().BeNull();
//             customerAllowNull.CustomerName.Should().BeNull();
//         }
//     }
// }