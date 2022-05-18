using Microsoft.Data.Sqlite;

namespace LabManager.Database;

public class DatabaseSetup
{
    public DatabaseSetup()
    {
        _createComputerTable();
        _createLabTable();   
    }

    private void _createComputerTable()
    {
        var connection = new SqliteConnection("Data Source=database.db");

        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Computer(
                ID int not null primary key,
                ram varchar(100) not null,
                processor varchar(100) not null
        );";

        command.ExecuteNonQuery();

        connection.Close();
    }

    private void _createLabTable()
    {
        var connection = new SqliteConnection("Data Source=database.db");

        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Lab(
                ID INT NOT NULL PRIMARY KEY,
                Number INT NOT NULL,
                Name VARCHAR(100) NOT NULL,
                Block VARCHAR(50) NOT NULL
            );";

        command.ExecuteNonQuery();

        connection.Close();
    }
}