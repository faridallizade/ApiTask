namespace ApiTask.Entitites
{
    public class Colour :BaseEntity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
