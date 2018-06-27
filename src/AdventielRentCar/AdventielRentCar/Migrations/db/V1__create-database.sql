create table user (
	id integer primary key autoincrement,
	login TEXT not null, 
	salt TEXT not null, 
	hash TEXT not null
);

create unique index ix1_user on user (login);

create table reference (
	id integer primary key autoincrement,
	code text not null, 
	domain text not null, 
	value text, description text not null
);

create unique index ix1_reference on reference (code, domain);

