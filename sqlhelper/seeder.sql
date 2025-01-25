CREATE TABLE Exercises (
    ExerciseId INT PRIMARY KEY,
    ExerciseName NVARCHAR(50),
    MuscleGroup NVARCHAR(50)
);

INSERT INTO Exercises (ExerciseId, ExerciseName, MuscleGroup) VALUES
(1, 'Squat', 'Legs'),
(2, 'Deadlift', 'Back'),
(3, 'Bench Press', 'Chest'),
(4, 'Pull-up', 'Back'),
(5, 'Push-up', 'Chest'),
(6, 'Incline Bench Press', 'Chest'),
(7, 'Dumbbell Fly', 'Chest'),
(8, 'Push-up', 'Chest'),
-- Back Exercises
(9, 'Pull-up', 'Back'),
(10, 'Barbell Row', 'Back'),
(11, 'Lat Pulldown', 'Back'),
-- Legs Exercises
(12, 'Leg Press', 'Legs'),
(13, 'Lunges', 'Legs'),
(14, 'Calf Raise', 'Legs'),
-- Shoulders Exercises
(15, 'Shoulder Press', 'Shoulders'),
(16, 'Lateral Raise', 'Shoulders'),
(17, 'Front Raise', 'Shoulders'),
-- Arms Exercises
(18, 'Bicep Curl', 'Arms'),
(19, 'Tricep Dip', 'Arms'),
(20, 'Hammer Curl', 'Arms'),
-- Core Exercises
(21, 'Plank', 'Core'),
(22, 'Sit-up', 'Core'),
(23, 'Russian Twist', 'Core'),
-- Cardio Exercises
(24, 'Running', 'Cardio'),
(25, 'Cycling', 'Cardio'),
(26, 'Rowing', 'Cardio'),
-- Other
(27, 'Deadlift', 'Full Body'),
(28, 'Clean and Press', 'Full Body'),
(29, 'Kettlebell Swing', 'Full Body');