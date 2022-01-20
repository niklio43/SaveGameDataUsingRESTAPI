using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore;

    private UserData userData;

    void Start()
    {
        userData = GameObject.FindGameObjectWithTag("UserData").GetComponent<UserData>();
        currentScore = userData.score;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "Score: "+currentScore;
    }
}
