# Object Relationships
## Contents
- [The Key Objects](#the-key-objects)
- [Relationships](#relationships)
- [Attributes](#attributes)
  - [Name](#name)
  - [Tags](#tags)
- [Secondary Objects](#secondary-objects)
  - [Playlists](#playlists)
  - [Stat Block](#stat-block)
  - [Catalogue](#catalogue)
  - [Date](#date)
  - [Note](#notes)
- [On Template Creation](#on-template-creation)
## The Key Objects
Okay, so in this software, the main objects are as follows:
- Locations
- NPCs
- Events &
- Items

Then, for in-game, we have:
- Sessions

## Relationships
- Locations can have child Locations (As Castle to City)
- NPCs can be found in Locations (As Leader to Castle)
- Events occur at Locations (As Meeting to Throne Room)
- Items can be found in Locations (As Chest to Armoury)
- Items can have child Items (As Chest to Weapon)
- NPCs can participate in Events (As Leader to Meeting)
- NPCs can have Items (As Leader to Ring)

- Sessions provide quick access to all objects.

## Attributes
### Name
A unique string identifier.
### Tags
Tags can:
- Allow for filtering
- Communicate a method of use, type of object, or 
- Can communicates item collections or lore
## Secondary Objects
#### Playlists
A collection of music *Playlists* used for immersion.

Used in locations.
### Stat Block
A Collection of 6 *Stats* --> (STR, DEX, CON, WIS, INT & CHA)

Used in NPCs
### Catalogue
An object used to list the relation between an item and it's cost given that unique *Catalogue*

Used in NPCs
### Date
An object used in the *Calendar* to keep track of time and for *Automation*

Used in Events

### Notes
All Key Objects can have a collection of *Notepad*s.
A *Notepad* is an object that can hold either:
- Written Information or
- Picture Information
I'm sure what a *Notepad* can hold with develop as development goes on.

## On Template Creation
I want this application to allow creation of certain types of objects.
So, the user can create 'templates' that will hold:
- Notes
- Tags
That can later be edited to suit the context of the object.

## On Sessions
The view that contains all data from the database is too overwhelming during a single session.
So, the GM will select what information will (or may be) useful during a session, and the view will only show that during 'Play' mode, and the Session Editor.
r