using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Device;

public class StartScreenPilot : MonoBehaviour
{
    [SerializeField] private GameObject instructorCheckBox;
    [SerializeField] private float timer;
    [SerializeField] private Toggle pilotToggle;
    [SerializeField] private Toggle instructorToggle;
    private bool startedCount = false;

    void Update()
    {
        if (GameManager.Singleton.sharedGameState != null)
        {
            instructorCheckBox.SetActive(GameManager.Singleton.sharedGameState.instructorInvitedToStart.Value);
            bool ready = GameManager.Singleton.sharedGameState.instructorInvitedToStart.Value && GameManager.Singleton.sharedGameState.pilotInvitedToStart.Value;
            if (ready || startedCount)
            {
                timer -= Time.fixedDeltaTime;
                startedCount = true;
            }
            if (timer < 0)
            { 
                this.gameObject.SetActive(false);
                GameObject.FindObjectOfType<PilotManager>().resumeTheGame();
                Destroy(this);
            }
        }

    }
}
