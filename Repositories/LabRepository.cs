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
        
        // var command = connection.CreateCommand();
        // command.CommandText = "SELECT * FROM Lab;";

        // var reader = command.ExecuteReader();
        // while (reader.Read())
        // {
        //     var lab = ReaderToLab(reader);
        //     labs.Add(lab);
        // }

        connection.Close();

        return labs;
    }

    public void Save(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Lab VALUES($id, $name, $block, $number);";

        command.Parameters.AddWithValue("$id", lab.ID);
        command.Parameters.AddWithValue("$name", lab.Name);
        command.Parameters.AddWithValue("$block", lab.Block);
        command.Parameters.AddWithValue("$number", lab.Number);

        command.ExecuteNonQuery();

        connection.Close();
    }

    public Lab GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab WHERE ID=$id;";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();

        //if (reader.Read())
        //{
        var lab = ReaderToLab(reader);

        connection.Close();

        return lab;
        //}

        //throw new ApplicationException("Não há laboratorio com esse ID!");
    }

    public Lab Update(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "UPDATE Lab SET Name=$Name, Block=$Block, Number=$Number WHERE ID=$ID;";
        command.Parameters.AddWithValue("$ID", lab.ID);
        command.Parameters.AddWithValue("$Name", lab.Name);
        command.Parameters.AddWithValue("$Block", lab.Block);
        command.Parameters.AddWithValue("$Number", lab.Number);

        command.ExecuteNonQuery();

        connection.Close();

        return lab;
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "DELETE FROM Lab WHERE ID=$ID;";
        command.Parameters.AddWithValue("$ID", id);

        command.ExecuteNonQuery();

        connection.Close();
    }

    private Lab ReaderToLab(SqliteDataReader reader)
    {
        return new Lab(
            id: reader.GetInt32(0),
            name: reader.GetString(1),
            block: reader.GetString(2),
            number: reader.GetInt32(3)
        );
    }

    public bool ExistsById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "SELECT COUNT(ID) FROM Lab WHERE ID=$ID";
        command.Parameters.AddWithValue("$ID", id);

        // var reader = command.ExecuteReader();
        
        // var resultado = reader.GetBoolean(0);

        var resultado = Convert.ToBoolean(command.ExecuteScalar());
        
        connection.Close();
        return resultado;
    }
}
