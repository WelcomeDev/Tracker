using System.Text.Json;

using GeneratePomodoroMock;

using MockUser;

using WelcomeDev.Utils;

Console.WriteLine("Enter amount:");
int amount = int.Parse(Console.ReadLine());


List<MockPomodoro> mockData = new List<MockPomodoro>();
var users = MockUsersSource.GetUsers();
int[] hoursPresetOptions = { 0, 1 };
int[] minutesPresetOptions = { 0, 15, 30 };
Random rnd = new Random(DateTime.Now.Millisecond);

for (int i = 0; i < amount; i++)
{
    var data = new MockPomodoro
    {
        User = users.ElementAt(i % users.Count()),
        Title = "Pomodoro" + (i + 1).ToString(),
        StartDate = new DateTime(2021,
                                 rnd.Next(1, 13),
                                 rnd.Next(1, 27),
                                 rnd.Next(0, 24),
                                 rnd.Next(0, 60),
                                 0),
        Duration = new TimeSpan(hoursPresetOptions[rnd.Next(0, hoursPresetOptions.Length)],
                                minutesPresetOptions[rnd.Next(0, minutesPresetOptions.Length)],
                                0),
        Id = Guid.NewGuid(),
    };

    mockData.Add(data);
}

string jsonData = JsonSerializer.Serialize<IEnumerable<MockPomodoro>>(mockData,
                                                                      new JsonSerializerOptions
                                                                      {
                                                                          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                                      });
StreamWriter sw = new StreamWriter("pomodoro_data.json");
sw.Write(jsonData);
