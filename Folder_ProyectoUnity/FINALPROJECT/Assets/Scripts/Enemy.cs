using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class Enemy : MonoBehaviour
{
    protected string _enemyName;
    protected int _enemyLife;
    protected float enemySpeed;
    protected Material _enemymaterial;
    protected int _enemyDamage;
    protected PlayerController _playerReference;
    void Awake()
    {
        _playerReference = GetComponent<PlayerController>();
    }
    public virtual void EnemyMovement()
    {
        //MRUV
    }
    public virtual void DamagePlayer()
    {
        _playerReference._playerLife = _playerReference._playerLife - _enemyDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
