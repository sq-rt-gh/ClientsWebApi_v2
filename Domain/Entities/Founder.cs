using System;
using ClientsWebApi_v2.Domain.Entities.Common;

namespace ClientsWebApi_v2.Domain.Entities;

public class Founder : BaseEntity<Founder>
{
    public string FullName { get; protected set; }

    public Client Client { get; protected set; }

    protected Founder()
    {
    }

    public Founder(string fullName, string inn, Client client) : base(inn)
    {
        SetFullName(fullName);
        SetClient(client);
    }

    public Founder SetFullName(string fullName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        FullName = fullName;

        return this;
    }

    public Founder SetClient(Client client)
    {
        ArgumentNullException.ThrowIfNull(client, nameof(client));
        Client = client;

        return this;
    }
}