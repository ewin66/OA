DELIMITER $$

DROP PROCEDURE IF EXISTS InsertActivityRemovedAction $$
/*
 * Insert a single activity removed action.
 */	
CREATE PROCEDURE InsertActivityRemovedAction
(
	IN p_WORKFLOW_INSTANCE_ID BIGINT UNSIGNED
	,IN p_WORKFLOW_INSTANCE_EVENT_ID BIGINT UNSIGNED
	,IN p_QUALIFIED_NAME VARCHAR(128)
	,IN p_TYPE_FULL_NAME VARCHAR(128)
	,IN p_ASSEMBLY_FULL_NAME VARCHAR(256)
	,IN p_PARENT_QUALIFIED_NAME VARCHAR(128)
	,IN p_REMOVED_ACTIVITY_ACTION VARCHAR(2000)
	,IN p_ORDER INT UNSIGNED
)
sproc:BEGIN

	DECLARE l_ACTIVITY_TYPE_ID BIGINT UNSIGNED;
	
	CALL GetTypeId(l_ACTIVITY_TYPE_ID, p_TYPE_FULL_NAME, p_ASSEMBLY_FULL_NAME, NULL);
	
	INSERT INTO REMOVED_ACTIVITY
	(
		WORKFLOW_INSTANCE_ID
		,WORKFLOW_INSTANCE_EVENT_ID
		,QUALIFIED_NAME
		,ACTIVITY_TYPE_ID
		,PARENT_QUALIFIED_NAME
		,REMOVED_ACTIVITY_ACTION
		,`ORDER`
	)
	VALUES
	(
		p_WORKFLOW_INSTANCE_ID
		,p_WORKFLOW_INSTANCE_EVENT_ID
		,p_QUALIFIED_NAME
		,l_ACTIVITY_TYPE_ID
		,p_PARENT_QUALIFIED_NAME
		,p_REMOVED_ACTIVITY_ACTION
		,p_ORDER
	);
	
END $$

DELIMITER ;
