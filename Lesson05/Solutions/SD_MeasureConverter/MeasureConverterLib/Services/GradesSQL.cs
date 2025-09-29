using Dapper;
using MySql.Data.MySqlClient;
using System.Text.Json.Serialization;

namespace MeasureConverterLib.Services
{
    public class GradesSQL
    {
        private const string MyConnectionString = "server=127.0.0.1;port=3307;uid=root;pwd=admin;database=converter;";


        public static async Task<List<GradesDto>> Get()
        {
            try
            {
                await using var connection = new MySqlConnection(MyConnectionString);
                await connection.OpenAsync();
                var grades = connection.Query<GradesDto>("select * from grades").ToList();
                var gradesList = grades.Select(grade => new GradesDto
                {
                    Id = grade.Id,
                    Denmark = grade.Denmark,
                    Usa = grade.Usa
                }).ToList();
                return gradesList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving grades from database", ex);
            }

        }
    }
}

public record GradesDto
{
    [JsonPropertyName("cGradeId")]
    public int Id { get; init; }
    [JsonPropertyName("cDenmark")]
    public required string Denmark { get; init; }
    [JsonPropertyName("cUSA")]
    public required string Usa { get; init; }

}