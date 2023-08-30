using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool up, down, left, right, move;
    int direction;
    int UP = 0;
    int DOWN = 1;
    int LEFT = 2;
    int RIGHT = 3;
    Rigidbody2D rb;
    [SerializeField] float speed;
    public GameObject wallRayObject;
    bool gravitate;
    float verInput, horInput;
    Vector2 faceTowards;
    RaycastHit2D hitWall;
    List<string> keys;
    [SerializeField] List<AudioClip> audioClips;
     AudioSource audioSource;
    AudioClip clip;
    bool playWoosh;
    public ParticleSystem particles;
    public Vector2 startPosition;
    void Start()
    {
        direction = -1;
        keys = new List<string>();
        rb = GetComponent<Rigidbody2D>();
        move = true;
        audioSource= GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
      
    }
    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.W))
        {
            playWoosh = true;
            up = true;
        }
     if (Input.GetKeyDown(KeyCode.A)) {
            playWoosh = true;
            left = true;
    }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playWoosh = true;
            down = true;
             }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playWoosh = true;
                right = true;
            }
        if (Input.GetKeyUp(KeyCode.W))
            up = false;
        if (Input.GetKeyUp(KeyCode.A))
            left = false;
        if (Input.GetKeyUp(KeyCode.S))
            down = false;
        if (Input.GetKeyUp(KeyCode.D))
            right = false;
        // Debug.Log(hitWall.collider.name);

        if (playWoosh)
        {
            clip = audioClips[2];
            audioSource.clip = clip;
            audioSource.Play();
            playWoosh = false;
          //  particles.Play();
        }
    }
    private void FixedUpdate()
    {

        if (up) //player movement
        {
            Physics2D.gravity = new Vector2(0, 9.8f);

          faceTowards = Vector2.down;
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, faceTowards);
            hitWall = Physics2D.Raycast(wallRayObject.transform.position, Vector2.up);
            Debug.DrawRay(wallRayObject.transform.position, Vector2.up * hitWall.distance, Color.cyan);

        }
        if (down)
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
 faceTowards = Vector2.up;
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, faceTowards);
            hitWall = Physics2D.Raycast(wallRayObject.transform.position, -Vector2.up);
            Debug.DrawRay(wallRayObject.transform.position, -Vector2.up * hitWall.distance, Color.cyan);
        
 


        }
        if (left)
        {
            Physics2D.gravity = new Vector2(-9.8f,0);
 
     faceTowards = Vector2.right;
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, faceTowards);
            hitWall = Physics2D.Raycast(wallRayObject.transform.position, -Vector2.right);
            Debug.DrawRay(wallRayObject.transform.position, -Vector2.right * hitWall.distance, Color.cyan);
         
        }
        if (right)
        {
            Physics2D.gravity = new Vector2(9.8f, 0);
          faceTowards = Vector2.left;
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, faceTowards);
            hitWall = Physics2D.Raycast(wallRayObject.transform.position, Vector2.right);
            Debug.DrawRay(wallRayObject.transform.position, Vector2.right * hitWall.distance, Color.cyan);
           

        }
    
        /*if (gravitate)
        {
            GravityForce(faceTowards,direction);
            GetComponent < Transform>().position = new Vector3(xChange * Time.deltaTime, yChange * Time.deltaTime);
        }
        else
            gravitate = false;*/
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Beam")
        {
            Reset();
        }
        if (collision.gameObject.name == "ForceField0")
        {
            SceneManager.LoadScene("Lvl1");
            gameObject.transform.position = startPosition;
            gameObject.transform.position = new Vector2(-8.44f, -4.08f);


        }
        if (collision.gameObject.name == "ForceField1" && keys.Contains("Key1") )
        {
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            SceneManager.LoadScene("Lvl2");
            gameObject.transform.position = startPosition;
            keys.Remove("Key1");
        }
        if (collision.gameObject.name == "ForceField2" && keys.Contains("Key2"))
        {collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            keys.Remove("Key2");
        }
        if (collision.gameObject.name == "ForceField3" && keys.Contains("Key3"))
        {
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            SceneManager.LoadScene("Lvl3");
            gameObject.transform.position = startPosition;
            keys.Remove("Key3");
        }
        if (collision.gameObject.name == "ForceField4" && keys.Contains("Key4"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            keys.Remove("Key4");
        }
        if (collision.gameObject.name == "ForceField5" && keys.Contains("Key5"))
        {
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            SceneManager.LoadScene("Lvl4");
            gameObject.transform.position = startPosition;
            keys.Remove("Key5");
        }
        if (collision.gameObject.name == "ForceField6" && keys.Contains("Key6"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            keys.Remove("Key6");
            keys.Remove("Key6");
        }
        if (collision.gameObject.name == "ForceField7" && keys.Contains("Key7"))
        {
            clip = audioClips[3];
            audioSource.clip = clip;
            audioSource.Play();
            SceneManager.LoadScene("Lvl5");
            gameObject.transform.position = startPosition;
         gameObject.transform.position= new Vector2(-7.926f, 19.072f);

            keys.Remove("Key7");
        }
        if (collision.gameObject.tag == "Spike")
        {
            Reset();

        }

    }
    public void GravityForce(Vector2 faceTowards, int direction )
    {
        hitWall = Physics2D.Raycast(wallRayObject.transform.position, -faceTowards);

        if (hitWall.distance >= 0.2)
        {
            if(direction==DOWN)
                Physics2D.gravity = new Vector2(0, -9.8f);
            if (direction == UP)
                Physics2D.gravity = new Vector2(0, 9.8f);
            if(direction == LEFT)
                Physics2D.gravity = new Vector2(-9.8f,0);
            if (direction == RIGHT)
                Physics2D.gravity = new Vector2(9.8f,0);

        }


        ///  rb.velocity += -faceTowards * speed * Time.deltaTime;
        //  rb.AddForce(-faceTowards * speed * Time.deltaTime * 9f,0f);
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Key"))
        {
            Debug.Log("Hit Trigger");
            keys.Add(collision.gameObject.name);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
          collision.gameObject.GetComponent<AudioSource>().Play();
        }

    }
    public void SetStartPosition(Vector2 startPosition)
    {
        this.startPosition = startPosition;
       
    }
    public void Reset()
    {
        clip = audioClips[0];
        audioSource.clip = clip;
        audioSource.Play();
        gameObject.transform.position = startPosition;
        down = false;
        left = false;
        up = false;
        right = false;
        gravitate = false;
        faceTowards = Vector2.up;
        rb.velocity = Vector2.zero;


        rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, faceTowards);
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("Key").Length; x++)
        {
            GameObject k = GameObject.FindGameObjectsWithTag("Key")[x];
            k.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            k.gameObject.GetComponent<Collider2D>().enabled = true;
        }
        for (int x = 0; x < GameObject.FindGameObjectsWithTag("ForceField").Length; x++)
        {
            GameObject f = GameObject.FindGameObjectsWithTag("ForceField")[x];
            f.gameObject.GetComponent<Collider2D>().enabled = true;
            f.gameObject.GetComponent<SpriteRenderer>().enabled = true;

        }

        Physics2D.gravity = Vector2.zero;

        keys.Clear();
        gameObject.transform.position = startPosition;

    }
}
