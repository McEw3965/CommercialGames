using UnityEngine;

public class MapManager : MonoBehaviour
{

    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject interactionText;
    [SerializeField] private GameObject DialogueBoxAlien;
    [SerializeField] private GameObject DialogueBoxCaptain;
    [SerializeField] private GameObject Crosshair;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ToggleMap()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Timer.SetActive(true);
            DialogueBoxAlien.SetActive(true);
            DialogueBoxCaptain.SetActive(true);
            interactionText.SetActive(true);
            Crosshair.SetActive(true);

        }
        else
        {
            gameObject.SetActive(true);
            Timer.SetActive(false);
            DialogueBoxAlien.SetActive(false);
            DialogueBoxCaptain.SetActive(false);
            interactionText.SetActive(false);
            Crosshair.SetActive(false);
        }
    }

}
