using SteamAudio;
using UnityEngine;

public class Speakers : MonoBehaviour
{

    private AudioSource AudioSource;
    [SerializeField] private taskTerminal TT;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    public void TurnOnAlarm()
    {
      if(TT.alarmTaskActive)
        {
            AudioSource.Play();
        }
    }


    public void TurnOffAlarm()
    {
        AudioSource.Stop();
    }

}
