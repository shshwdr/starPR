using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeituEditableItem : MonoBehaviour
    {
        [HideInInspector]
        public float radius;
        
        // Start is called before the first frame update
        void Start()
        {
            if(GameObject.Find("meitu Canvas"))
        {
            //bad code
            var canvas = GameObject.Find("meitu Canvas").GetComponent<Canvas>();
            //Vector2 sizeDelta = GetComponent<RectTransform>().sizeDelta;
            Vector2 canvasScale = new Vector2(canvas.transform.localScale.x, canvas.transform.localScale.y);

            //Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);
            radius = Mathf.Max(GetComponent<RectTransform>().rect.width * canvasScale.x, GetComponent<RectTransform>().rect.height * canvasScale.y);
        }


        }
    public void select()
    {

        var renderer = GetComponent<Image>();
        
            var mat = renderer.material;

            mat.EnableKeyword("OUTBASE_ON");
        
    }

    public void deselect()
    {

        var renderer = GetComponent<Image>();

        var mat = renderer.material;

        mat.DisableKeyword("OUTBASE_ON");
    }

        // Update is called once per frame
        void Update()
        {

        }
    }
