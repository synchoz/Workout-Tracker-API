using WorkoutTrackerAPI.Controllers;
using WorkoutTrackerAPI.Data;
using WorkoutTrackerAPI.Models;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorkoutTrackerAPI.Tests
{
    public class WorkoutControllerTest
    {
        [Fact]
        public async Task GetAll_Workouts_Success()
        {
            // Arrange
            var data = new List<Workout>
            {
                new Workout { Id = 1, UserId = 1, Status = "Pending", Notes = "Workout 1" },
                new Workout { Id = 2, UserId = 1, Status = "Completed", Notes = "Workout 2", 
                    WorkoutExercises = new List<WorkoutExercise> 
                    { 
                        new WorkoutExercise { Id = 1, WorkoutId = 2, MuscleGroup = "Bench", Name = "Dumbel Press", Reps = 3, Sets = 3, Weight = 80 },
                        new WorkoutExercise { Id = 2, WorkoutId = 2, MuscleGroup = "Legs", Name = "Squat", Reps = 3, Sets = 3, Weight = 90 }
                    },
                    User = new User { Id = 1, Username = "synchoz", Email = "dima2191@gmail.com", CreatedDateAt = DateTime.Now}}
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Workout>>();
            mockSet.As<IQueryable<Workout>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Workout>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Workout>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Workout>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<MvcWorkoutContext>();
            mockContext.Setup(c => c.Workouts).Returns(mockSet.Object);

            var controller = new WorkoutController(mockContext.Object);
            int validUserId = 1;
            int invalidUserId = 2;

            // Act
          /*   var errorActionResult = await controller.GetWorkouts(2); */
            var actionResult = await controller.GetWorkouts(1); 
            var okResult = actionResult.Result as OkObjectResult; 
            var result = okResult?.Value as IEnumerable<Workout>; 

            // Assert
           /*  Assert.IsType<NotFoundResult>(errorActionResult); */
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Workout>>(result); 
            Assert.Collection(result,
                item => Assert.Equal("Workout 1", item.Notes),
                item => Assert.Equal("Workout 2", item.Notes),
                item => Assert.Equal("Completed", item.Status),
                item => Assert.Equal(2, item.WorkoutExercises.Count),
                item => Assert.Equal("synchoz", item.User?.Username)
            );
        }
    }
}
