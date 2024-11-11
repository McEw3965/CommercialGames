
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioSource[] RadioTracks;
    public int trackNum = 0;
    public bool isRadioOn = false;
    public alienBehaviour AB;
    public taskTerminal TT;
    MainUIManager UIManager;
    private void Start()
    {
        UIManager = FindAnyObjectByType<MainUIManager>();
    }

    public void TurnRadioOn() {
        if (AB.isFollowing == true)
        {
            AB.radioChanged = true;
            print(AB.radioChanged);
        }




            if (!isRadioOn) //if the radio is off
            {
                Debug.Log("Playing Radio");
                RadioTracks[trackNum].Play(); //play the first track
                isRadioOn = true;

            }

            else if (isRadioOn && trackNum < RadioTracks.Length - 1)
            {
                Debug.Log("Increasing Track");

                RadioTracks[trackNum].Stop(); //stop the music
                trackNum++; //increase the track by one
                RadioTracks[trackNum].Play(); //play the new track 

            }

            else //if radio is on the last track
            {
                Debug.Log("Stopping Radio");

                RadioTracks[trackNum].Stop(); //stop the music
                trackNum = 0; //reset the track
                isRadioOn = false;
            }

            if (TT.radioTaskActive)
        {
            TT.radioTaskActive = false;
            UIManager.AdjustScore(10);
            TT.eraseTaskList();
        }

          

    }


}
