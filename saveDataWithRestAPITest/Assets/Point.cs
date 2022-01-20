using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
