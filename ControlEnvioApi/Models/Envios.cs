namespace ControlEnvioApi.Models
{
    public class Envios
    {
        public Guid id {  get; set; }
        public string destino { get; set; }
        public float pesoKg { get; set; }
        public float precioporKg { get; set; }
        public bool esUrgente { get; set; }

    }
}
//Envios(id,destino,pesoKg,precioporKg,esUrgente) Calcular el valor del envio, aplicando 15 adicional si es urgente
