using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeituSelectManager : Singleton<MeituSelectManager>
{
    MeituEditableItem selectedItem;
    bool hasChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        //EventPool.OptIn<MeituEditableItem>("SelectImage", selectItem);
        EventPool.OptIn("SelectImageFailed", clearItem);
    }

    public void reset()
    {
        //
    }
    public void removeSelected()
    {
        selectedItem.gameObject.SetActive(false);
        selectedItem = null;
        hasChanged = true;

        EventPool.Trigger("changedImage");
        EventPool.Trigger("removeSelected");
    }
    public void selectItem(MeituEditableItem item)
    {
        Debug.Log("test1");
        clearItem();
        selectedItem = item;
        item.select();
        //var editableItems = GameObject.FindObjectsOfType<MeituEditableItem>();
        //foreach (var eItem in editableItems)
        //{
        //    if(eItem == item)
        //    {
        //        ei
        //    }
        //}
    }

    void clearItem()
    {

        var editableItems = GameObject.FindObjectsOfType<MeituEditableItem>();
        foreach ( var item in editableItems)
        {
            item.deselect();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
