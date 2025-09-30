using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public int itemName;
    public string description;
    public Sprite icon;
    public Item (int ID, int itemName, string description, Sprite icon)
    {
        this.ID = ID;
        this.itemName = itemName;
        this.description = description;
        this.icon = icon;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
