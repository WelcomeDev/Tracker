namespace Auth.Di
{
    public interface IUserIdentity/* : IGuid*/
    {
        string Name { get; }

        Guid Id { get; }
    }
}
