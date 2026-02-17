using ControlEnvioApi.Models;

namespace ControlEnvioApi.Interfaces
{
    public interface IEnviosService
    {
        List<Envios> GetAll();
        Envios getById(Guid id);
        float getPrice(Guid id);
    }
}
