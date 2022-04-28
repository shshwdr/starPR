using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiboContentsView : MonoBehaviour
{
    OneWeiboCell[] weiboCells;

    // Start is called before the first frame update
    void Awake()
    {
        weiboCells = GetComponentsInChildren<OneWeiboCell>(true);
        EventPool.OptIn("updateWeibos", updateWeibos);
    }

    void updateWeibos()
    {
        var currentWeibos = WeiboManager.Instance.CurrentWeibos;
        int i = 0;
        for (; i < Mathf.Min( currentWeibos.Count, weiboCells.Length); i++)
        {
            weiboCells[i].gameObject.SetActive(true);
            weiboCells[i].init(currentWeibos[i]);
        }
        for(;i< weiboCells.Length; i++)
        {

            weiboCells[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
