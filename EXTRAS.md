## Requisitos adicionales

- **Tilemap**:
  - Carpeta Art de Level 1, 2 y 3
- **Animaciones** mediante Animator Controllers:
  - Art/Player/PlayerAnimationController
  - Art/Level2/Banana
  - Art/Level2/CrusherEnemy
  - Art/Level2/FlyingEnemy
  - Art/Level2/WakingEnemy
- **IA de los Enemigos**:
  - Scripts: EnemyBehavior, CrusherBehavior, Hitbox
  - En CrusherBehavior usa una corrutina para gestionar el movimiento que hace el enemigo al detectar un jugador debajo del mismo.
  - Para darle un efecto más realista a ese movimiento tanto para caer como para volver a la posición inicial hemos usado tweens de la web https://easings.net.
- **Físicas**:
  - Material: PlayerPhysicsMaterial
  - Impulsos (ForceMode2D.Impulse) en el salto y en el empuje del ataque (Script: PlayerController)

## Extras

- **Menú de opciones**:
  - Scene: UIOptions + escape dentro de los Levels, cargada de forma aditiva sobre el nivel
  - Scripts: PauseMenu, UIOptions
- **Música y efectos de sonido**:
  - Scripts: BananaAudio, PlayerAudio -> GameManager, PlayerController
  - AudioMixer con volúmenes separados de Master, Music y SFX
- **Persistencia de datos** mediante el uso de variables estáticas y configuración se guarda en PlayerPrefs:
  - Script: GameSettings
- **Pantallas de inicio, victoria y game over, y UI de vida**:
  - Scripts: UIStart, UIWin, UIGameOver, PlayerHealthUI
- **Fondo con parallax** infinito y velocidad distinta por eje:
  - Script: ParallaxBackground
- **Cámara con zona muerta** y seguimiento suavizado:
  - Script: DeadzoneCameraHandler
- **Plataformas que desaparecen** tras estar encima un tiempo (corrutina):
  - Script: VanishingPlatform
- **Hojas que dejan caer al jugador** si se queda encima demasiado, con animación por frames y recuperación:
  - Script: LeafHandler
- **Hojas giratorias** en círculo que hacen daño al jugador:
  - Scripts: SpinningLeavesHandler, SpinningLeaf
- **Parpadeo rojo** al recibir daño:
  - Script: SpriteFlash
- **Invencibilidad temporal** tras recibir daño o atacar:
  - Script: PlayerController
- **Ataque con empuje** en la dirección en la que mira el jugador:
  - Script: PlayerController
- **Interfaz común de daño** para jugador, enemigos y obstáculos:
  - Script: ILivingEntity
