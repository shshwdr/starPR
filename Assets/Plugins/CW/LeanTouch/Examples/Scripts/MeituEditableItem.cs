using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class MeituEditableItem : MonoBehaviour
    {
        [HideInInspector]
        public float radius;
        
        // Start is called before the first frame update
        void Start()
        {
            var canvas = GameObject.FindObjectOfType<MeituCanvas>().GetComponent<Canvas>();
            Vector2 sizeDelta = GetComponent<RectTransform>().sizeDelta;
            Vector2 canvasScale = new Vector2(canvas.transform.localScale.x, canvas.transform.localScale.y);

            Vector2 finalScale = new Vector2(sizeDelta.x * canvasScale.x, sizeDelta.y * canvasScale.y);
            radius = Mathf.Max(GetComponent<RectTransform>().rect.width* canvasScale.x, GetComponent<RectTransform>().rect.height* canvasScale.y);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
