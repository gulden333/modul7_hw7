namespace spp_pr7.Mediator;
using System;
using System.Collections.Generic;
public class User
{
    public string Name { get; }
    private IMediator mediator;

    public User(string name, IMediator mediator)
    {
        Name = name;
        this.mediator = mediator;
        mediator.AddUser(this);
    }

    public void LeaveChat()
    {
        mediator.RemoveUser(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} отправляет: {message}");
        mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} получает: {message}");
    }

    public void SendPrivate(string message, User toUser)
    {
        Console.WriteLine($"{Name} отправляет приватное сообщение {toUser.Name}: {message}");
        mediator.SendPrivateMessage(message, this, toUser);
    }

    public void ReceivePrivate(string message, User fromUser)
    {
        Console.WriteLine($"[Приватно] {Name} получает от {fromUser.Name}: {message}");
    }
}
