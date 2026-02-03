# HW4
## Devlog
### Model-View-Control
<b>View:</b> when the pipe moves past the player, it collides with an invisible GameObject (`PointsGiver`) that plays a sound and invokes `GetPointE`. `GameController` receives this event, and updates the score and UI.<br>
<b>Control:</b> when the pipe contacts the player, it calls `GameController.Instance.HandleGameOver()`, which invokes `GameOverE` and stops spawning pipes. The `Player` receives the event and blocks further player input (ie: the player can no longer control the bird). All `Pipe`s receive the event and stop moving.

I used events to prevent having to call a function on `GameController` to update points as was done in previous minigames, and to prevent from having to track all Pipes to stop them via function when the game ends.

`GameController` was implemented as a Singleton so any `Pipe` could call the `HandleGameOver()` function easily without needing a reference. It also makes sense, as there should not be two `GameController`s in the scene at once, as that could cause unexpected behaviour.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
