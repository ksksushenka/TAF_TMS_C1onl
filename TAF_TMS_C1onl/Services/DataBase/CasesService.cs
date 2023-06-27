using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NLog;
using Npgsql;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services.DataBases;

public class CasesService
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly NpgsqlConnection _connection;

    public CasesService(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public void CreateTable()
    {
        var sqlQuery = "CREATE TABLE customers (" +
                       "id SERIAL PRIMARY KEY, " +
                       "section_id INTEGER, " +
                       "title CHARACTER VARYING(255), " +
                       ");";

        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        cmd.ExecuteNonQuery();
    }

    public void DropTable()
    {
        var sqlQuery = "drop table if exists cases;";

        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        cmd.ExecuteNonQuery();
    }

    public List<Case> GetAllCases()
    {
        var sqlQuery = "SELECT * FROM customers;";
        var actualList = new List<Case>();

        // Retrieve all rows
        using var cmd = new NpgsqlCommand(sqlQuery, _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var testCase = new Case()
            {
                SectionId = reader.GetInt32(0),
                Title = reader.GetString(reader.GetOrdinal("firstname"))
            };

            _logger.Info(testCase.ToString);
            actualList.Add(testCase);
        }

        return actualList;
    }

    public int AddCase(Case testCase)
    {
        var sqlQuery = "insert into cases (sectionId, title) VALUES ($1, $2);";

        using var cmd = new NpgsqlCommand(sqlQuery, _connection)
        {
            Parameters =
            {
                new() { Value = testCase.SectionId },
                new() { Value = testCase.Title }
            }
        };

        return cmd.ExecuteNonQuery();
    }

    public int DeleteCustomer(string sectionId)
    {
        var sqlQuery = "delete from customers WHERE sectionId = $1;";

        using var cmd = new NpgsqlCommand(sqlQuery, _connection)
        {
            Parameters =
            {
                new() { Value =  sectionId}
            }
        };

        return cmd.ExecuteNonQuery();
    }
}