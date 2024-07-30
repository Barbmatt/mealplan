create
or replace table Ingredients (
    id int auto_increment primary key,
    name text not null,
    unit enum ('g', 'ml', 'unit')
);

create
or replace table Recipes (
    id int not null auto_increment,
    name text not null,
    category text,
    description text,
    picture blob,
    link text,
    primary key (id)
);

create
or replace table RecipesIngredients (
    idRecipe int,
    idIngredient int,
    amount float,
    category text,
    foreign key (idRecipe) references Recipes (id),
    foreign key (idIngredient) references Ingredients (id)
);