using System.Collections.Generic;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Application.Interfaces.Services;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Services;

public class FounderService(IFounderRepository founderRepository) : IFounderService
{
    public IEnumerable<Founder> GetAll()
        => founderRepository.GetEnumerable();

    public Founder? GetById(int id)
        => founderRepository.GetItemNullable(id);

    public Founder Create(FounderForm form)
    {
        var founder = new Founder(form.Inn, form.FullName);
        return founderRepository.Add(founder);
    }

    public Founder Update(int id, FounderForm form)
    {
        var founder = founderRepository.GetItemNullable(id)
                      ?? throw new KeyNotFoundException($"Founder with id:{id} is not found");

        founder.SetFullName(form.FullName)
            .SetInn(form.Inn);

        return founderRepository.Update(founder);
    }

    public bool Delete(int id)
        => founderRepository.Delete(id);
}