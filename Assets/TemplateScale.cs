using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateScale : MonoBehaviour
{
    public GameObject scoreText, timerText,comboCounterText, gameOverPanel;
    SpriteRenderer spriteRenderer;
    public GameObject player,interstitial;
    public float randomX, randomY;
    public bool effect=false;

    public AudioClip comboSound;

    private AudioSource audioSource;

    public float timer;

    private float lastComboTime = 3;

    public int score = 0;
    public int comboCounter = 0;
    public int interstatil = 0;

    void Start()
    {
        PlayerPrefs.SetFloat("timer", 5);
        timer = PlayerPrefs.GetFloat("timer");

        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        randomX = UnityEngine.Random.Range(0.04f, 0.86f);
        randomY = UnityEngine.Random.Range(0.04f, 1.65f);
        transform.localScale = new Vector3(randomX, randomY, transform.localScale.z);
        scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        timerText.GetComponent<UnityEngine.UI.Text>().text = timer.ToString();

        gameOverPanel.SetActive(false);
    }

    
    void Update()
    {
        if (gameOverPanel.activeInHierarchy == false)
        {
            timer -= Time.deltaTime;

            timerText.GetComponent<UnityEngine.UI.Text>().text = Mathf.Round(timer).ToString();

            if (((player.transform.localScale.x > transform.localScale.x - 0.02f && player.transform.localScale.y > transform.localScale.y - 0.02f) &&
               (player.transform.localScale.x < transform.localScale.x + 0.01f && player.transform.localScale.y < transform.localScale.y + 0.01f)) ||
               ((-player.transform.localScale.x > transform.localScale.x - 0.02f && -player.transform.localScale.y > transform.localScale.y - 0.02f) &&
               (-player.transform.localScale.x < transform.localScale.x + 0.01f && -player.transform.localScale.y < transform.localScale.y + 0.01f)) ||
               ((-player.transform.localScale.x > transform.localScale.x - 0.02f && player.transform.localScale.y > transform.localScale.y - 0.02f) &&
               (-player.transform.localScale.x < transform.localScale.x + 0.01f && player.transform.localScale.y < transform.localScale.y + 0.01f)) ||
               ((player.transform.localScale.x > transform.localScale.x - 0.02f && -player.transform.localScale.y > transform.localScale.y - 0.02f) &&
               (player.transform.localScale.x < transform.localScale.x + 0.01f && -player.transform.localScale.y < transform.localScale.y + 0.01f)))
            {
                interstatil++;

                spriteRenderer.color = Color.green;
                randomX = UnityEngine.Random.Range(0.04f, 0.86f);
                randomY = UnityEngine.Random.Range(0.04f, 1.65f);
                transform.localScale = new Vector3(randomX, randomY, transform.localScale.z);
                player.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                spriteRenderer.color = Color.black;

                score += 1;
                scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
                
                if(lastComboTime<=timer)
                {
                    audioSource.PlayOneShot(comboSound);
                    comboCounter++;
                    score += comboCounter;
                    timer += 2f;
                    lastComboTime = timer - 2f;
                    comboCounterText.GetComponent<UnityEngine.UI.Text>().text = "x " + comboCounter.ToString();
                    scoreText.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
                }
                else
                {
                    lastComboTime = timer - 2f;
                    comboCounter = 0;
                    comboCounterText.GetComponent<UnityEngine.UI.Text>().text = " ";
                }

                //Combo counter.
                /*if (lastComboTime - timer <= 2 && lastComboTime - timer > 0)
                {
                    audioSource.PlayOneShot(comboSound);
                    comboCounter++;
                    timer += 3f;
                    lastComboTime = timer - 2;
                    comboCounterText.GetComponent<UnityEngine.UI.Text>().text = "x " + comboCounter.ToString();
                }
                else
                {
                    comboCounter = 0;
                    comboCounterText.GetComponent<UnityEngine.UI.Text>().text = "x " + comboCounter.ToString();
                }*/
            }
        }

        if (Mathf.Round(timer) <= 0)
        {
            
            if (score > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", score);
            }

            if (PlayerPrefs.GetInt("rewardedSay") == 0)
            {
                gameOverPanel.SetActive(true);
            }else if (PlayerPrefs.GetInt("rewardedSay") == 1)
            {
                timer = 5;
                gameOverPanel.SetActive(false);
                PlayerPrefs.SetInt("rewardedSay", 0);
            }

            
            if (interstatil >= 3)
            {
                GameObject.FindGameObjectWithTag("add").GetComponent<AddControl>().ShowAd();
                PlayerPrefs.SetInt("interstatil", 0);
            }
            else
            {
                PlayerPrefs.SetInt("interstatil", 0);
            }
            
        }
    }
}
