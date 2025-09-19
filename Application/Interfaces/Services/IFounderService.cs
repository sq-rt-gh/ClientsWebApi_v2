using System.Collections.Generic;
using ClientsWebApi_v2.Application.Forms;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Interfaces.Services;

public interface IFounderService
{
    IEnumerable<Founder> GetAll();
    Founder? GetById(int id);
    Founder Create(FounderForm form);
    Founder Update(int id, FounderForm form);
    bool Delete(int id);
}