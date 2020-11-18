using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public Sprite maiaFaceSprite;
    public Sprite bodyFaceSprite;
    public Sprite completeHeartSprite;
    public Sprite halfHeartSprite;
    public BodyHealthManager bodyHealthManager;

    void Update()
    {
        TranslateHealthToHearts();
    }

    private Image CreateHeartImage(Vector2 position, Sprite heartSprite)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        heartGameObject.GetComponent<RectTransform>().anchoredPosition = position;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(68, 59);

        Image heartImage = heartGameObject.GetComponent<Image>();
        heartImage.sprite = heartSprite;

        return heartImage;
    }

    private Image AddFaceToUI(Sprite face)
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Face")
            {
                Destroy(child.gameObject);
            }
        }
        GameObject faceGameObject = new GameObject("Face", typeof(Image));

        faceGameObject.transform.SetParent(transform);
        faceGameObject.transform.localPosition = Vector3.zero;

        faceGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(450, -220);
        faceGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 540);

        Image faceImage = faceGameObject.GetComponent<Image>();
        faceImage.sprite = face;

        return faceImage;
    }

    private void TranslateHealthToHearts()
    {
        foreach (Transform child in transform)
        {
            if(child.name == "Heart")
            {
                Destroy(child.gameObject);
            }
        }
        var attachedBodyHealth = 0;

        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().isInputEnabled)
        {
            AddFaceToUI(bodyFaceSprite);
            attachedBodyHealth = bodyHealthManager.currentHealth;
        }
        else
        {
            AddFaceToUI(maiaFaceSprite);
            if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().canBeDamaged)
            {
                attachedBodyHealth = bodyHealthManager.currentHealth;
            }
        }

        var completeHeartCount = attachedBodyHealth / 10;
        var halfHeartCount = 0;
        if (attachedBodyHealth % 10 != 0)
        {
            halfHeartCount = 1;
        }
        int count;
        for (count = 1; count <= completeHeartCount; count++)
        {
            CreateHeartImage(new Vector2(120 + 80 * count, -50), completeHeartSprite);
        }
        if (halfHeartCount == 1)
        {
            CreateHeartImage(new Vector2(120 + 80 * count, -50), halfHeartSprite);
        }
    }
}