CREATE TABLE IF NOT EXISTS "questionTypes" (
	"id" integer NOT NULL GENERATED ALWAYS AS identity PRIMARY KEY,
    "type" varchar NOT NULL,
    "usesQuestionResponseGroups" boolean NOT NULL
);

INSERT INTO "questionTypes"
("type")
VALUES('Text'), ('Number'), ('Boolean'), ('Radio'), ('Select');

CREATE TABLE IF NOT EXISTS "questionResponseGroups" (
	"id" integer NOT NULL GENERATED ALWAYS AS identity PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS "questionResponses" (
	"id" integer NOT NULL GENERATED ALWAYS AS identity PRIMARY KEY,
    "responseText" varchar NOT NULL,
    "questionResponseGroupId" integer NOT NULL REFERENCES "questionResponseGroups"(id)
);

CREATE TABLE IF NOT EXISTS "questionTemplates" (
	"id" integer NOT NULL GENERATED ALWAYS AS identity PRIMARY KEY,
	"questionId" integer NOT NULL,
	"version" integer NOT NULL,
    "text" varchar NULL,
    "questionTypeId" integer NOT NULL REFERENCES "questionTypes"(id),
    "questionResponseGroupId" integer NULL REFERENCES "questionResponseGroups"(id)
);

CREATE TABLE IF NOT EXISTS "formTemplates" (
	"id" integer NOT NULL GENERATED ALWAYS AS identity PRIMARY KEY,
    "name" varchar NOT NULL,
    "isPrimary" boolean NOT NULL
);

INSERT INTO "formTemplates"
("name", "isPrimary")
VALUES('Primary', true);
