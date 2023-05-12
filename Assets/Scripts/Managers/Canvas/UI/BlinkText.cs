using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private float TimeAnim;
    private Text text;

    [SerializeField] private float CustomTimeAnim;

    void Start()
    {
        text = GetComponent<Text>();
        TimeAnim = CustomTimeAnim;
    }

    
    void Update()
    {
        TimeAnim -= Time.deltaTime;

        if(TimeAnim <= 0)
        {
            text.enabled = !text.enabled;
            TimeAnim = CustomTimeAnim;
        }
    }
}
