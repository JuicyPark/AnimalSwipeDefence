using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InGame
{
    public class LobbyAnimal : MonoBehaviour
    {
        [SerializeField] Image Icon;
        [SerializeField] Text description;
        [SerializeField] GameObject descriptionPanel;
        [SerializeField] GameObject modeSelectPanel;

        [TextArea(3, 10)]
        [SerializeField] string animalDescription;
        [SerializeField] Sprite animalIcon;
        void OnMouseUp()
        {
            if (!descriptionPanel.activeSelf && !modeSelectPanel.activeSelf)
            {
                descriptionPanel.SetActive(true);
                Icon.sprite = animalIcon;
                description.text = animalDescription;
            }
        }
        void OnMouseExit() => descriptionPanel.SetActive(false);

    }
}