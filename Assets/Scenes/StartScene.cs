using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class StartScene : MonoBehaviour
{
    private void Start()
    {
        Bridge.Initialize(isInitialized =>
        {
            if (isInitialized)
            {
                Debug.Log("Initialized");
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }
}