using System.Collections;
using TMPro;
using UnityEngine;

//https://www.youtube.com/watch?v=hxpUk0qiRGs&ab_channel=TheGameGuy
public class Timer : MonoBehaviour
{
    public bool timerOn = false;
    public float timeleft = 60;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] private GameObject Explosions;
    [SerializeField] private AudioSource explosionSound;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private CameraShake camerashake;
    [SerializeField] private GameObject allobjects;
    private void Start()
    {
        gameObject.SetActive(false);

    }
    void Update()
    {
        if (timerOn)
        {
            if (timeleft > 0)
            {
                timeleft -= Time.deltaTime;
                updateTimer(timeleft);
            }
            else
            {
                Debug.Log("Times up - Game Over");
                timeleft = 0;
                timerOn = false;

                StartCoroutine(GameOverSequence());
            }
        }
    }


    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        m_TextMeshProUGUI.text = string.Format("{0:00} : {1:00}", min, sec);
    }


    IEnumerator GameOverSequence()
    {

        activateExplosion();

        // Wait for 2 seconds
        yield return new WaitForSeconds(1f);

        gameOver.displayGameOverMenu();
    }

    void activateExplosion()
    {

        StartCoroutine(camerashake.Shake(1f, 1f));
        makeEverythingFly();

        Explosions.SetActive(true);
        explosionSound.Play();
    }

    void makeEverythingFly()
    {
        foreach (Transform child in allobjects.transform)
        {
            //to stop getting errors:
            MeshCollider meshCollider = child.gameObject.GetComponent<MeshCollider>();

            if (meshCollider != null)
            {
                Debug.Log($"Skipping MeshCollider on: {child.gameObject.name}");
                continue;
            }

         
            //to add rigidbody to all the objects inside the ship
            Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = child.gameObject.AddComponent<Rigidbody>();
                Debug.Log($"Added Rigidbody to: {child.gameObject.name}");
            }
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;

            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
