namespace BorderControl.Models.Interfaces
{
    public interface ICitizen : IIdentifiable
    {
        string Name { get; }
        int Age { get; }
    }
}
