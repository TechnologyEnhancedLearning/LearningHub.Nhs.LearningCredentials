--------------------------------------------------------------------------
--	Dave Brown 28 Feb 2023  - Initial version
--------------------------------------------------------------------------
CREATE PROCEDURE [dsp].[proc_LatestCompletedActivityByComponents]
	@userId		INT, 
	@ComponentIds NVARCHAR(1024)
AS
BEGIN

	WITH return_table (ComponentId, UserComponentId, ComponentTypeId, ComponentName, AttainmentStatus)
	AS
	(
		SELECT c.componentId, uc.userComponentId, c.componentTypeId, c.componentName, act.activityStatus
		from userComponentTBL uc
		INNER JOIN activityStatusTBL act ON uc.activityStatusId = act.activityStatusId
		INNER JOIN componentTBL c on uc.componentId = c.componentId
		INNER JOIN fun_NTextToIntTable(@ComponentIds) componentIds ON componentIds.Value = uc.componentId
		WHERE uc.ActivityStatusId in (3 /* Completed */, 5 /* Passed */)
			AND userId = @UserID
			AND uc.deleted = 0 AND c.deleted = 0
	)

	SELECT	res.ComponentId, res.UserComponentId, res.ComponentTypeId, res.ComponentName, res.AttainmentStatus, Max(uca.activityEnd) as ActivityDate
	FROM return_table res
	INNER JOIN userComponentActivityTBL uca ON res.UserComponentId = uca.userComponentId
	WHERE	res.ComponentTypeId = 7 -- session
		AND uca.ActivityStatusId in (3 /* Completed */, 5 /* Passed */)
	GROUP BY res.ComponentId, res.UserComponentId, res.ComponentTypeId, res.ComponentName, res.AttainmentStatus
	UNION
	SELECT	res.ComponentId, res.UserComponentId, res.ComponentTypeId, res.ComponentName, res.AttainmentStatus, Max(uca.activityEnd) as ActivityDate
	FROM return_table res
	INNER JOIN relationshipCourseSessionTBL rcs ON rcs.courseComponentId = res.ComponentId
	INNER JOIN userComponentTBL uc ON rcs.sessionComponentId = uc.ComponentId AND uc.userId = @UserID
	INNER JOIN userComponentActivityTBL uca ON uca.userComponentId = uc.userComponentId
	WHERE	res.ComponentTypeId = 4 -- course
		AND uca.ActivityStatusId in (3 /* Completed */, 5 /* Passed */)
		AND rcs.deleted = 0 AND uc.deleted = 0
	GROUP BY res.ComponentId, res.UserComponentId, res.ComponentTypeId, res.ComponentName, res.AttainmentStatus

END
GO
