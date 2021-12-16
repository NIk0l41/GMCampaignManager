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

