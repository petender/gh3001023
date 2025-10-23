using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace gh3001023.Pages;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime HiringDate { get; set; }
    public string Department { get; set; }
    public string JobTitle { get; set; }
}

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    public List<Employee> Employees { get; set; } = new();

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "sampledata.json");
        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            Employees = JsonSerializer.Deserialize<List<Employee>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Employee>();
        }
    }
}

