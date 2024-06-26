using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private bool _isRotating = false;
    [SerializeField] float speed;
    [SerializeField] GameObject button;


    //MRUV
    [SerializeField] private float startTime;
    [SerializeField] private float acceleration;
    [SerializeField] private float result;
    [SerializeField] private float initialVelocity;

    [SerializeField] public float currentTime = 0;


    //[SerializeField] Rigidbody _rouletteRBD;

    public void Cliked()
    {
        _isRotating = true;
        button.SetActive(false);

        currentTime = Time.time - startTime;
        result = initialVelocity * currentTime + (acceleration * Mathf.Pow(currentTime, 2) / 2);
        // if(Time.deltaTime <= 0)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
       // transform.Rotate(Vector3.back * Time.deltaTime * speed);
        
        

        CallStopRotate();
        
    }
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        
        if (_isRotating == true)
        {
           this.gameObject.transform.Rotate(Vector3.back * result * Time.deltaTime);
          
        }
    }
    void Rotate()
    {
       _isRotating = false;
    }
    IEnumerator StopRotate(float time)
    {
        yield return new WaitForSeconds(time);
        Rotate();


    }
    public void CallStopRotate()
    {
        StartCoroutine(StopRotate(5f));
    }
}
