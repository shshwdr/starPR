using Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHeaderView : MonoBehaviour
{
    [SerializeField]
    Text hp;
    [SerializeField]
    Text fans;
    [SerializeField]
    Text money;

    // Start is called before the first frame update
    void Awake()
    {
        EventPool.OptIn("updateFans", updateFans);
        EventPool.OptIn("updateHP", updateHP);
        EventPool.OptIn("updateMoney", updateMoney);
    }

    void updateFans()
    {
        fans.text = ResourceManager.Instance.getFansCount().ToString();
    }

    void updateHP()
    {
        hp.text = ResourceManager.Instance.getHP().ToString();

    }
    void updateMoney()
    {

        money.text = ResourceManager.Instance.getMoney().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
