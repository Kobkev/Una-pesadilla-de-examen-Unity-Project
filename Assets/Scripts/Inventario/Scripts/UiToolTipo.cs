using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToolTipo : MonoBehaviour
{

    [SerializeField] private RectTransform canvasRectTransform;
    private RectTransform rectTransform;
    private RectTransform backgroundRectTransform;



    private void Awake()
    {
        rectTransform = transform.GetComponent<RectTransform>();
        backgroundRectTransform = transform.Find("ItemInfo").GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;

        if (anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width)
        {
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }
        if (anchoredPosition.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height)
        {
            anchoredPosition.y = canvasRectTransform.rect.height - backgroundRectTransform.rect.height;
        }
        rectTransform.anchoredPosition = anchoredPosition;
    }
}
