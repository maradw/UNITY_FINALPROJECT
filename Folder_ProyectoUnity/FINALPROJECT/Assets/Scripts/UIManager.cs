using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform _titleGame;
    [SerializeField] private float _effectDuration;
    [SerializeField] private Transform _newTitlePos;
    [SerializeField] private float _endPosY = 0f;
    [SerializeField] private Ease EaseParam;
    bool snapping = false;
    [SerializeField] private Rigidbody textRGB;
    // Start is called before the first frame update
    void Start()
    {
        //_endPosY = transform.position.y + 9;
        _titleGame.DOMoveY(_newTitlePos.position.y, _effectDuration, snapping).SetEase(EaseParam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
