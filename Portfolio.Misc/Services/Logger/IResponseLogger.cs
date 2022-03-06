namespace Portfolio.Misc.Services.Logger;

public interface IResponseLogger
{
    public void AddLog(string email, string message, string name, string subject);
}