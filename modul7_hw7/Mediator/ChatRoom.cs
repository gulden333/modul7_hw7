namespace spp_pr7.Mediator;
using System;
using System.Collections.Generic;public class ChatRoom : IMediator
{
    private List<User> users = new List<User>();

    public void SendMessage(string message, User user)
    {
        // Проверяем, что user не null
        if (user != null && !users.Contains(user))
        {
            Console.WriteLine($"Ошибка: {user.Name} не в чате");
            return;
        }

        foreach (var u in users)
        {
            if (u != user) // Если user null, то сообщение получат все
            {
                u.Receive(message);
            }
        }
    }

    public void AddUser(User user)
    {
        users.Add(user);
        // Отправляем сообщение от null (системное сообщение)
        SendMessage($"{user.Name} присоединился к чату", null);
    }

    public void RemoveUser(User user)
    {
        if (users.Contains(user))
        {
            users.Remove(user);
            // Отправляем сообщение от null (системное сообщение)
            SendMessage($"{user.Name} покинул чат", null);
        }
    }

    public void SendPrivateMessage(string message, User fromUser, User toUser)
    {
        if (!users.Contains(fromUser))
        {
            Console.WriteLine($"Ошибка: {fromUser.Name} не в чате");
            return;
        }

        if (!users.Contains(toUser))
        {
            Console.WriteLine($"Ошибка: {toUser.Name} не в чате");
            return;
        }

        toUser.ReceivePrivate(message, fromUser);
    }
}
