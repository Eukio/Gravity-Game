using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    //timer, has player, keys, sounds
    [SerializeField] Player player;
    [SerializeField] Canvas canvas;
    [SerializeField] Text text;
    bool run;
    long startTime;
    long elapsed;
    void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(text);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(player);

        Scene activeScene = SceneManager.GetActiveScene();

         
        text.text = "";
        RestartTime();
        run = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            
            elapsed = (DateTime.Now.Ticks - startTime) / 10000;
          
            text.text =(elapsed/1000f).ToString();
        }
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene.name == "Lvl0")
        {
            player.SetStartPosition(new Vector2(-7.926f, 19.072f));
        }
        if (activeScene.name == "Lvl1") {
            player.SetStartPosition(new Vector2(-8.44f, -4.08f));

        }
        if (activeScene.name == "Lvl2")
        {
            player.SetStartPosition(new Vector2(-10.5f, -4.08f));

        }
        if (activeScene.name == "Lvl3")
        {
            player.SetStartPosition(new Vector2(-7.27f, 5.8f));
        }
        if (activeScene.name == "Lvl4")
        {
            player.SetStartPosition(new Vector2(-11.46f, 15.41f));
        }
        if (activeScene.name == "Lvl5")
        {
            run = false;
            player.SetStartPosition(new Vector2(-9.72f, 6.327235f));
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Lvl0");
            player.SetStartPosition(new Vector2(-7.926f, 19.072f));
            player.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Lvl1");
            player.SetStartPosition(new Vector2(-8.44f, -4.08f));
            player.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Lvl2");
            player.SetStartPosition(new Vector2(-10.5f, -4.08f));
            player.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Lvl3");
            player.SetStartPosition(new Vector2(-7.27f, 5.8f));
            player.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Lvl4");
            player.SetStartPosition(new Vector2(-7.67f, 16.71f));
            player.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Lvl5");
            player.SetStartPosition(new Vector2(-9.72f, 6.327235f));

            player.Reset();
            run = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && activeScene.name == "Lvl5")
        {
            RestartTime();
            run = true;
            text.text = "";
            SceneManager.LoadScene("Lvl0");
            Awake();

            player.Reset();
            player.SetStartPosition(new Vector2(-7.926f, 19.072f));
            player.transform.position = new Vector2(-7.926f, 19.072f);
        }
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        canvas.worldCamera = cam;

    }
    private void Awake()
    {
       if (GameObject.FindGameObjectsWithTag("Game").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Game")[1]);
       if (GameObject.FindGameObjectsWithTag("Text").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Text")[1]);
        if (GameObject.FindGameObjectsWithTag("Canvas").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Canvas")[1]);
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
            Destroy(GameObject.FindGameObjectsWithTag("Player")[1]);
    }

    void RestartTime()
    {
        startTime = DateTime.Now.Ticks;
        elapsed = 0;

    }

}
