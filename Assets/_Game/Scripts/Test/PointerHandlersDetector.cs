using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Test
{
    public class PointerHandlersDetector:MonoBehaviour
    {
        [SerializeField] private Camera miniGameCamera;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Renderer renderTextureRenderer;
        private RenderTextureInputProjector _renderTextureInputProjector;

        private void Awake()
        {
            _renderTextureInputProjector = new(mainCamera, miniGameCamera, renderTextureRenderer);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var pointerDownHandlers = 
                    _renderTextureInputProjector.GetCollisions<IPointerDownHandler>(out PointerEventData pointerEventData);
                foreach (var pointerDownHandler in pointerDownHandlers)
                {
                    pointerDownHandler.OnPointerDown(pointerEventData);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                var pointerDownHandlers = 
                    _renderTextureInputProjector.GetCollisions<IPointerUpHandler>(out PointerEventData pointerEventData);
                pointerDownHandlers.ForEach(pointerDownHandler => pointerDownHandler.OnPointerUp(pointerEventData));
                
            }

            if (Input.GetMouseButton(0))
            {
                var pointerDownHandlers = 
                    _renderTextureInputProjector.GetCollisions<IPointerMoveHandler>(out PointerEventData pointerEventData);
                foreach (var pointerDownHandler in pointerDownHandlers)
                {
                    pointerDownHandler.OnPointerMove(pointerEventData);
                }
            }
        }
    }
}