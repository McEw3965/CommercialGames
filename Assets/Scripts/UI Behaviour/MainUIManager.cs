using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainUIManager : MonoBehaviour
{
    public GameObject ratingHeader;
    public TextMeshProUGUI ratingValue;
    public float rating = 0;
    [SerializeField] private TextMeshProUGUI score;
   // public Animator headerAnim;
    //public Animator valueAnim;
    // Start is called before the first frame update
   

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

    public void overallScore()
    {
        score.text = rating.ToString();
    }
}
