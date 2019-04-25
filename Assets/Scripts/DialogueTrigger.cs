using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] Dialogue dialogue;

        public void TriggerDialogue()=>DialogueManager.Instance.StartDialogue(dialogue);
    }
}