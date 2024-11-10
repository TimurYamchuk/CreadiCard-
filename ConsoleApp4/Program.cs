using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер карты: ");
        string cardNumber = Console.ReadLine();

        Console.Write("Введите имя владельца: ");
        string ownerName = Console.ReadLine();

        Console.Write("Введите дату истечения (ГГГГ-ММ-ДД): ");
        DateTime expirationDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Установите ПИН-код (4 цифры): ");
        int pin = int.Parse(Console.ReadLine());

        Console.Write("Введите кредитный лимит: ");
        decimal creditLimit = decimal.Parse(Console.ReadLine());

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
