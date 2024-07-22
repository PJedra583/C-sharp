using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;
using System.Text.RegularExpressions;

namespace Tutorial5.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public AnimalsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    [HttpGet]
    public IActionResult GetAnimals(string? OrderBy = null)
    {
        if (OrderBy != null)
        {
            OrderBy = OrderBy.ToLower();
            string regexPattern = "^(name|description|category|area)$";
            bool isMatch = Regex.IsMatch(OrderBy, regexPattern);
            if (!isMatch)
            {
                return BadRequest("Avaible parameters: name, description, category, area");
            }
        }
        // Uruchamiamy połączenie do bazy
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        // Definiujemy command
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        if (OrderBy == null)
        {
            command.CommandText = "SELECT * FROM Animal order by Name";
        }
        else
        {
            //Protected from sql injection above
            command.CommandText = "SELECT * FROM Animal order by " + OrderBy;
        }
        // Uruchomienie zapytania
        var reader = command.ExecuteReader();

        List<Animal> animals = new List<Animal>();

        int idAnimalOrdinal = reader.GetOrdinal("IdAnimal");
        int NameOrdinal = reader.GetOrdinal("Name");
        int DescriptionOrdinal = reader.GetOrdinal("Description");
        int categoryOrdinal = reader.GetOrdinal("Category");
        int areaOrdinal = reader.GetOrdinal("Area");
        
        while (reader.Read())
        {
            int idAnimal = reader.GetInt32(idAnimalOrdinal);
            string nameAnimal = reader.GetString(NameOrdinal);
            string descriptionAnimal;
            if (reader.IsDBNull(DescriptionOrdinal))
            {
                descriptionAnimal = "";
            }
            else
            {
                descriptionAnimal = reader.GetString(DescriptionOrdinal);
            }
            string categoryAnimal = reader.GetString(categoryOrdinal);
            string area = reader.GetString(areaOrdinal);
            animals.Add(new Animal(idAnimal,nameAnimal,descriptionAnimal,categoryAnimal,area));
        }
        connection.Close();
        //var animals = _repository.GetAnimals();
        
        return Ok(animals);
    }


    [HttpPost]
    public IActionResult AddAnimal(AddAnimal addAnimal)
    {
        // Uruchamiamy połączenie do bazy
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();

        // Definiujemy command
        using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal VALUES(@animalId,@animalName,@animalDescription,@animalCategory,@animalArea)";
        command.Parameters.AddWithValue("@animalName", addAnimal.Name);
        command.Parameters.AddWithValue("@animalId", addAnimal.Id);
        command.Parameters.AddWithValue("@animalDescription", addAnimal.Description);
        command.Parameters.AddWithValue("@animalCategory", addAnimal.Category);
        command.Parameters.AddWithValue("@animalArea", addAnimal.Area);
        
        // Wykonanie commanda
        command.ExecuteNonQuery();
        connection.Close();
        return Created("Created an Animal", null);
    }

    [HttpPut("{idAnimal}")]
    public IActionResult editAnimal(int idAnimal, EditAnimal editAnimal)
    {
        using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal FROM Animal where IdAnimal = @idAnimal";
        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
        var reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            reader.Close();
            cmd.CommandText =
                "UPDATE Animal SET Name = @animalName, Description = @animalDescription, Category = @animalCategory, area = @animalArea  WHERE idanimal = @idAnimal";
            cmd.Parameters.AddWithValue("@animalName", editAnimal.Name);
            cmd.Parameters.AddWithValue("@animalDescription", editAnimal.Description);
            cmd.Parameters.AddWithValue("@animalCategory", editAnimal.Category);
            cmd.Parameters.AddWithValue("@animalArea", editAnimal.Area);
            cmd.ExecuteNonQuery();
            return Ok();
        }
        con.Close();
        return BadRequest("No such ID");
    }

    [HttpDelete("{idAnimal}")]
    public IActionResult deleteAnimal(int idAnimal)
    {
        using SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Default"));
        con.Open();
        using SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal where idanimal = @animalId";
        cmd.Parameters.AddWithValue("@animalId", idAnimal);
        if (cmd.ExecuteNonQuery() > 0)
        {
            return Ok();
        }
        con.Close();
        return BadRequest("No such id");
    }
}