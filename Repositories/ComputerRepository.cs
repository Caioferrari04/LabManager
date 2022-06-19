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
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computers =  connection.Query<Computer>("SELECT * FROM Computer");

        connection.Close();
        return computers;
    }

    public void Save(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Computer VALUES(@ID, @Ram, @Processor);", computer);
        
        connection.Close();
    }

    public Computer GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM Computer WHERE ID=$id;";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();

        //if (reader.Read())
        //{
        var computer = readerToComputer(reader);

        connection.Close();

        return computer;
        //}

        //throw new ApplicationException("Não há computador com esse ID!");
    }
    public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();


        var command = connection.CreateCommand();

        command.CommandText = $"UPDATE Computer SET Ram=$Ram, Processor=$Processor WHERE ID=$ID;";
        command.Parameters.AddWithValue("$ID", computer.ID);
        command.Parameters.AddWithValue("$Ram", computer.Ram);
        command.Parameters.AddWithValue("$Processor", computer.Processor);

        command.ExecuteNonQuery();

        connection.Close();

        return computer;
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();


        var command = connection.CreateCommand();

        command.CommandText = $"DELETE FROM Computer WHERE ID=$ID;";
        command.Parameters.AddWithValue("$ID", id);

        command.ExecuteNonQuery();

        connection.Close();
    }

    private Computer readerToComputer(SqliteDataReader reader)
    {
        return new Computer(
            id: reader.GetInt32(0),
            ram: reader.GetString(1),
            processor: reader.GetString(2)
        ); ;
    }

    public bool ExistsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT COUNT(ID) FROM Computer WHERE ID=$ID";
        command.Parameters.AddWithValue("$ID", id);

        var reader = command.ExecuteReader();

        connection.Close();
        return reader.GetBoolean(0);
    }
}