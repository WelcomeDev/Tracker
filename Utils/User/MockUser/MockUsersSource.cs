using System.Text.Json;

using Auth.Di;

using MockUser.Properties;

namespace MockUser
{
    public static class MockUsersSource
    {
        public static IEnumerable<IUserIdentity> GetUsers()
        {
            var result = JsonSerializer.Deserialize<MockUser[]>(Resources.users/*,
                                                          new JsonSerializerOptions()
                                                          {
                                                              PropertyNamingPolicy = SnakeCaseNamingPolicy.Policy,
                                                          }*/)/*.Select(x=>new MockUser(x))*/;

            return result;
        }
    }
}
