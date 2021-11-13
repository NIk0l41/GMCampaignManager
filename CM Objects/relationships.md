# Object Relationships
## Contents
 - [Key Objects](#the-key-objects)
 - [Relationships](#relationships)
 - [Attributes](#attributes)
   - [Location](#location)
   - [NPC](#npc)
   - [Event](#event)
   - [Item](#item)
   - [Note](#note)

## The Key Objects
Okay, so in this software, the main objects are as follows:
- Locations
- NPCs
- Events,
- Items and
- Notes

## Relationships
- Locations can have child Locations (As Castle to City)
- NPCs can be found in Locations (As Leader to Castle)
- Events occur at Locations (As Meeting to Throne Room)
- Items can be found in Locations (As Chest to Armoury)
- Items can have child Items (As Chest to Weapon)
- NPCs can participate in Events (As Leader to Meeting)
- NPCs can have Items (As Leader to Ring)
- Every Object has Notes

## Attributes
### Location
Name
### NPC
Name
_NPC Type_
Stats
_Catalogue_
### Event
Name
_Date_
### Item
_Item Type_
_Tag_
### Note
_**Notepad**_s

## Secondary Objects
