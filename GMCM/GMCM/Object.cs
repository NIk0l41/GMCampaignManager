using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace GMCM
{
    namespace Object {


        abstract class Object
        {
            public string name;
        }

        class ItemTemplate : Object
        {
            public int itemId;

            public ItemTemplate(int itemId, string itemName) {
                this.name = itemName;
                this.itemId = itemId;
            }
        }

        class ItemInstance : Object
        {
            public int instanceID;
            public List<ItemInstance> contains;

            public ItemInstance(int instanceID, string instanceName) {
                this.instanceID = instanceID;
                name = instanceName;
            }

        }

        class Npc : Object
        {
            public int npcId;
            public ItemInstance inventory;

            public Npc(string name, int id, ItemInstance inventory) {
                this.name = name;
                npcId = id;
                this.inventory = inventory;
            }
        }
    }

 
}
