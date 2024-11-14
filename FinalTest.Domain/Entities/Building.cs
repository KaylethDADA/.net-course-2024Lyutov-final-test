namespace FinalTest.Domain.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; private set; }
        /// <summary>   
        /// TODO: сделать как отдельный объект
        /// </summary>
        public string Address { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<Sensor> Sensors { get; private set; } = new List<Sensor>();
        
        public Building(string name, string address, Guid userId)
        {
            Name = name;
            Address = address;
            UserId = userId;
        }

        public Building()
        {
            
        }

        public Building Update(string name, string addres)
        { 
            Name = name;
            Address = addres;

            return this;
        }
    }
}
