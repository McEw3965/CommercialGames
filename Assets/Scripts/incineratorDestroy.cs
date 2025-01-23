using UnityEngine;

public class incineratorDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.name) {
            case "Trash_Bag":
                other.GetComponent<TrashBagManager>().resetPositon();
                Debug.Log("Trash Destroyed");
                break;
            case "Cat":
                Debug.Log("Game Over: Cat Destroyed");
                break;
            case "Player":
                Debug.Log("Game Over: Player Died");
                break;
        }


    }
}
