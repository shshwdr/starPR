using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeituCanvas : MonoBehaviour
{
    [SerializeField]
    Button removeButton;
    [SerializeField]
    Button resetButton;
    [SerializeField]
    Button publishButton;
    [SerializeField]
    Transform imageParent;

    bool hasLoadedImage = false;
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<MeituEditableItem>("SelectImage", selectItem);
        EventPool.OptIn("SelectImageFailed", unselectItem);
        EventPool.OptIn("removeSelected",removeSelectedItem);
        removeButton.onClick.AddListener(removeItem);
        resetButton.onClick.AddListener(resetItem);
        publishButton.onClick.AddListener(publish);
        removeButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        publishButton.gameObject.SetActive(false);

        EventPool.OptIn("changedImage", changedImage);

        showImage();
    }

    void removeSelectedItem()
    {
        removeButton.gameObject.SetActive(false);
    }

    void showImage()
    {
        string imageName = MeituManager.Instance.getImageName();
        Utils.destroyAllChildren(imageParent);
        if (imageName != null)
        {
            var go = Instantiate(Resources.Load<GameObject>("MeituImage/" + imageName), imageParent);
            go.name = imageName;
            hasLoadedImage = true;
        }
        else
        {
            hasLoadedImage = false;
        }
    }

    void changedImage()
    {
        if (!hasLoadedImage)
        {
            return;
        }
        resetButton.gameObject.SetActive(true);
        publishButton.gameObject.SetActive(true);
    }
    void selectItem(MeituEditableItem item)
    {
        if (!hasLoadedImage)
        {
            return;
        }
        removeButton.gameObject.SetActive(true);
    }
    void unselectItem()
    {
        if (!hasLoadedImage)
        {
            return;
        }
        removeButton.gameObject.SetActive(false);
    }

    void removeItem()
    {
        if (!hasLoadedImage)
        {
            return;
        }
        MeituSelectManager.Instance.removeSelected();
    }
    void resetItem()
    {
        if (!hasLoadedImage)
        {
            return;
        }
        removeButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        publishButton.gameObject.SetActive(false);
        showImage();
    }

    void publish()
    {
        MeituManager.Instance.publish();
        removeButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        publishButton.gameObject.SetActive(false);
        showImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
