public class Entery
{
  public string _date;
  public string _prompt;
  public string _userResponse;

  public void Display()
  {
    Console.WriteLine($"{_date} - {_prompt}");
  }
}
