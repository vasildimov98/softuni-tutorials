namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        //Transaction properties exception messages
        public const string INVALID_ID_VALUE
            = "Value of the id cannot be zero or negative!";
        public const string INVALID_FROM_VALUE
            = "Value of the sender cannot be empty or null!";
        public const string INVALID_TO_VALUE
            = "Value of the receiver cannot be empty or null!";
        public const string INVALID_AMOUNT_VALUE
           = "Value of the salary cannot be zero or negative!";

        //Chainblock properties and methods exception messages;
        public const string INVALID_TRANSACTION_VALUE
            = "Value of the transaction cannot be null!";
        public const string INVALID_ADD_TRANSACTION_OPERATION
            = "Transaction already exists in the records!";
        public const string INVALID_ID_NOT_PRESENT
           = "Transaction with this id doesn't exists in the records!";
        public const string INVALID_STATUS_NOT_PRESENT
           = "Transactions with this status doesn't exist in the records!";
        public const string INVALID_SENDER_NOT_PRESENT
           = "Sender doesn't exists in the records!";
        public const string INVALID_RECEIVER_NOT_PRESENT
          = "Receiver doesn't exists in the records!";
    }
}
