using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader SN;
    public UnityEngine.UI.Toggle Music_Play;

    private void Awake()
    {
        SN = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play_Sound("BG");
        Music_Play.onValueChanged.AddListener(OnToggleValueChanged);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        SceneManager.LoadScene("Setting");
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            FindObjectOfType<AudioManager>().Stop_Sound("BG");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play_Sound("BG");
        }
    }
}