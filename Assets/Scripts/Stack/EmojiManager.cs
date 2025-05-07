using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManager : MonoBehaviour
{
    public EmojiEffect[] emojis;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandEmoji()
    {
        int index = Random.Range(0,emojis.Length);
        emojis[index].Show();
    }
}
