DROP TABLE IF EXISTS ACTIVITY;
CREATE TABLE ACTIVITY
(
	WORKFLOW_TYPE_ID BIGINT UNSIGNED NOT NULL
	,QUALIFIED_NAME VARCHAR(128) NOT NULL
	,ACTIVITY_TYPE_ID BIGINT UNSIGNED NOT NULL
	,PARENT_QUALIFIED_NAME VARCHAR(128) NULL
	,PRIMARY KEY (WORKFLOW_TYPE_ID, QUALIFIED_NAME)
);

CREATE INDEX ACTIVITY_IDX01 ON ACTIVITY ( QUALIFIED_NAME );
CREATE INDEX ACTIVITY_IDX02 ON ACTIVITY ( WORKFLOW_TYPE_ID );
