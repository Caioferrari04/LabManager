using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Database;

public class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;
    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateComputerTable();
        CreateLabTable();
    }

    private void CreateComputerTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Computer(
                 ID int not null primary key,
                 Ram varchar(100) not null,
                 Processor varchar(100) not null
            );
        ");

        connection.Close();
    }

    private void CreateLabTable()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Lab(
                ID int not null primary key,
                Name varchar(100) not null,
                Block varchar(100) not null,
                Number int not null
        );";

        command.ExecuteNonQuery();

        connection.Close();
    }
}