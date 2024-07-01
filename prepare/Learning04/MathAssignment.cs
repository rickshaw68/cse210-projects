public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textBookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textBookSection;
        _problems = problems;
    }
    
   
    public string GetHomeworkList()
    {
        return $"Textbook: {_textbookSection}\nProblems: {_problems}";
    }

}