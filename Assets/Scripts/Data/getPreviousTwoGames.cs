using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using TMPro;

public class getPreviousTwoGames : MonoBehaviour
{
    public TextMeshProUGUI previousPlayerDataText;
    private DatabaseReference databaseReference;   
    public gameManager gm;

    public void FetchPreviousTwoGames(string playerName)
    {
        gm = FindObjectOfType<gameManager>();
        if (gm != null && gm.firebaseInitialized)
        {
            databaseReference = gm.databaseReference;
        }
        else
        {
            Debug.LogError("Firebase DatabaseReference is not initialized in gameManager!");
            return;
        }

        if (databaseReference == null)
        {
            Debug.LogError("Firebase database reference is not initialized!");
            return;
        }

        databaseReference.Child("scores").OrderByChild("playerName").EqualTo(playerName).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error fetching data: " + task.Exception);
                previousPlayerDataText.text = "Error fetching data.";
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    string stats = playerName + "'s previous 2 runs:\n";
                    List<(string playerNameFromDB, string circles, string triangles, string stars, string timeSpent, string totalPoints, string timestamp)> games = new List<(string, string, string, string, string, string, string)>();

                    foreach (var child in snapshot.Children)
                    {
                        string playerNameFromDB = child.Child("playerName").Value?.ToString();
                        string circles = child.Child("circleCount").Value?.ToString();
                        string triangles = child.Child("triangleCount").Value?.ToString();
                        string stars = child.Child("starCount").Value?.ToString();
                        string timeSpent = child.Child("timeSpent").Value?.ToString();
                        string totalPoints = child.Child("totalPoints").Value?.ToString();
                        string timestamp = child.Child("timestamp").Value?.ToString();

                        if (!string.IsNullOrEmpty(circles) && !string.IsNullOrEmpty(triangles) &&
                            !string.IsNullOrEmpty(stars) && !string.IsNullOrEmpty(timeSpent) &&
                            !string.IsNullOrEmpty(totalPoints) && !string.IsNullOrEmpty(timestamp))
                        {
                            games.Add((playerNameFromDB,
                                circles,
                                triangles,
                                stars,
                                timeSpent,
                                totalPoints,
                                timestamp));
                        }
                    }

                    // Sort the games by timestamp (descending)
                    games.Sort((a, b) =>
                    {
                        long timeA = long.Parse(a.timestamp);
                        long timeB = long.Parse(b.timestamp);
                        return timeB.CompareTo(timeA); // Descending order
                    });

                    // Process the last two games
                    int count = Mathf.Min(2, games.Count);
                    string prevStats = $"{playerName}'s previous {count} Games:\n";
                    for (int i = 0; i < count; i++)
                    {
                        var game = games[i];
                        string circles = game.circles;
                        string triangles = game.triangles;
                        string stars = game.stars;
                        string timeSpent = game.timeSpent;
                        string totalPoints = game.totalPoints;

                        string circlesSymbol = "";
                        string trianglesSymbol = "";
                        string starsSymbol = "";

                        string scoreColor = "white"; // Default color
                        if (i == 0 && count > 1) // Compare with the previous game (not the first one)
                        {
                            int currentPoints = int.Parse(totalPoints);
                            int prevPoints = int.Parse(games[i + 1].totalPoints);

                            if (currentPoints > prevPoints)
                            {
                                scoreColor = "green"; // If higher
                            }
                            else if (currentPoints < prevPoints)
                            {
                                scoreColor = "red"; // If lower
                            }

                            // Circles comparison
                            int currentCircles = int.Parse(circles);
                            int prevCircles = int.Parse(games[i + 1].circles);
                            circlesSymbol = (currentCircles > prevCircles) ? " + " : (currentCircles < prevCircles) ? " - " : "";

                            // Triangles comparison
                            int currentTriangles = int.Parse(triangles);
                            int prevTriangles = int.Parse(games[i + 1].triangles);
                            trianglesSymbol = (currentTriangles > prevTriangles) ? " + " : (currentTriangles < prevTriangles) ? " - " : "";

                            // Stars comparison
                            int currentStars = int.Parse(stars);
                            int prevStars = int.Parse(games[i + 1].stars);
                            starsSymbol = (currentStars > prevStars) ? " + " : (currentStars < prevStars) ? " - " : "";
                        }

                        // Apply color to the totalPoints field using rich text
                        string gameLabel = (i == 0) ? "current game" : "previous game";
                        prevStats += $"\n" +
                                    $"{playerName}'s {gameLabel}:\n" +
                                    $"Circles: {circles}    {circlesSymbol}\n" +
                                    $"Triangles: {triangles}    {trianglesSymbol}\n" +
                                    $"Stars: {stars}    {starsSymbol} \n" +
                                    $"Time: {timeSpent}\n" +
                                    $"<color={scoreColor}>Points: {totalPoints}</color>\n";
                    }

                    Debug.Log("Stats: " + prevStats);
                    previousPlayerDataText.text = prevStats;
                }
                else
                {
                    Debug.LogWarning("No data found in Firebase.");
                    previousPlayerDataText.text = "No previous games found.";
                }
            }
        });
    }
}
