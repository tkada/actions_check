using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MessageFromStreamingAssets : MonoBehaviour
{
    [SerializeField] Text text;

    private void Start()
    {
        try
        {
            using (StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/message.txt"))
            {
                text.text = sr.ReadToEnd();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }
    }
}
