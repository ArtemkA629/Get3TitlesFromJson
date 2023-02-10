int titlesNumber = 3;
string json = await GetJsonString();
string[] titles = GetTitles(json);
for (int i = 0; i < titlesNumber; i++)
    Console.WriteLine(titles[new Random().Next(0, titles.Length)]);

static async Task<string> GetJsonString()
{
    using (HttpClient httpClient = new HttpClient())
        return await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
}

static string[] GetTitles(string json)
{
    string[] titleLines = json.Split('\n')
        .Where(x => x.Contains("title"))
        .ToArray();
    int titleIndex = 3;
    return titleLines.Select(x => x!.Split("\"")[titleIndex]).ToArray();
}