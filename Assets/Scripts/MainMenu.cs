using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainPage, optionsPage;
    public Slider gtimeSlider, enemySlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        Global.GameTime = gtimeSlider.value;
        Global.EnemySpawnTime = enemySlider.value;
        SceneManager.LoadScene("Game");
    }
    public void OptionsButton()
    {
        optionsPage.SetActive(true);
        mainPage.SetActive(false);
    }
    public void BackButton()
    {
        mainPage.SetActive(true);
        optionsPage.SetActive(false);
    }
}
