using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Api.Dto;

public class ClientInputDto : BaseInputDto, IValidatableObject
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Type is required")]
    [EnumDataType(typeof(ClientType))]
    public ClientType? Type { get; set; }

    public ICollection<FounderInputDto>? Founders { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Type == ClientType.Individual && Founders is { Count: > 0 })
            yield return new ValidationResult("У ИП не может быть учредителей");
    }
}