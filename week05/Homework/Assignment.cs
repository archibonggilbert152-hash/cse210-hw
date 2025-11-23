public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Getter so derived classes can access the student name
    public string GetStudentName()
    {
        return _studentName;
    }

    // Summary method (same for all assignments)
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}
