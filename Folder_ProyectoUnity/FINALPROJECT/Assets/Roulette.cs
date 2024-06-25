using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    bool _isRotating = false;
    float _rotationSpeed;
    [SerializeField] GameObject button;
    void Start()
    {
        
    }
    public void ButtonCliked()
    {
        _isRotating = true;

        button.SetActive(false);
        CallStopRotate();
        
    }
    void Update()
    {
        if(_isRotating == true)
        {
            transform.Rotate( Vector3.back * _rotationSpeed * Time.deltaTime);
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
