public class SimpleGoal : Goal
{
    public bool IsComplete 
    { 
        get; 
        set; 
    }

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        IsComplete = false;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override bool Complete => IsComplete;

    public override string GetStringRepresentation()
    {
        return $"Simple;{Name};{Description};{Points};{IsComplete}";
    }

    public override string GetDetailsString()
    {
        return $"{(IsComplete ? "[X]" : "[ ]")} {Name}: {Description}";
    }
}
