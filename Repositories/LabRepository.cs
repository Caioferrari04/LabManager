using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

public class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public IEnumerable<Lab> GetAll()
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var labs = connection.Query<Lab>("SELECT * FROM Lab");

        connection.Close();

        return labs;
    }

    public void Save(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Lab VALUES(@ID, @Name, @Block, @Number);", lab);

        connection.Close();
    }

    public Lab GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var lab = connection.QuerySingle<Lab>("SELECT * FROM Lab WHERE ID=@ID", new { @ID = id });

        connection.Close();

        return lab;
    }

    public void Update(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("UPDATE Lab SET Name=@Name, Block=@Block, Number=@Number WHERE ID=@ID", lab);

        connection.Close();
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Lab WHERE ID=@ID", new { @ID = id });

        connection.Close();
    }

    public bool ExistsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var exists = connection.ExecuteScalar<bool>("SELECT COUNT(ID) FROM Lab WHERE ID=@ID", new { @ID = id });

        connection.Close();
        return exists;
    }
}
