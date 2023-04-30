using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Message[] messages;
    public Actor[] actors;
    [System.Serializable]
    public class Message
    {
        public int actorId;
        public string message;
    }

    [System.Serializable]
    public class Actor
    {
        public Sprite sprite;
    }
}
