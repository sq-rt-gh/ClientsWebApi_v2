using System;
using System.Collections.Generic;
using System.Linq;
using ClientsWebApi_v2.Domain.Entities.Common;

namespace ClientsWebApi_v2.Domain.Entities;

public class Client : BaseEntity<Client>
{
    public string Name { get; protected set; }

    public ClientType Type { get; protected set; }

    private ICollection<Founder>? _founders;
    public IReadOnlyCollection<Founder>? Founders => _founders?.ToArray();

    protected Client()
    {
    }

    public Client(string inn, string name, ClientType type, ICollection<Founder>? founders = null) : base(inn)
    {
        SetName(name);
        SetClientType(type);
        SetFounders(founders);
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

    public Client SetFounders(ICollection<Founder>? founders)
    {
        if (Type == ClientType.Individual && Founders is { Count: > 0 })
            throw new InvalidOperationException("ИП не может иметь учредителей");

        _founders = founders ?? new List<Founder>();
        foreach (var founder in _founders)
            founder.SetClient(this);

        return this;
    }
}