namespace mkproject.Models
{
    public class Person
    {
        protected Person()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public Person(string firstName, string lastName, string? phoneNumber = null) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public string? PhoneNumber { get; protected set; }
    }
}