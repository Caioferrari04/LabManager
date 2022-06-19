namespace LabManager.Models;

public class Computer 
{
    public Computer()
    { }

    public Computer(int id, string ram, string processor)
    {
        ID = id;
        Ram = ram;
        Processor = processor;
    }

    public int ID { get; set; }
    
    public string Ram { get; set; }
    
    public string Processor { get; set; }
}