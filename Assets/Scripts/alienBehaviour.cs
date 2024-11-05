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
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void wave()
    {
        alienAnimator.SetBool("Wave", true);

    }

}
