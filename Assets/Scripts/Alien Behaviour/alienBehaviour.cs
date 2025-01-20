using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBehaviour : MonoBehaviour
{
    private Animator alienAnimator;
    private MainUIManager UIManager;
    private taskTerminal TT;
    public AINavigations AiNav;
    public AudioSource alienSound;
    [SerializeField] private Timer timer;

    public bool isFollowing;

    private int waveLayerIndex;
    private int danceLayerIndex;




    void Start()
    {
        alienAnimator = GetComponent<Animator>();
        TT = GameObject.Find("Tasks").GetComponent<taskTerminal>();
        UIManager = FindAnyObjectByType<MainUIManager>();

        waveLayerIndex = alienAnimator.GetLayerIndex("Wave");
        danceLayerIndex = alienAnimator.GetLayerIndex("Dance");




    }

    public void animateAlien()
    {
        int randomNum = Random.Range(0, 2);

        switch (randomNum)
        {
            case 0:
                AlienWave();
                break;
            case 1:
                AlienDance();
                break;
        }
        alienSound.Play();
    }
    public void AlienWave()
    {
        Debug.Log("Wave");
        alienAnimator.SetLayerWeight(waveLayerIndex, 1f);
        alienAnimator.SetLayerWeight(danceLayerIndex, 0f);
        alienAnimator.SetBool("isWaving", true);
        StartCoroutine(ResetWave(0.5f));

        if (TT.WaveAlienTaskActive)
        {
            TT.WaveAlienTaskActive = false;
            UIManager.AdjustScore(10);
            timer.timeleft += 5;
            TT.removeFromList("TaskAlien");
        }
    }
    private IEnumerator ResetWave(float delay)
    {
        yield return new WaitForSeconds(delay); //Wait

        alienAnimator.SetBool("isWaving", false); //Set the bool to false to end the animation
    }


    public void AlienDance()
    {
        Debug.Log("Dance!");
        alienAnimator.SetLayerWeight(waveLayerIndex, 0f);
        alienAnimator.SetLayerWeight(danceLayerIndex, 1f);

        alienAnimator.SetTrigger("isDancing");
    }

}
