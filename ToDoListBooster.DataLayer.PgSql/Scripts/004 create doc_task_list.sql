create table doc_task_list
(
	id						serial not null primary key,
	title					varchar(250) not null,
	descrition				varchar(2000) not null,
	user_id					integer not null,
	created_date			timestamp without time zone default now() not null,

	constraint fk_user_id					foreign key ( user_id )				references sys_user ( id )
);
