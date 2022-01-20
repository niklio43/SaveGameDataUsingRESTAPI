using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine.Networking;

class ParseJson
{
    public int userID;
    public string username;
    public string password;
}

class ParseJsonScore
{
    public int userID;
    public int scoreID;
    public int score;
}

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    public GameObject UserData;

    private static readonly HttpClient client = new HttpClient();

    public void Auth()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        string[] userData = new string[] { username, password };

        StartCoroutine(GetUserData("http://localhost/unityRestAPItest/api/user/read_single_user.php?username="+username+"&password="+password, userData));
    }


    IEnumerator GetUserData(string url, string[] userData)
    {
        var request = new UnityWebRequest(url, "GET");

        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        string response = request.downloadHandler.text;

        ParseJson parseJson = JsonUtility.FromJson<ParseJson>(response);

        UserData.GetComponent<UserData>().userID = parseJson.userID;

        UserData.GetComponent<UserData>().username = parseJson.username;

        if (userData[0] == parseJson.username && userData[1] == parseJson.password)
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
            StartCoroutine(GetUserScore("http://localhost/unityRestAPItest/api/score/read_single_score.php?userID=" + parseJson.userID));
        }
        else
        {
            Debug.Log("Erro: " + request.error);
        }
    }

    IEnumerator GetUserScore(string url)
    {
        var request = new UnityWebRequest(url, "GET");

        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        string response = request.downloadHandler.text;

        ParseJsonScore parseJsonScore = JsonUtility.FromJson<ParseJsonScore>(response);

        UserData.GetComponent<UserData>().score = parseJsonScore.score;

        SceneManager.LoadScene("Game");
    }


    public void Register()
    {
        SceneManager.LoadScene("Register");
    }
}
