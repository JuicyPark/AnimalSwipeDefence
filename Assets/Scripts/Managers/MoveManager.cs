﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;

namespace Manager
{
    public class MoveManager : MonoBehaviour
    {
        enum Direction { None, MoveToX, MoveToY }

        Vector2 startTouch;
        Vector2 endTouch;
        Vector2 moveTouch;
        int blockNumber = 49;
        float dragDistance;

        [SerializeField]
        Block selectBlock;
        [SerializeField]
        Block[] selectBlocks = new Block[7];
        [SerializeField]
        Block[] blocks;
        [SerializeField]
        Transform field;

        Direction currentDirection = Direction.None;

        public float touchSenstive = 50f;

        void Update()
        {
            DragBlock();
        }
        void DragBlock()
        {
            // BeganDrag
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouch = Input.GetTouch(0).position;

                SelectBlock();
            }

            // EndedDrag
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (selectBlock == null)
                    return;

                endTouch = Input.GetTouch(0).position;
                if (currentDirection.Equals(Direction.None))
                {
                    if (endTouch.x - startTouch.x > touchSenstive || endTouch.x - startTouch.x <= -touchSenstive)
                    {
                        dragDistance = endTouch.x - startTouch.x;
                        SetSelectBlocks(Direction.MoveToX);
                        currentDirection = Direction.MoveToX;
                        dragDistance = Normalize(dragDistance);
                        ChangePositionX(dragDistance);
                        StartCoroutine(CMoveHorizontal(dragDistance));
                    }
                    else if (endTouch.y - startTouch.y > touchSenstive || endTouch.y - startTouch.y < -touchSenstive)
                    {
                        dragDistance = endTouch.y - startTouch.y;
                        SetSelectBlocks(Direction.MoveToY);
                        currentDirection = Direction.MoveToY;
                        dragDistance = Normalize(dragDistance);
                        ChangePositionY(dragDistance);
                        StartCoroutine(CMoveVertical(dragDistance));
                    }
                }
                selectBlock = null;
            }
        }

        void SelectBlock()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider != null)
                    selectBlock = hit.transform.gameObject.GetComponent<Block>();
            }
        }

        void SetSelectBlocks(Direction direction)
        {
            int blockIndex = 0;
            for (int i = 0; i < blockNumber; i++)
            {
                if (direction.Equals(Direction.MoveToX) && selectBlock.positionY.Equals(blocks[i].positionY)
                    || direction.Equals(Direction.MoveToY) && selectBlock.positionX.Equals(blocks[i].positionX))
                {
                    selectBlocks[blockIndex] = blocks[i];
                    selectBlocks[blockIndex].transform.SetParent(transform);
                    blockIndex++;
                }
            }
        }

        int Normalize(float value)
        {
            if (value >= 0)
                return 1;
            else
                return -1;
        }

        void ChangePositionX(float direction)
        {
            if (direction < 0)
            {
                for (int i = 0; i < selectBlocks.Length; i++)
                {
                    selectBlocks[i].positionX--;
                    if (selectBlocks[i].positionX.Equals(-1))
                    {
                        selectBlocks[i].positionX = selectBlocks.Length - 1;
                        selectBlocks[i].transform.position = new Vector3(selectBlocks.Length, 0, selectBlocks[i].positionY);
                    }
                }
            }
            else
            {
                for (int i = 0; i < selectBlocks.Length; i++)
                {
                    selectBlocks[i].positionX++;
                    if (selectBlocks[i].positionX.Equals(selectBlocks.Length))
                    {
                        selectBlocks[i].positionX = 0;
                        selectBlocks[i].transform.position = new Vector3(-1, 0, selectBlocks[i].positionY);
                    }
                }
            }
        }

        void ChangePositionY(float direction)
        {
            if (direction < 0)
            {
                for (int i = 0; i < selectBlocks.Length; i++)
                {
                    selectBlocks[i].positionY--;
                    if (selectBlocks[i].positionY.Equals(-1))
                    {
                        selectBlocks[i].positionY = selectBlocks.Length - 1;
                        selectBlocks[i].transform.position = new Vector3(selectBlocks[i].positionX, 0, selectBlocks.Length);
                    }
                }
            }
            else
            {
                for (int i = 0; i < selectBlocks.Length; i++)
                {
                    selectBlocks[i].positionY++;
                    if (selectBlocks[i].positionY.Equals(selectBlocks.Length))
                    {
                        selectBlocks[i].positionY = 0;
                        selectBlocks[i].transform.position = new Vector3(selectBlocks[i].positionX, 0, -1);
                    }
                }
            }
        }

        IEnumerator CMoveHorizontal(float direction)
        {
            float distance = 10f * direction;
            float delay = 0.005f;

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(delay);
                transform.Translate(1 / distance, 0, 0);
            }
            for (int i = 0; i < selectBlocks.Length; i++)
            {
                selectBlocks[i].transform.SetParent(field);
                selectBlocks[i] = null;
            }
            currentDirection = Direction.None;
        }

        IEnumerator CMoveVertical(float direction)
        {
            float distance = 10f * direction;
            float delay = 0.005f;

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(delay);
                transform.Translate(0, 0, 1 / distance);
            }
            for (int i = 0; i < selectBlocks.Length; i++)
            {
                selectBlocks[i].transform.SetParent(field);
                selectBlocks[i] = null;
            }
            currentDirection = Direction.None;
        }
    }
}