using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaikeContentView : MonoBehaviour
{
    OneBaikeCell[] weiboCells;

    // Start is called before the first frame update
    void Start()
    {
        weiboCells = GetComponentsInChildren<OneBaikeCell>(true);
        //EventPool.OptIn("updateWeibos", updateWeibos);
        updateBaikes();
    }

    void updateBaikes()
    {
        var currentWeibos = BaikeManager.Instance.unlockedBaikeEntries();
        int i = 0;
        for (; i < Mathf.Min(currentWeibos.Count, weiboCells.Length); i++)
        {
            weiboCells[i].gameObject.SetActive(true);
            weiboCells[i].init(currentWeibos[i]);
        }
        for (; i < weiboCells.Length; i++)
        {

            weiboCells[i].gameObject.SetActive(false);
        }
    }
}
