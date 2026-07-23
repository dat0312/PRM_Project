using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program {
    static async Task Main() {
        var client = new HttpClient { BaseAddress = new Uri("http://localhost:5139") };
        var loginResponse = await client.PostAsJsonAsync("/api/auth/login", new { PhoneNumber = "0352578129", Password = "denhat123" });
        if (!loginResponse.IsSuccessStatusCode) {
            Console.WriteLine("Login failed: " + loginResponse.StatusCode); return;
        }
        var loginData = await loginResponse.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();
        var token = loginData.GetProperty("token").GetString();
        
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        
        var url = "/api/schedule?startDate=2026-07-19T17:00:00.000Z&endDate=2026-07-26T16:59:59.999Z&classId=1";
        var res = await client.GetAsync(url);
        Console.WriteLine($"Status: {res.StatusCode}");
        var content = await res.Content.ReadAsStringAsync();
        Console.WriteLine($"Content: {content}");
    }
}
