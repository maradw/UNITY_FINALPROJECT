using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _myParticleSys;
    [SerializeField] private BookSO _bookInfo;
    //[SerializeField] private Material _myMat;
   // [SerializeField] private Renderer _matRenderer;
    private int _value;
    private int _order;
    // Start is called before the first frame update
    void Start()
    {
        _myParticleSys.Play();
       // _matRenderer.material = _bookInfo._baseMat;
        _value = _bookInfo._bookValue;
        _order = _bookInfo._bookNumb;
       // _bookInfo._baseMat = _myMat;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _myParticleSys.Pause();
            _myParticleSys.Clear();
            //OnEnter?.Invoke();

        }
    }
}
