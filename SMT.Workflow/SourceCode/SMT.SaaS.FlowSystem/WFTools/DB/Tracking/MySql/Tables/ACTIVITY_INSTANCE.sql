DROP TABLE IF EXISTS ACTIVITY_INSTANCE;
CREATE TABLE ACTIVITY_INSTANCE
(
	ACTIVITY_INSTANCE_ID BIGINT UNSIGNED AUTO_INCREMENT NOT NULL
	,WORKFLOW_INSTANCE_ID BIGINT UNSIGNED NOT NULL
	,QUALIFIED_NAME VARCHAR(128) NOT NULL
	,CONTEXT_GUID CHAR(36) NOT NULL
	,PARENT_CONTEXT_GUID CHAR(36) NULL
	,WORKFLOW_INSTANCE_EVENT_ID BIGINT UNSIGNED NULL
	,PRIMARY KEY ( ACTIVITY_INSTANCE_ID )
);

CREATE INDEX ACTIVITY_INSTANCE_IDX01 ON ACTIVITY_INSTANCE ( WORKFLOW_INSTANCE_ID );
CREATE INDEX ACTIVITY_INSTANCE_IDX02 ON ACTIVITY_INSTANCE ( WORKFLOW_INSTANCE_ID, QUALIFIED_NAME, CONTEXT_GUID, PARENT_CONTEXT_GUID );
