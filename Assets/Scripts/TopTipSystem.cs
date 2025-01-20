using System.Collections;
using UnityEngine;

public class TopTipSystem : MonoBehaviour
{
    [SerializeField] private GameObject torchTip;
    [SerializeField] private GameObject SprintTip;

    bool torchTipDisplayed = false;
    bool sprintTipDisplayed = false;

    private void Start()
    {

        StartCoroutine(DisplayTorchTip());
        StartCoroutine(DisplaySprintTip());
    }

    private IEnumerator DisplayTorchTip()
    {
        yield return new WaitForSeconds(5f);

        if(!torchTipDisplayed)
        {
            torchTipDisplayed = true;
            torchTip.SetActive(true);
            yield return new WaitForSeconds(5f);
            torchTip.SetActive(false);
        }

    }





    private IEnumerator DisplaySprintTip()
    {
        yield return new WaitForSeconds(25f);

        if (!sprintTipDisplayed)
        {
            sprintTipDisplayed = true;
            SprintTip.SetActive(true);
            yield return new WaitForSeconds(5f);
            SprintTip.SetActive(false);
        }

    }
}
