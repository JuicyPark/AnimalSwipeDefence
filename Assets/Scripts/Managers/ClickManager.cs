using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Service;
using InGame;

namespace Manager
{
    public class ClickManager : Singleton<ClickManager>
    {
        public void ClickPlayerBlock(Collider[] hitColliders)
        {
            foreach (Collider hit in hitColliders)
            {
                Block targetBlock = hit.GetComponent<Block>();
                if (BlockManager.Instance.selectBlock.animalLevel<AnimalInformation.Instance.level.Length-1 && !BlockManager.Instance.selectBlock.transform.name.Equals(hit.transform.name) &&
                    targetBlock.blockType.Equals(BlockManager.Instance.selectBlock.blockType) && targetBlock.animalLevel.Equals(BlockManager.Instance.selectBlock.animalLevel) &&
                    targetBlock.animalIndex.Equals(BlockManager.Instance.selectBlock.animalIndex))
                {
                    MixBlock(targetBlock);
                    return;
                }
            }
        }

        public void ClickNoneBlock()
        {
            if (LevelManager.Instance.resource >= LevelManager.Instance.priceAnimal)
            {
                LevelManager.Instance.DecreaseResource(LevelManager.Instance.priceAnimal);
                BlockManager.Instance.selectBlock.blockType = Block.Type.Player;
                BlockManager.Instance.animalBlock.Add(BlockManager.Instance.selectBlock);
                UIManager.Instance.AnimateResourceUI();
                RandomAnimal();
            }
            EventManager.Instance.onClickInvoke();
        }

        void RandomAnimal()
        {
            BlockManager.Instance.selectBlock.animalIndex = Random.Range(0, AnimalInformation.Instance.level[BlockManager.Instance.selectBlock.animalLevel].animalSprite.Length);
            BlockManager.Instance.selectBlock._spriteRenderer.sprite = AnimalInformation.Instance.level[BlockManager.Instance.selectBlock.animalLevel].animalSprite[BlockManager.Instance.selectBlock.animalIndex];
            if (CatCheck())
                BlockManager.Instance.catNumber++;
            else if (DogCheck())
                BlockManager.Instance.dogNumber++;
            else if (BearCheck())
                BlockManager.Instance.bearNumber++;
        }

        void MixBlock(Block targetBlock)
        {
            if (CatCheck())
                BlockManager.Instance.catNumber -= 2;
            else if (DogCheck())
                BlockManager.Instance.dogNumber -= 2;
            else if (BearCheck())
                BlockManager.Instance.bearNumber -= 2;

            BlockManager.Instance.selectBlock.animalLevel++;
            RandomAnimal();

            targetBlock.animalLevel = 0;
            targetBlock.animalIndex = 0;
            targetBlock.blockType = Block.Type.None;
            targetBlock._spriteRenderer.sprite = AnimalInformation.Instance.noneSprite;
            BlockManager.Instance.animalBlock.Remove(targetBlock);
        }

        bool CatCheck()
        {
            int animalIndex = BlockManager.Instance.selectBlock.animalIndex;
            int animalLevel = BlockManager.Instance.selectBlock.animalLevel;
            if ((animalLevel.Equals(0)&& animalIndex.Equals(1))||
                (animalLevel.Equals(3) && animalIndex.Equals(4)) ||
                (animalLevel.Equals(3) && animalIndex.Equals(6)) ||
                (animalLevel.Equals(4) && animalIndex.Equals(6))) return true;
            return false;
        }

        bool DogCheck()
        {
            int animalIndex = BlockManager.Instance.selectBlock.animalIndex;
            int animalLevel = BlockManager.Instance.selectBlock.animalLevel;
            if ((animalLevel.Equals(0) && animalIndex.Equals(3)) ||
                (animalLevel.Equals(1) && animalIndex.Equals(4)) ||
                (animalLevel.Equals(2) && animalIndex.Equals(2)) ||
                (animalLevel.Equals(2) && animalIndex.Equals(5))) return true;
            return false;
        }
        bool BearCheck()
        {
            int animalIndex = BlockManager.Instance.selectBlock.animalIndex;
            int animalLevel = BlockManager.Instance.selectBlock.animalLevel;
            if ((animalLevel.Equals(3) && animalIndex.Equals(0)) ||
                (animalLevel.Equals(3) && animalIndex.Equals(5)) ||
                (animalLevel.Equals(4) && animalIndex.Equals(3))) return true;
            return false;
        }
    }
}
