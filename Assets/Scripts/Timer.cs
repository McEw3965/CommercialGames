using System.Collections;
using TMPro;
using UnityEngine;

//https://www.youtube.com/watch?v=hxpUk0qiRGs&ab_channel=TheGameGuy
public class Timer : MonoBehaviour
{
    public bool timerOn = false;
    public float timeleft = 60;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] private GameObject Explosions;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private CameraShake camerashake;
    private void Start()
    {
        gameObject.SetActive(false);    
      
    }
    void Update()
    {
        if (timerOn)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                updateTimer(timeleft);
            }
            else
            {
                Debug.Log("Times up - Game Over");
                timeleft = 0;
                timerOn = false;
         
                StartCoroutine(GameOverSequence());
            }
        }
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        m_TextMeshProUGUI.text = string.Format("{0:00} : {1:00}", min, sec);
    }


     IEnumerator GameOverSequence()
    {
      
        activateExplosion();

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        gameOver.displayGameOverMenu();
    }

    void activateExplosion()
    {
      
        StartCoroutine(camerashake.Shake(.30f, .7f));
        Explosions.SetActive(true);
        explosionSound.Play();
    }

    
}