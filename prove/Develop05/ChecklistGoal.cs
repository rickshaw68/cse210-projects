public class ChecklistGoal : Goal
{
    public int Target { get; set; }
    public int Bonus { get; set; }
    public int AmountCompleted { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        Target = target;
        Bonus = bonus;
        AmountCompleted = 0;
    }

    public override int RecordEvent()
    {
        AmountCompleted++;
        if (AmountCompleted >= Target)
        {
            return Points + Bonus;
        }
        return Points;
    }

    public override bool Complete => AmountCompleted >= Target;

    public override string GetStringRepresentation()
    {
        return $"Checklist;{Name};{Description};{Points};{AmountCompleted};{Target};{Bonus}";
    }

    public override string GetDetailsString()
    {
        return $"{(Complete ? "[X]" : "[ ]")} {Name}: {Description} ({AmountCompleted}/{Target} completed)";
    }
}
