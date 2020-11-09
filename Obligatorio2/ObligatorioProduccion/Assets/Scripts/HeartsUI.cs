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
    public BodyDetachController bdc;

    void Start()
    {
        bdc = GameObject.FindGameObjectWithTag("Body").GetComponent<BodyDetachController>();
    }


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().canBeDamaged)
        {
            TranslateHealthToHearts();
        }
        else
        {
            TranslateHealthToHearts();
        }
    }

    private Image CreateHeartImage(Vector2 position, Sprite heartSprite)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;

        heartGameObject.GetComponent<RectTransform>().anchoredPosition = position;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(960, 540);

        Image heartImage = heartGameObject.GetComponent<Image>();
        heartImage.sprite = heartSprite;

        return heartImage;
    }

    private Image AddFaceToUI(Sprite face)
    {
        GameObject faceGameObject = new GameObject("Face", typeof(Image));

        faceGameObject.transform.SetParent(transform);
        faceGameObject.transform.localPosition = Vector3.zero;

        faceGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(200, -50);
        faceGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 270);

        Image faceImage = faceGameObject.GetComponent<Image>();
        faceImage.sprite = face;

        return faceImage;
    }

    private void TranslateHealthToHearts()
    {
        transform.DetachChildren();
        var attachedBodyHealth = 0;

        if (GameObject.FindGameObjectWithTag("Body").GetComponent<BodyController>().canBeDamaged)
        {
            AddFaceToUI(bodyFaceSprite);
            attachedBodyHealth = bodyHealthManager.currentHealth;
        }
        else
        {
            AddFaceToUI(maiaFaceSprite);
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
            CreateHeartImage(new Vector2(110 + 110 * count, 5), completeHeartSprite);
        }
        if (halfHeartCount == 1)
        {
            CreateHeartImage(new Vector2(110 + 110 * count, 5), halfHeartSprite);
        }
    }
}