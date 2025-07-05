
CREATE TABLE Recipes (
    RecipeID INT IDENTITY(1,1) PRIMARY KEY,
    RecipeName NVARCHAR(255) NOT NULL,
    Ingredients TEXT NOT NULL,
    Instructions TEXT NOT NULL
);
GO
