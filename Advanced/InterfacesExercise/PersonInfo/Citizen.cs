namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }

    }
}
