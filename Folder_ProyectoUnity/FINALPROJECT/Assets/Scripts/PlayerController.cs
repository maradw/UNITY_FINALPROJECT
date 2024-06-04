using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private float _rotation = 5f;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;

    [SerializeField] private GameObject proyectile;
    private Vector3 position;
    [SerializeField] private Transform _gun;
    [SerializeField] private ParabolicLaunch parabolicLaunch;
    [SerializeField] private Transform enemy;
    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;
        position = new Vector3(_horizontal, 0, _vertical);
        if (position != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(position), _rotation * Time.deltaTime);
        }

    }
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        //Instantiate(proyectile, _gun.position, Quaternion.identity);
        parabolicLaunch.Launch();

    }

    public void FixedUpdate()
    {
        myRBD.velocity = new Vector3(_horizontal * velocityModifier, myRBD.velocity.y, _vertical * velocityModifier);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void DetectEnemy()
    {
        bool hit = false;


        //Vector3 fwd = transform.TransformDirection(Vector3.forward);

        /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
            print("hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*10f, Color.magenta);
        }*/
        if (Physics.Raycast(_gun.position, _gun.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            hit = true;
            Debug.DrawRay(_gun.position, _gun.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
            enemy = hitinfo.transform;
            parabolicLaunch.SetTarget(enemy);
            print("hit");

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.magenta);
            hit = false;
            if (hit == false)
            {
                parabolicLaunch.DeleteTarget();
            }
        }

        // Ray ray = new Ray(transform.position, )
    }
    // Update is called once per frame
    void Update()
    {
        DetectEnemy();
    }
}