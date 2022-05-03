using AplicacionDigital.Services.Helpers;
using FluentValidation;
using System;
using System.Text.Json.Serialization;

namespace AplicacionDigital.Services.DTOs
{
    public class PublisherDTO
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public string address { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("maxibooks")]
        public string Maxibooks { get; set; }
    }

    public class ValidationsPublisher : AbstractValidator<PublisherDTO>
    {
        public ValidationsPublisher()
        {
            _ = RuleFor(a => a.Name)
                .NotEmpty()
                .Custom((Name, contex) =>
                {
                    if (!Name.WithRegEx())
                        contex.AddFailure($"Nombre:{Name} no es valido!!");
                });
            _ = RuleFor(a => a.address)
                .NotEmpty();

            _ = RuleFor(a => a.PhoneNumber)
                .NotEmpty()
                .Custom((phone, context) =>
                {
                    if (phone.IsValidNumberPhone())
                        context.AddFailure($"Phone: {phone} no valido");
                });

            _ = RuleFor(a => a.Maxibooks)
                .Custom((maxibooks, context) =>
                {
                    if (maxibooks.IsValidNumberPhone())
                        context.AddFailure($"Phone: {maxibooks} no valido");
                });

        }

    }
}