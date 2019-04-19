using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

namespace InGame
{
    public class Block : MonoBehaviour
    {
        public enum Type { None, Player, Enemy }
        public Type blockType;
        
        public SpriteRenderer _spriteRenderer;
        public int positionX;
        public int positionY;
        public int animalIndex;
        public int animalLevel;

        public void ClickBlock()
        {
            if (blockType.Equals(Type.Player))
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.5f, BlockManager.Instance.blockLayerMask);
                ClickManager.Instance.ClickPlayerBlock(hitColliders);
            }
            else if (blockType.Equals(Type.None))
                ClickManager.Instance.ClickNoneBlock();
        }
    }
}
