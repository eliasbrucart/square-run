using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISettings : MonoBehaviour
{
    public GameObject panelPluginLogs;
    public TMP_Text pluginLogs;
    void Start()
    {
        SquareLoggerImpl.UpdateLogText += UpdateTextOfLogs;
    }

    private void OnDisable()
    {
        SquareLoggerImpl.UpdateLogText -= UpdateTextOfLogs;
    }

    void Update()
    {
        if (panelPluginLogs.activeSelf)
            pluginLogs.text = SquareLoggerImpl.GetInstance().ReadFile(" ");
    }

    public void DeleteLogs()
    {
        SquareLoggerImpl.GetInstance().ShowAlert();
    }

    public void ActivateLogs()
    {
        panelPluginLogs.SetActive(!panelPluginLogs.activeSelf);
    }

    public void UpdateTextOfLogs(string text)
    {
        pluginLogs.text = text;
    }

    public void DisableLogs()
    {
        panelPluginLogs.SetActive(false);
    }
}
