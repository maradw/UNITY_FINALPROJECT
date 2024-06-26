using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private Text _text;
    public string[] dialogueText;
    public float timeBetween = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = " ";
    }
    public void OnTalk(InputAction.CallbackContext talk)
    {
        StartCoroutine(Displaytext(dialogueText[0]));                            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Displaytext(string text)
    {
        int textLenght = text.Length;
        int currentIndex = 0;
        _text.text = " ";
        while (currentIndex < textLenght)
        {
            _text.text += text[currentIndex];
            currentIndex++;
            if (currentIndex < textLenght)
            {
                yield return new WaitForSeconds(timeBetween);
            }
            else
            {
                break;
            }
            _text.text = " ";

        }
    }
}