using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private float _rotation = 3f;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private NPCNavMovement NPC;
    public float _gravityScale;
    public Transform camera;

    public float smoothTime = 0.1f;
    float smoothVelocity;
    private Vector3 position;
    public int _playerLife = 50;
    int force = 3;
    public void OnMovement(InputAction.CallbackContext move)
    {
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;
        position = new Vector3(_horizontal, 0, _vertical).normalized;
        if (position.magnitude>= 0.1f)
        {
            float targetAngle = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
           // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(position), _rotation );
        }

    }
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {

        }
    }
    public void Interact(InputAction.CallbackContext interact)
    {
       // NPC.CallInteract();
    }
    public void Jump(InputAction.CallbackContext jump)
    {
        Debug.Log("pressed");
        myRBD.AddForce(Vector3.up * force, ForceMode.Impulse);
        //if(myRBD.velocity.y> 0)
        //funionaxdperomas o menos

    }
    public void FixedUpdate()
    {
        myRBD.velocity = new Vector3(_horizontal * velocityModifier, myRBD.velocity.y, _vertical * velocityModifier);
    }

    public void DetectEnemy()
    {
        bool hit = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            /*hit = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
            enemy = hitinfo.transform;
            parabolicLaunch.SetTarget(enemy);
            print("hit");*/

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.magenta);
            hit = false;
            if (hit == false)
            {
                //parabolicLaunch.DeleteTarget();
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            GameManager.Instance.ChangeScene("Main Game");
        }
    }
    void Update()
    {
        //DetectEnemy();
    }
}
