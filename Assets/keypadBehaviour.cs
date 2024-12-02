using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadBehaviour : MonoBehaviour
{
    public codeManager CM;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void inputCharacter()
    {
        CM.tempPass += this.gameObject.name;
    }
}
