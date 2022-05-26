using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppButton : MonoBehaviour
{
    [SerializeField] GameObject redDot;

    public void showRedDot()
    {
        redDot.SetActive(true);
    }
    public void hideRedDot()
    {
        redDot.SetActive(false);
    }

    public void clickButton()
    {
        //not a good idea. maybe find a way to check after each sentence.
        // EventPool.Trigger("dialogueConditionChanged");
       // GetComponent<Button>().Select();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
