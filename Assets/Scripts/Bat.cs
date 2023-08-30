using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] float startXPosition;
    [SerializeField] float startYPosition;
    GameObject player;
    private Vector2 movement;
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float maxY;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameObject.transform.position =  new Vector2( startXPosition,startYPosition);
    }

    // Update is called once per frame
    void Update()
    {
         direction = player.transform.position - transform.position;
       direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveTowards(direction);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.transform.position = new Vector2(startXPosition, startYPosition);

        }
    }
    void MoveTowards(Vector2 direction)
    {
        if(gameObject.transform.position.y < maxY )
       gameObject.transform.position = ((Vector2)transform.position + (direction*speed*Time.deltaTime));

    }
}
