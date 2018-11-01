using Rehab.Popups.Plan;
using Rehab.Popups.Test;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rehab
{
    public class UIMiniGameDragger : MonoBehaviour2
    {
        private bool dragging = false;

        private Vector2 originalPosition;

        private Transform objectToDrag;
        private Image objectToDragImage;

        List<RaycastResult> hitObjects = new List<RaycastResult>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnUserMouseDown();

            if (dragging)
                objectToDrag.position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
                OnUserMouseUp();
        }

        private void OnUserMouseDown()
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag == null)
                return;

            dragging = true;
            objectToDrag.SetAsLastSibling();

            originalPosition = objectToDrag.position;
            objectToDragImage = objectToDrag.GetComponent<Image>();
            objectToDragImage.raycastTarget = false;
        }

        private void OnUserMouseUp()
        {
            if (objectToDrag)
            {
                GameObject objectCatcher = GetCatcherUnderMouse();

                if (objectCatcher)
                {
                    var solution = objectToDrag.GetComponent<DragSolution>();
                    objectCatcher.GetComponent<DragAnswer>().TryMatch(solution);
                }

                objectToDrag.position = originalPosition;
                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }
            dragging = false;
        }

        private GameObject GetObjectUnderMouse()
        {
            var pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            EventSystem.current.RaycastAll(pointer, hitObjects);

            if (hitObjects.Count <= 0)
                return null;

            return hitObjects[0].gameObject;
        }

        private GameObject GetCatcherUnderMouse()
        {
            var pointer = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            EventSystem.current.RaycastAll(pointer, hitObjects);

            for(int i = 0; i < hitObjects.Count; i++)
            {
                var hitted = hitObjects[i].gameObject;

                if (hitted && hitted.tag == Constans.CATCHER_TAG)
                    return hitted;
            }
            return null;
        }

        private GameObject GetParent(GameObject gameObject)
        {
            return gameObject.transform.parent.gameObject;
        }

        private Transform GetDraggableTransformUnderMouse()
        {
            GameObject clickedObject = GetObjectUnderMouse();

            if (clickedObject && clickedObject.tag == Constans.DRAGGABLE_TAG)
                return clickedObject.transform;
            else
                return null;
        }
    }
}
