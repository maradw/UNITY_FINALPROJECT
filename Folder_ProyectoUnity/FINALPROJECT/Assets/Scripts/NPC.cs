using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NPC : MonoBehaviour
{
    [SerializeField] Transform _NPCOrigin;
    [SerializeField] private float _rePosDuration;
    [SerializeField] float duration;
    [SerializeField] private Ease EaseValue;
    [SerializeField] private Vector3 _height;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private int _jumpsNumb;
    bool snapping = false;
    [SerializeField] private Ease EaseParam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Sequence NPCSecuence = DOTween.Sequence();

            NPCSecuence.Append( transform.DOJump(_height, _jumpPower,_jumpsNumb, duration, snapping));
            NPCSecuence.Append(transform.DOMove(_NPCOrigin.position, _rePosDuration, snapping).SetEase(EaseParam));
        }
    }
    
}
