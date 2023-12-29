using System;

class Program
{
    static void Main()
    {
        Bank bank = new Bank(); // definicja klas 
        Customer loggedCustomer = null;

        while (true)
        {
            Console.WriteLine("----------- Menu Główne -----------");
            Console.WriteLine("1. Zaloguj się");
            Console.WriteLine("2. Wyświetl listę klientów");
            Console.WriteLine("3. Zakończ program");
            Console.Write("Wybierz opcję (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Podaj numer konta: ");
                    string accountNumber = Console.ReadLine();
                    loggedCustomer = bank.LogIn(accountNumber);

                    if (loggedCustomer != null)
                    {
                        Console.WriteLine($"Zalogowano jako {loggedCustomer.FirstName} {loggedCustomer.LastName} (Saldo: {loggedCustomer.Balance} zł)");
                    }
                    else
                    {
                        Console.WriteLine("Błąd logowania: Nieprawidłowy numer konta.");
                    }
                    break;

                case "2":
                    bank.DisplayCustomers();
                    break;

                case "3":
                    Console.WriteLine("Program został zakończony.");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 3.");
                    break;
            }

            // Jeżeli klient jest zalogowany, umożliwiamy mu dodatkowe operacje
            if (loggedCustomer != null)
            {
                Console.WriteLine("----------- Operacje bankowe -----------");
                Console.WriteLine("1. Wykonaj przelew");
                Console.WriteLine("2. Sprawdź stan konta");
                Console.WriteLine("3. Wyloguj");
                Console.Write("Wybierz opcję (1-3): ");

                string operationChoice = Console.ReadLine();

                switch (operationChoice)
                {
                    case "1":
                        Console.Write("Podaj numer konta odbiorcy: ");
                        string receiverAccountNumber = Console.ReadLine();
                        Customer receiver = bank.LogIn(receiverAccountNumber);

                        if (receiver != null)
                        {
                            Console.Write("Podaj kwotę przelewu: ");
                            decimal transferAmount;
                            if (decimal.TryParse(Console.ReadLine(), out transferAmount))
                            {
                                bank.TransferMoney(loggedCustomer, receiver, transferAmount);
                            }
                            else
                            {
                                Console.WriteLine("Błąd: Nieprawidłowa kwota przelewu.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Błąd: Nieprawidłowy numer konta odbiorcy.");
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Saldo konta: {loggedCustomer.Balance} zł");
                        break;

                    case "3":
                        loggedCustomer = null;
                        Console.WriteLine("Wylogowano.");
                        break;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 3.");
                        break;
                }
            }

            Console.WriteLine("gg"); // Dodatkowy odstęp dla czytelności
        }
    }
}