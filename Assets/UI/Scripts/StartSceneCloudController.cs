using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneCloudController : MonoBehaviour
{
    [SerializeField] GameObject cloud_1;
    [SerializeField] GameObject cloud_2;
    [SerializeField] GameObject cloud_3;
    [SerializeField] GameObject cloud_4;
    [SerializeField] GameObject cloud_5;

    int cloudCount = 0;
    string time_string;
    float time = 0f;

    private void Start()
    {
        CloudActiveFalse();
    }

    private void Update()
    {
        time += Time.deltaTime;

        time_string = time.ToString("N0");

        cloudCount = CloudCountControl(time_string);
        CloudControl(cloudCount, time_string);
    }

    public void CloudControl(int count, string time)
    {
        if (int.Parse(time_string) % 12 == 11)
            CloudActiveFalse();

        switch (count)
        {
            case 1:
                cloud_1.SetActive(true);
                break;
            case 2:
                cloud_2.SetActive(true);
                break;
            case 3:
                cloud_3.SetActive(true);
                break;
            case 4:
                cloud_4.SetActive(true);
                break;
            case 5:
                cloud_5.SetActive(true);
                break;
        }
    }

    public int CloudCountControl(string time)
    {
        int count = 0;

        if(int.Parse(time_string) % 12 == 0)
            count = 1;
        else if(int.Parse(time_string) % 12 == 2)
            count = 2;
        else if(int.Parse(time_string) % 12 == 4)
            count = 3;
        else if (int.Parse(time_string) % 12 == 6)
            count = 4;
        else if (int.Parse(time_string) % 12 == 8)
            count = 5;

        return count;
    }    

    public void CloudActiveFalse()
    {
        cloud_1.SetActive(false);
        cloud_2.SetActive(false);
        cloud_3.SetActive(false);
        cloud_4.SetActive(false);
        cloud_5.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
