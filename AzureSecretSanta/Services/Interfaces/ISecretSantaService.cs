using System.Threading.Tasks;

namespace AzureSecretSanta.Services.Interfaces
{
    public interface ISecretSantaService
    {
        Task ShuffleUsers();
    }
}
