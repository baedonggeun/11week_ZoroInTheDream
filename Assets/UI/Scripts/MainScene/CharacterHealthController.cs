using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IDamagable
{

}

public class CharacterHealthController : MonoBehaviour, IDamagable
{
    public Image Health;

    private void Start()
    {
        Health.fillAmount = 1f;

    }

    public void TakePhisicalDamage()
    {
        Health.fillAmount -= 0.2f;
    }
}


