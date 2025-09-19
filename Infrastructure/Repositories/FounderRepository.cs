using System;
using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Application.Interfaces.Repositories;
using ClientsWebApi_v2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsWebApi_v2.Infrastructure.Repositories;

public class FounderRepository(AppDbContext context) : IFounderRepository
{
    public IEnumerable<Founder> GetEnumerable()
        => context.Founders.Include(f => f.Client).AsNoTracking().ToArray();

    public Founder? GetItemNullable(int id)
        => context.Founders.Include(f => f.Client).FirstOrDefault(f => f.Id == id);

    public Founder Add(Founder founder)
    {
        founder.UpdateDateModified();
        context.Founders.Add(founder);
        context.SaveChanges();
        return founder;
    }

    public Founder Update(Founder founder)
    {
        founder.UpdateDateModified();
        context.Founders.Update(founder);
        context.SaveChanges();
        return founder;
    }

    public bool Delete(int id)
    {
        var founder = context.Founders.Find(id);
        if (founder == null) return false;

        context.Founders.Remove(founder);
        context.SaveChanges();
        return true;
    }
}