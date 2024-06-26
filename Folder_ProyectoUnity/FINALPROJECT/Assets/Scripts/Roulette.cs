using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private bool _isRotating = false;
    [SerializeField] float speed;
    [SerializeField] GameObject startRotate;
    [SerializeField] GameObject NextScene;

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
        startRotate.SetActive(false);

        currentTime = Time.time - startTime;
        result = initialVelocity * currentTime + (acceleration * Mathf.Pow(currentTime, 2) / 2);
        // if(Time.deltaTime <= 0)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * speed);
        }
       // transform.Rotate(Vector3.back * Time.deltaTime * speed);
        
        

        CallStopRotate();
        //if()
        

        CallHide();
    }
    private void Start()
    {
        startTime = Time.time;
        NextScene.SetActive(false);
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
    IEnumerator HideAndPass()
    {
        yield return new WaitForSeconds(8f);
        NextScene.SetActive(true);

    }
    public void CallHide()
    {
        StartCoroutine(HideAndPass());
    }
     public void Continue(string scene)
    {
        GameManager.Instance.ChangeScene(scene);
    }
}

