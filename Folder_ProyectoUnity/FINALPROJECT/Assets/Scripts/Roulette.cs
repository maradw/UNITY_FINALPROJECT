using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private bool _isRotating = false;
    [SerializeField] float speed =5;
    [SerializeField] GameObject startRotate;
    [SerializeField] GameObject NextScene;

    //MRUV
    [SerializeField] private float acceleration;
    [SerializeField] private float result;
    [SerializeField] private float initialVelocity;
    private int _rotationTime = 5;

    public void Cliked()
    {
        _isRotating = true;
        startRotate.SetActive(false);

        result = initialVelocity * _rotationTime + (acceleration * Mathf.Pow(_rotationTime, 2) / 2);
        CallStopRotate();
        CallHide();
    }
    private void Start()
    {
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
        StartCoroutine(StopRotate(_rotationTime));
    }
    IEnumerator HideAndPass()
    {
        yield return new WaitForSeconds(_rotationTime+0.5f);
        NextScene.SetActive(true);

    }
    public void CallHide()
    {
        StartCoroutine(HideAndPass());
    }
     public void Continue(string scene)
    {
        GameManager.Instance.ChangeScene("Main game");
    }
}

