// HabitTracker.Application/Habits/GetHabit/HabitResponse.cs
public record HabitResponse(
    Guid Id,
    string Name,
    DateTime CreatedAt
);