using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutTrackerAPI.Models;

public class User
{
    public int Id {get; set;}

    [StringLength(100, MinimumLength = 1)]
    public string Username {get; set;} = string.Empty;

    [StringLength(100, MinimumLength = 0)]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
    public string Email {get; set;} = string.Empty;

    [StringLength(100, MinimumLength = 1)]
    [JsonIgnore]
    public string PasswordHash {get; set;} = string.Empty;

    [JsonIgnore]
    public DateTime CreatedDateAt {get; set;} = DateTime.Now;

    //since user can have many Workouts for the orm i need this to be in here
    [JsonIgnore]
    public ICollection<Workout>? Workouts {get; set;}
}

public class UserD
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    [JsonIgnore]
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime CreatedDateAt { get; set; }  = DateTime.Now;
/*     [JsonIgnore] */
    /* public ICollection<Workout> Workouts {get; set;} */
}