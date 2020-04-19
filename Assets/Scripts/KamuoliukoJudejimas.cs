using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KamuoliukoJudejimas : MonoBehaviour
{
    public float greitis = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool lieciaGrindis;
    public Vector3 respawnPoint;
    private Scene CurrentScene;
    private CoinDetection aku;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        CurrentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        lieciaGrindis = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal"); //[-1;1] reiksmiu intervalas, -1 kai judama kairen, 1 kai desinen
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * greitis, rigidBody.velocity.y);
        }
        else if (movement < 0)
        {
            rigidBody.velocity = new Vector2(movement * greitis, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump")&&lieciaGrindis==true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector" || other.tag == "spike")
        {
            //transform.position = respawnPoint;
            SceneManager.LoadScene(CurrentScene.name);
        }
        else if(other.tag == "Finish")
        {
           if(CurrentScene.name == "1lygis")
            {
                SceneManager.LoadScene("2lygis");
            }
           else if(CurrentScene.name == "2lygis")
            {
                SceneManager.LoadScene("3lygis");
            }
           else if(CurrentScene.name == "3lygis")
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
