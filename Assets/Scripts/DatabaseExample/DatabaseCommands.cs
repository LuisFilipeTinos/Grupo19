using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class DatabaseCommands : MonoBehaviour
{
    string query;
    string connString;
    public string databaseName { get; private set; } = "/teste_grupo_19.s3db";

    async Task Awake()
    {
        await CreatePlayersTable();
    }

    public DatabaseConnection NewConnection()
    {
        string filePath = Application.dataPath + databaseName;
        connString = "URI=file:" + filePath;
        return new DatabaseConnection(connString);
    }
    public async Task CreatePlayersTable()
    {
        try
        {
            await Awaitable.BackgroundThreadAsync();

            using (var connection = NewConnection())
            {
                await connection.ConnectAsync();
                DbCommand dbCmd = connection.con.CreateCommand();

                query = "CREATE TABLE IF NOT EXISTS [player] (" +
                    "[id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "[name] VARCHAR(255) NOT NULL)";

                dbCmd.CommandText = query;
                await dbCmd.ExecuteScalarAsync();

                await connection.DisconnectAsync();
            }
            
            await Awaitable.MainThreadAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task CreatePlayer(string name)
    {
        try
        {
            await Awaitable.BackgroundThreadAsync();

            using (var connection = NewConnection())
            {
                await connection.ConnectAsync();
                DbCommand dbCmd = connection.con.CreateCommand();

                query = $"INSERT INTO player ('name') VALUES (@name)";

                dbCmd.Parameters.Add(new SqliteParameter("@name", name));

                dbCmd.CommandText = query;
                await dbCmd.ExecuteScalarAsync();

                await connection.DisconnectAsync();
            }
            
            await Awaitable.MainThreadAsync();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<List<Player>> GetAllPlayers()
    {
        try
        {
            await Awaitable.BackgroundThreadAsync();
            var playersList = new List<Player>();

            using (var connection = NewConnection())
            {
                await connection.ConnectAsync();
                DbCommand dbCommand = connection.con.CreateCommand();

                query = "SELECT id, name FROM player ORDER BY name";

                dbCommand.CommandText = query;

                using (IDataReader reader = await dbCommand.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var playerId = Convert.ToInt32(reader["id"]);
                        var playernName = Convert.ToString(reader["name"]);
                        playersList.Add(new Player(playerId, playernName));
                    }

                    reader.Close();
                }

                await connection.DisconnectAsync();
            }

            await Awaitable.MainThreadAsync();
            return playersList;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
