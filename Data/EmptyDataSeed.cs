using Microsoft.EntityFrameworkCore;

namespace AmazingBookStore.Data;

public class EmptyDataSeed<TContext>: IDataSeed<TContext> where TContext : DbContext
{
    public void EnsureDataExists(TContext context) { }
}