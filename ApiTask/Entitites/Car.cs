namespace ApiTask.Entitites
{
    public class Car:BaseEntity
    {
        public int Modelyear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColorId { get; set; }
        public Colour Color { get; set; }
    }
}
