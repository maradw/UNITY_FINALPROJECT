using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    //private float _rotation = 3f;
    [SerializeField] private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    //[SerializeField] private NPCNavMovement NPC;
    public float _gravityScale;
    public Transform cameraRef;

    public float smoothTime = 0.1f;
    float smoothVelocity;
    
    public int _playerLife = 50;
    int force = 3;

    [Header("Anlges Rotations")]
    [SerializeField] private Quaternion CameraRotaiton;
    [SerializeField] private Quaternion PlayerRotation;
    [SerializeField] private Vector3 RBVelocity;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float positionMagnitud;
    [SerializeField] private float ConstAngle;
    [SerializeField] private float TargetAngle;


    

    private void CameraAngles()
    {
        TargetAngle = Mathf.Atan2(direction.x, direction.y)* Mathf.Rad2Deg + cameraRef.eulerAngles.y;
        ConstAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref smoothVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0f, ConstAngle, 0f);
    }

    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector2>();

        positionMagnitud = direction.magnitude;
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
        /*if (direction.magnitude >= 0.1f)
        {
            CameraAngles();
        }

        CameraRotaiton = camera.rotation;
        PlayerRotation = transform.rotation;*/

        //myRBD.velocity = new Vector3(-_horizontal  * Mathf.Cos(ConstAngle * Mathf.Deg2Rad) * velocityModifier, myRBD.velocity.y, _vertical  * Mathf.Sin(ConstAngle * Mathf.Deg2Rad) * velocityModifier);
        //RBVelocity = myRBD.velocity;

        //myRBD.velocity = new Vector3(_horizontal * velocityModifier, 0, _vertical * velocityModifier) * Vector3.Dot(myRBD.velocity.normalized, myRBD.transform.forward);
        myRBD.velocity = new Vector3(cameraRef.TransformDirection(direction).x * velocityModifier, myRBD.velocity.y, cameraRef.TransformDirection(direction).y * velocityModifier);//Maria
        //Vector3 moveDirection = new Vector3(direction.x, myRBD.velocity.y, direction.y).normalized;
        //myRBD.velocity = cameraRef.TransformDirection(moveDirection) * velocityModifier;
        //RBVelocity = myRBD.velocity;
        
    }

    public void DetectEnemy()
    {
        bool hit = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            hit = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
            //enemy = hitinfo.transform;
           // parabolicLaunch.SetTarget(enemy);
            print("hit");

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.magenta);
            hit = false;
            if (hit == false)
            {

            }
        }

    }
    public void CreateInventory()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            GameManager.Instance.ChangeScene("Main Game");
        }
        else if (other.tag == "ChozuyaTalk")
        {

        }
    }
    void Update()
    {
        DetectEnemy();
    }
}
