using System.Collections.Generic;
using ClientsWebApi_v2.Domain.Entities;

namespace ClientsWebApi_v2.Application.Interfaces.Repositories;

public interface IFounderRepository
{
    IEnumerable<Founder> GetEnumerable();
    Founder? GetItemNullable(int id);
    Founder Add(Founder founder);
    Founder Update(Founder founder);
    bool Delete(int id);
}