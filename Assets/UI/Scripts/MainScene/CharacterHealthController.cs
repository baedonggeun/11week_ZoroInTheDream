using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterHealthController : MonoBehaviour
{
    public Image Health;

    private void Start()        //초기 체력 5칸으로 설정
    {
        Health.fillAmount = 1f;

    }

    public void TakePhisicalDamage()        //데미지 받았을 경우 체력 1칸씩 깍이도록 설정
    {
        Health.fillAmount -= 0.2f;
    }
}


