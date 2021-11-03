using System.Text.Json;

using Pomodoro.Di;

namespace GeneratePomodoroMock
{
    public static class MockPomodoroSource
    {
        public static IEnumerable<IPomodoroData> GetPomodoroData()
        {
            return JsonSerializer.Deserialize<IEnumerable<MockPomodoro>>("pomodoro_data.json",
                                                                      new JsonSerializerOptions
                                                                      {
                                                                          PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                                      });
        }
    }
}
