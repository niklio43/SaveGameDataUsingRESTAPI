using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public int userID;
    public string username;
    public int score;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
