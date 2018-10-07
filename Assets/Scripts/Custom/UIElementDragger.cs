using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rehab
{
    public class UIElementDragger : MonoBehaviour2
    {
        private bool dragging = false;

        private Vector2 originalPosition;

        private Transform objectToDrag;
        private Image objectToDragImage;

        List<RaycastResult> hitObjects = new List<RaycastResult>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
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

            if (dragging)
            {
                objectToDrag.position = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (objectToDrag)
                {
                    Transform objectToReplace = GetDraggableTransformUnderMouse();

                    if (objectToReplace)
                    {
                        objectToDrag.position = objectToReplace.position;
                        objectToReplace.position = originalPosition;
                    }
                    else
                    {
                        objectToDrag.position = originalPosition;
                    }

                    objectToDragImage.raycastTarget = true;
                    objectToDrag = null;
                }
                dragging = false;
            }
        }

        private GameObject GetObjectUnderMouse()
        {
            var pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            EventSystem.current.RaycastAll(pointer, hitObjects);

            if (hitObjects.Count <= 0)
                return null;

            return hitObjects[0].gameObject;
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
