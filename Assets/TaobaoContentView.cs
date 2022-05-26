using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaobaoContentView : MonoBehaviour
{
    OneTaobaoCell[] taobaoCells;

    // Start is called before the first frame update
    void Start()
    {
        taobaoCells = GetComponentsInChildren<OneTaobaoCell>(true);
        //EventPool.OptIn("updateWeibos", updateWeibos);
        updateTaobaos();
    }

    void updateTaobaos()
    {
        var currentWeibos = TaobaoManager.Instance.unlockedItems;
        int i = 0;
        for (; i < Mathf.Min(currentWeibos.Count, taobaoCells.Length); i++)
        {
            taobaoCells[i].gameObject.SetActive(true);
            taobaoCells[i].init(currentWeibos[i]);
        }
        for (; i < taobaoCells.Length; i++)
        {

            taobaoCells[i].gameObject.SetActive(false);
        }
    }
}
