using System.Threading.Tasks;

namespace AzureSecretSanta.Interfaces.Services
{
    public interface ISecretSantaService
    {
        Task ShuffleUsers();
    }
}
