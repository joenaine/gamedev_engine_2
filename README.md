# AI Homework - State Machine & Input System

My homework project for AI behavior with state machines and input interfaces.

## Features

- AI state machine with Idle, Chase, and Attack states
- Input interface system for player and NPC control
- Character system with proper data encapsulation
- Distance-based state transitions

## Scripts

- **Character.cs** - Base character class
- **CharacterData.cs** - Character stats with read-only properties
- **IInputHandler.cs** - Input interface for player and NPC
- **PlayerInputHandler.cs** - Handles player keyboard input
- **NPCInputHandler.cs** - Handles NPC AI-driven input
- **Player.cs** - Player character implementation
- **Enemy.cs** - Enemy character with AI behavior
- **AIStateMachine.cs** - Manages AI state transitions
- **AIState.cs** - Base state class
- **IdleState.cs** - Enemy idle behavior
- **ChaseState.cs** - Enemy chase/pursuit behavior
- **AttackState.cs** - Enemy attack behavior
- **GameManager.cs** - Main game controller

## Setup

1. Create new 3D Unity project
2. Copy Scripts folder to Assets
3. Create a plane for the ground
4. Create a capsule for the player, add Player component
5. Create cubes for enemies, add Enemy component
6. Create empty GameObject, add GameManager
7. Assign player and enemies in GameManager inspector
8. Assign player reference in each Enemy inspector

## Controls

- **WASD** - Move player
- **Space** - Attack
- **ESC** - Quit

## How It Works

### State Machine

Enemy AI has three states:

1. **Idle** - Waits and checks for player
2. **Chase** - Moves toward player when in detection range
3. **Attack** - Attacks player when in attack range

State transitions:
- Idle -> Chase: Player enters detection range
- Chase -> Attack: Player enters attack range
- Attack -> Chase: Player moves out of attack range but still in detection range
- Chase -> Idle: Player moves out of detection range

### Input System

Both player and NPC use the same `IInputHandler` interface. Player gets input from keyboard, NPC gets input from AI logic. This makes the code cleaner and easier to extend.

### Character Data

`CharacterData` uses properties with only get accessors to make data read-only from outside. Data can only be modified through specific methods like `TakeDamage()` and `Heal()`.

All classes receive the full `Character` reference during initialization instead of just `CharacterData`, allowing better access to character methods and transforms.

# gamedev_engine_2
