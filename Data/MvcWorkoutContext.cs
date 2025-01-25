using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WorkoutTrackerAPI.Models;

namespace WorkoutTrackerAPI.Data
{
    public class MvcWorkoutContext : DbContext
    {
        public MvcWorkoutContext (DbContextOptions<MvcWorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutsReport> WorkoutsReport { get; set;}

        public async Task<WorkoutsReport> GetWorkoutsReport(int userId, string start, string end)
        {
            var summary = WorkoutsReport
                            .FromSqlInterpolated($"EXEC GetWorkoutsReport @UserId={userId}, @StartDate={start}, @EndDate={end}")
                            .AsEnumerable() 
                            .FirstOrDefault(); 

            if (summary == null)
            {
                return new WorkoutsReport();
            }

            var workouts = await Workouts.FromSqlInterpolated($"EXEC GetWorkoutsDetails @UserId={userId}, @StartDate={start}, @EndDate={end}").ToListAsync();

            var workoutExercises = await WorkoutExercises.FromSqlInterpolated($"EXEC GetWorkoutExercises @UserId={userId}, @StartDate={start}, @EndDate={end}").ToListAsync();

            foreach (var workout in workouts)
            {
                workout.WorkoutExercises = workoutExercises.Where(we => we.WorkoutId == workout.Id).ToList();
            }
            
            summary.Workouts = workouts;

            return summary;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkoutsReport>().HasNoKey();

            //(1-to-Many)
            modelBuilder.Entity<Workout>()
                .HasOne(c => c.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(c => c.UserId)
                .IsRequired();
            //(1-to-Many)
            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(c => c.Workout)
                .WithMany(u => u.WorkoutExercises)
                .HasForeignKey(c => c.WorkoutId)
                .IsRequired();
        }
    }
}