using UnityEngine;

public class incineratorDestroy : MonoBehaviour
{

    public Timer timer;
    private AudioSource meow;

    private void Start()
    {
        meow = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.name) {
            case "Trash_Bag":
                other.GetComponent<TrashBagManager>().resetPositon();
                Debug.Log("Trash Destroyed");
                break;
            case "Cat":
                Debug.Log("Game Over: Cat Destroyed");
                meow.Play();
                timer.timeleft = 0f;
                break;
            case "Player":
                Debug.Log("Game Over: Player Died");
                timer.timeleft = 0f;

                break;
        }


    }
}
