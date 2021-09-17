using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public SpriteRenderer BG;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = BG.bounds.size.x / BG.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = BG.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = BG.bounds.size.y / 2 * differenceInSize;
        }
    }

    
}
