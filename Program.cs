using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankingApp
{
    class BankAccount
    {
        // Properties
        public string BankName { get; set; }
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }

        // Private Balance
        private decimal balance;

        // Transaction History
        private List<string> transactions = new List<string>();

        // Constructor
        public BankAccount(string bankName, string holder, string accNo, decimal openingBalance)
        {
            BankName = bankName;
            AccountHolder = holder;
            AccountNumber = accNo;
            balance = openingBalance;
        }

        // Get Balance
        public decimal GetBalance()
        {
            return balance;
        }

        // Deposit Method
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;

                transactions.Add(
                    $"Deposited Rs.{amount:F2} | Balance: Rs.{balance:F2}"
                );

                Console.WriteLine("Deposit Successful!");
                Console.WriteLine($"Updated Balance : Rs.{balance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid Deposit Amount!");
            }
        }

        // Withdraw Method
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Withdrawal Amount!");
                return false;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance!");
                return false;
            }

            balance -= amount;

            transactions.Add(
                $"Withdrawn Rs.{amount:F2} | Balance: Rs.{balance:F2}"
            );

            Console.WriteLine("Withdrawal Successful!");
            Console.WriteLine($"Remaining Balance : Rs.{balance:F2}");

            return true;
        }

        // Display Account Details
        public void ShowAccountDetails()
        {
            Console.WriteLine("================================");
            Console.WriteLine("         ACCOUNT DETAILS        ");
            Console.WriteLine("================================");

            Console.WriteLine($"Bank Name      : {BankName}");
            Console.WriteLine($"Account Holder : {AccountHolder}");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Balance        : Rs.{balance:F2}");

            Console.WriteLine("================================");
        }

        // Show Transactions
        public void ShowTransactions()
        {
            Console.WriteLine("================================");
            Console.WriteLine("      TRANSACTION HISTORY       ");
            Console.WriteLine("================================");

            if (transactions.Count == 0)
            {
                Console.WriteLine("No Transactions Yet!");
            }
            else
            {
                foreach (string item in transactions)
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("================================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShowWelcome();

            // User Input
            Console.Write("Enter Account Holder Name : ");
            string userName = Console.ReadLine();

            Console.Write("Enter Account Number : ");
            string accNo = Console.ReadLine();

            Console.Write("Enter Opening Balance : ");
            decimal openingBalance = Convert.ToDecimal(Console.ReadLine());

            // Create Object
            BankAccount account = new BankAccount(
                "UniCom Bank",
                userName,
                accNo,
                openingBalance
            );

            int choice = 0;

            // Loop
            while (choice != 6)
            {
                Console.Clear();

                ShowMenu();

                Console.Write("Enter Your Choice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        account.ShowAccountDetails();
                        break;

                    case 2:
                        Console.WriteLine("================================");
                        Console.WriteLine($"Current Balance : Rs.{account.GetBalance():F2}");
                        Console.WriteLine("================================");
                        break;

                    case 3:
                        Console.Write("Enter Deposit Amount : ");
                        decimal depositAmount =
                            Convert.ToDecimal(Console.ReadLine());

                        account.Deposit(depositAmount);
                        break;

                    case 4:
                        Console.Write("Enter Withdrawal Amount : ");
                        decimal withdrawAmount =
                            Convert.ToDecimal(Console.ReadLine());

                        account.Withdraw(withdrawAmount);
                        break;

                    case 5:
                        account.ShowTransactions();
                        break;

                    case 6:
                        Console.WriteLine("Thank You For Using UniCom Bank!");
                        break;

                    default:
                        Console.WriteLine("Invalid Menu Option!");
                        break;
                }

                // Pause
                if (choice != 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key To Return Menu...");
                    Console.ReadKey();
                }
            }
        }

        // Welcome Method
        static void ShowWelcome()
        {
            Console.WriteLine("================================");
            Console.WriteLine("         WELCOME TO             ");
            Console.WriteLine("         UNICOM BANK              ");
            Console.WriteLine("================================");
        }

        // Menu Method
        static void ShowMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("            MAIN MENU           ");
            Console.WriteLine("================================");

            Console.WriteLine("1. View Account Details");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("4. Withdraw Money");
            Console.WriteLine("5. Transaction History");
            Console.WriteLine("6. Exit");

            Console.WriteLine("================================");
        }
    }
}
