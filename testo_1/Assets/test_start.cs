using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_start : MonoBehaviour
{
    public NetworkingManager networking;
    // Start is called before the first frame update
    void Start()
    {
        networking.StartHost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
