using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WorkoutTrackerAPI.Models;

//this more like a master table for workoutexercises
public class Exercise
{
    public int Id {get; set;}
    [StringLength(50, MinimumLength = 0)]
    public string ExerciseName {get; set;} = string.Empty;
    [StringLength(50, MinimumLength = 0)]
    public string MuscleGroup {get; set;} = string.Empty;
    [StringLength(2000, MinimumLength = 1)]
    public string Description {get; set;} = string.Empty;
}