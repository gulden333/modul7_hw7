namespace spp_pr7.Mediator;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        IMediator chatRoom = new ChatRoom();
        
        User user1 = new User("Никита1", chatRoom);
        User user2 = new User("Никита2", chatRoom);
        User user3 = new User("Никита3", chatRoom);

        Console.WriteLine("ОБЩИЕ СООБЩЕНИЯ");
        user1.Send("привет всем!");
        user2.Send("привет, Никита589");
        user3.Send("ты перепутал он Никита1");

        Console.WriteLine("\nПРИВАТНЫЕ СООБЩЕНИЯ");
        user1.SendPrivate("как дела?", user2);
        user2.SendPrivate("норм", user1);

        Console.WriteLine("\nУВЕДОМЛЕНИЯ");
        user3.LeaveChat();
        User user4 = new User("Никита4", chatRoom);

        Console.WriteLine("\nОБРАБОТКА ОШИБОК");
        // Пытаемся отправить сообщение после выхода из чата
        user3.Send("это сообщение не должно отправиться");

        user1.Send("нормальное сообщение");
    }
}