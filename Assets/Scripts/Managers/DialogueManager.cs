using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InGame;
using Service;

namespace Manager
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        [SerializeField] Text dialogueText;
        [SerializeField] Animator dialogueAnimator;

        Queue<string> sentences;

        void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            dialogueAnimator.SetBool("IsOpen", true);
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
                sentences.Enqueue(sentence);
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }

        void EndDialogue()
        {
            dialogueAnimator.SetBool("IsOpen", false);
        }
    }
}