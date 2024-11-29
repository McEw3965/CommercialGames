using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject cutsceneCam;
    public GameObject UI;
    public Animator alienAnimation;
    public int CutsceneTimeLength = 10;
  
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cutsceneCam.SetActive(true); //turn on cutscene camera
        player.SetActive(false);

        UI.SetActive(false);
        
        StartCoroutine(FinishCut());

    }

    IEnumerator FinishCut()
    {
        player.SetActive(true);
        UI.SetActive(true);
        cutsceneCam.SetActive(false);
        yield return new WaitForSeconds(CutsceneTimeLength); //wait ten seconds

    }
}
