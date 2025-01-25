using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutTrackerAPI.Models;
public class WorkoutExercise
{
    [JsonIgnore]
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string MuscleGroup {get; set;} = string.Empty;
    public int WorkoutId {get; set;}
    public int Reps {get; set;}
	public int Sets {get; set;}
	public int Weight {get; set;}
	public string Notes {get; set;} = string.Empty;

    //needed for the foreignkey in dbcontext
    [JsonIgnore]
    public  Workout? Workout {get; set;}
}
    