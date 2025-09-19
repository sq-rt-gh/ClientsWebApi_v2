using System.Collections.Generic;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Forms;

public record ClientForm(string Inn, string Name, ClientType Type, IEnumerable<FounderForm>? Founders);