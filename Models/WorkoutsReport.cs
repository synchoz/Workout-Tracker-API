using System.ComponentModel.DataAnnotations.Schema;

namespace WorkoutTrackerAPI.Models;
public class WorkoutsReport
{
    public string Username {get;set;} = string.Empty;
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }  
    public int TotalWorkouts {get;set;}
    public int TotalExercises {get;set;} 
    public string MostFrequentWorkout {get;set;} = string.Empty;
    public ICollection<Workout>? Workouts {get;set;} = new List<Workout>();
}