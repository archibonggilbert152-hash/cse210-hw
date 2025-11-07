public class Entery
{
  public string _date;
  public string _prompt;
  public string _userResponse;

  public void Display()
  {
    Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
  }
  
    // Converts the entry to a single saveable line
    public string csv()
    {
        return $"{_date}|{_prompt}|{_response}";
    }
}
