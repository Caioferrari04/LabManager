using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

public class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM Computer;";

        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var ram = reader.GetString(1);
            var processor = reader.GetString(2);

            var computer = new Computer(id: id, ram: ram, processor: processor);
            computers.Add(computer);
        }

        connection.Close();

        return computers;
    }

    public void Save(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = $"INSERT INTO Computer VALUES($id, $ram, $processor)";

        command.Parameters.AddWithValue("$id", computer.ID);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();

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

        reader.Read();
        var ram = reader.GetString(1);
        var processor = reader.GetString(2);

        var computer = new Computer(id: id, ram: ram, processor: processor);

        connection.Close();

        return computer;
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
}