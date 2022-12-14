﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISettings : MonoBehaviour
{
    public GameObject panelPluginLogs;
    public TMP_Text pluginLogs;
    void Start()
    {
        
    }
    void Update()
    {
        if (panelPluginLogs.activeSelf)
            pluginLogs.text = "Saved last score: " + SquareLoggerImpl.GetLastScore();
    }

    public void ActivateLogs()
    {
        panelPluginLogs.SetActive(!panelPluginLogs.activeSelf);
    }

    public void DisableLogs()
    {
        panelPluginLogs.SetActive(false);
    }
}
