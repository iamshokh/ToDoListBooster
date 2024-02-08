create table doc_task_item
(
	id						serial not null primary key,
	title					varchar(250) not null,
	descrition				varchar(2000) not null,
	task_list_id			integer not null,
	status_id				integer not null,
	created_date			timestamp without time zone default now() not null,

	constraint fk_task_list_id					foreign key ( task_list_id )				references doc_task_list ( id ),
	constraint fk_status_id					    foreign key ( status_id )				    references enum_status ( id )
);
