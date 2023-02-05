using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public int currentLevel;
    private Player player;
    private Vector3 playerDefaultPosition;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt(key: "Level", defaultValue: 0);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerDefaultPosition = player.transform.position;
    }
    public void StartLevel()
    {
        levels[currentLevel%levels.Length].gameObject.SetActive(true);
        
        player.transform.position = playerDefaultPosition;

    }

    public void StartNextLevel()
    {
        levels[currentLevel % levels.Length].ResetLevel();
        levels[currentLevel%levels.Length].gameObject.SetActive(false);
        currentLevel++;
        StartLevel();
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
    }

    public void EndLevel()
    {
 
    }
    private void Update()
    {
        
    }


}
