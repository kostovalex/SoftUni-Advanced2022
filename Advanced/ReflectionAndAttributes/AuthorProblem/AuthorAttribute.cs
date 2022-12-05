namespace AuthorProblem
{
    using System;
    
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method ,AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }    
    }
}
