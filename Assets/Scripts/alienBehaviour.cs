using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBehaviour : MonoBehaviour
{
    Animator alienAnimator;
    private bool isFollowing;
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
        if (radioTimer >= 0)
        {
            radioRequest();
            radioTimer = Random.Range(30f, 90f);
        }

    }

    public void wave()
    {
        alienAnimator.SetBool("Wave", true);

    }

    public void radioRequest()
    {
        isFollowing = true;
        AiNav.canFollowPlayer = true;

    }
}
