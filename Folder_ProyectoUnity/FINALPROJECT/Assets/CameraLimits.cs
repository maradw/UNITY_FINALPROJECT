using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimits : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float minXposition;
    [SerializeField] private float maxXposition;
    [SerializeField] private float minZposition;
    [SerializeField] private float maxZposition;
    private float Xposition;
    private float Zposition;


    void Update()
    {
       // transform.position = new Vector3(_player.transform.position.x, 19f, _player.transform.position.z);
        Xposition = Mathf.Clamp(transform.position.x, minXposition, maxXposition);
        Zposition = Mathf.Clamp(transform.position.y, minZposition, maxZposition);

        transform.position = new Vector3(Xposition,19f, Zposition);



    }   
}
