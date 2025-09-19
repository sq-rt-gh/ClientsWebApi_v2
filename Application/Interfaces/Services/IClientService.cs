using System.Collections.Generic;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Interfaces.Services;

public interface IClientService
{
    IEnumerable<Client> GetAll();
    Client? GetById(int id);
    Client Create(ClientForm form);
    Client Update(int id, ClientForm form);
    bool Delete(int id);
}