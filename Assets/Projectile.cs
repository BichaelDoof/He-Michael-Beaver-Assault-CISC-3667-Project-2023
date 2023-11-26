using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    [SerializeField] const float SPEED = 0.01f;
    [SerializeField] Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("Projectile");
        }
        if (audio == null)
            audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1.0f)
        {
            transform.Translate(SPEED, 0, 0);
        }
        if(transform.position.x >= 11.75f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //controller.GetComponent<Scorekeeper>().AddPoints();
        if(collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Distract")
        {
            Destroy(gameObject);
        }
    }
}
