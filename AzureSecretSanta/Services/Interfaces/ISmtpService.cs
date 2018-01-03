using System.Threading.Tasks;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Services.Interfaces
{
    public interface ISmtpService
    {
        Task SendEmail(UserModel to, UserModel santaOf);
    }
}
