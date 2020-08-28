using Services;

namespace PacketParser.Interfaces
{
    public interface IUsers : IHasGuid
    {
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Access { get; set; }
        EnSecurityQuestion SecurityQuestion { get; set; }
        string AnswerQuestion { get; set; }
        string Email { get; set; }
        string Mobile { get; set; }
        decimal Account { get; set; }
        decimal AccountFirst { get; set; }
    }
}
