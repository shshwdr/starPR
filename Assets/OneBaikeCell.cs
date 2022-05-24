using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneBaikeCell : MonoBehaviour
{

    [SerializeField]
    TMP_Text keyword;
    [SerializeField]
    TMP_Text content;
    BaikeEntryInfo baikeInfo;
    public void init(BaikeEntryInfo _info)
    {
        baikeInfo = _info;
        updateBaikeCell();
    }
    public void updateBaikeCell()
    {
        keyword.text = baikeInfo.keyword;
        content.text = baikeInfo.content;
    }
}
