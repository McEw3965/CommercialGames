using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    private RawImage map;

    private void Start()
    {
        map = GetComponent<RawImage>();

        map.gameObject.SetActive(false);
    }

    public void ToggleMap()
    {

        if (map.gameObject.activeSelf)
        {
            map.gameObject.SetActive(false); // If currently active, deactivate it
        }
        else
        {
            map.gameObject.SetActive(true); // If currently inactive, activate it
        }
    }

}
