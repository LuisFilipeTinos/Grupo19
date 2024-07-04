using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using System.Threading;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.SceneManagement;

//A Fazer

//Botão de jogar novamente
//Botão de sair
//Botão de creditos

//Layout e estiliziação da tela
public class DB : MonoBehaviour
{
    [SerializeField] TMP_InputField DBInputName;
    [SerializeField] TMP_InputField DBInputPoints;
    
    [SerializeField] TextMeshProUGUI textDisplayName;
    [SerializeField] TextMeshProUGUI textDisplayPoints;

    [SerializeField] TextMeshProUGUI PlayerDisplayPoints;
    [SerializeField] TextMeshProUGUI PlayerDisplayName;

    private string dbName = "Data Source=file:scoreboard.db";

    // Start is called before the first frame update
    void Start()
    {
        CreateDb();
        DisplayDB();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDb(){
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS scoreboard (name VARCHAR(60), points SMALLINT)";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void DisplayDB()
    {
        textDisplayName.text = "";
        textDisplayPoints.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM scoreboard ORDER by points DESC";   

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textDisplayName.text += reader["name"] + "\n";
                        textDisplayPoints.text += reader["points"] + "\n";
                    }

                    reader.Close();
                }
            }

            connection.Close();
        }
    }

    public void InsertDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO scoreboard (name, points) VALUES ('" + DBInputName.text + "', '" + DBInputPoints.text + "')";
                command.ExecuteNonQuery();
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(0);
    }
}
