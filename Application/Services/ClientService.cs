using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Services;

public class ClientService(IClientRepository clientRepository,
    IFounderRepository founderRepository)
    : IClientService
{
    public IEnumerable<Client> GetAll()
        => clientRepository.GetEnumerable();

    public Client? GetById(int id)
        => clientRepository.GetItemNullable(id);

    public Client Create(ClientForm form)
    {
        var founders = form.Founders?.Select(f => new Founder(f.Inn, f.FullName)).ToArray() ?? [];
        var client = new Client(form.Inn, form.Name, form.Type, founders);

        return clientRepository.Add(client);
    }

    public Client Update(int id, ClientForm form)
    {
        var client = clientRepository.GetItemNullable(id)
                     ?? throw new KeyNotFoundException($"Client with id:{id} is not found");

        var founders = form.Founders?.Select(f => new Founder(f.FullName, f.Inn)).ToArray() ?? [];
        client.SetInn(form.Inn).SetName(form.Name).SetClientType(form.Type).SetFounders(founders);

        return clientRepository.Update(client);
    }

    public bool Delete(int id)
        => clientRepository.Delete(id);
}