using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you. Your new balance is: " + currentUser.getBalance());

        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {

                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go. Thank you");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("458795213365557", 1234, "John", "Griffith", 250.95));
        cardHolders.Add(new cardHolder("758795213365625", 5674, "Ashley", "Smith", 1780.52));
        cardHolders.Add(new cardHolder("558795213365667", 4321, "Andrew", "Bibs", 630.61));
        cardHolders.Add(new cardHolder("458795213365777", 1895, "Monica", "Hardens", 287.37));
        cardHolders.Add(new cardHolder("958795213365888", 7879, "Barbara", "Goldman", 859.28));

        Console.WriteLine("Welcome to HomelandATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitcardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitcardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitcardNum);
                if (currentUser != null)
                {
                    break;
                }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        {
            Console.WriteLine("Thank you. Have a nice day");
        }
         
    }
}

