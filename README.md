Mijn TD game

Welcome <Player Name>,

In this game you must protect your hive from angry robots.
You do this by placing towers on the designated plots.
But be carefull, some robots are protected against a certain type of damage, so place your turrets with that in mind.
It costs Bio Points to place towers, which you can collect by destroying robots along the path towards your base.
 
 
 
 
 
 
 
 
 
 
 ```mermaid
 graph TD
    A((Start)) -->|Wait 5 seconds| B(Spawn Wave)
    B --> C(Check Enemy List)
    C --> D{Spawn Enemies}
    D --> |Enemies reached base|E(Player loses life)
    D --> |Enemies Killed|F(Money made)
    F --> G(Next wave available?)
    E --> G
    E --> |No lives left|J
    G --> |Yes|B
    G --> |No|I(Check LevelList)
    I --> |Next Level Available|H(Next Level)
    I --> |No Next Level|J(Endscreen)
    H --> A
    J --> |Clicked Restart game|A
    J --> |Closed Game|K(Game Closed)
   
