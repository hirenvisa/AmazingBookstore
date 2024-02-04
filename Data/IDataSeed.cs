using Microsoft.EntityFrameworkCore;

namespace AmazingBookStore.Data;

public interface IDataSeed<TContext> where TContext : DbContext
{
    void EnsureDataExists(TContext context);
}
