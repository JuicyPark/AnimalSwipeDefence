using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace Map
{
    public class Block : MonoBehaviour
    {
        enum Type { None, Player, Enemy }
        LayerMask blockLayerMask = 1 << 8;

        [SerializeField] Type blockType;

        public SpriteRenderer _spriteRenderer;
        public int positionX;
        public int positionY;
        public int animalIndex;
        public int animalLevel;

        public void MixCheck()
        {
            if (blockType.Equals(Type.Player))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f, blockLayerMask);
                foreach (Collider hit in hitColliders)
                {
                    Block targetBlock = hit.GetComponent<Block>();
                    if (!transform.name.Equals(hit.transform.name) && targetBlock.blockType.Equals(blockType)
                        && targetBlock.animalLevel.Equals(animalLevel) && targetBlock.animalIndex.Equals(animalIndex))
                    { 
                        MixBlock(targetBlock);
                        return;
                    }
                }
            }
        }

        void MixBlock(Block targetBlock)
        {
            animalLevel++;
            animalIndex = Random.Range(0, AnimalInformation.Instance.level[animalLevel].animalSprite.Length);
            _spriteRenderer.sprite = AnimalInformation.Instance.level[animalLevel].animalSprite[animalIndex];

            targetBlock.animalLevel = 0;
            targetBlock.animalIndex = 0;
            targetBlock.blockType = Type.None;
            targetBlock._spriteRenderer.sprite = AnimalInformation.Instance.noneSprite;
        }
    }
}
