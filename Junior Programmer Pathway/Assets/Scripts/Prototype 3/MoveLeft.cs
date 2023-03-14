using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerCon playerConScript;
    private float leftBound = -15;

    private void Start()
    {
        playerConScript = GameObject.Find("Player").GetComponent<PlayerCon>();
    }

    void Update()
    {
        if(playerConScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
