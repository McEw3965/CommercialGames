using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBehaviour : MonoBehaviour
{
    Animator alienAnimator;
    public bool isFollowing;
    public AINavigations AiNav;
    private float radioTimer = 20f;
    public bool radioChanged;
    public taskTerminal TT; 
    // Start is called before the first frame update
    void Start()
    {
        alienAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        radioTimer -= Time.deltaTime;

        if (radioTimer <= 0 && isFollowing != true)
        {
            AiNav.canFollowPlayer = true;
            isFollowing = true;
            print("Change Radio NOW");
        }

        if (radioChanged == true)
        {
            print("Happy with Radio :)");
            radioTimer = Random.Range(30f, 90f);
            radioChanged = false;
            AiNav.canFollowPlayer = false;
            isFollowing = false;

        }
    }

    public void AlienWave()
    {
        Debug.Log("Wave");
        alienAnimator.SetBool("wave", true);
        StartCoroutine(ResetWave(0.5f));

        if (TT.WaveAlienTaskActive)
        {
            TT.WaveAlienTaskActive = false;

            TT.eraseTaskList();
        }
    }
    private IEnumerator ResetWave(float delay)
    {
        yield return new WaitForSeconds(delay); //Wait
        alienAnimator.SetBool("wave", false); //Set the bool to false to end the animation
    }
}
