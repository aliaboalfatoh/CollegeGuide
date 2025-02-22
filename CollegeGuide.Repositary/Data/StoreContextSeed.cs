using CollegeGuide.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext dbContext)
    {
        try
        {
            await SeedUniversitiesAsync(dbContext);
            await SeedCollegesAsync(dbContext);
            await SeedRecommendationsAsync(dbContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static async Task SeedUniversitiesAsync(StoreContext dbContext)
    {
        if (!await dbContext.Universities.AnyAsync())
        {
            string filePath = "D:\\CollegeGuide\\CollegeGuide.Repositary\\Data\\DataSeed\\Universities.Json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }
            var jsonData = File.ReadAllText("D:\\CollegeGuide\\CollegeGuide.Repositary\\Data\\DataSeed\\CollegeGuideData.Json");
            Console.WriteLine(" Loaded JSON Content: " + jsonData);


            var universityData = await File.ReadAllTextAsync(filePath);
            var universities = JsonSerializer.Deserialize<List<University>>(universityData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (universities is { Count: > 0 })
            {
                await dbContext.Universities.AddRangeAsync(universities);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Failed to load or deserialize university data.");
            }
        }
    }

    private static async Task SeedCollegesAsync(StoreContext dbContext)
    {
        if (!await dbContext.Colleges.AnyAsync())
        {
            string filePath = "D:\\CollegeGuide\\CollegeGuide.Repositary\\Data\\DataSeed\\Colleges.Json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var collegeData = await File.ReadAllTextAsync(filePath);
            var colleges = JsonSerializer.Deserialize<List<College>>(collegeData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (colleges is { Count: > 0 })
            {
                var universityDict = await dbContext.Universities.ToDictionaryAsync(u => u.Uni_Id);

                foreach (var college in colleges)
                {
                    if (universityDict.TryGetValue(college.Uni_Id, out var university))
                    {
                        college.Uni_Id = university.Uni_Id;
                    }
                    else
                    {
                        Console.WriteLine($"No university found for ID: {college.Uni_Id}");
                    }
                }

                await dbContext.Colleges.AddRangeAsync(colleges);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Failed to load or deserialize college data.");
            }
        }
    }

    private static async Task SeedRecommendationsAsync(StoreContext dbContext)
    {
        if (!await dbContext.Recommendations.AnyAsync())
        {
            string filePath = "D:\\CollegeGuide\\CollegeGuide.Repositary\\Data\\DataSeed\\Recommendations.Json";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var recommendationData = await File.ReadAllTextAsync(filePath);
            var recommendations = JsonSerializer.Deserialize<List<Recommendation>>(recommendationData,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (recommendations is { Count: > 0 })
            {
                var universityDict = await dbContext.Universities.ToDictionaryAsync(u => u.Uni_Id);
                var collegeDict = await dbContext.Colleges.ToDictionaryAsync(c => c.Col_Id);

                foreach (var recommendation in recommendations)
                {
                    if (universityDict.TryGetValue(recommendation.Uni_Id, out var university))
                    {
                        recommendation.Uni_Id = university.Uni_Id;
                    }
                    else
                    {
                        Console.WriteLine($"No university found for ID: {recommendation.Uni_Id}");
                    }

                    if (collegeDict.TryGetValue(recommendation.Col_Id, out var college))
                    {
                        recommendation.Col_Id = college.Col_Id;
                    }
                    else
                    {
                        Console.WriteLine($"No college found for ID: {recommendation.Col_Id}");
                    }
                }

                await dbContext.Recommendations.AddRangeAsync(recommendations);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Failed to load or deserialize recommendation data.");
            }
        }
    }
}
