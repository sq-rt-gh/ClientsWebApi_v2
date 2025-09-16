using System;
using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Domain.Entities.Common;

namespace ClientsWebApi_v2.Domain.Entities;

public class Client : BaseEntity<Client>
{
    public string Name { get; protected set; }

    public ClientType Type { get; protected set; }

    private readonly ICollection<Founder> _founders = new HashSet<Founder>();
    public IReadOnlyCollection<Founder> Founders => _founders.ToHashSet();

    protected Client()
    {
    }

    public Client(string inn, string name, ClientType type, IEnumerable<Founder> founders) : base(inn)
    {
        SetName(name);
        SetClientType(type);

        foreach (var founder in founders)
        {
            AddFounder(founder);
        }
    }

    public Client SetName(string? name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;

        return this;
    }

    public Client SetClientType(ClientType type)
    {
        Type = type;

        return this;
    }

    public Client AddFounder(Founder founder)
    {
        if (Type == ClientType.Individual)
            throw new InvalidOperationException("ИП не может иметь учредителей");

        if (!_founders.Contains(founder))
        {
            _founders.Add(founder);
        }

        return this;
    }

    public Client RemoveFounder(Founder founder)
    {
        _founders.Remove(founder);

        return this;
    }
}