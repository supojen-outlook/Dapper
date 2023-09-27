create table accounts (
	id bigserial primary key,
	owner varchar(10) not null,
	balance decimal not null,
	currency varchar(10) not null default 'USD',
	created_at timestampz not null default now()
);

create table entries (
	id bigserial primary key,
	amount decimal not null,
	account_id big int not null references accounts(id),
	created_at timestampz not null default now()
);

create table transfers (
	id bigserial primary key,
	amount decimal not null,
	from_account_id bigint not null references accounts(id),
	to_account_id bigint not null references accounts(id),
	created_at timestampz not null default now()
);
