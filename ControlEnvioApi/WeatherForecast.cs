namespace ControlEnvioApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
//Envios(id,destino,pesoKg,precioporKg,esUrgente) Calcular el valor del envio, aplicando 15 adicional si es urgente