using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class SaveScore
{
    public int userID, score;
    public SaveScore(int userIDDATA, int scoreDATA)
    {
        userID = userIDDATA;
        score = scoreDATA;
    }
}

public class Save : MonoBehaviour
{

    private Score score;
    private UserData userData;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        userData = GameObject.FindGameObjectWithTag("UserData").GetComponent<UserData>();
    }

    public void SaveExit()
    {
        SaveScore saveScore = new SaveScore(userData.userID, score.currentScore);

        string values = JsonConvert.SerializeObject(saveScore);
        Debug.Log(values);

        StartCoroutine(PostData("http://localhost/unityRestAPItest/api/score/create_score.php", values));
    }

    IEnumerator PostData(string url, string json)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
