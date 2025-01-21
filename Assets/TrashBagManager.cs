using UnityEngine;
using UnityEngine.Rendering;

public class TrashBagManager : MonoBehaviour
{
    PickUpItem pickup; //reference to the pickup script

    [Header("Debugging Brush Position:")]
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    private Vector3 initialPos;
    public MeshRenderer[] children;


    private void Start()
    {
        pickup = GameObject.FindWithTag("Player").GetComponent<PickUpItem>();
        initialPos = this.gameObject.GetComponent<Transform>().localPosition;
        

    }
    // Update is called once per frame
    void Update()
    {
        if (pickup.itemInHand && pickup.currentItem.name == "Trash_Bag" || pickup.currentItem.name == "Trash_Bag 2" && pickup.itemInHand)
        {

            position = new Vector3(0, -1f, 3f);
            rotation = new Vector3(52, -180, -4.1f);

            pickup.SetPosition(position);
            pickup.SetRotaion(rotation);
        }
    }

    public void resetPositon()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.gameObject.GetComponent<Transform>().position = initialPos;
        disableMesh();
    }

    public void enableMesh()
    {
        for (int i = 0; i < children.Length; i ++)
        {
            children[i].enabled = true;
        }
    }

    public void disableMesh()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].enabled = false;
        }
    }
}
