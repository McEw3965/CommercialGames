
using UnityEngine;
using TMPro;
public class RadioController : MonoBehaviour
{

    [SerializeField] private AudioSource[] RadioTracks;

    Camera playerCamera; // The player's camera
    GameObject Player;
    taskTerminal TT;
    MainUIManager UIManager;
    TMPro.TextMeshPro textMeshPro;

    public int trackNum = 0;
    public bool isRadioOn = false;
   

    Vector3 originalScale;
    private void Start()
    {
        //Referencing
        playerCamera = Camera.main;
        Player = GameObject.FindWithTag("Player");
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        UIManager = FindAnyObjectByType<MainUIManager>();
        textMeshPro = (TextMeshPro)GetComponentInChildren<TMP_Text>();


        textMeshPro.text = ""; //Set text to empty
        
    }
    
    public void TurnRadioOn() {

        /*
        GameObject radio = this.gameObject;
        originalScale = this.transform.localScale;
        this.transform.SetParent(playerCamera.transform);
        radio.transform.localPosition = new Vector3(0,-2.5f, 2);
        radio.transform.localScale = originalScale; // Restore original scale
        */

  //      Player.GetComponent<FirstPersonController>().playerCanMove = false;
//        Player.GetComponent<FirstPersonController>().cameraCanMove = false;


        if (!isRadioOn) //if the radio is off
            {
                Debug.Log("Playing Radio");
                RadioTracks[trackNum].Play(); //play the first track
                textMeshPro.text = "Playing: Song " + (trackNum + 1);
                isRadioOn = true;

            }

            else if (isRadioOn && trackNum < RadioTracks.Length - 1)
            {
                Debug.Log("Increasing Track");

                RadioTracks[trackNum].Stop(); //stop the music
               // textMeshPro.text = "";
                trackNum++; //increase the track by one
                RadioTracks[trackNum].Play(); //play the new track 
                textMeshPro.text = "Playing: Song " + (trackNum + 1);

        }

            else //if radio is on the last track
            {
                Debug.Log("Stopping Radio");

                RadioTracks[trackNum].Stop(); //stop the music
                trackNum = 0; //reset the track
                isRadioOn = false;
                textMeshPro.text = "";
        }

            if (TT.radioTaskActive)
        {
            TT.radioTaskActive = false;
            UIManager.AdjustScore(10);
            TT.removeFromList("TaskRadio");
        }

       // Player.GetComponent<FirstPersonController>().playerCanMove = true;
       // Player.GetComponent<FirstPersonController>().cameraCanMove = true;

    }


}
