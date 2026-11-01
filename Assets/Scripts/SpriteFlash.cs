using System.Collections;
using UnityEngine;

namespace deltaformer {
    public static class SpriteFlash {
        public static IEnumerator FlashRed(SpriteRenderer spriteRenderer, float duration = 0.3f) {
            var originalColor = spriteRenderer.color;
            var elapsed = 0f;

            while (elapsed < duration) {
                elapsed += Time.deltaTime;
                spriteRenderer.color = Color.Lerp(Color.red, originalColor, elapsed / duration);
                yield return null;
            }

            spriteRenderer.color = originalColor;
        }
    }
}
