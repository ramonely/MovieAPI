create database movieapi;

create table movies 
(
	id int not null auto_increment primary key,
    title varchar(25),
    genre varchar(25)
);

insert into movies
values(0, "Awesome Movie", "Action"),
(0, "We Are Fun", "Comedy"),
(0, "Timeless", "Drama"),
(0, "Back Again", "Horror"),
(0, "Warriors", "Action"),
(0, "Attack On The Ring", "Drama"),
(0, "The Rooftop", "Sci-Fi"),
(0, "Black Cat", "Action"),
(0, "Fast Too Fast", "Action");