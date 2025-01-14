
using TMPro;
using UnityEngine;


public class taskTerminal : MonoBehaviour
{
    public ventBehaviour[] ventBehaviour;
    public int ventNumber;

    //public CutSceneEnter cutscene;
    [Header("Tasks Active:")]
    public bool ventTaskActive;
    public bool alarmTaskActive;
    public bool radioTaskActive;
    public bool WaveAlienTaskActive;
    public bool lightTaskActive;
    
    public FlashingLights lightFlash;

    [SerializeField] private int chosenTask;

    [Header("Time between each task:")]
    [SerializeField] private float time = 5f; 
    [SerializeField] private GameObject listTasks; 
    [SerializeField] private Transform listParent;
    private float timer = 0f;
    [Header("Space between each task in UI")]
    [SerializeField] private float itemHeight = 100f; // Spacing between items


    [SerializeField] private StartGameScript StartGameScript;
    private void Start()
    {
        listParent = GameObject.Find("Main Tasks").transform;
        listTasks = GameObject.Find("ListTasks");
    }
    private void Update()
    {

        if (StartGameScript.tutorialOn)
        {

         
        }
        else
        {


            timer += Time.deltaTime;

            if (timer >= time)
            {
                randomselectTask();
                timer = 0f;
            }


            ReorganizeList();
        }
    }


    void addToList(string task, string tag, Color color)
    {
        GameObject newTask = Instantiate(listTasks, listParent);
        TextMeshProUGUI textComponent = newTask.GetComponent<TextMeshProUGUI>();
        newTask.tag = tag;
        if (textComponent != null)
        {
            textComponent.text = task;
            textComponent.color = color;
        }

        RectTransform rectTransform = newTask.GetComponent<RectTransform>();
        int itemCount = listParent.childCount;

        

        rectTransform.anchoredPosition = new Vector2(0, -itemHeight * (itemCount - 1));

        rectTransform.offsetMin = new Vector2(0, rectTransform.offsetMin.y); // Set left offset to 0
        rectTransform.offsetMax = new Vector2(0, rectTransform.offsetMax.y); // Right offset remains the same

    }

    public void removeFromList(string tag) 
    {
        GameObject taskToRemove = GameObject.FindWithTag(tag);
        Destroy(taskToRemove);
        
            }

    private void ReorganizeList()
    {
        // Loop through all children and adjust their positions
        for (int i = 0; i < listParent.childCount; i++)
        {
            RectTransform rectTransform = listParent.GetChild(i).GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, -itemHeight * i);
        }
    }


    public void selectspecifictask(int task)
    {
        selectTask(task);  
    }

    public void randomselectTask()
    {
        chosenTask = Random.Range(0, 4);

        selectTask(chosenTask);
    }

    void selectTask(int tasks)
    {
        switch (tasks)
        {
            case 0:
                if (!ventTaskActive)
                {
                    ventNumber = Random.Range(0, 3);
                    ventBehaviour[ventNumber].igniteVent();
                    ventTaskActive = true;
                    addToList("Extinguish Vent +9s", "TaskVent", Color.red);
                    lightFlash.alarmOn = true;
                    alarmTaskActive = true;

                }
                break;


            case 1:
                if (!radioTaskActive)
                {
                    radioTaskActive = true;
                    addToList("Press Radio +5s", "TaskRadio", Color.green);
                }

                break;
            case 2:
                if (!WaveAlienTaskActive)
                {
                    WaveAlienTaskActive = true;
                    addToList("Wave to Alien +5s", "TaskAlien", Color.green);
                }
                break;
            case 3:
                if (!lightTaskActive)
                {
                    lightTaskActive = true;
                    addToList("Turn the lights on +5s", "TaskLights", Color.green);
                }
                break;
        }
    }



}
