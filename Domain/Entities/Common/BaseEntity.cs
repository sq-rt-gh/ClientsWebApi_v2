using System;
using System.Text.RegularExpressions;

namespace ClientsWebApi_v2.Domain.Entities.Common;

public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    private static readonly Regex InnRegex = new(@"^\d{10}(\d{2})?$", RegexOptions.Compiled);

    public Guid Id { get; protected set; } = Guid.NewGuid();

    public string Inn { get; protected set; }

    public DateTime DateCreated { get; protected set; } = DateTime.Now;

    public DateTime DateModified { get; protected set; } = DateTime.Now;

    protected BaseEntity()
    {
    }

    protected BaseEntity(string? inn)
    {
        SetInn(inn);
    }

    public T SetInn(string? inn)
    {
        ArgumentException.ThrowIfNullOrEmpty(inn);

        if (!InnRegex.IsMatch(inn))
            throw new ArgumentException("ИНН должен содержать 10 или 12 цифр");

        Inn = inn;
        return (T)this;
    }

    public T UpdateDateModified()
    {
        DateModified = DateTime.Now;

        return (T)this;
    }
}