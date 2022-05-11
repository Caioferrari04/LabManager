using Microsoft.Data.Sqlite;

var connection = new SqliteConnection("Data Source=database.db");
connection.Open();

var command = connection.CreateCommand();

command.CommandText = @"CREATE TABLE";

connection.Close();

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine($"List computer");
        
    }
    else if (modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];
        Console.WriteLine($"New computer");
        Console.WriteLine($"{id}, {ram}, {processor}");
        
    }
}