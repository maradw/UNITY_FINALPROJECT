using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Enemy : MonoBehaviour
{
    protected string _enemyName;
    protected int _enemyLife;
    protected float enemySpeed;
    protected Material _enemymaterial;
    void Start()
    {
        
    }
    public virtual void EnemyMovement()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
