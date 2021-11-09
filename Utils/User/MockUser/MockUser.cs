using Auth.Di;

namespace MockUser
{
    internal class MockUser : IUserIdentity
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public MockUser()
        {

        }

        public MockUser(MockUserData mockData)
        {
            Name = mockData.Name;
            Id = new Guid(mockData.Id);
        }
    }
}
