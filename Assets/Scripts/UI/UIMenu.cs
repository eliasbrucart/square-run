using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardsPanel;
    [SerializeField] private GameObject menuPanel;

    private void Start()
    {
        PlayGames.Init();
    }

    public void ToggleLeaderboardsPanel()
    {
        leaderboardsPanel.SetActive(!leaderboardsPanel.activeSelf);
    }

    public void ToggleMenuPanel()
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }
}
