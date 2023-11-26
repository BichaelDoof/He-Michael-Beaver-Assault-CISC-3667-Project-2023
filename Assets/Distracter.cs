using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Distracter : MonoBehaviour
{
    [SerializeField] const float SPEED = 0.003f;
    [SerializeField] bool hitTop = false;
    [SerializeField] float top = 4.7f;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitTop)
        {
            if(Time.timeScale == 1.0f)
            {
                transform.Translate(0, SPEED, 0);
            }
            if(transform.position.y >= top)
            {
                hitTop = true;
            }
        }
        if(hitTop)
        {
            if(Time.timeScale == 1.0f)
            {
                transform.Translate(0, -SPEED, 0);
            }
            if(transform.position.y <= -top)
            {
                hitTop = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
        }
    }

}
