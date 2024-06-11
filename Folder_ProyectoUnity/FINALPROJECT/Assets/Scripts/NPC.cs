using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class NPC : MonoBehaviour
{
    [SerializeField] Transform tarjet;
    [SerializeField] float duration;
    [SerializeField] private Ease EaseValue;
    // Start is called before the first frame update


    [SerializeField] private float moveTo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //press z
            Sequence NPCSecuence = DOTween.Sequence();
           // NPCSecuence.Append(transform.DOMoveY(moveTo, 3f, bool snapping)

            NPCSecuence.Append(transform.DOMove(new Vector3(transform.position.x + 6, transform.position.y +3), duration).SetEase(EaseValue));
            //guardar la posicion para que regrese
        }
    }
}
