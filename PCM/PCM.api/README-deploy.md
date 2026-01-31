Deployment & local run
======================

Quick steps to build and run locally with Docker Compose (includes SQL Server for demo):

1. From folder `PCM.api` run:

```bash
docker compose up --build
```

2. The API will be available at `http://localhost:8080`.

Notes for production deploy (cloud provider / Render / Docker host):
- Provide a valid connection string via environment variable `ConnectionStrings__DefaultConnection`.
  Example (SQL Server): `Server=tcp:<DB_HOST>,1433;Database=PCM_DB;User Id=<user>;Password=<pass>;TrustServerCertificate=True;`
- If your hosting provides a single `DATABASE_URL` style variable, set `ConnectionStrings__DefaultConnection` correspondingly.
- Before first run, apply EF migrations (from your dev machine or a migration container):

```bash
dotnet ef database update --project ./PCM.api --startup-project ./PCM.api
```

Or run the published container once with migration steps (advanced).

Docker tips:
- Image built by this repository will publish the app and run `PCM.dll` on port `8080`.
- Use `-e ConnectionStrings__DefaultConnection="<your-conn>"` when running `docker run`.

If you want, I can:
- add an automated migration step in the container entrypoint,
- or prepare a Kubernetes/Render service file for your target host.
