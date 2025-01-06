using TMPro;
using UnityEngine;

//https://www.youtube.com/watch?v=hxpUk0qiRGs&ab_channel=TheGameGuy
public class Timer : MonoBehaviour
{
    public bool timerOn = false;
    public float timeleft = 60;
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    private void Start()
    {
        timerOn = true;
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
                Debug.Log("Times up");
                timeleft = 0;
                timerOn = false;
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
}