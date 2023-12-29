public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public Customer(int customerId, string firstName, string lastName, string accountNumber, decimal balance)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        AccountNumber = accountNumber;
        Balance = balance;
    }
}


