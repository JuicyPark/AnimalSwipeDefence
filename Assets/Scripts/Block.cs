using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class Block : MonoBehaviour
    {
        enum Type {None, Player, Enemy}

        [SerializeField]
        Type blockType;

        public int positionX;
        public int positionY;
    }
}
