using System;
using System.Collections.Generic;

public class Bank
{
    private List<Customer> customers;

    public Bank()
    {
        customers = new List<Customer>
        {
            new Customer(1, "Jan", "Kowalski", "123456789", 1000),
            new Customer(2, "Tomasz", "Nowak", "987654321", 1500),
            new Customer(3, "Karolina", "Kasprzyk", "111223344", 2000),
            new Customer(4, "Ewa", "Swoboda", "555666777", 500)
        };
    }

    public void DisplayCustomers()
    {
        Console.WriteLine("Lista klientów banku:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.CustomerId}, Imię: {customer.FirstName}, Nazwisko: {customer.LastName}, Numer konta: {customer.AccountNumber}");
        }
    }

    public Customer LogIn(string accountNumber)
    {
        return customers.Find(c => c.AccountNumber == accountNumber);
    }

    public void TransferMoney(Customer sender, Customer receiver, decimal amount)
    {
        if (sender != null && receiver != null && sender != receiver && sender.Balance >= amount)
        {
            sender.Balance -= amount;
            receiver.Balance += amount;
            Console.WriteLine($"Przelew z konta {sender.AccountNumber} na konto {receiver.AccountNumber} na kwotę {amount} zł został zrealizowany.");
        }
        else
        {
            Console.WriteLine("Błąd: Nieprawidłowy klient, własne konto lub niewystarczające środki na koncie.");
        }
    }
}
