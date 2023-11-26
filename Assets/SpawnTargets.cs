using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTargets : MonoBehaviour
{
    const int NUM_TARGET = 5;
    const int NUM_DISTRACT = 1;
    [SerializeField] GameObject target;
    [SerializeField] GameObject distracter;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        Spawn(NUM_TARGET * level);
        SpawnDistracter(NUM_DISTRACT * level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(int targets)
    {
        float xMin = -6f;
        float xMax = 9.5f;
        float yMin = -3.8f;
        float yMax = 3.8f;

        for (int i = 0; i < targets; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(target, position, Quaternion.identity);
        }
    }
    void SpawnDistracter(int targets)
    {
        float xMin = -4f;
        float xMax = 7.8f;
        float yMin = -3.8f;
        float yMax = 3.8f;

        for (int i = 0; i < targets; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(distracter, position, Quaternion.identity);
        }
    }
}
