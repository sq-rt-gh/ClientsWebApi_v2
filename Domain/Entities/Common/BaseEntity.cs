using System;
using System.Text.RegularExpressions;

namespace ClientsWebApi_v2.Domain.Entities.Common;

public abstract class BaseEntity<T> where T : BaseEntity<T>
{
    private static readonly Regex InnRegex = new(@"^\d{10}(\d{2})?$", RegexOptions.Compiled);

    public int Id { get; protected set; }

    public string Inn { get; protected set; }

    public DateTime DateCreated { get; protected set; }

    public DateTime DateModified { get; protected set; }

    protected BaseEntity()
    {
    }

    public BaseEntity(string inn)
    {
        SetInn(inn);
        var now = DateTime.Now;
        DateCreated = now;
        DateModified = now;
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