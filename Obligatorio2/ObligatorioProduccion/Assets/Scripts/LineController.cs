using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private GameObject soul;
    private GameObject body;
    private LineRenderer line;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    private float posBodyX;
    private float posBodyY;
    private float posSoulX;
    private float posSoulY;
    public GameObject lifelineParticles;
    private GameObject localParticlesMiddle;
    private GameObject localParticlesBody;
    private GameObject localParticlesSoul;
    private GameObject localParticlesCloserBody;
    private GameObject localParticlesCloserSoul;


    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();

        body = GameObject.FindGameObjectWithTag("Body");
        soul = GameObject.FindGameObjectWithTag("Soul");

        line.startWidth = 0.0f;
        line.endWidth = 0.0f;
        line.material = new Material(Shader.Find("Sprites/Default"));

        line.sortingLayerName = "Player";

        line.startColor = line.endColor = new Color(1, 0, 0, 1);
     
        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.cyan;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.35f;
        alphaKey[0].time = 1.0f;
        alphaKey[1].alpha = 0.2f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
     
        line.colorGradient = gradient;

        Vector3 posInit = new Vector3(0, 0, 0);
        localParticlesMiddle = Instantiate(lifelineParticles, posInit, Quaternion.Euler(Vector3.zero));
        localParticlesBody = Instantiate(lifelineParticles, posInit, Quaternion.Euler(Vector3.zero));
        localParticlesSoul = Instantiate(lifelineParticles, posInit, Quaternion.Euler(Vector3.zero));
        localParticlesCloserBody = Instantiate(lifelineParticles, posInit, Quaternion.Euler(Vector3.zero));
        localParticlesCloserSoul = Instantiate(lifelineParticles, posInit, Quaternion.Euler(Vector3.zero));
    }
    

    void Update()
    {
        line.startWidth = 0.0f;
        line.endWidth = 0.0f;

        if (body.GetComponent<BodyController>().canBeDamaged && soul.GetComponent<SoulController>().IsInputEnabled)
        {
            line.startWidth = 0.08f;
            line.endWidth = 0.12f;
            
            line.SetPosition(0, body.transform.localPosition);
            line.SetPosition(1, soul.transform.localPosition);

            posBodyX = body.transform.position.x;
            posBodyY = body.transform.position.y;
            posSoulX = soul.transform.position.x;
            posSoulY = soul.transform.position.y;
            Vector3 posCloserBody = new Vector3((posBodyX + 1 * (posSoulX - posBodyX) / 6), (posBodyY + 1* (posSoulY - posBodyY) / 6), 0);
            Vector3 posCloseBody = new Vector3((posBodyX + 2*(posSoulX - posBodyX) / 6), (posBodyY + 2 * (posSoulY - posBodyY) / 6), 0);
            Vector3 posMiddle = new Vector3((posBodyX + (posSoulX - posBodyX) / 2), (posBodyY + (posSoulY - posBodyY) / 2), 0);
            Vector3 posCloseSoul = new Vector3((posBodyX + 4*(posSoulX - posBodyX) / 6), (posBodyY + 4 * (posSoulY - posBodyY) / 6), 0);
            Vector3 posCloserSoul = new Vector3((posBodyX + 5 * (posSoulX - posBodyX) / 6), (posBodyY + 5 * (posSoulY - posBodyY) / 6), 0);
            localParticlesMiddle.transform.position = posMiddle;
            localParticlesBody.transform.position = posCloseBody;
            localParticlesSoul.transform.position = posCloseSoul;
            localParticlesCloserBody.transform.position = posCloserBody;
            localParticlesCloserSoul.transform.position = posCloserSoul;
            localParticlesMiddle.SetActive(true);
            localParticlesBody.SetActive(true);
            localParticlesSoul.SetActive(true);
            localParticlesCloserBody.SetActive(true);
            localParticlesCloserSoul.SetActive(true);
        }
        else
        {
            localParticlesMiddle.SetActive(false);
            localParticlesBody.SetActive(false);
            localParticlesSoul.SetActive(false);
            localParticlesCloserBody.SetActive(false);
            localParticlesCloserSoul.SetActive(false);
        }

    }
}
