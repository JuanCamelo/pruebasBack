using FluentValidation;
using System;
using System.Text.Json.Serialization;
using AplicacionDigital.Services.Helpers;

namespace AplicacionDigital.Services.DTOs
{
    public class AuthorsDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        [JsonPropertyName("dateBirth")]
        public DateTime DateBirth { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("gmail")]
        public string Gmail { get; set; }
    }

    public class ValidationsAuthors : AbstractValidator<AuthorsDTO>
    {
       
        public ValidationsAuthors()
        {
            _ = RuleFor(a => a.FullName)
                .NotEmpty()
                .Custom((fullName, contex) =>
                {
                    if (!fullName.WithRegEx())
                        contex.AddFailure($"Nombre:{fullName} no es valido!!");
                });
            _ = RuleFor(a => a.City)
                .NotEmpty()
                .Custom((city, contex) =>
                {
                    if (!city.WithRegEx())
                        contex.AddFailure("No se reconoce como una ciudad valida!!");
                });
            _ = RuleFor(a => a.Gmail)
                .NotEmpty()
                .Custom((email, context) =>
                {
                    if (!email.IsValidEmail())
                        context.AddFailure($"email: {email} no valido");
                });
            _ = RuleFor(a => a.DateBirth)
                .NotEmpty();

        }
       
    }
}
