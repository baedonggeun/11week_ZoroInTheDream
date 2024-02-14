using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject fadeOutImage;
    [SerializeField] private Transform endingCredit;

    public void FadeOutButton()
    {
        StartCoroutine(FadeOutCoroutine());
        StartCoroutine(EndingCreditCoroutine());
    }

    IEnumerator FadeOutCoroutine()
    {
        float fadeCount = 1f;

        while(fadeCount > 0f)
        {
            fadeCount -= 0.0005f;
            yield return new WaitForSeconds(0.001f);
            image.color = new Color(255f, 255f, 255f, fadeCount);

        }
    }


    IEnumerator EndingCreditCoroutine()
    {

        float posY = 2f;
        int count = 0;

        while (count < 2500)
        {
            endingCredit.transform.position += Vector3.up * posY;

            count++;

            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(5f);

        Application.Quit();
    }
}
