using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    public  SimplyLinkedList<NodeController> adjacentNodes = new SimplyLinkedList<NodeController>();
    public int index;

    void Start()
    {

    }
    public void AddAdjacentNode(NodeController node)
    {
        adjacentNodes.InsertNodeAtEnd(node);
    }
    public NodeController SelecRandomAdjancent()
    {
        index = Random.Range(0, adjacentNodes.length);
        return adjacentNodes.ObtainNodeAtPosition(index);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
