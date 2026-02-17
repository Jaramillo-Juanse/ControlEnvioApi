using ControlEnvioApi.Models;
using ControlEnvioApi.Interfaces;


namespace ControlEnvioApi.Services
{
    public class EnviosService : IEnviosService
    {
        private static List<Envios> _envios = new List<Envios>
        {
            new Envios{id= Guid.NewGuid(), destino = "Medellin",pesoKg = 10.0f,precioporKg = 3.0f,esUrgente = true, isActive = true},
            new Envios{id= Guid.NewGuid(), destino = "Sonsón",pesoKg = 16.0f,precioporKg = 5.0f,esUrgente = false, isActive = true},
            new Envios{id= Guid.NewGuid(), destino = "Barranquilla",pesoKg = 10.0f,precioporKg = 3.0f,esUrgente = false, isActive = true},

        };

        public List<Envios> GetAll() => _envios.Where(e=>e.isActive==true).ToList();
        public Envios getById(Guid id) => _envios.FirstOrDefault(e => e.id == id);
        public float getPrice(Guid id)
        {
            var envio = getById(id);
            if (envio == null || envio.isActive == false) return 0.0f;
            var precio= envio.pesoKg * envio.precioporKg;
            precio = envio.esUrgente ? precio + 15 : precio;
            return precio;
        }
        public Envios Create(Envios newEnvio)
        {
            //Generamos id para nuevo registro
            newEnvio.id = Guid.NewGuid();
            //Agregamos registro
            _envios.Add(newEnvio);
            return newEnvio;
        }
        public bool Update(Guid id, Envios editedEnvio)
        {
            //validar existencia
            var envioExiste = getById(id);
            if (envioExiste == null) return false;
            envioExiste.destino = editedEnvio.destino;
            envioExiste.pesoKg = editedEnvio.pesoKg;
            envioExiste.precioporKg = editedEnvio.precioporKg;
            envioExiste.esUrgente = editedEnvio.esUrgente;
            return true;
        }
        public bool ChangeStatus(Guid id)
        {
            var existe = getById(id);
            if (existe == null) return false;
            existe.isActive = existe.isActive ? false : true;
            return true;
        }
    }
}
//Envios(id,destino,pesoKg,precioporKg,esUrgente) Calcular el valor del envio, aplicando 15 adicional si es urgente