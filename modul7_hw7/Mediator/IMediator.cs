namespace spp_pr7.Mediator;
using System;
using System.Collections.Generic;
public interface IMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
    void RemoveUser(User user);
    void SendPrivateMessage(string message, User fromUser, User toUser);
}