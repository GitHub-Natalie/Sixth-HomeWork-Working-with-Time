using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLock : MonoBehaviour
{
    int[] GameCode = new int[3] { 4, 7, 6 };
    int[] CurrentCode = new int[3] { 2, 8, 4 };

    [SerializeField] private Sprite[] Numbers;

    public Text timerText;

    public GameObject OpenDoorPanel;
    public GameObject WinPanel;
    public GameObject FailPanel;

    public GameObject ButtonWithRune01;
    public GameObject ButtonWithRune02;
    public GameObject ButtonWithRune03;

    public GameObject Number01;
    public GameObject Number02;
    public GameObject Number03;

    public float startTime = 60f;

    public void Start()
    {
        timerText.text = startTime.ToString();
        ChangeSprites();
    }

    /// <summary>
    ///  Метод для подсчета и вывода оставшегося времени
    /// </summary>
    void Update()
    {
        startTime -= Time.deltaTime;

        if (startTime > 0)
        {
            if (CurrentCode[0] != GameCode[0] || CurrentCode[1] != GameCode[1] || CurrentCode[2] != GameCode[2])
            {
                timerText.text = Mathf.Round(startTime).ToString();
            }
            else if (CurrentCode[0] == GameCode[0] && CurrentCode[1] == GameCode[1] && CurrentCode[2] == GameCode[2])
            {
                Time.timeScale = 0;
                WinPanel.gameObject.SetActive(true);
            }
        }
        else if (startTime < 0)
        {
            timerText.text = "0";
            FailPanel.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Метод для изменения текущего значения первого числа кода
    /// </summary>
    public void Button01Click()
    {
        CurrentCode[0] += 1;
        CurrentCode[1] -= 1;
        CurrentCode[2] = CurrentCode[2];

        for (int i = 0; i < 3; i++)
        {
            if (CurrentCode[i] > 9) CurrentCode[i] -= 10;
            if (CurrentCode[i] < 0) CurrentCode[i] += 10;
        }

        ChangeSprites();
    }

    /// <summary>
    /// Метод для изменения текущего значения второго числа кода
    /// </summary>
    public void Button02Click()
    {
        CurrentCode[0] -= 1;
        CurrentCode[1] += 2;
        CurrentCode[2] -= 1;

        for (int i = 0; i < 3; i++)
        {
            if (CurrentCode[i] > 9) CurrentCode[i] -= 10;
            if (CurrentCode[i] < 0) CurrentCode[i] += 10;
        }

        ChangeSprites();
    }

    /// <summary>
    /// Метод для изменения текущего значения третьего числа кода
    /// </summary>
    public void Button03Click()
    {
        CurrentCode[0] -= 1;
        CurrentCode[1] += 1;
        CurrentCode[2] += 1;

        for (int i = 0; i < 3; i++)
        {
            if (CurrentCode[i] > 9) CurrentCode[i] -= 10;
            if (CurrentCode[i] < 0) CurrentCode[i] += 10;
        }

        ChangeSprites();
    }

    /// <summary>
    /// Метод для смены изображения чисел
    /// </summary>
    void ChangeSprites()
    {
        Number01.GetComponent<Image>().sprite = Numbers[CurrentCode[0]];
        Number02.GetComponent<Image>().sprite = Numbers[CurrentCode[1]];
        Number03.GetComponent<Image>().sprite = Numbers[CurrentCode[2]];
    }

    /// <summary>
    /// Метод для перезапуска игрового меню со взломом замка
    /// </summary>
    public void RestartOpenLock()
    {
        CurrentCode = new int[3] { 2, 8, 4 };
        FailPanel.gameObject.SetActive(false);
        startTime = 60f;
        Start();
    }
}
