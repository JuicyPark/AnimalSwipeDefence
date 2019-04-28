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
        [SerializeField] DialogueTrigger guide;
        [SerializeField] GameObject dialougePanel;
        [SerializeField] GameObject exitButton;
        [SerializeField] GameObject[] guideImage;
        Queue<string> sentences;

        void Start()
        {
            EventManager.Instance.onClick += GuideCheck1;

            sentences = new Queue<string>();
            if (PlayerPrefs.GetInt("Tutorial").Equals(0))
            {
                dialougePanel.SetActive(true);
                guide.TriggerDialogue();
                exitButton.SetActive(false);
            }
            else
                EventManager.Instance.onClick -= GuideCheck1;
        }

        public void StartDialogue(Dialogue dialogue)
        {
            dialogueAnimator.SetBool("IsOpen", true);
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
                sentences.Enqueue(sentence);
            DisplaySentence();
        }

        public void DisplaySentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            else if (sentences.Count == 10)
            {
                guideImage[3].SetActive(true);
                NextSentence();
            }
            else if (sentences.Count == 8)
            {
                guideImage[0].SetActive(true);
                NextSentence();
            }
            else if (sentences.Count == 7)
            {
                guideImage[1].SetActive(true);
                NextSentence();
            }
            else if (sentences.Count == 6)
            {
                guideImage[0].SetActive(false);
                guideImage[1].SetActive(false);
                NextSentence();
            }
            else if (sentences.Count == 5)
            {
                guideImage[2].SetActive(true);
                NextSentence();
            }
            else if (sentences.Count == 3)
            {
                guideImage[2].SetActive(false);
                NextSentence();
            }
            else if (sentences.Count != 12 && sentences.Count != 9)
                NextSentence();
        }

        public void NextSentence()
        {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            BlockManager.Instance.clickAble = false;
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
            if (sentences.Count == 12 || sentences.Count == 9)
                BlockManager.Instance.clickAble = true;
        }

        void EndDialogue()
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            BlockManager.Instance.clickAble = true;
            exitButton.SetActive(true);
            dialogueAnimator.SetBool("IsOpen", false);
        }

        void GuideCheck1()
        {
            NextSentence();
            EventManager.Instance.onClick -= GuideCheck1;
            EventManager.Instance.onMove += GuideCheck2;
        }
        void GuideCheck2()
        {
            guideImage[3].SetActive(false);
            NextSentence();
            EventManager.Instance.onMove -= GuideCheck2;
        }
    }
}