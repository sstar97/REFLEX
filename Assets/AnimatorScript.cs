using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimatorScript : MonoBehaviour
{
    public Sprite[] animatedImages;
    public Image animateImageObj;

    public GameObject scoreText;
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("score");
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        animateImageObj.sprite = animatedImages[(int)(Time.time * 10 %animatedImages.Length)];

        if(Input.touchCount > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
