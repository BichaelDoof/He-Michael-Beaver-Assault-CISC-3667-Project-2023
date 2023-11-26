using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField] const float SPEED = 0.003f;
    [SerializeField] bool hitTop = false;
    [SerializeField] float top = 4.7f;
    [SerializeField] AudioSource audio;
    [SerializeField] Vector3 scaleChange;
    [SerializeField] const float maxSize = 1f;
    [SerializeField] GameObject scoreController;
    [SerializeField] int scoreValue = 10;
    [SerializeField] int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        difficulty = PersistentData.Instance.GetDifficulty();
        scaleChange = new Vector3((0.05f * difficulty), (0.05f * difficulty), 0);
        if (scoreController == null)
        {
            scoreController = GameObject.FindGameObjectWithTag("GameController");
        }
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
        InvokeRepeating("Enlarge", (5 - difficulty), (5 - difficulty));
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
        if(transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);
            scoreController.GetComponent<Score>().UpdateScore(scoreValue * difficulty);
        }
    }

    void Enlarge()
    {
        transform.localScale += scaleChange;
        top -= 0.1f;
        scoreValue -= (1 * difficulty);
        if(transform.localScale.x >= 0.25)
        {
            Destroy(gameObject);
        }
    }
}
