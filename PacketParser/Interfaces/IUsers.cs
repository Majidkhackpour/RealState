﻿namespace PacketParser.Interfaces
{
    public interface IUsers : IHasGuid
    {
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Access { get; set; }
        string SecurityQuestion { get; set; }
        string AnswerQuestion { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
    }
}
