using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;

    private void Start()
    {
        Canvas c = GetComponentInChildren(typeof(Canvas)) as Canvas;
        Text t = c.GetComponentInChildren(typeof(Text)) as Text;
        t.text = username;

    }
}
