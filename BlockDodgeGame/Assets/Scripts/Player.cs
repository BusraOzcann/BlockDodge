using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 15f;
    public float mapWidth = 5f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + (Vector2.right * x);

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth); // newposition degerini iki sınır arasında sınırlandırdı.

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().EndGame();
        Debug.Log("we hit");
    }

    

}
