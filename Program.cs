using System;

namespace CSharp.LabExercise3
{
    class MenuMessageAlert
    {
        public void BackToMenu()
        {
            Console.Write("\nBack to Main Menu?\n(y to continue/any key to exit): ");
            string choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank You!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(-1);
            }
        }
    }

    class Transaction
    {
        MenuMessageAlert menuMessageAlert = new MenuMessageAlert();
        public decimal Balance { get; set; }

        public Transaction(decimal balance)
        {
            this.Balance = balance;
        }
        
        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
            Console.WriteLine("Transaction Successful!");
            Console.WriteLine("Your Balance: PHP {0}", this.Balance);

            menuMessageAlert.BackToMenu();
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("Transaction Successful!");
            Console.WriteLine("Your Balance: PHP {0}", this.Balance);

            menuMessageAlert.BackToMenu();
        }
    }

    class BalanceInquiry
    {
        Transaction transaction;
        MenuMessageAlert menuMessageAlert = new MenuMessageAlert();

        public BalanceInquiry(Transaction transaction)
        {
            this.transaction = transaction;
        }
        public void DisplayBalance()
        {
            Console.WriteLine("----- BALANCE INQUIRY -----");
            Console.WriteLine("Your Current Balance: PHP {0}", transaction.Balance);

            menuMessageAlert.BackToMenu();
        }
    }

    class WithdrawalTransaction
    {
        Transaction transaction;

        public WithdrawalTransaction(Transaction transaction)
        {
            this.transaction = transaction;
        }

        public void WithdrawAmount()
        {
            string choice;
            if (transaction.Balance == 0)
            {
                Console.WriteLine("----- WITHDRAWAL TRANSACTION -----");
                Console.WriteLine("Balance: 0");
                Console.WriteLine("You can't withdraw\n");
                Console.WriteLine("Returning to Menu...");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("----- WITHDRAWAL TRANSACTION -----");
                        Console.Write("Enter Withdraw Amount: PHP ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        if (withdrawAmount <= 0)
                        {
                            Console.WriteLine("Please input a Valid Amount(Positive Integer)\n");
                        }
                        else if (withdrawAmount > transaction.Balance)
                        {
                            Console.WriteLine("Insufficient Balance\n");

                        }
                        else if (withdrawAmount % 100 != 0)
                        {
                            Console.WriteLine("Amount must be divisible by 100\n");
                        }
                        else
                        {
                            transaction.Withdraw(withdrawAmount);
                            break;
                        }
                        Console.Write("Try Again? (y to try again/any key to Menu): ");
                        choice = Console.ReadLine();
                        if (choice == "y" || choice == "Y")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Returning to Menu...");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Input\n");
                        Console.Write("Try Again? (y to try again/any key to Menu): ");
                        choice = Console.ReadLine();
                        if (choice == "y" || choice == "Y")
                        {
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Returning to Menu...");
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                    }

                }
            }
        }
    }

    class DepositTransaction
    {
        Transaction transaction;

        public DepositTransaction(Transaction transaction)
        {
            this.transaction = transaction;
        }

        public void DepositAmount()
        {
            string choice;
            while (true)
            {
                try
                {
                    Console.WriteLine("----- DEPOSIT TRANSACTION -----");
                    Console.Write("Enter Deposit Amount: PHP ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    if (depositAmount <= 0)
                    {
                        Console.WriteLine("Please input a Valid Amount(Positive Integer)\n");
                    }
                    else
                    {
                        transaction.Deposit(depositAmount);
                        break;
                    }

                    Console.Write("Try Again? (y to try again/any key to Menu): ");
                    choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Returning to Menu...");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Input\n");
                    Console.Write("Try Again? (y to try again/any key to Menu): ");
                    choice = Console.ReadLine();
                    if (choice == "y" || choice == "Y")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Returning to Menu...");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            decimal balance = 0;
            Transaction transaction = new Transaction(balance);
            while (true)
            {
                Console.WriteLine("----- WELCOME TO ATM SERVICE -----");
                Console.WriteLine("[1] - Check Balance");
                Console.WriteLine("[2] - Withdraw Cash");
                Console.WriteLine("[3] - Deposit Cash");
                Console.WriteLine("[4] - Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        BalanceInquiry balanceInquiry = new BalanceInquiry(transaction);
                        balanceInquiry.DisplayBalance();
                        break;
                    case "2":
                        Console.Clear();
                        WithdrawalTransaction withdrawal = new WithdrawalTransaction(transaction);
                        withdrawal.WithdrawAmount();
                        break;
                    case "3":
                        Console.Clear();
                        DepositTransaction deposit = new DepositTransaction(transaction);
                        deposit.DepositAmount();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Thank you");
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice!\nReturning to Menu...");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}