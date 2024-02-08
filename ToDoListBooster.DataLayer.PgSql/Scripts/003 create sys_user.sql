create table sys_user
(
	id						serial not null primary key,
	user_name				varchar(250) not null,
	password_hash			varchar(250) not null,
	password_salt			varchar(250) not null,
	email					varchar(250) not null,
	created_date			timestamp without time zone default now() not null
);
