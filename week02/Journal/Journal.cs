using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
  public List<Entery> _entries = new List<Entery>();

  public void Display()
  {
    foreach (Entery entry in _entries)
    {
      entry.Display();
    }
  }

  public void SaveToFile(string file)
  {
    // Add your save implementation here
  }

  public void LoadFromFile(string file)
  {
    // Add your load implementation here
  }
}