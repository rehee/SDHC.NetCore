using Common.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Cruds
{
  public interface ICrud
  {
    Func<ISave> GetRepo { get; }
    void Create(IInt64Key model, ISave repo);
    void Create<T>(T input) where T : class;
    void Create(object input, out ISave repo);
    void Create(object input);
    void Create(object input, ISave repo);
    IQueryable<T> Read<T>(Expression<Func<T, bool>> where, out ISave db) where T : class;
    IQueryable<T> Read<T>(Expression<Func<T, bool>> where) where T : class;
    IQueryable<T> Read<T>(Expression<Func<T, bool>> where, ISave db) where T : class;
    IQueryable<T> Read<T>(Type type, Expression<Func<T, bool>> where, out ISave db);
    IQueryable<T> Read<T>(Type type, Expression<Func<T, bool>> where);
    IQueryable<T> Read<T>(Type type, Expression<Func<T, bool>> where, ISave db);

    void Update<T>(T input) where T : class, IInt64Key;
    void Update(Type type, IInt64Key input);

    T Find<T>(long id, out ISave repo) where T : class, IInt64Key;
    T Find<T>(long id) where T : class, IInt64Key;
    T Find<T>(Type type, long id, out ISave repo) where T : class, IInt64Key;
    T Find<T>(Type type, long id) where T : class, IInt64Key;
    object Find(Type type, long id, out ISave repo);
    object Find(Type type, long id);
    void Delete<T>(ISave repo, T model) where T : class, IInt64Key;
    void Delete<T>(T model, ISave repo = null) where T : class, IInt64Key;
    void Delete(object model, ISave repo = null);
    
    Task CreateAsync(IInt64Key model, ISave repo);
    Task CreateAsync<T>(T input) where T : class;
    Task CreateAsync(object input, out ISave repo);
    Task CreateAsync(object input);
    Task CreateAsync(object input, ISave repo);
    Task<IQueryable<T>> ReadAsync<T>(Expression<Func<T, bool>> where, out ISave db) where T : class;
    Task<IQueryable<T>> ReadAsync<T>(Expression<Func<T, bool>> where) where T : class;
    Task<IQueryable<T>> ReadAsync<T>(Expression<Func<T, bool>> where, ISave db) where T : class;
    Task<IQueryable<T>> ReadAsync<T>(Type type, Expression<Func<T, bool>> where, out ISave db);
    Task<IQueryable<T>> ReadAsync<T>(Type type, Expression<Func<T, bool>> where);
    Task<IQueryable<T>> ReadAsync<T>(Type type, Expression<Func<T, bool>> where, ISave db);

    Task UpdateAsync<T>(T input) where T : class, IInt64Key;
    Task UpdateAsync(Type type, IInt64Key input);

    Task<T> FindAsync<T>(long id, out ISave repo) where T : class, IInt64Key;
    Task<T> FindAsync<T>(long id) where T : class, IInt64Key;
    Task<T> FindAsync<T>(Type type, long id, out ISave repo) where T : class, IInt64Key;
    Task<T> FindAsync<T>(Type type, long id) where T : class, IInt64Key;
    Task<object> FindAsync(Type type, long id, out ISave repo);
    Task<object> FindAsync(Type type, long id);
    Task DeleteAsync<T>(ISave repo, T model) where T : class, IInt64Key;
    Task DeleteAsync<T>(T model, ISave repo = null) where T : class, IInt64Key;
    Task DeleteAsync(object model, ISave repo = null);
  }
}

