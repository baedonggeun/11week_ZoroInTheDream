using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform trsMenu;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject characterInformaion;

    bool menuOpened;

    private void Start()
    {
        background.SetActive(false);
        menuOpened = false;
    }
    IEnumerator SlideMenuBar()
    {
        int count = 0;

        if(menuOpened)
        {
            while (count < 50)
            {
                float posY = 3.1f;

                trsMenu.transform.position += Vector3.left * posY;

                count++;

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }
        else if(!menuOpened)
        {
            while (count < 50)
            {
                float posY = 3.1f;

                trsMenu.transform.position += Vector3.left * -posY;

                count++;

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }
        
    }

    public void OnClickMenu()
    {
        if(!menuOpened)
        {
            background.SetActive(true);

            menuOpened = true;

            StartCoroutine("SlideMenuBar");
        }
        else if(menuOpened)
            MenuClose();
    }

    public void MenuClose()
    {
        background.SetActive(false);

        menuOpened = false;

        StartCoroutine("SlideMenuBar");
    }

    public void OnContinueButton()
    {
        MenuClose();
    }

    public void OnCharacterInformaionButton()
    {
        Time.timeScale = 0f;
        characterInformaion.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
