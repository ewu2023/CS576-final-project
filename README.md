# CS576-final-project
Final project for CS 576: Game programming

### Contributions
# Eric
**Inventory System Code** (inspired by Brackeys' tutorial on Inventory Systems: https://www.youtube.com/watch?v=YLhj7SfaxSE)
- Consumable.cs (From tutorial)
- InventorySlot.cs (Own work: Lines 9-13, 40-46)
- InventoryUI.cs (Own work: Lines 28-38)
- Pickup.cs (Completely own work)
- PlayerInventory.cs (Own work: 50-58)

**Power Ups** 
- SpeedPowerup.cs
- SlowMotionPowerup.cs
- PowerupUI.cs

**Questions and Gameplay Logic**
- QuestionManager.cs
- Book.cs
- TimeManager.cs

**Partially Edited**
- BookManager.cs (Lines 7-31, 56-75, 95-99)

**Asset References**
- Clock sprite: https://opengameart.org/content/simple-clock-16x16
- Key sprite: https://www.pixilart.com/art/key-sprite-test-99e4543b507dae7?ft=album&ft_id=147860
- Lightning sprite: https://gamedeveloperstudio.itch.io/ui-icons
- Inventory UI elements: https://devassets.com/assets/rpg-tutorial-assets/

# Victor
**Enemy AI and Obstacles** 
- EnemyAI.cs
- BullyAI.cs
- Navmesh for rooms, navmesh obstacles on doors and some of the level design decor (most of it was Chris)

**Partially Edited**
- Door.cs (lines 27-30, 65-68, 81, 105 so that the Terminator can interact with doors/not interact with locked doors)
- BookSpawn.cs (lines 14, 35, 36, so that new spawned books can be added to a public list, so that the Terminator knows when to speed up when more books are picked up)

**Pause Menu** 
- PauseMenu.cs (followed and modified from Brackey's tutorial on Pause Menus https://www.youtube.com/watch?v=JivuXdrIHK0)

**Asset References**
- Smiley Face https://www.deviantart.com/boosman/art/Smile-texture-358144173
- Terminator model and animations (X-bot from Mixamo https://www.mixamo.com/#/?page=1&query=x+bot&type=Character)
- First Person Controller https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525


# Christopher Tran
**Level Design and Doors**
- Created the entire level design (rooms, hallways, lighting)
- Furnished all rooms except in Main Office, Cafe, and Closets)
- Door.cs (lines 7-15, 32-41, 51-63, 72-161)

**Power Ups**
- Visual and sound design for all power ups
- Key item and doorlock programmed through Door.cs
- ItemManager.cs
- ItemSpawner.cs
- ItemBehavior.cs

**Book Spawner**
- BookManager.cs
- BookSpawn.cs

**UI**
- Created scenes for menu, win screen, lose screen
- PlayButton.cs
- MenuButton.cs

**Asset References**
- Office Furniture https://assetstore.unity.com/packages/3d/environments/urban/pixel-modern-office-extras-225670
- Clock 3D Design https://assetstore.unity.com/packages/3d/props/interior/clock-4250
- Speed Particle 3D Design https://assetstore.unity.com/packages/vfx/particles/powerup-particles-16458
- Key 3D Design https://assetstore.unity.com/packages/3d/props/tools/simple-keys-231162
- Power Down Sound https://pixabay.com/sound-effects/power-down-7103/
- Electric Zap Sound https://pixabay.com/sound-effects/electric-zap-001-6374/
- Get Key Sound https://pixabay.com/sound-effects/key-get-39925/
- Lock Sound https://www.fesliyanstudios.com/royalty-free-sound-effects-download/door-lock-91
- Door Sounds https://www.youtube.com/watch?v=-dZ_Zz9Ppjg&ab_channel=GamingSoundFX