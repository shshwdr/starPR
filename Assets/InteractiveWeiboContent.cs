using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveWeiboContent : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI m_TextMeshPro;
    Camera m_Camera;
    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
       // m_Camera = Camera.main;
    }
    void LateUpdate()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);
        if (linkIndex != -1)
        {

            TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
            Debug.Log("link click " + linkInfo.GetLinkText() +" id "+ linkInfo.GetLinkID());
            WeiboKeywordsManager.Instance.addKeywordCount(linkInfo.GetLinkText());
        }
    }
}
