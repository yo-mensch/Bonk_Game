using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDetection : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreScript.ScoreValue += 100;
        Destroy(gameObject);
    }
}
