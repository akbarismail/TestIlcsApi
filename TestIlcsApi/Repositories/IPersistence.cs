namespace TestIlcsApi.Repositories;

public interface IPersistence
{
    Task SaveChangesAsync();
    Task BeginTransactionsAsync();
    Task CommitTransactionAsync();
    Task RollBackTransactionAsync();
}