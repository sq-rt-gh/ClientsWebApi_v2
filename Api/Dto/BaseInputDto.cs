using System.ComponentModel.DataAnnotations;

namespace ClientsWebApi_v2.Api.Dto;

public class BaseInputDto
{
    [Required(ErrorMessage = "Inn is required")]
    public string? Inn { get; set; }
}