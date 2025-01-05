using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using TMPro;

public class compareToHighscore : MonoBehaviour
{
    //previousPlayerDataText
    public TextMeshProUGUI compareHighscore;
    public TextMeshProUGUI motivationalMessage;
    private DatabaseReference databaseReference;
    public gameManager gm;

    // This function will compare the latest game to the highest-scoring game
    public void CompareToHighscore(string playerName)
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
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    List<(string playerName, string circles, string triangles, string stars, string timeSpent, string totalPoints, string timestamp)> games = new List<(string, string, string, string, string, string, string)>();

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
                            games.Add((playerNameFromDB, circles, triangles, stars, timeSpent, totalPoints, timestamp));
                        }
                    }

                    if (games.Count < 2)
                    {
                        motivationalMessage.text = "Play 2 games to see your highscore comparison!";
                        return;
                    }

                    // Sort the games by timestamp (descending) to get the latest game
                    games.Sort((a, b) =>
                    {
                        long timeA = long.Parse(a.timestamp);
                        long timeB = long.Parse(b.timestamp);
                        return timeB.CompareTo(timeA); // Descending order
                    });

                    // Find the game with the highest score
                    var highestScoringGame = games.OrderByDescending(game => int.Parse(game.totalPoints)).FirstOrDefault();

                    // Get the most recent game (the first one in the sorted list)
                    var latestGame = games.FirstOrDefault();

                    if (!string.IsNullOrEmpty(latestGame.totalPoints) && !string.IsNullOrEmpty(highestScoringGame.totalPoints))
                    {
                        string stats = $"{playerName}'s Latest Game vs Highest Scoring Game:\n";

                        // Compare the two games
                        stats += CompareGames(latestGame, highestScoringGame);

                        // Display the comparison result in the UI
                        compareHighscore.text = stats;
                    }
                    else
                    {
                        compareHighscore.text = "No data available for comparison.";
                    }
                }
                else
                {
                    compareHighscore.text = "No previous games found.";
                }
            }
        });
    }

    // Helper method to compare two games
    private string CompareGames((string playerName, string circles, string triangles, string stars, string timeSpent, string totalPoints, string timestamp) latestGame,
                                (string playerName, string circles, string triangles, string stars, string timeSpent, string totalPoints, string timestamp) highestScoringGame)
    {
        string comparisonResult = "";
        string motivation = "";

        // Check if both games have valid data before proceeding
        if (!string.IsNullOrEmpty(latestGame.totalPoints) && !string.IsNullOrEmpty(highestScoringGame.totalPoints))
        {
            // Compare Circles
            int latestCircles = int.Parse(latestGame.circles);
            int highestCircles = int.Parse(highestScoringGame.circles);
            comparisonResult += $"Circles: {latestCircles} vs {highestCircles}";

            // Compare Triangles
            int latestTriangles = int.Parse(latestGame.triangles);
            int highestTriangles = int.Parse(highestScoringGame.triangles);
            comparisonResult += $"\nTriangles: {latestTriangles} vs {highestTriangles}";

            // Compare Stars
            int latestStars = int.Parse(latestGame.stars);
            int highestStars = int.Parse(highestScoringGame.stars);
            comparisonResult += $"\nStars: {latestStars} vs {highestStars}";

            // Compare Total Points
            int latestPoints = int.Parse(latestGame.totalPoints);
            int highestPoints = int.Parse(highestScoringGame.totalPoints);
            comparisonResult += $"\nTotal Points: {latestPoints} vs {highestPoints}";
            
            int latestScore = int.Parse(latestGame.totalPoints);
            int highscore = int.Parse(highestScoringGame.totalPoints);
            
            if (latestScore < highscore)
            {
                motivation += "\nYou can do better! Keep trying!";
            }
            else if (latestScore > highscore)
            {
                motivation += "\nYou did it! Try to get an even higher score now!";
            }
            motivationalMessage.text = motivation;

        }
        else
        {
            comparisonResult = "One or both games have invalid data.";
        }

        return comparisonResult;
    }
}
