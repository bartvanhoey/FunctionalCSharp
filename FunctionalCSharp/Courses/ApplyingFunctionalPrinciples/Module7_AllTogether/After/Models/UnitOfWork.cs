using System.Data;
using CSharpFunctionalExtensions;
using NHibernate;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class UnitOfWork : IDisposable
{
    private readonly ISession _session;
    private readonly ITransaction _transaction;
    private bool _isAlive = true;
    private bool _isCommitted;

    public UnitOfWork()
    {
        _session = SessionFactory.OpenSession();
        _transaction = _session.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    public void Dispose()
    {
        if (!_isAlive)
            return;

        _isAlive = false;

        try
        {
            if (_isCommitted)
            {
                _transaction.Commit();
            }
        }
        finally
        {
            _transaction.Dispose();
            _session.Dispose();
        }
    }

    public void Commit()
    {
        if (!_isAlive)
            return;

        _isCommitted = true;
    }

    internal Maybe<T> Get<T>(long id) where T : class 
        => _session.Get<T>(id)!;

    internal void SaveOrUpdate<T>(T entity)
    {
        _session.SaveOrUpdate(entity);
    }

    internal void Delete<T>(T entity)
    {
        _session.Delete(entity);
    }

    internal IQueryable<T> Query<T>()
    {
        return _session.Query<T>();
    }
}