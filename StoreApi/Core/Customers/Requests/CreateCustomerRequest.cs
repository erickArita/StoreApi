using System.ComponentModel.DataAnnotations;

namespace StoreApi.Core.Customers.Requests;

public class CreateCustomerRequest
{
    [Required(ErrorMessage = "El campo FirstName es obligatorio.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "El campo LastName es obligatorio.")]
    public string LastName { get; set; }

    [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
    public string Email { get; set; }

    [DataType(DataType.Date)] public DateTime BirthDate { get; set; }

    [StringLength(100, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 100 caracteres.")]
    public string Address { get; set; }

    [Phone(ErrorMessage = "El campo PhoneNumber debe ser un número de teléfono válido.")]
    public string PhoneNumber { get; set; }
}