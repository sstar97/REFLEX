using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToScale : MonoBehaviour
{
    private Touch touch;
    private float speedMod;
    public GameObject gameOverPanel;

    private void Start()
    {
        speedMod = 0.002f;
    }

    void Update()
    {
        if (gameOverPanel.activeInHierarchy == false)
        {

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.localScale = new Vector3(
                        transform.localScale.x + touch.deltaPosition.x * speedMod,
                        transform.localScale.y + touch.deltaPosition.y * speedMod,
                        transform.localScale.z);
                }

                /*if (transform.localScale.x <= 0.03f &&
                transform.localScale.y <= 0.03f)
                {
                    transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                }
                if (transform.localScale.x > 1)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.x);
                }
                if (transform.localScale.y > 1.7f)
                {
                    transform.localScale = new Vector3(transform.localScale.x, 1.7f, transform.localScale.x);
                }*/
            }
        }
    }
}
