using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsWebApi_v2.Infrastructure.Repositories;

public class ClientRepository(AppDbContext dbContext)
    : IClientRepository
{
    public IEnumerable<Client> GetEnumerable()
        => dbContext.Clients.Include(c => c.Founders).AsNoTracking().ToList();

    public Client? GetItemNullable(int id)
        => dbContext.Clients.Include(c => c.Founders).FirstOrDefault(c => c.Id == id);

    public Client Add(Client client)
    {
        dbContext.Clients.Add(client);
        dbContext.SaveChanges();
        return client;
    }

    public Client Update(Client client)
    {
        dbContext.Clients.Update(client);
        dbContext.SaveChanges();
        return client;
    }

    public bool Delete(int id)
    {
        var client = dbContext.Clients.Find(id);
        if (client == null) return false;

        dbContext.Clients.Remove(client);
        dbContext.SaveChanges();
        return true;
    }
}