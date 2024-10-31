using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienBehaviour : MonoBehaviour
{
    Animator alienAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wave()
    {
        alienAnimator.SetBool("Wave", true);

    }
}
