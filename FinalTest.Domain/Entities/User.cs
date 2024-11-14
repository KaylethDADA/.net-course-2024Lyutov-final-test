namespace FinalTest.Domain.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// TODO: сделать как отдельный объект
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// TODO: сделать как отдельный объект
        /// </summary>
        public string Email { get; private set; }
        public ICollection<Building> Buildings { get; init; } = new List<Building>();

        public User(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public User()
        {


        }

        public User Update(string fullName, string email)
        {
            FullName = fullName;
            Email = email;

            return this;
        }
    }
}
