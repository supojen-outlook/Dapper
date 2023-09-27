db-container:
	docker run --rm --name postgres -e POSTGRES_PASSWORD=secret -p 5432:5432 -d postgres:alpine:3.17
create-db:
	docker exec -it postgres createdb --username=postgres --owner=postgres test
sqlc-init:
	sqlc init
db-up:
	migrate -path doc/migration -database "postgresql://postgres:secret@localhost:5432/test?sslmode=disable" -verbose up
db-down:
	migrate -path doc/migration -database "postgresql://postgres:secret@localhost:5432/test?sslmode=disable" -verbose down
