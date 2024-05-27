using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class conteinerControll : MonoBehaviour
{
    [SerializeField] private Material _baseMat;
    [SerializeField] private Material _secondMat;
    [SerializeField] private Renderer _conteinerRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    //public static event Action OnEnter;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<Renderer>().material = _baseMat;
        _conteinerRenderer.material = _baseMat;
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _conteinerRenderer.material = _secondMat;
            //OnEnter?.Invoke();

        }
    }
}
