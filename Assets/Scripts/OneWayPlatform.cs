using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour //ac
{
    // Start is called before the first frame update
    [SerializeField] GameObject BlockPlatform;
    [SerializeField] GameObject RayObject;
    [SerializeField] string direction;
    float initalDistance;
    RaycastHit2D hitWall;
   

        void Start()
    {
        DrawRay();
        StartCoroutine(WaitForRay());
    }

    // Update is called once per frame
    void Update()
    {
        DrawRay();
        if(hitWall.distance < initalDistance)
        {
            BlockPlatform.GetComponent<Collider2D>().enabled = true;
            Debug.Log("Pass Ray");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        DrawRay();
        if (collision.gameObject.name == "Player")
        {
            BlockPlatform.GetComponent<Collider2D>().enabled = false;
            Debug.Log("move through");
        }
    }
    IEnumerator WaitForRay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(1);
        initalDistance = hitWall.distance;
        // Log a message to the console
    }
    public void DrawRay()
    {
        if (direction.CompareTo("UP") == 0)
        {
            hitWall = Physics2D.Raycast(RayObject.transform.position, Vector2.up);
            Debug.DrawRay(RayObject.transform.position, Vector2.up * hitWall.distance, Color.red);
        }

        if (direction.CompareTo("LEFT") == 0) {
            hitWall = Physics2D.Raycast(RayObject.transform.position, -Vector2.right);
            Debug.DrawRay(RayObject.transform.position, -Vector2.right * hitWall.distance, Color.red);
        }
        if (direction.CompareTo("DOWN") == 0) {
            hitWall = Physics2D.Raycast(RayObject.transform.position, -Vector2.up);
            Debug.DrawRay(RayObject.transform.position, -Vector2.up * hitWall.distance, Color.red);
        }

        if (direction.CompareTo("RIGHT") == 0) { 
        hitWall = Physics2D.Raycast(RayObject.transform.position, Vector2.right);
        Debug.DrawRay(RayObject.transform.position, Vector2.right * hitWall.distance, Color.red); }

    }
}
