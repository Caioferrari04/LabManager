namespace LabManager.Models;

public class Lab
{
    public Lab(int id, string name, string block, int number)
    {
        ID = id;
        Name = name;
        Block = block;
        Number = number;
    }
    
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public string Block { get; set; }
    
    public int Number { get; set; }
    
}
