DROP TABLE IF EXISTS `Notes`;
DROP TABLE IF EXISTS `HasAccessToCatalogue`;
DROP TABLE IF EXISTS `NPCs`;
DROP TABLE IF EXISTS `Locations`;
DROP TABLE IF EXISTS `CatalogueEntries`;
DROP TABLE IF EXISTS `ItemInstances`;
DROP TABLE IF EXISTS `CatalogueData`;
DROP TABLE IF EXISTS `ItemTemplates`;


CREATE TABLE NPCs(
	npcID INTEGER PRIMARY KEY AUTOINCREMENT,
	npcName VARCHAR(255) NOT NULL,
	currentLocation INTEGER,
	inventoryItemID INTEGER NOT NULL,
	FOREIGN KEY (currentLocation) REFERENCES Locations(locationID),
	FOREIGN KEY (inventoryItemID) REFERENCES ItemInstances(instanceID)
);

CREATE TABLE Locations(
	locationID INTEGER PRIMARY KEY AUTOINCREMENT,
	locationName VARCHAR(255) NOT NULL,
	parentLocationID INTEGER,
	inventoryItemID INTEGER NOT NULL,
	FOREIGN KEY (parentLocationID) REFERENCES Locations(locationID)
	FOREIGN KEY (inventoryItemID) REFERENCES ItemInstances(instanceID)
);

CREATE TABLE ItemTemplates(
	itemID INTEGER PRIMARY KEY AUTOINCREMENT,
	itemName VARCHAR(255) NOT NULL
);

CREATE TABLE ItemInstances(
	-- Do ItemInstances need to reference an ItemTemplate?
	instanceID INTEGER PRIMARY KEY AUTOINCREMENT,
	instanceName VARCHAR(255) NOT NULL,
	inventoryID INTEGER,
	FOREIGN KEY (inventoryID) REFERENCES ItemInstances(instanceID)
);

CREATE TABLE HasAccessToCatalogue(
	npcID INTEGER NOT NULL,
	catalogueID INTEGER NOT NULL,
	FOREIGN KEY (npcID) REFERENCES NPCs(npcID),
	FOREIGN KEY (catalogueID) REFERENCES CatalogueData(catalogueID)
);

CREATE TABLE CatalogueData(
	catalogueID INTEGER PRIMARY KEY AUTOINCREMENT,
	catalogueLabel VARCHAR NOT NULL
);

CREATE TABLE CatalogueEntries(
	-- The combination of catalogueID and itemID is a composite key.
	catalogueID INTEGER NOT NULL,
	itemID INTEGER NOT NULL,
	price VARCHAR(255) NOT NULL,
	PRIMARY KEY (catalogueID, itemID),
	FOREIGN KEY (itemID) REFERENCES ItemTemplates(itemID),
	FOREIGN KEY (catalogueID) REFERENCES CatalogueData(catalogueID)
);

CREATE TABLE Notes(
	noteID INTEGER PRIMARY KEY AUTOINCREMENT,
	ownerID INT NOT NULL,
	-- Ownertype documentation can be created later (0 --> Session etc.)
	ownerType INT NOT NULL,
	contents VARCHAR
	/*colour ENUM("BLUE", "RED", "YELLOW") DEFAULT "YELLOW"			Just in case I want to add colour channigng notes later on :P*/
);




INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Johnny');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Grace');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Toowoomba');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Town Hall');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Forest of Tears');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Smithys Smith');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Fried Lettuce');
INSERT INTO `ItemInstances` (instanceName) VALUES ('_inventory-Trader Mags');

--Parent Locations
INSERT INTO `Locations` (locationName, inventoryItemID) VALUES ('Toowoomba', 3);
-- Child Locations
INSERT INTO `Locations` (locationName, parentLocationID, inventoryItemID) VALUES ('Town Hall', 1, 4);
INSERT INTO `Locations` (locationName, parentLocationID, inventoryItemID) VALUES ('Forest of Tears', 1, 5);
INSERT INTO `Locations` (locationName, parentLocationID, inventoryItemID) VALUES ('Smithys Smith', 1, 6);

-- NPCs w/Location
INSERT INTO `NPCs` (npcName, currentLocation, inventoryItemID) VALUES ('Johnny', 3, 1);
INSERT INTO `NPCs` (npcName, currentLocation, inventoryItemID) VALUES ('Grace', 2, 2);
INSERT INTO `NPCs` (npcName, currentLocation, inventoryItemID) VALUES ('Fried Lettuce', 4, 7);
INSERT INTO `NPCs` (npcName, currentLocation, inventoryItemID) VALUES ('Trader Mags', 2, 8);