using UnityEngine;

public class incineratorDestroy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name) {
            case "Trash_Bag":
                other.GetComponent<TrashBagManager>().resetPositon();
                other.GetComponent <TrashBagManager>().enableMesh();
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
