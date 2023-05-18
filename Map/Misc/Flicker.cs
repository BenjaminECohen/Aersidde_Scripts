using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// class that handles the visual flicker of the UI
/// </summary>


public class Flicker : MonoBehaviour
{

    public float speed = 2f;
    public Image image;
    private float targetValue;
    float startValue;
    float t;

    bool done = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            targetValue = Random.Range(0f, 1f);
            startValue = image.color.a;
            done = false;
            t = 0;
        }
        else
        {
            t += Time.deltaTime * speed;
            if (t >= 1f)
            {
                t = 1f;
                done = true;
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(startValue, targetValue, t));
            
        }

    }
}
