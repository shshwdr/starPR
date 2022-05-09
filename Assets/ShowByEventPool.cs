using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowByEventPool : MonoBehaviour
{
    public string eventName;
    public GameObject toShow;

    // Start is called before the first frame update
    void Start()
    {
        toShow.SetActive(false);
        EventPool.OptIn(eventName, show);
    }
    public void show()
    {
        toShow.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
