using WorkoutTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorkoutTrackerAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace WorkoutTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly MvcWorkoutContext _context;

        public WorkoutController(MvcWorkoutContext context)
        {
            _context = context;
        }

        [HttpGet("{userid}")]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts(int userid, [FromQuery] string status = "Pending")
        {
            var workouts = await _context.Workouts
                .Where(e => e.UserId == userid && (status == null || e.Status == status))
               /*  .OrderBy(e => e.ScheduledDate) */
                .Include(b => b.User) //eagearly bring user 
                .Include(b => b.WorkoutExercises) //eagearly bring array of workout exercises
                .ToListAsync();
            
            if (workouts == null)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteWorkout(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return Ok("the workout was deleted succesfully");
        }

        //it should get the exerciseId from the UI in a way...
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(Workout workoutItem)
        {
            var workout = new Workout
            {
                UserId = workoutItem.UserId,
                ScheduledDate = workoutItem.ScheduledDate,
                Notes = workoutItem.Notes,
                WorkoutExercises = workoutItem.WorkoutExercises
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(PostWorkout),
                new { id = workout.Id },
                workout);
        }



        [HttpPut("{id}")]
   /*      [Authorize] */
        public async Task<IActionResult> UpdateWorkout(int id, [FromBody] WorkoutUpdateDto workoutDto)
        {
            var existingWorkout = await _context.Workouts.Include(w => w.WorkoutExercises).FirstOrDefaultAsync(w => w.Id == id);
            //include is also needed heere to eagrly load the relationship tables

            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return NotFound();
            }

            existingWorkout.ScheduledDate = workoutDto.ScheduledDate;
            existingWorkout.Notes = workoutDto.Notes;
            existingWorkout.WorkoutExercises = workoutDto.WorkoutExercises; ///i think this might need validaitons for the workoutid in the workoutexercise etc...
            //like how can i the workoutid ??? 

            
            await _context.SaveChangesAsync();

            return Ok("the workout has been updated succesfully");
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<Workout>>> ScheduleWorkout(int id, [FromQuery] DateTime dateTime)
        {
            var workout = await _context.Workouts.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id);
            
            if (workout == null)
            {
                return NotFound();
            }

            workout.ScheduledDate = dateTime;
            await _context.SaveChangesAsync();

            return Ok($"the work out has been succesfully scheduled to: {dateTime}");
        }

        [HttpGet("Report")]
        public async Task<ActionResult> GetWorkoutsReport([FromQuery] int userId, [FromQuery] string startDate, [FromQuery] string endDate)
        {
            var report = await _context.GetWorkoutsReport(userId, startDate, endDate);
            if(report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }
    }
}