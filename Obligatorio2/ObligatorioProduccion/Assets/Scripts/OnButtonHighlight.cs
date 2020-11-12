using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
    }
}
