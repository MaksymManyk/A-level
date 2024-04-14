using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Services.Abstractions
{
    public interface IDbContextWrapper<T>
        where T : DbContext
    {
        T DbContext { get; }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
