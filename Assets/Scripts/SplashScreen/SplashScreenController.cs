﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UI = UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{

    [SerializeField]
    GameNameGenerator nameGenerator = null;

    [SerializeField]
    UI.Text gameNameLabel = null;

    [SerializeField]
    private bool hasCues = true;


    // Start is called before the first frame update
    void Start()
    {
        EventLogger.SetName(nameGenerator.Name());
        gameNameLabel.text = nameGenerator.Name();
        CueManager.SetCues(hasCues);
        EventLogger.Log(EventLog.EventCode.GameHasCues(CueManager.HasCues()));
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(MutationManager.MutationName()+"");
        }
        if (Input.GetKeyUp(KeyCode.F12))
        {
            hasCues = !hasCues;
            CueManager.SetCues(hasCues);
            EventLogger.Log(EventLog.EventCode.GameHasCues(CueManager.HasCues()));
        }
    }
}
