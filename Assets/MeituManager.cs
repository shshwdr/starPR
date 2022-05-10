using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeituManager : Singleton<MeituManager>
{
    List<string> meituImageList = new List<string>();
    MeituImage currentEditingImage;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void publish()
    {
        currentEditingImage = GameObject.FindObjectOfType<MeituImage>();
        if (!currentEditingImage)
        {
            Debug.LogError("no image to publish");
            return;
        }
        if (currentEditingImage.isValid())
        {
            EventPool.Trigger<string>("ShowMessage", "成功发布");
            meituImageList.Remove(currentEditingImage.name);

            DialogueLua.SetVariable("processedImagesCount", DialogueLua.GetVariable("processedImagesCount").asInt + 1);
            Sequencer.Message("processedImagesCount_1");

        }
        else
        {
            EventPool.Trigger<string>("ShowMessage", "发布失败，请继续修改");
        }
    }

    public void addImage(string imageName)
    {
        if (meituImageList.Contains(imageName))
        {
            return;
        }
        EventPool.Trigger("showMeitu");
        DialogueLua.SetVariable("collectImagesCount", DialogueLua.GetVariable("collectImagesCount").asInt +1);
        Sequencer.Message("collectImagesCount_1");
        meituImageList.Add(imageName);
    }

    public string getImageName()
    {
        if (meituImageList.Count > 0)
        {
            return meituImageList[0];
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
