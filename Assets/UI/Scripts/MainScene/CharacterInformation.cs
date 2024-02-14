using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : MonoBehaviour
{
    [SerializeField] private GameObject characterInformation;
    public void OnCloseButton()
    {
        Time.timeScale = 1f;
        characterInformation.SetActive(false);
    }
}
