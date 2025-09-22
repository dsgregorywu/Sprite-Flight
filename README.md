# Sprite-Flight Planetary Puzzle

## Play the Game
**Unity Play Link**: [Your Unity Play URL]

## Game Overview
Welcome to Sprite Flight Planetary Puzzle! You are a ship trying to dodge planets as they bump into each other. 

### Controls
Left click towards a spot to move that way. The further away, the faster you go!

### How to Play
Left click towards a spot to move that way. The further away, the faster you go! Don't get hit by the planets, and don't touch the walls!

## Base Game Implementation

### Completion Status
- [x] Player movement and controls
- [x] Obstacle spawning system
- [x] Collision detection
- [x] Score system
- [x] Game over state
- [ ] [Any incomplete features]

### Known Bugs
None known

### Limitations
None known

## Extensions Implemented

### 1. [Cohesive Color Scheme] (2 points)
**Implementation**: I liked purple as my base color and built off of that. I found a cute purple space background, and liked orange as an accent color. The spaceship sprite I used had a nice blue accent so I used that as the fire, which conveniently works!
**Game Impact**: Looks more cohesive and put together.
**Technical Details**: Nothing notable
**Known Issues**: Nothing known.

### 2. [Changing Game Concept] (2 points)
**Implementation**: I didn't change it much since I like the space theme a lot, but made it planets rather than asteroids.
**Game Impact**: Higher stakes.
**Technical Details**: Nothing notable
**Known Issues**: Nothing known.

### 3. [Swap Sprites] (3 points)
**Implementation**: I found sprites from the Unity Asset store and used them! I liked the planet assets and couldn't find a realistic spaceship sprite, otherwise the spaceship would look more real. I also found my nice space background!
**Game Impact**: Changes some hitboxes slightly but nothing crazy.
**Technical Details**: The planets are still hexagons underneath the planet.
**Known Issues**: Nothing known.

### 4. [Destroy Borders on Game Over] (4 points)
**Implementation**: I made the borders unrender on player death, allowing the planets to fly off screen on player death.
**Game Impact**: None to gameplay.
**Technical Details**: Nothing noteable.
**Known Issues**: Nothing known.

### 5. [Increase Difficulty Over Time] (5 points)
**Implementation**: The asteroids are made of a material that has a bounciness of 1.05, so they gradually speed up over time.
**Game Impact**: Harder to survive for long periods of time.
**Technical Details**: Spinning adds more unpredictability.
**Known Issues**: Nothing known.

### 6. [Add Sound Effects] (5 points)
**Implementation**: I added sound effects for the booster and for player death. I wanted to keep the silent ambiance of space so I didn't add any background music.
**Game Impact**: Gives better indication of when the user is using the booster and dies.
**Technical Details**: Nothing notable
**Known Issues**: Nothing known.

### 6. [Animate Booster] (5 points)
**Implementation**: I added a booster flare to the rocket that marks when the user is boosting, and also has a sound effect attached.
**Game Impact**: Gives better indication of when the user is using the booster, is more realistic and improves color palette.
**Technical Details**: Nothing notable
**Known Issues**: Nothing known.

## Credits
Earth & Planets skyboxes - https://assetstore.unity.com/packages/2d/textures-materials/sky/earth-planets-skyboxes-53752
Tiny Spaceships - https://assetstore.unity.com/packages/2d/characters/tiny-space-ships-326914
Dynamic Space Bachttps://assetstore.unity.com/packages/2d/textures-materials/dynamic-space-background-lite-104606
Sci Fi Spaceship - https://freesound.org/people/Akkaittou/sounds/823208/
HH Pd 09 - https://freesound.org/people/pomeroyjoshua/sounds/513371/

## Reflection
**Total Points Claimed**: [Base: 80% + Extensions: 26?% = 106%]
**Challenges**: My main challenges in this were figuring out how collision works between the planets, and just getting a grip on Unity. The first project in a software is always the hardest due to the nature of figuring out how to effectively use the software, and this was definitely true for me.
**Learning Outcomes**: I learned a lot about making a game in Unity, especially about how the software works, and how it interacts with my C# code. 

## Development Notes
Thank you for reading this and playing my game :)
