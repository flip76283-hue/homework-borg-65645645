using System;
using System.Numerics;
using System.Globalization;

// Task 1
class Calculator
{
    public void Run()
    {
        Console.WriteLine("Number System Calculator");
        Console.WriteLine("1. Decimal to Binary");
        Console.WriteLine("2. Binary to Decimal");
        Console.WriteLine("3. Decimal to Octal");
        Console.WriteLine("4. Octal to Decimal");
        Console.WriteLine("5. Decimal to Hexadecimal");
        Console.WriteLine("6. Hexadecimal to Decimal");

        try
        {
            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            string result = "";

            switch (choice)
            {
                case 1:
                    int decimalToBinary = int.Parse(input);
                    result = Convert.ToString(decimalToBinary, 2);
                    break;

                case 2:
                    result = Convert.ToInt32(input, 2).ToString();
                    break;

                case 3:
                    int decimalToOctal = int.Parse(input);
                    result = Convert.ToString(decimalToOctal, 8);
                    break;

                case 4:
                    result = Convert.ToInt32(input, 8).ToString();
                    break;

                case 5:
                    int decimalToHex = int.Parse(input);
                    result = Convert.ToString(decimalToHex, 16).ToUpper();
                    break;

                case 6:
                    result = Convert.ToInt32(input, 16).ToString();
                    break;

                default:
                    throw new ArgumentException("Invalid menu option.");
            }

            Console.WriteLine("Result: " + result);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The number is outside the Int32 range.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid number format.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Task 2
class ForeignPassport
{
    private string passportNumber;
    private string fullName;
    private DateTime issueDate;
    private DateTime expiryDate;
    private string country;

    public string PassportNumber
    {
        get { return passportNumber; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Passport number cannot be empty.");

            passportNumber = value;
        }
    }

    public string FullName
    {
        get { return fullName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Full name cannot be empty.");

            fullName = value;
        }
    }

    public DateTime IssueDate
    {
        get { return issueDate; }
        set
        {
            if (value > DateTime.Today)
                throw new ArgumentException("Issue date cannot be in the future.");

            issueDate = value;
        }
    }

    public DateTime ExpiryDate
    {
        get { return expiryDate; }
        set
        {
            if (value <= issueDate)
                throw new ArgumentException("Expiry date must be after the issue date.");

            expiryDate = value;
        }
    }

    public string Country
    {
        get { return country; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Country cannot be empty.");

            country = value;
        }
    }

    public ForeignPassport(string passportNumber, string fullName,
        DateTime issueDate, DateTime expiryDate, string country)
    {
        PassportNumber = passportNumber;
        FullName = fullName;
        IssueDate = issueDate;
        ExpiryDate = expiryDate;
        Country = country;
    }

    public override string ToString()
    {
        return "Passport Number: " + PassportNumber +
               "\nFull Name: " + FullName +
               "\nIssue Date: " + IssueDate.ToShortDateString() +
               "\nExpiry Date: " + ExpiryDate.ToShortDateString() +
               "\nCountry: " + Country;
    }
}

class Program
{
    static void Main()
    {
        // Task 1
        Calculator calculator = new Calculator();
        calculator.Run();

        Console.WriteLine("\n--------------------");

        // Task 2
        try
        {
            ForeignPassport passport = new ForeignPassport(
                "AB123456",
                "John Smith",
                new DateTime(2024, 5, 10),
                new DateTime(2034, 5, 10),
                "Ukraine"
            );

            Console.WriteLine(passport);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}