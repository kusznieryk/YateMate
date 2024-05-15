CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "AspNetRoles" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetRoles" PRIMARY KEY,
    "Name" TEXT NULL,
    "NormalizedName" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL
);

CREATE TABLE "AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "UserName" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "Email" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "PasswordHash" TEXT NULL,
    "SecurityStamp" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "AccessFailedCount" INTEGER NOT NULL
);

CREATE TABLE "AspNetRoleClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY AUTOINCREMENT,
    "RoleId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserClaims" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY AUTOINCREMENT,
    "UserId" TEXT NOT NULL,
    "ClaimType" TEXT NULL,
    "ClaimValue" TEXT NULL,
    CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserLogins" (
    "LoginProvider" TEXT NOT NULL,
    "ProviderKey" TEXT NOT NULL,
    "ProviderDisplayName" TEXT NULL,
    "UserId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserRoles" (
    "UserId" TEXT NOT NULL,
    "RoleId" TEXT NOT NULL,
    CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AspNetUserTokens" (
    "UserId" TEXT NOT NULL,
    "LoginProvider" TEXT NOT NULL,
    "Name" TEXT NOT NULL,
    "Value" TEXT NULL,
    CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");

CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");

CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");

CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('00000000000000_CreateIdentitySchema', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "AspNetUsers" ADD "Apellido" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "Dni" INTEGER NULL;

ALTER TABLE "AspNetUsers" ADD "FechaNacimiento" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "Nacionalidad" TEXT NULL;

ALTER TABLE "AspNetUsers" ADD "Nombre" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240502134527_datos-registro', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "AspNetUsers" ADD "Genero" TEXT NULL;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240502142209_mas-datos-registro', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "Bienes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Bienes" PRIMARY KEY AUTOINCREMENT,
    "Nombre" TEXT NOT NULL,
    "Descripcion" TEXT NOT NULL,
    "UsuarioId" INTEGER NOT NULL,
    "Imagen" BLOB NOT NULL,
    "ApplicationUserId" TEXT NULL,
    CONSTRAINT "FK_Bienes_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

CREATE TABLE "Embarcaciones" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Embarcaciones" PRIMARY KEY AUTOINCREMENT,
    "Nombre" TEXT NOT NULL,
    "ClienteId" TEXT NOT NULL,
    "Eslora" REAL NOT NULL,
    "Calado" REAL NOT NULL,
    "ApplicationUserId" TEXT NULL,
    CONSTRAINT "FK_Embarcaciones_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

CREATE TABLE "Publicaciones" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Publicaciones" PRIMARY KEY AUTOINCREMENT,
    "EmbarcacionId" INTEGER NOT NULL,
    "Image" BLOB NOT NULL,
    "Titulo" TEXT NOT NULL,
    "Descripcion" TEXT NOT NULL
);

CREATE INDEX "IX_Bienes_ApplicationUserId" ON "Bienes" ("ApplicationUserId");

CREATE INDEX "IX_Embarcaciones_ApplicationUserId" ON "Embarcaciones" ("ApplicationUserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240508161133_NO SE', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "ef_temp_Publicaciones" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Publicaciones" PRIMARY KEY AUTOINCREMENT,
    "Descripcion" TEXT NOT NULL,
    "EmbarcacionId" INTEGER NOT NULL,
    "Image" TEXT NOT NULL,
    "Titulo" TEXT NOT NULL
);

INSERT INTO "ef_temp_Publicaciones" ("Id", "Descripcion", "EmbarcacionId", "Image", "Titulo")
SELECT "Id", "Descripcion", "EmbarcacionId", "Image", "Titulo"
FROM "Publicaciones";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Publicaciones";

ALTER TABLE "ef_temp_Publicaciones" RENAME TO "Publicaciones";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240513012601_Cambio de forma de Publicacion', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "ef_temp_Bienes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Bienes" PRIMARY KEY AUTOINCREMENT,
    "ApplicationUserId" TEXT NULL,
    "Descripcion" TEXT NOT NULL,
    "Imagen" TEXT NOT NULL,
    "Nombre" TEXT NOT NULL,
    "UsuarioId" TEXT NOT NULL,
    CONSTRAINT "FK_Bienes_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

INSERT INTO "ef_temp_Bienes" ("Id", "ApplicationUserId", "Descripcion", "Imagen", "Nombre", "UsuarioId")
SELECT "Id", "ApplicationUserId", "Descripcion", "Imagen", "Nombre", "UsuarioId"
FROM "Bienes";

CREATE TABLE "ef_temp_AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "AccessFailedCount" INTEGER NOT NULL,
    "Apellido" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "Dni" INTEGER NULL,
    "Email" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "FechaNacimiento" TEXT NULL,
    "Genero" TEXT NOT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "Nacionalidad" TEXT NULL,
    "Nombre" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "PasswordHash" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "SecurityStamp" TEXT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "UserName" TEXT NULL
);

INSERT INTO "ef_temp_AspNetUsers" ("Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Dni", "Email", "EmailConfirmed", "FechaNacimiento", "Genero", "LockoutEnabled", "LockoutEnd", "Nacionalidad", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName")
SELECT "Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Dni", "Email", "EmailConfirmed", "FechaNacimiento", IFNULL("Genero", ''), "LockoutEnabled", "LockoutEnd", "Nacionalidad", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
FROM "AspNetUsers";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Bienes";

ALTER TABLE "ef_temp_Bienes" RENAME TO "Bienes";

DROP TABLE "AspNetUsers";

ALTER TABLE "ef_temp_AspNetUsers" RENAME TO "AspNetUsers";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Bienes_ApplicationUserId" ON "Bienes" ("ApplicationUserId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240514153932_No tengo idea amigo', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Embarcaciones" ADD "Matricula" TEXT NOT NULL DEFAULT '';

CREATE TABLE "ef_temp_Embarcaciones" (
    "Matricula" TEXT NOT NULL CONSTRAINT "PK_Embarcaciones" PRIMARY KEY,
    "ApplicationUserId" TEXT NULL,
    "Calado" REAL NOT NULL,
    "ClienteId" TEXT NOT NULL,
    "Eslora" REAL NOT NULL,
    "Id" INTEGER NOT NULL,
    "Nombre" TEXT NOT NULL,
    CONSTRAINT "FK_Embarcaciones_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

INSERT INTO "ef_temp_Embarcaciones" ("Matricula", "ApplicationUserId", "Calado", "ClienteId", "Eslora", "Id", "Nombre")
SELECT "Matricula", "ApplicationUserId", "Calado", "ClienteId", "Eslora", "Id", "Nombre"
FROM "Embarcaciones";

CREATE TABLE "ef_temp_Bienes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Bienes" PRIMARY KEY AUTOINCREMENT,
    "ApplicationUserId" TEXT NULL,
    "Descripcion" TEXT NOT NULL,
    "Imagen" TEXT NOT NULL,
    "Nombre" TEXT NOT NULL,
    "UsuarioId" TEXT NOT NULL,
    CONSTRAINT "FK_Bienes_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

INSERT INTO "ef_temp_Bienes" ("Id", "ApplicationUserId", "Descripcion", "Imagen", "Nombre", "UsuarioId")
SELECT "Id", "ApplicationUserId", "Descripcion", "Imagen", "Nombre", "UsuarioId"
FROM "Bienes";

CREATE TABLE "ef_temp_AspNetUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AspNetUsers" PRIMARY KEY,
    "AccessFailedCount" INTEGER NOT NULL,
    "Apellido" TEXT NULL,
    "ConcurrencyStamp" TEXT NULL,
    "Dni" INTEGER NULL,
    "Email" TEXT NULL,
    "EmailConfirmed" INTEGER NOT NULL,
    "FechaNacimiento" TEXT NULL,
    "Genero" TEXT NOT NULL,
    "LockoutEnabled" INTEGER NOT NULL,
    "LockoutEnd" TEXT NULL,
    "Nacionalidad" TEXT NOT NULL,
    "Nombre" TEXT NULL,
    "NormalizedEmail" TEXT NULL,
    "NormalizedUserName" TEXT NULL,
    "PasswordHash" TEXT NULL,
    "PhoneNumber" TEXT NULL,
    "PhoneNumberConfirmed" INTEGER NOT NULL,
    "SecurityStamp" TEXT NULL,
    "TwoFactorEnabled" INTEGER NOT NULL,
    "UserName" TEXT NULL
);

INSERT INTO "ef_temp_AspNetUsers" ("Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Dni", "Email", "EmailConfirmed", "FechaNacimiento", "Genero", "LockoutEnabled", "LockoutEnd", "Nacionalidad", "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName")
SELECT "Id", "AccessFailedCount", "Apellido", "ConcurrencyStamp", "Dni", "Email", "EmailConfirmed", "FechaNacimiento", IFNULL("Genero", ''), "LockoutEnabled", "LockoutEnd", IFNULL("Nacionalidad", ''), "Nombre", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"
FROM "AspNetUsers";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Embarcaciones";

ALTER TABLE "ef_temp_Embarcaciones" RENAME TO "Embarcaciones";

DROP TABLE "Bienes";

ALTER TABLE "ef_temp_Bienes" RENAME TO "Bienes";

DROP TABLE "AspNetUsers";

ALTER TABLE "ef_temp_AspNetUsers" RENAME TO "AspNetUsers";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Embarcaciones_ApplicationUserId" ON "Embarcaciones" ("ApplicationUserId");

CREATE INDEX "IX_Bienes_ApplicationUserId" ON "Bienes" ("ApplicationUserId");

CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240515201945_agregando la propiedad de matricula a la embarcacion', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "ef_temp_Embarcaciones" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Embarcaciones" PRIMARY KEY AUTOINCREMENT,
    "ApplicationUserId" TEXT NULL,
    "Calado" REAL NOT NULL,
    "ClienteId" TEXT NOT NULL,
    "Eslora" REAL NOT NULL,
    "Matricula" TEXT NOT NULL,
    "Nombre" TEXT NOT NULL,
    CONSTRAINT "FK_Embarcaciones_AspNetUsers_ApplicationUserId" FOREIGN KEY ("ApplicationUserId") REFERENCES "AspNetUsers" ("Id")
);

INSERT INTO "ef_temp_Embarcaciones" ("Id", "ApplicationUserId", "Calado", "ClienteId", "Eslora", "Matricula", "Nombre")
SELECT "Id", "ApplicationUserId", "Calado", "ClienteId", "Eslora", "Matricula", "Nombre"
FROM "Embarcaciones";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Embarcaciones";

ALTER TABLE "ef_temp_Embarcaciones" RENAME TO "Embarcaciones";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Embarcaciones_ApplicationUserId" ON "Embarcaciones" ("ApplicationUserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240515202033_agregando matricula, ahora si', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240515202415_noseflacomatricula', '8.0.4');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240515202721_ultimointentoo', '8.0.4');

COMMIT;

