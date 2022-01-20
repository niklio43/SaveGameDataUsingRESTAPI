using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class RegData
{
    public string username, password;
    public RegData(string usernameData, string passwordData)
    {
        username = usernameData;
        password = passwordData;
    }
}

public class Register : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;

    private static readonly HttpClient client = new HttpClient();

    public void RegisterUser()
    {
        RegData regdata = new RegData(usernameField.text, passwordField.text);

        string values = JsonConvert.SerializeObject(regdata);
        Debug.Log(values);

        StartCoroutine(PostData("http://localhost/unityRestAPItest/api/user/create_user.php", values));
    }

    IEnumerator PostData(string url, string json)
    {

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
            SceneManager.LoadScene("Login");
        }
    }

}