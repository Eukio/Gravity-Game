using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject beam;
    [SerializeField] GameObject charged;
    [SerializeField] double time;


    long startTime;
    long elapsed;

    void Start()
    {
        RestartTime();
        charged.GetComponent<SpriteRenderer>().enabled = false;

    }
    // Update is called once per frame
    void Update()
        {

            elapsed = (DateTime.Now.Ticks - startTime) / 10000;
            if (elapsed >= time)
            {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            charged.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(FireLaser());
            }

        }

        void RestartTime()
        {
            startTime = DateTime.Now.Ticks;
            elapsed = 0;

    }
    IEnumerator FireLaser()
        {
      //  Debug.Log("Start");
            yield return new WaitForSeconds(3f);
            beam.SetActive(true);
            yield return new WaitForSeconds(4f);
            beam.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        charged.GetComponent<SpriteRenderer>().enabled = false;
        RestartTime();
    }
    }
