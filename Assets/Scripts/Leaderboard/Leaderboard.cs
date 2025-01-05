using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI topPlayersDataText;
    private DatabaseReference databaseReference;

    public void Initialize(DatabaseReference dbReference)
    {
        databaseReference = dbReference;
    }

    public void FetchTopPlayers()
    {
        if (databaseReference == null)
        {
            Debug.LogError("Firebase database reference is not initialized!");
            return;
        }

        databaseReference.Child("scores").OrderByChild("totalPoints").LimitToLast(10).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error fetching data: " + task.Exception);
                if (topPlayersDataText != null)
                    topPlayersDataText.text = "Error fetching data.";
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                if (snapshot.Exists)
                {
                    List<KeyValuePair<string, int>> topPlayers = new List<KeyValuePair<string, int>>();

                    foreach (var child in snapshot.Children)
                    {
                        string playerName = child.Child("playerName").Value?.ToString();
                        int totalPoints = int.Parse(child.Child("totalPoints").Value?.ToString() ?? "0");

                        if (!string.IsNullOrEmpty(playerName))
                        {
                            topPlayers.Add(new KeyValuePair<string, int>(playerName, totalPoints));
                        }
                    }

                    topPlayers.Sort((x, y) => y.Value.CompareTo(x.Value));

                    if (topPlayersDataText != null)
                    {
                        topPlayersDataText.text = "Top 10 Players:\n";
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            topPlayersDataText.text += $"{i + 1}. {topPlayers[i].Key} - {topPlayers[i].Value} Points\n";
                        }
                    }
                }
                else
                {
                    if (topPlayersDataText != null)
                        topPlayersDataText.text = "No player data found.";
                }
            }
        });
    }
}