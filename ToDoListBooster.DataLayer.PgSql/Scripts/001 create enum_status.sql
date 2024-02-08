create table enum_status (
    id              int not null primary key,
    code            varchar(50) null,
    short_name      varchar(250) not null,
    full_name       varchar(300) not null,
    created_date    timestamp without time zone default now() not null
);
