using System;

public class CreditCard
{
    public string CardNumber { get; }
    public string OwnerName { get; }
    public DateTime ExpirationDate { get; }
    private int Pin { get; set; }
    public decimal CreditLimit { get; }
    public decimal Balance { get; private set; }
    private const decimal InterestRate = 0.05m;

    public CreditCard(string cardNumber, string ownerName, DateTime expirationDate, int pin, decimal creditLimit)
    {
        CardNumber = cardNumber;
        OwnerName = ownerName;
        ExpirationDate = expirationDate;
        Pin = pin;
        CreditLimit = creditLimit;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Депозит: ${amount}. Текущий баланс: ${Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (Balance + CreditLimit >= amount)
        {
            Balance -= amount;
            if (Balance < 0) Balance -= Balance * InterestRate;
            Console.WriteLine($"Снятие: ${amount}. Текущий баланс: ${Balance}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств для снятия.");
        }
    }

    public void UpdatePin(int newPin)
    {
        if (newPin != Pin)
        {
            Pin = newPin;
            Console.WriteLine("ПИН-код обновлен.");
        }
        else
        {
            Console.WriteLine("Новый ПИН-код не должен совпадать с текущим.");
        }
    }

    public void DisplayCardInfo()
    {
        Console.WriteLine($"\n--- Данные карты ---\nНомер: {CardNumber}\nВладелец: {OwnerName}\nСрок действия: {ExpirationDate.ToShortDateString()}\nБаланс: ${Balance}\nЛимит: ${CreditLimit}");
    }

    public bool IsExpirationSoon() => (ExpirationDate - DateTime.Now).TotalDays <= 30;
}
