namespace Mottu.Patio.API.Models
{
    public class Localizacao
    {
        public int Id { get; set; }
        public int MotoId { get; set; }
        public Moto Moto { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public System.DateTime Data { get; set; }
    }
}