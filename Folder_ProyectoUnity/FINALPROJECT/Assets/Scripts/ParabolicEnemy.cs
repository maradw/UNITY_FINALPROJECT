using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicEnemy : MonoBehaviour
{
    [SerializeField] ParabolicLaunch ball;
    private Transform _playerReference;
    private bool _startShooting = false;
    private bool _shootAgain = true;

    public void Update()
    {
        if(_startShooting == true && _shootAgain == true)
        {
            StartCoroutine(StartShoot());
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerReference = other.transform;
            _startShooting = true;
            Debug.Log("a");
        }
        if (other.tag == "Ground" && other.tag == "Player")
        {
            Destroy(ball);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _playerReference = null;
            _startShooting = false;
        }
    }
    public void Shoot()
    {
        Instantiate(ball, transform.position, transform.rotation).Launch(_playerReference);
       
    }
    IEnumerator StartShoot()
    {
        _shootAgain = false;
        Shoot();
        yield return new WaitForSeconds(0.8f);
        _shootAgain = true;
    }
    
}
