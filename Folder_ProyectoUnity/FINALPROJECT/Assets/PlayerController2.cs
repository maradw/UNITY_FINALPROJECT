using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController2 : MonoBehaviour
{


    private float _horizontal;
    private float _vertical;
    private float rotationmodifier;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private Vector3 direction;
    private Vector2 movement;
    [SerializeField] private float velocityModifier = 5f;

    // Start is called before the first frame update






    private float jumpForce = 5f;
    private Vector3 forceDirection = Vector3.zero;
    void Start()
    {
        
    }
    public void Jump(InputAction.CallbackContext jump)
    {
        /*Debug.Log("pressed");
        //myRBD.AddForce(Vector3.up * force, ForceMode.Impulse);
        //if(myRBD.velocity.y> 0)
        //funionaxdperomas o menos
        Debug.Log("ekisde");
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
            Debug.Log("ekisde2");
        }*/
    }
    /*private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }*/
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMovement(InputAction.CallbackContext move)
    {
        Debug.Log("aea");
        _horizontal = move.ReadValue<Vector2>().x;
        _vertical = move.ReadValue<Vector2>().y;

        //direction = move.ReadValue<Vector2>();

        //positionMagnitud = direction.magnitude;
    }
    private void FixedUpdate()
    {

        myRBD.velocity = new Vector3(_horizontal * velocityModifier, myRBD.velocity.y, _vertical * velocityModifier);



       Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        //animatorPlayer.SetBool("IsRunning", direction.magnitude >= 0.1f);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationmodifier, 0.1f);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            myRBD.MovePosition(transform.position + moveDirection * velocityModifier * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            GameManager.Instance.ChangeScene("Roulette");
            Debug.Log("help");
        }
       // if (other.tag == "Damage")
        {

        }
    }
    
}