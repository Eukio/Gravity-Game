using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour
{
    private GameObject player;
    private Vector2 rel;
    private Vector2 newPos;
    [SerializeField] float screenPosLeft;
    [SerializeField] float screenPosRight;
    [SerializeField] float screenPosDown;
    [SerializeField] float screenPosUp;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        newPos = Vector2.SmoothDamp(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y), ref rel, .5f);
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= screenPosLeft)
        {
            newPos = Vector2.SmoothDamp(new Vector2(screenPosLeft, transform.position.y), new Vector2(screenPosLeft, player.transform.position.y), ref rel, .5f);

            transform.position = new Vector3(screenPosLeft, newPos.y, transform.position.z);
        }
        if (transform.position.x >= screenPosRight)
        {
            newPos = Vector2.SmoothDamp(new Vector2(screenPosRight, transform.position.y), new Vector2(screenPosRight, player.transform.position.y), ref rel, .5f);

            transform.position = new Vector3(screenPosRight, newPos.y, transform.position.z);
        }
        if (transform.position.y >= screenPosUp)
        {
            newPos = Vector2.SmoothDamp(new Vector2(transform.position.x, screenPosUp), new Vector2(transform.position.x, screenPosUp), ref rel, .5f);

            transform.position = new Vector3(newPos.x, screenPosUp, transform.position.z);
        }
        if (transform.position.y <= screenPosDown)
        {
            newPos = Vector2.SmoothDamp(new Vector2(transform.position.x, screenPosDown), new Vector2(transform.position.x, screenPosDown), ref rel, .5f);

            transform.position = new Vector3(newPos.x, screenPosDown, transform.position.z);
        }
        if (transform.position.x >= screenPosLeft && transform.position.x <= screenPosRight && transform.position.y <= screenPosUp && transform.position.y >= screenPosDown)
        {
            newPos = Vector2.SmoothDamp(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y), ref rel, .5f);
            // transform.position = player.transform.position + new Vector3(0, 1, -5);
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }
}
