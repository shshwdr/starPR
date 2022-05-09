using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeituImage : MonoBehaviour
{
    [SerializeField]
    List<MeituEditableItem> needToHide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isValid()
    {
        foreach(var item in needToHide)
        {
            if (item.gameObject.active)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
