using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreKnowledge.Api.Interceptors;

public class TransactionInterceptor(ILogger<TransactionInterceptor> logger) : DbTransactionInterceptor
{
    public override async Task TransactionCommittedAsync(DbTransaction transaction, TransactionEndEventData eventData,
        CancellationToken cancellationToken = new CancellationToken())
    {
        logger.LogInformation("Transaction {TransactionId} successful.", eventData.TransactionId);

        await base.TransactionCommittedAsync(transaction, eventData, cancellationToken);
    }
}