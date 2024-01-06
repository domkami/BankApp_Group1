using System;
using System.Collections.Generic;

public class Bank
{
    private List<Customer> customers;

    public Bank()
    {
        customers = new List<Customer>
        {
            new Customer(1, "Jan", "Nowak", "001", 1457.23m),
            new Customer(2, "Agnieszka", "Kowalska", "002", 3600.18m),
            new Customer(3, "Robert", "Lewandowski", "003", 2745.03m),
            new Customer(4, "Zofia", "Plucińska", "004", 7344.00m),
            new Customer(5, "Grzegorz", "Braun", "005", 455.38m)
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
