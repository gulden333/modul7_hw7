namespace spp_pr7.Mediator;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IMediator chatRoom = new ChatRoom();
        
        User user1 = new User("Виктория", chatRoom);
        User user2 = new User("Александра", chatRoom);
        User user3 = new User("Кристана", chatRoom);

        Console.WriteLine("ОБЩИЕ СООБЩЕНИЯ");
        user1.Send("привет всем!");
        user2.Send("привет, Вика");
        user3.Send("привет!! сегодня пойдем в кино?");

        Console.WriteLine("\nПРИВАТНЫЕ СООБЩЕНИЯ");
        user1.SendPrivate("как дела?", user2);
        user2.SendPrivate("норм", user1);

        Console.WriteLine("\nУВЕДОМЛЕНИЯ");
        user3.LeaveChat();
        User user4 = new User("Карина", chatRoom);

        Console.WriteLine("\nОБРАБОТКА ОШИБОК");
        // Пытаемся отправить сообщение после выхода из чата
        user3.Send("это сообщение не должно отправиться");

        user1.Send("нормальное сообщение");
    }
}