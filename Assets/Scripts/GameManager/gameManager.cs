using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class gameManager : MonoBehaviour
{
    
    private Firebase.FirebaseApp app;
    private DatabaseReference databaseReference;

    void Start()
    {
        InitializeFirebase();
    }

    private void InitializeFirebase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("Firebase initialized successfully!");

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void SubmitPlayerData(string playerName, int circleCount, float timeSpent)
    {
        if(databaseReference == null)
        {
            Debug.LogError("Firebase not initialized");
            return;
        }

        string key = databaseReference.Child("scores").Push().Key;
        var entryData = new Dictionary<string, object>
        {
            { "playerName", playerName },
            { "circleCount", circleCount },
            { "timeSpent", timeSpent }
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

