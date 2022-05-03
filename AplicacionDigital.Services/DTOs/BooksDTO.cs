using FluentValidation;
using System.Text.Json.Serialization;
using AplicacionDigital.Services.Helpers;
using System;

namespace AplicacionDigital.Services.DTOs
{
    public class BooksDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("year")]
        public string Year { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("numberPages")]
        public int NumberPages { get; set; }
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }
        [JsonPropertyName("author")]
        public string Authors { get; set; }
    }

    public class ValidationBooks : AbstractValidator<BooksDTO>
    {

        public ValidationBooks()
        {

            _ = RuleFor(a => a.Title)
                .NotEmpty();

            _ = RuleFor(a => a.Year)
                .NotEmpty();

            _ = RuleFor(a => a.Gender)
                .NotEmpty();

            _ = RuleFor(a => a.Authors)
                .NotEmpty()
                .Custom((author, context) =>
                {
                    if (author == null || Guid.Parse(author) == Guid.Empty)
                        context.AddFailure("require una author para poder registrar un libro!!");
                }); ;

            _ = RuleFor(a => a.Publisher)
                .NotEmpty()
                .Custom((publisher, context) =>
                {
                    if (publisher == null)
                        context.AddFailure("require una editorial para poder registrar un libro!!");
                });

        }


    }
}
