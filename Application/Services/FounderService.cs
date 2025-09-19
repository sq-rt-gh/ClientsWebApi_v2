using System.Collections.Generic;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Services;

public class FounderService(IFounderRepository founderRepository,
    IClientRepository clientRepository)
    : IFounderService
{
    public IEnumerable<Founder> GetAll()
        => founderRepository.GetEnumerable();

    public Founder? GetById(int id)
        => founderRepository.GetItemNullable(id);

    public Founder Create(FounderForm form, int clientId)
    {
        var founder = new Founder(form.Inn, form.FullName);

        var client = clientRepository.GetItemNullable(clientId)
                     ?? throw new KeyNotFoundException($"Client with id:{clientId} was not found");

        return founderRepository.Add(founder.SetClient(client));
    }

    public Founder Update(int id, FounderForm form, int clientId)
    {
        var founder = founderRepository.GetItemNullable(id)
                      ?? throw new KeyNotFoundException($"Founder with id:{id} was not found");

        var client = clientRepository.GetItemNullable(clientId)
                     ?? throw new KeyNotFoundException($"Client with id:{clientId} was not found");

        founder.SetFullName(form.FullName).SetInn(form.Inn).SetClient(client);

        return founderRepository.Update(founder);
    }

    public bool Delete(int id)
        => founderRepository.Delete(id);
}