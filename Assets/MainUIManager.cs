using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public GameObject ratingHeader;
    public Text ratingValue;
    public float rating = 0;

   // public Animator headerAnim;
    //public Animator valueAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ratingValue.text = rating.ToString();
    }

    public void AdjustScore(float score)
    {
        rating += score;
        ratingValue.color = Color.green;
        ratingHeader.SetActive(true);
    }
}
