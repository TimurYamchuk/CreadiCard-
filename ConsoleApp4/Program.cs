using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер карты: ");
        string cardNumber = Console.ReadLine();

        Console.Write("Введите имя владельца: ");
        string ownerName = Console.ReadLine();

        DateTime expirationDate;
        Console.Write("Введите дату истечения (ГГГГ-ММ-ДД): ");
        while (!DateTime.TryParse(Console.ReadLine(), out expirationDate))
        {
            Console.Write("Неверная дата. Введите в формате ГГГГ-ММ-ДД: ");
        }

        int pin;
        Console.Write("Установите ПИН-код (4 цифры): ");
        while (!int.TryParse(Console.ReadLine(), out pin) || pin < 1000 || pin > 9999)
        {
            Console.Write("ПИН-код должен быть 4-значным числом: ");
        }

        decimal creditLimit;
        Console.Write("Введите кредитный лимит: ");
        while (!decimal.TryParse(Console.ReadLine(), out creditLimit) || creditLimit < 0)
        {
            Console.Write("Лимит должен быть положительным числом: ");
        }

        var card = new CreditCard(cardNumber, ownerName, expirationDate, pin, creditLimit);
        var notificationService = new NotificationService();
        var accountManager = new AccountManager(card, notificationService);

        accountManager.DisplayCardInfo();
        accountManager.PerformDeposit(200);
        accountManager.PerformWithdraw(50);
        accountManager.PerformWithdraw(300);
        accountManager.CheckBalanceGoal(500);
        accountManager.UpdatePin(5678);
        accountManager.DisplayCardInfo();
    }
}
