using System.Collections.Generic;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Interfaces.Repositories;

public interface IClientRepository
{
    IEnumerable<Client> GetEnumerable();
    Client? GetItemNullable(int id);
    Client Add(Client client);
    Client Update(Client client);
    bool Delete(int id);
}