using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject cutsceneCam;
    public GameObject UI;
    public Animator alienAnimation;
  
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true); //turn on cutscene camera
        player.SetActive(false);
        alienAnimation.SetBool("happyIdle", true);

        UI.SetActive(false);
        StartCoroutine(FinishCut());

    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(10); //wait ten seconds
        player.SetActive(true);
        UI.SetActive(true);
    
        alienAnimation.SetBool("happyIdle", false);

        cutsceneCam.SetActive(false);
    }
}
