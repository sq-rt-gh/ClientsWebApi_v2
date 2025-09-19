using System;
using ClientsWebApi_v2.Domain.Entities.Common;

namespace ClientsWebApi_v2.Domain.Entities;

public class Founder : BaseEntity<Founder>
{
    public string FullName { get; protected set; }

    public int ClientId { get; protected set; }

    public Client Client { get; protected set; }

    protected Founder()
    {
    }

    public Founder(string inn, string fullName) : base(inn)
    {
        SetFullName(fullName);
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
        ClientId = client.Id;

        return this;
    }
}