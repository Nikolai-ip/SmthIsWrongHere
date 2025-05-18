using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Test
{
    public class RenderTextureInputProjector
    {
        private readonly Camera _mainCamera;
        private readonly Camera _remoteCamera;
        private readonly Renderer _renderTextureRenderer;

        public RenderTextureInputProjector(Camera mainCamera, Camera remoteCamera, Renderer renderTextureRenderer)
        {
            _mainCamera = mainCamera;
            _remoteCamera = remoteCamera;
            _renderTextureRenderer = renderTextureRenderer;
        }

        public List<T> GetCollisions<T>(out PointerEventData eventData)
        {
            List<T> pointerInteractHandlers = new List<T>();
            eventData = new PointerEventData(EventSystem.current);
            if (TryConvertPoint(Input.mousePosition, out Vector2 worldPoint))
            {
                var hits = Physics2D.OverlapPointAll(worldPoint);
                eventData.position = worldPoint;
                foreach (var h in hits)
                {
                    if (h.TryGetComponent(out T pointerDownHandler))
                        pointerInteractHandlers.Add(pointerDownHandler);
                }
            }
            return pointerInteractHandlers;
        }

        public bool TryConvertPoint(Vector2 mousePosition, out Vector2 worldPoint)
        {
            worldPoint = Vector2.zero;

            // Шаг 1: Бросаем луч из mainCamera
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == _renderTextureRenderer.gameObject)
                {
                    // Шаг 2: Получаем локальную позицию попадания по поверхности projectora
                    Vector3 localHitPos = _renderTextureRenderer.transform.InverseTransformPoint(hit.point);

                    // Шаг 3: Переводим её в UV (от 0 до 1)
                    Vector2 uv = new Vector2(
                        localHitPos.x + 0.5f, // предполагаем, что projector по X от -0.5 до 0.5
                        localHitPos.y + 0.5f  // предполагаем, что projector по Y от -0.5 до 0.5
                    );

                    // Шаг 4: Переводим UV в пиксельную координату RenderTexture
                    var renderTexture = _remoteCamera.targetTexture;
                    Vector2 pixelCoord = new Vector2(uv.x * renderTexture.width, uv.y * renderTexture.height);

                    // Шаг 5: Используем ortho-камеру miniGameCamera, чтобы перевести пиксель в мировую 2D координату
                    Vector3 convertedWorldPoint = _remoteCamera.ScreenToWorldPoint(new Vector3(pixelCoord.x, pixelCoord.y, _remoteCamera.nearClipPlane));
                    worldPoint = convertedWorldPoint;
                    return true;
                }
            }

            return false;
        }
    }
}