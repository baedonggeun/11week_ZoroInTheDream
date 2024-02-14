using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInformation : MonoBehaviour
{
    [SerializeField] private GameObject characterInformation;
    public void OnCloseButton()     //게임 시간 다시 흐르고 상태창 닫음
    {
        Time.timeScale = 1f;
        characterInformation.SetActive(false);
    }
}
