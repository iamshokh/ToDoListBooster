create table info_comment
(
	id						serial not null primary key,
	tekst					varchar(2000) not null,
	task_item_id			integer not null,
	created_date			timestamp without time zone default now() not null,

	constraint fk_task_item_id					foreign key ( task_item_id )				references doc_task_item ( id )
);
