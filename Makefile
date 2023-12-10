init:
	make run ; make migrate

db:
	cd Docker; wsl docker compose up mssql -d --build --force-recreate

run:
	cd Docker; wsl docker compose up -d --build --force-recreate

migrate:
	cd Company.BookManager.Infrastructure/ ; dotnet ef database update

kill:
	cd Docker; wsl docker compose down
