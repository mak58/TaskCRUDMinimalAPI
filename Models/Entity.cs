namespace Minimal.Models
{
    public abstract class Entity
    {
        protected  Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Code { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set; }
        public DateTime BirthDay { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModificatedAt { get; set; } = DateTime.Now;
    }
}