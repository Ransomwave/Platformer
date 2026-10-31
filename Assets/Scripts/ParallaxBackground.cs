using UnityEngine;
using UnityEngine.Serialization;

namespace deltaformer {
    public class ParallaxBackground : MonoBehaviour {
        private const float WrapMargin = 5f; // Wraps before the edge of the repeated sprite becomes visible

        [Header("Horizontal Parallax (X)")]
        [Tooltip("0 = moves with the camera. 1 = stays still horizontally (infinitely far away)")]
        [FormerlySerializedAs("velocidadParallaxX")]
        [SerializeField, Range(0f, 1f)] private float _parallaxSpeedX = 0.5f;

        [Header("Vertical Parallax (Y)")]
        [Tooltip("1 = moves with the camera. Lower values make it drift more as the camera moves up and down")]
        [FormerlySerializedAs("friccionVerticalY")]
        [SerializeField, Range(0.8f, 1f)] private float _verticalFrictionY = 0.95f;

        [Header("Initial Vertical Framing")]
        [Tooltip("Vertical offset from the camera at start, e.g. to show only the bottom half of the background")]
        [FormerlySerializedAs("desfaseVerticalInicial")]
        [SerializeField] private float _initialVerticalOffset = 2f;

        private Transform _cameraTransform;
        private float _startPositionX;
        private float _spriteWidth;

        private void Start() {
            _cameraTransform = Camera.main.transform;
            _startPositionX = transform.position.x;

            var spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && spriteRenderer.sprite != null) {
                // sprite.bounds is the size of the original image, not the tiled width of the renderer
                _spriteWidth = spriteRenderer.sprite.bounds.size.x;
            }

            var position = transform.position;
            position.y = _cameraTransform.position.y + _initialVerticalOffset;
            transform.position = position;
        }

        private void LateUpdate() {
            var cameraPosition = _cameraTransform.position;
            var parallaxOffsetX = cameraPosition.x * (1 - _parallaxSpeedX);

            // shift the base position by one sprite width once the camera has travelled past a full repetition
            var relativeCameraDistance = cameraPosition.x * _parallaxSpeedX;
            if (relativeCameraDistance > _startPositionX + _spriteWidth - WrapMargin) {
                _startPositionX += _spriteWidth;
            } else if (relativeCameraDistance < _startPositionX - _spriteWidth + WrapMargin) {
                _startPositionX -= _spriteWidth;
            }

            var parallaxOffsetY = cameraPosition.y * (1 - _verticalFrictionY);

            transform.position = new Vector3(
                _startPositionX + parallaxOffsetX,
                cameraPosition.y + _initialVerticalOffset - parallaxOffsetY,
                transform.position.z
            );
        }
    }
}
