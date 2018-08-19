using System;

namespace Lab3
{
    [Serializable]
    class Transaction
    {
        public Guid SenderPrivateKey { get; set; }
        public Guid TransactionPublicToken { get; set; }
        public float Amount { get; set; }

        public Transaction(Guid senderPrivateKey, Guid transactionPublicToken, float amount)
        {
            SenderPrivateKey = senderPrivateKey;
            TransactionPublicToken = transactionPublicToken;
            Amount = amount;
        }
    }
}
