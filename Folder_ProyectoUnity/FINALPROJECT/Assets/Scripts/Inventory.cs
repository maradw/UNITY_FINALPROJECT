using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{

    [SerializeField] private float _distanceBetween;
    [SerializeField] private RectTransform Origin;
    private LinkedCircularList<GameObject> inventory = new LinkedCircularList<GameObject>();

    [SerializeField] private GameObject test0;
    [SerializeField] private GameObject test1;
    [SerializeField] private GameObject test2;
    [SerializeField] private GameObject test3;
    [SerializeField] private GameObject test4;

    private GameObject CurrentSlot;
    private int CurrentIndex;


    void Start()
    {
        CurrentIndex = 0;
        inventory.InsertNodeAtStart(test0);
        inventory.InsertNodeAtStart(test1);
        inventory.InsertNodeAtStart(test2);
        inventory.InsertNodeAtStart(test3);
        inventory.InsertNodeAtStart(test4);
    }
    void Update()
    {
        inventoryPos();
    }
    void FixedUpdate()
    {
        CurrentSlot = inventory.GetNodeAtPosition(CurrentIndex);
        EvaluateList();
    }
    public void inventoryPos()
    {
        for (int i = 0; i < inventory.length; i++)
        {
            inventory.GetNodeAtPosition(i).GetComponent<RectTransform>().position = new Vector3(Origin.position.x + (_distanceBetween * i), Origin.position.y, 0);
        }
    }
    public void EvaluateList()
    {
        for (int i = 0; i < inventory.length; i++)
        {
            CurrentSlot.GetComponent<RectTransform>().localScale = Vector3.Slerp(CurrentSlot.GetComponent<RectTransform>().localScale, Vector3.one * 2, 5 * Time.deltaTime);


            if (CurrentIndex != i)
            {
                inventory.GetNodeAtPosition(i).GetComponent<RectTransform>().localScale = Vector3.Slerp(inventory.GetNodeAtPosition(i).GetComponent<RectTransform>().localScale, Vector3.one, 5 * Time.deltaTime);
            }
        }
    }
    public void NavInventory(InputAction.CallbackContext nav)
    {
        if (nav.performed)
        {
            Vector2 navDir = nav.ReadValue<Vector2>();
            if (navDir == Vector2.left)
            {
                if (CurrentIndex == 0)
                {
                    CurrentIndex = inventory.length - 1;
                }
                else
                {
                    CurrentIndex--;
                }
            }
            else if (navDir == Vector2.right)
            {
                if (CurrentIndex == inventory.length - 1)
                {
                    CurrentIndex = 0;
                }
                else
                {
                    CurrentIndex++;
                }
            }
        }
    }

}
