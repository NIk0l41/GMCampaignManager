CREATE TABLE NPC(
    npcID INTEGER PRIMARY KEY AUTOINCREMENT,
    npcName VARCHAR(255) NOT NULL,
    /*
        Stat blocks?
            > What if a game has > 6 stats? Namely Honour and Sanity?
        Inventory?
            > A Collection of Item IDs...
            > A single string??
            > OR
            > A table...for each NPC...
            > What, do you seriously want
                -> `inventOf<npcName>();` as a god-damn table?
                -> Fuck off.
                -> It would solve the item instancing problem
                -> how??
                -> um...
                -> yeah. exactly. It doesn't.
                -> Well, to be fair, we haven't designed an item object yet. Maybe it could work.
    */
);