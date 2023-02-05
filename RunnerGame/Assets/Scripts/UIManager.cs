using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button btnStart, btnNextLevel;
    public GameObject menuUI, InGameUI, endUI;
    private GameManager gameManager;
    public TextMeshProUGUI txtLevel;
    void Start()
    {
        SetBindings();
        gameManager= GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    private void SetBindings()
    {
        btnStart.onClick.AddListener(call: () =>
        {
            menuUI.SetActive(false);
            gameManager.StartGame();
            InGameUI.SetActive(true);
        }
        );
        btnNextLevel.onClick.AddListener(call: () =>
        {
            gameManager.StartNextGame();
            endUI.SetActive(false);
            InGameUI.SetActive(true);
            
        });
    }
    public void UpdateLevelText(int level)
    {
        txtLevel.text = "LEVEL "+(level+1);
    }

    void Update()
    {
        
    }

    internal void EndLevel()
    {
        InGameUI.SetActive(false);
        endUI.SetActive(true);
    }
}
