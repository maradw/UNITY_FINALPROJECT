using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
//using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _vertical;
    private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    public Transform cameraRef;


    public static event Action OnPlayerGather;
    public static event Action<int> OnPlayerDamage;

    public static event Action OnTalk;
    public int _playerLife = 50;
    int force = 3;

    bool isOnChozuya = false;

    public static event Action OnPaused;

    [Header("Angles Rotations")]
    /*[SerializeField] private Quaternion CameraRotaiton;
    [SerializeField] private Quaternion PlayerRotation;
    [SerializeField] private Vector3 RBVelocity;*/
    [SerializeField] private Vector3 direction;

    /*[SerializeField] private float positionMagnitud;
    [SerializeField] private float ConstAngle;
    [SerializeField] private float TargetAngle;*/

    private bool _canJump;
    private float jumpForce = 7.5f;
   // private Vector3 forceDirection = Vector3.zero;
    private RaycastHit _rayHit1;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float _rayLenght;
    [SerializeField] private Transform _refMovement;


    [SerializeField] GameObject _lose;


    public bool isRunning = false;
    public bool isPaused = false;
    
    void Start()
    {
        _canJump = true;
        myRBD = GetComponent<Rigidbody>();
    }
    /*public void Run(InputAction.CallbackContext run)
    {
        isRunning = true;
       
    }*/
    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector3>();
    }
    public void OnPause (InputAction.CallbackContext pause)
    {
        /*

        isPaused = !isPaused;
        if (isPaused)
        {
            Debug.Log("causaaaaa");
            GameManager.Instance.Pause();
            // OnPaused?.Invoke();
        }
        else
        {
            GameManager.Instance.Resume();
        }
        /* if (pause.performed)
         {
             isPaused = true;
             Debug.Log("causaaaaa");
             GameManager.Instance.Pause();
            // OnPaused?.Invoke();
         }
         if (pause.performed && isPaused == true)
         {
             isPaused = false;
             GameManager.Instance.Resume();
         }*/
        //UIManager.Instance.Show(pauseBAr);

        GameManager.Instance.RealPause();
        
    }
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {

        }
    }
    public void Interact(InputAction.CallbackContext interact)
    {
        if (interact.performed && isOnChozuya == true)
        {
            Debug.Log("sisepudocausa");
            OnTalk?.Invoke();
           // UIManager.Instance.Show()
        }
        else if (interact.performed)
        {
            Debug.Log("habla p");
        }
    }
    public void Jump(InputAction.CallbackContext jump)
    {
       if(jump.performed && _canJump == true)
       {
            myRBD.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _canJump = false;

       }
        Debug.Log("sdsd" + Time.timeScale);
    }

    public void FixedUpdate()
    {
            myRBD.linearVelocity = new Vector3(_refMovement.TransformDirection(direction).normalized.x * velocityModifier, myRBD.linearVelocity.y, _refMovement.TransformDirection(direction).normalized.z * velocityModifier);
            transform.rotation = Quaternion.LookRotation(_refMovement.TransformDirection(Vector3.forward));
            _refMovement.rotation = new Quaternion(0, cameraRef.rotation.y, 0, cameraRef.rotation.w);
        
        

        if (Physics.Raycast(transform.position, Vector3.down, out _rayHit1, _rayLenght, layer))
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayHit1.distance, Color.magenta);
            _canJump = true;

        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayLenght, Color.green);

        }
    }

    public void DetectEnemy()
    {
        bool hit = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            hit = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);

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
            GameManager.Instance.ChangeScene("Roulette");

        }

        if (other.tag == "Book")
        {
            OnPlayerGather?.Invoke();
        }

        
        if (other.tag == "ChozuyaTalk")
        {
            Debug.Log("a");
            isOnChozuya = true;

        }
        if (other.tag == "Damage")
        {
            Restlife(6);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void Restlife(int damage)
    {
        _playerLife -= damage;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            velocityModifier = 10;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocityModifier = 5;

        }
        //DetectEnemy();
        LifeStatus();
    }
    private void LifeStatus()
    {
        if (_playerLife <= 0)
        {
            Debug.Log("lose");
            UIManager.Instance.Show(_lose);
            //GameManager.Instance.ChangeScene("Menu");
        }
    }
}
