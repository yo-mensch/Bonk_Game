using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetection : MonoBehaviour
{
    public int score = 0;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        score = score + 400;
        Debug.Log("score: " + score);
    }
}
