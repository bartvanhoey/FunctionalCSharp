using System.ComponentModel.DataAnnotations;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.Before;

public class CustomerModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name is too long")]
    public string Name { get; set; }
        
    [Required(ErrorMessage = "E-mail is required")]
    [RegularExpression(@"^(.+)@(.+)$", ErrorMessage = "Invalid email address")]
    [StringLength(256, ErrorMessage = "Email is too long")]
    public string Email { get; set; }
}