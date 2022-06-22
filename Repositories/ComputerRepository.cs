using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

public class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public IEnumerable<Computer> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computers = connection.Query<Computer>("SELECT * FROM Computer");
        return computers;
    }

    public void Save(Computer computer)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        
        connection.Execute("INSERT INTO Computer VALUES(@ID, @Ram, @Processor);", computer);
    }

    public Computer GetById(int id)
    {
        using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
        {
            var computer = connection.QuerySingle<Computer>("SELECT * FROM Computer WHERE ID=@ID", new { @ID = id });
            return computer;
        }
    }

    public void Update(Computer computer)
    {
        using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
        {
            connection.Execute("UPDATE Computer SET Ram=@Ram, Processor=@Processor WHERE ID=@ID", computer);
        }
    }

    public void Delete(int id)
    {
        using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
        {
            connection.Execute("DELETE FROM Computer WHERE ID=@ID", new { @ID = id });
        }
    }

    public bool ExistsById(int id)
    {
        using (var connection = new SqliteConnection(_databaseConfig.ConnectionString))
        {
            var exists = connection.ExecuteScalar<bool>("SELECT COUNT(ID) FROM Computer WHERE ID=@ID", new { @ID = id });
            return exists;
        }
    }
}
