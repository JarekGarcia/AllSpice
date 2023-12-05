CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(50) NOT NULL,
        instructions TEXT NOT NULL,
        img VARCHAR(1000) NOT NULL,
        category CHAR(100) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE recipes

INSERT INTO
    recipes(
        title,
        instructions,
        img,
        category,
        creatorId
    )
VALUES (
        "Hoot Doogs",
        "you put the hoot doog on the boon",
        "somecoolimg.img",
        "Hot Dogs",
        "652ec5cdc493eda84a6f68df"
    )

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        name CHAR(50) NOT NULL,
        quantity CHAR(100) NOT NULL,
        recipeId INT NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DROP TABLE ingredients

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        FOREIGN KEY(accountId) REFERENCES accounts(id) ON DELETE CASCADE,
        FOREIGN KEY(recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT ''

DROP TABLE favorites