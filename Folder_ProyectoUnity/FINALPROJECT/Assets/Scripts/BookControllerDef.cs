using System.Collections;
using UnityEngine;

public class BookControllerDef : MonoBehaviour
{
    [SerializeField] private BookSO _bookInfo;
    [SerializeField] private int _order;

    void Start()
    {
        //_myParticleSys = _bookInfo._bookPart;
        _order = _bookInfo._bookNumb;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
