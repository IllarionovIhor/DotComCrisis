using ClassLibrary;
using System.Net.NetworkInformation;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// can't really access working directory of the solution, so I am digging out of the exe's path to outside

string relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString() + @"\users.bin";
string storagePath = @"C:\Users\user\Desktop\UNI\SUBJECTS ARCHIVE\C2-S1\.net\DotNet1\DotNetLab1\users.bin";

AutomatedTellerMachine atm = new AutomatedTellerMachine("69", 1000, relativePath);
atm.LogInSuccess += (sender,e) => Console.WriteLine("\n# Успішна авторизація.\n");
atm.LogInFail += (sender, e) => Console.WriteLine("\n# Не вдалося авторизуватися.\n");
atm.GotBalance += (sender, e) => Console.WriteLine($"\n# Ваш баланс: {e.balance}.\n");
atm.Added += (sender, e) => Console.WriteLine($"\n# Ви поклали {e.amount}. Оновлений баланс: {e.recipient.Balance}\n");
atm.AmountLessOrEqualsToZero += (sender, e) => Console.WriteLine($"\n! Сума повинна бути більше нуля. !\n");
atm.Withdrawn += (sender, e) => Console.WriteLine($"\n# Ви зняли {e.amount}. Новий баланс: {e.recipient.Balance}\n");
atm.AtmInsufficientBalance += (sender, e) => Console.WriteLine($"\n! Недостатньо коштів в банкоматі !\n");
atm.AccountInsufficientBalance += (sender, e) => Console.WriteLine($"\n! Недостатньо коштів на картці !\n");
atm.Transfered += (sender,e) => Console.WriteLine($"\n# Ви переказали {e.amount} на картку {e.recipient.CardNumber} користувача {e.recipient.Name}. \n Новий баланс: {e.sender.Balance}\n");
atm.UserDoesntExist += (sender, e) => Console.WriteLine($"\n! Такої картки не існує !\n");
atm.TransferToSelf += (sender, e) => Console.WriteLine($"\n! Переказ на власну картку не можливий !\n");
atm.LogOut += (sender, e) => Console.WriteLine($"\n$ Ви вийшли з аккаунту.\n");

start();
void start()
{
    string cardNumber = "";
    string name = "";
    string enteredPin = "";

    Console.Write(
        $"> 1 - Увійти\n" +
        $"> 2 - Зареєструватись\n" +
        $"\n> ЗРОБІТЬ ВИБІР:  ");
    int choice = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (choice)
    {
        case 1:
            Console.Write("\n> Введіть номер картки: ");
            cardNumber = Console.ReadLine();

            if (atm.userByCard(cardNumber) == null)
            {
                Console.WriteLine("\n! Користувача з такою карткою не існує. Будь ласка, зареєструйтеся. !\n");
                start();
            }
            else
            {
                Console.Write("> Введіть ПIН: ");
                string pin = Console.ReadLine();
                if (!atm.login(cardNumber, pin))
                {
                    Console.Clear();
                    Console.WriteLine("\n! Не вдалося авторизуватися. !\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"$ Вітаємо, {atm.Acc.Name}!\n");
                    HandleUserActions();
                }
            }
            break;
        case 2:
            Console.Write("\n> Введіть ім'я: ");
            name = Console.ReadLine();
            Console.Write("\n> Введіть номер картки: ");
            cardNumber = Console.ReadLine();

            Console.Write("\n> Введіть PIN: ");
            enteredPin = Console.ReadLine();

            atm.Register(name, cardNumber, enteredPin);

            if (atm.login(cardNumber, enteredPin))
            {
                Console.Clear();
                Console.WriteLine($"$ Вітаємо, {atm.Acc.Name}!\n");
                HandleUserActions();
            }
            else
            {
                Console.WriteLine("\n! Не вдалося авторизуватися після реєстрації. !\n");
            }
            break;
        default:
            Console.WriteLine("\n! Виберіть одну з наявних опцій !\n");
            start();
            break;
    }
}


void HandleUserActions()
{
    int choice = 0;
    do
    {
        Console.Write(
            $"> 1 - Перевірити баланс\n" +
            $"> 2 - Поповнення балансу\n" +
            $"> 3 - Зняти коштів\n" +
            $"> 4 - Переказ на картку\n" +
            $"> 5 - Вийти\n" +
            $"\n> ЗРОБІТЬ ВИБІР:  ");

        try
        {
            choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    atm.getAccBalance();
                    break;
                case 2:
                    {
                        Console.Write("\n> Введіть суму: ");
                        int amount = int.Parse(Console.ReadLine());
                        atm.put(amount);
                        break;
                    }
                case 3:
                    {
                        Console.Write($"\n> Ваш баланс: {atm.Acc.Balance}. \n Введіть суму: "); 
                        int amount = int.Parse(Console.ReadLine());
                        atm.withdraw(amount);
                        break;
                    }
                case 4:
                    {
                        Console.Write($"\n> Ваш баланс: {atm.Acc.Balance}. \n Введіть суму: ");
                        int amount = int.Parse(Console.ReadLine());
                        Console.Write($"\n> Введіть картку отримувача: ");
                        string recp_card = Console.ReadLine();
                        atm.transfer(amount, recp_card);
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        atm.logout();
                        break;
                    }
                default:
                    Console.WriteLine("\n! Виберіть одну з наявних опцій !\n");
                    break;
            }
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("\n! Помилка введення !\n");
        }

    } while (choice != 5);
    start();
}
