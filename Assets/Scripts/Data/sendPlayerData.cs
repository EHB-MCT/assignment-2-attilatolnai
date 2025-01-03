using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class sendPlayerData : MonoBehaviour
{
    private DatabaseReference databaseReference;

    public gameManager gm;

    public void SubmitPlayerData(string playerName, int circleCount, int triangleCount, int starCount, float timeSpent, int totalPoints)
    {
        gameManager gm = FindObjectOfType<gameManager>();
        if (gm != null && gm.firebaseInitialized)
        {
            databaseReference = gm.databaseReference;
        }
        else
        {
            Debug.LogError("Firebase DatabaseReference is not initialized.");
            return;
        }

        string key = databaseReference.Child("scores").Push().Key;
        var entryData = new Dictionary<string, object>
        {
            { "playerName", playerName },
            { "circleCount", circleCount },
            { "triangleCount", triangleCount },
            { "starCount", starCount },
            { "timeSpent", timeSpent },
            { "totalPoints", totalPoints }
        };

        databaseReference.Child("scores").Child(key).SetValueAsync(entryData).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data submitted successfully!");
            }
            else
            {
                Debug.LogError($"Error submitting data: {task.Exception}");
            }
        });
    }
}
