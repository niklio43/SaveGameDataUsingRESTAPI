using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 mousePos;
    private Score score;

    public GameObject point;

    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        InvokeRepeating("InstantiatePoint", 1f, 1f);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector3.Lerp(transform.position, mousePos, 10 * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            score.currentScore++;
            Destroy(collision.gameObject);
        }
    }

    void InstantiatePoint()
    {

        int randomPos = Random.Range(-8, 8);

        Vector3 pos = new Vector3(randomPos, 4, 0);

        Instantiate(point, pos, Quaternion.identity);
    }
}
