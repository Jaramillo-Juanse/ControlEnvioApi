using ControlEnvioApi.Models;
using ControlEnvioApi.Interfaces;


namespace ControlEnvioApi.Services
{
    public class EnviosService : IEnviosService
    {
        private static List<Envios> _envios = new List<Envios>
        {
            new Envios{id= Guid.NewGuid(), destino = "Medellin",pesoKg = 10.0f,precioporKg = 300.0f,esUrgente = true},
            new Envios{id= Guid.NewGuid(), destino = "Sonsón",pesoKg = 16.0f,precioporKg = 500.0f,esUrgente = false},
            new Envios{id= Guid.NewGuid(), destino = "Barranquilla",pesoKg = 10.0f,precioporKg = 300.0f,esUrgente = false},

        };

        public List<Envios> GetAll() => _envios.ToList();
        public Envios getById(Guid id) => _envios.FirstOrDefault(e => e.id == id);
        public float getPrice(Guid id)
        {
            var envio = getById(id);
            if (envio == null) return 0;
            var precio= envio.pesoKg * envio.precioporKg;
            precio = envio.esUrgente ? precio + 15 : precio;
            return precio;
        }
    }
}
//Envios(id,destino,pesoKg,precioporKg,esUrgente) Calcular el valor del envio, aplicando 15 adicional si es urgente