using System.ComponentModel.DataAnnotations;

namespace WorkoutTrackerAPI.Models;

public class Workout
{
    public int Id {get; set;}
    public int UserId {get; set;}
	public DateTime ScheduledDate = DateTime.Now;
    [StringLength(20, MinimumLength = 0)]
	public string Status {get; set;} = "Pending";
	public string Notes {get; set;} = string.Empty;
    public User? User {get; set;}
    //the nullable is important for creating new Workout item
    
    //since workout can have many workout exercises for the orm i need this to be in here
    public ICollection<WorkoutExercise> WorkoutExercises {get; set;} = new List<WorkoutExercise>();
    //empty list is needed for new workout item to be created 
}

public class WorkoutUpdateDto
{
    public int Id { get; set; }
    public DateTime ScheduledDate { get; set; } = DateTime.Now;
    public string Status { get; set; }
    public string Notes { get; set; }
    public ICollection<WorkoutExercise> WorkoutExercises {get; set;} = new List<WorkoutExercise>();
}