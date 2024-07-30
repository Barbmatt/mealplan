create
or replace table ingredients (
    id int auto_increment primary key,
    name text not null,
    unit enum ('g', 'ml', 'unit')
);

create table
    recipes (
        id int not null auto_increment,
        name text not null,
        category text,
        description text,
        picture blob,
        link text,
        primary key (id)
    );

create table
    recipesingredients (
        idrecipe int,
        idingredient int,
        category text,
        foreign key (idrecipe) references recipes (id),
        foreign key (idingredient) references ingredients (id)
    );