# EndlessChase
**Game Objectives and Supportives:**
The character is lost in a deserted place and tries hard to survive by munching on the resources available to him but with the obstacle i.e. the enemy eagle which tries to guard the survival resources from the character who hunts for them, the enemy(eagle, possum, frog) follows the AI patrol and Chase game concept.
**Character Actions and roles:**
  **Player:**
    - Move about horizontally.
    - Jump, double Jump.
    - Crouch to hide under objects and pass through narrow areas.
    - Attack enemies but flee if enemy is stronger (used the logic from Task15)
    - Collect Cherries to survive and leave the deserted Island.
**How it all works:**
- Attacks: they work via the Collider events trigger and collides with Object Tag under either player or enemy.
- Jump: Anti-gravity for the part when player jump’s and the distance is calculated based on the number of times the key is pressed within the time frame.
- Horizontal movement is all based on the rigid2d body which is basically physics 2d and then the vector position is calculated based on the arrow keys and as for the speed the time.deltatime is used which basically indicates the real time and it’s same for all CPUS no matter the processing power so that with fast CPU the player doesn’t fly off or neither it lags with the slower ones.
- With the Path following I used A* AI path finding and Seeker script so that the shortest and most effective route is always chosen to chase after the player plus the distance where it should stop before submissively running into the player.

**Levels:**
![image](https://github.com/HasaanAkhtar/EndlessChase/assets/54102186/72f28cb6-a562-4ba1-a5ac-e847ea2b00d6)
![image](https://github.com/HasaanAkhtar/EndlessChase/assets/54102186/a7f3d236-36f0-44e2-bc73-53b2a2fb29c8)
![image](https://github.com/HasaanAkhtar/EndlessChase/assets/54102186/85e471d5-a583-4a01-9753-bf45d244f9cf)

**FSM Diagram used for animation:**

![image](https://github.com/HasaanAkhtar/EndlessChase/assets/54102186/443bbab6-6a06-4469-9dfa-0df564fa6ca6)

**NOTE:**
This was a custom progect created soley for testing and learning about AI Algorithms and personal project for my portfolio.

