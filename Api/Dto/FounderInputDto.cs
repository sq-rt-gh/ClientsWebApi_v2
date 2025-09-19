using System.ComponentModel.DataAnnotations;

namespace ClientsWebApi_v2.Api.Dto;

public class FounderInputDto : BaseInputDto
{
    [Required(ErrorMessage = "FullName is required")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "ClientId is required")]
    public int? ClientId { get; set; }
}