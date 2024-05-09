using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider Sensitivity_slider;
    public TextMeshProUGUI Sensitivity_count;

    // Start is called before the first frame update

    public void Awake()
    {
        Sensitivity_slider.value = PlayerPrefs.GetFloat("Sensitivity", 20);
    }

    private void FixedUpdate()
    {
        Sensitivity_count.text = Sensitivity_slider.value.ToString();
        PlayerPrefs.SetFloat("Sensitivity", Sensitivity_slider.value);
        PlayerControl.speed = Sensitivity_slider.value;
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}