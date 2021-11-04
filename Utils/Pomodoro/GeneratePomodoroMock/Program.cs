using System.Text.Json;

using GeneratePomodoroMock;

using MockUser;

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
        WorkDuration = new Duration
        {
            Hours = hoursPresetOptions[rnd.Next(0, hoursPresetOptions.Length)],
            Minutes = minutesPresetOptions[rnd.Next(0, minutesPresetOptions.Length)],
        },
        RestDuration = new Duration
        {
            Hours = 0,
            Minutes = 15,
        },
        Id = Guid.NewGuid(),
    };

    mockData.Add(data);
}

string jsonData = JsonSerializer.Serialize<IEnumerable<MockPomodoro>>(mockData,
                                                                      new JsonSerializerOptions
                                                                      {
                                                                          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                                      });
Console.WriteLine($"Generated:\n {jsonData}");
File.WriteAllText("pomodoro_data.json", jsonData);
