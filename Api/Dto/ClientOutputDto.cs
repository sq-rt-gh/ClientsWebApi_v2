using System.Collections.Generic;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Api.Dto;

public record ClientOutputDto(int Id,
    string Inn,
    string Name,
    ClientType Type,
    ICollection<FounderOutputDto>? Founders);