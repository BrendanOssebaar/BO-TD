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
   
