using System.Collections.Generic;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Interfaces.Services;

public interface IFounderService
{
    IEnumerable<Founder> GetAll();
    Founder? GetById(int id);
    Founder Create(FounderForm form, int clientId);
    Founder Update(int id, FounderForm form, int clientId);
    bool Delete(int id);
}