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

    bool isSkipButton = false;

    public void FadeOutButton()     //이미지 클릭 시 이미지 fadeout 및 endingcredit 올라오도록 설정
    {
        GameObject background = GameObject.Find("Image");

        StartCoroutine(FadeOutCoroutine(background));
        StartCoroutine(EndingCreditCoroutine());
    }

    public void SkipButton()        //엔딩 크레딧 이미지 버튼 클릭 시, 올라가는 속도 증가
    {
        isSkipButton = true;
    }

    IEnumerator FadeOutCoroutine(GameObject Object)     //이미지의 a 값을 0이 될 때까지 줄여 fade out 효과 만듦
    {
        float fadeCount = 1f;

        while(fadeCount > 0f)
        {
            fadeCount -= 0.0008f;
            yield return new WaitForSeconds(0.001f);
            image.color = new Color(255f, 255f, 255f, fadeCount);

            if(fadeCount < 0.001f )
            {
                Object.SetActive(false);
            }
        }
    }
    IEnumerator EndingCreditCoroutine()     //이미지 fade out 이후 ending credit 서서히 올라오도록 설정
    {
        float posY = 2f;
        int count = 0;

        while (count < 2500)
        {
            if(isSkipButton)        //ending credit 이미지 클릭 시, 올라가는 속도 증가
            {
                isSkipButton = false;
                posY += 2f;
            }

            endingCredit.transform.position += Vector3.up * posY;

            if (endingCredit.transform.position.y > 2550f)
                yield break;

            count++;

            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(5f);

        Application.Quit();     //ending credit 다 올라간 이후 게임 종료
    }


}
