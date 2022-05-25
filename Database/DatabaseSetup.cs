using Microsoft.Data.Sqlite;

namespace LabManager.Database;

public class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateComputerTable();
    }

    private void CreateComputerTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

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
}