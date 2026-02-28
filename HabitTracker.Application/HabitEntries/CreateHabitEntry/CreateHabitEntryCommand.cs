public record CreateHabitEntryCommand(

    Guid HabitId,
    DateTime? Date = null,
    bool Completed = true
);