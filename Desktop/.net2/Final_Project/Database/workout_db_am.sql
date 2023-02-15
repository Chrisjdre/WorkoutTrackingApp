/* check whether the database exists, if so, drop it */

IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'workout_db_am')
BEGIN
	DROP DATABASE workout_db_am
	print '' print '*** dropping database workout_db_am'
END
GO

print '' print '*** creating database workout_db_am'
GO
CREATE DATABASE workout_db_am
GO

print '' print '*** using workout_db_am'
GO
USE [workout_db_am]
GO




/* User table */

print '' print '*** creating User table'
GO
CREATE TABLE [dbo].[User] (
	[UserID]		[int] IDENTITY(1000,1)		NOT NULL,
	[GivenName]		[nvarchar](50)				NOT NULL,
	[FamilyName]	[nvarchar](100)				NOT NULL,
	[Username]		[NVARCHAR](50)				NOT NULL,
	[Gender]		[NVARCHAR](10)				NOT NULL,
	[Email]			[nvarchar](100)				NOT NULL,
	[PasswordHash]	[nvarchar](100)				NOT NULL DEFAULT
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Active]		[bit]						NOT NULL DEFAULT 1,
	CONSTRAINT [pk_UserID] PRIMARY KEY([UserID])
)
GO

/* User test records */

print '' print '*** inserting User test records'
GO
INSERT INTO [dbo].[User]
	([GivenName], [FamilyName],[UserName],[gender], [Email])
	VALUES
		('Darren', 'Bernard', 'DarrenB01','Male', 'Darren@company.com'),
		('Tracy', 'Ewing', 'Tracy02','Female', 'Tracy@company.com'),
		('John', 'Doe', 'John03','Male', 'John@company.com'),
		('Jim', 'Green', 'JimG01','Male', 'Jim@company.com'),
		('Tyler', 'Lund', 'TLund02','Male', 'Tyler@company.com'),
		('Elma', 'Ford', 'ElmaFord','Female', 'Elma@company.com'),
		('Chris', 'Dreismeier', 'Chrisjdre','Male', 'Chris@company.com')
GO


/* User stats table */

print '' print '*** creating User Stats table'
GO
CREATE TABLE [dbo].[Userstats] (
	[UserstatsID]	[int] IDENTITY(1000,1)	NOT NULL,
	[UserID]		[int]					NOT NULL,
	[Bodyfat]		[int]					NOT NULL,
	[calorieintake]	[int]					NOT NULL,
	[weight]		[decimal](5,2)				NOT NULL,
	[Date]	[datetime]					NOT NULL DEFAULT getdate(),
	CONSTRAINT [pk_userstatsID] PRIMARY KEY([UserstatsID]),
	CONSTRAINT [fk_user_stats_user_id]		FOREIGN KEY ([UserID])
		REFERENCES [dbo].[User] ([UserID])
)
GO



/* Userstats test records */

print '' print '*** inserting Userstats test records'
GO
INSERT INTO [dbo].[Userstats]
	([UserID], [Bodyfat],[calorieintake],[weight])
	VALUES
		(1000, 15, 2000,194.50),
		(1001, 15, 2000,194.50),
		(1002, 15, 2000,194.50),
		(1003, 15, 2000,194.50),
		(1004, 15, 2000,194.50),
		(1005, 15, 2000,194.50),
		(1006, 15, 2000,194.50)
GO


/* Role table */
print '' print '*** createing Role table'
GO
CREATE TABLE [dbo].[Role] (
	[RoleID]		[nvarchar](50)				NOT NULL,
	[Description]	[nvarchar](250)				NULL,
	CONSTRAINT [pk_RoleID] PRIMARY KEY ([RoleID])
)
GO

/* Role sample records */
print '' print '*** inserting sample role records'
GO
INSERT INTO [dbo].[Role]
	([RoleId], [Description])
	VALUES
		('Trainer', 'Creates workout templates and trains people'),
		('User', 'uses the program to see templates made and workout')
GO

/* UserRole join table to join User and Roles */
print '' print '*** creating UserRole table'
GO
CREATE TABLE [dbo].[UserRole] (
	[UserID]	[int]							NOT NULL,
	[RoleID]		[nvarchar](50)				NOT NULL,
	CONSTRAINT [fk_UserRole_UserID]		FOREIGN KEY ([UserID])
		REFERENCES [dbo].[User] ([UserID]),
	
	CONSTRAINT [fk_UserRole_RoleID]		FOREIGN KEY ([RoleID])
		REFERENCES [dbo].[Role] ([RoleID]),
	
	CONSTRAINT [pk_UserRole] PRIMARY KEY ([UserID], [RoleID])
)
GO

print '' print '*** inserting sample UserRole table'
GO
INSERT INTO [dbo].[UserRole]
	([UserID], [RoleID])
	VALUES
		(1000, 'User'),
		(1001, 'User'),
		(1002, 'User'),
		(1003, 'User'),
		(1004, 'User'),
		(1005, 'Trainer'),
		(1006, 'User')

GO


/* Workout table */

print '' print '*** creating Workout table'
GO
CREATE TABLE [dbo].[Workout] (
	[WorkoutID]		[int] IDENTITY(100000,1)	NOT NULL,
	[UserID]		[int]						NOT NULL,
	[WorkoutTypeName]		[NVARCHAR](50)		NOT NULL,
	[WorkoutName]	[NVARCHAR](50)				NOT NULL,
	[WorkoutDate]	[datetime]					NOT NULL,
	[Deleted]		[bit]						NOT NULL DEFAULT 0,
	CONSTRAINT [pk_WorkoutID] PRIMARY KEY([WorkoutID]),
	CONSTRAINT [fk_Workout_user_id]		FOREIGN KEY ([UserID])
		REFERENCES [dbo].[User] ([UserID])
)
GO

/* Workout sample records */
print '' print '*** inserting sample Workout records'
GO
INSERT INTO [dbo].[Workout]
	([UserID], [WorkoutTypeName], [WorkoutName], [WorkoutDate])
	VALUES
		(1000, 'Chest', 'Push Day', GETDATE()),
		(1001, 'Legs', 'Leg Day', GETDATE()),
		(1002, 'Cardio', 'Im gonna die', GETDATE()),
		(1003, 'Back', 'Give me big delts', GETDATE()),
		(1004, 'Shoulders', 'Boulders on my shoulders', GETDATE()),
		(1006, 'Chest', 'big titties', GETDATE())
GO


/* ExerciseEquipment table */

print '' print '*** creating ExerciseEquipment table'
GO
CREATE TABLE [dbo].[ExerciseEquipment] (
	[EquipmentID]	[int] IDENTITY(100000,1)	NOT NULL,
	[EquipmentName]	[NVARCHAR](20)						NOT NULL,
	CONSTRAINT [pk_EquipmentID] PRIMARY KEY([EquipmentID])
)
GO

print '' print '*** inserting sample ExerciseEquipment'
GO
INSERT INTO [dbo].[ExerciseEquipment]
	([EquipmentName])
	VALUES
		('Olympic Barbell'),
		('Dumbells'),
		('Bands'),
		('Ez Bar')
GO


/* Exercise table */

print '' print '*** creating Exercise table'
GO
CREATE TABLE [dbo].[Exercise] (
	[ExerciseID]				[int] IDENTITY(100000,1)	NOT NULL,
	[EquipmentID]				[int]						NULL,
	[ExerciseType]				[NVARCHAR](30)				NOT NULL,
	[ExerciseName]				[NVARCHAR](50)				NOT NULL,
	[ExerciseDescription]		[NVARCHAR](500)		NOT NULL,
	CONSTRAINT [pk_ExerciseID] PRIMARY KEY([ExerciseID]),
	CONSTRAINT [fk_Exercise_EquipmentID]		FOREIGN KEY ([EquipmentID])
		REFERENCES [dbo].[ExerciseEquipment] ([EquipmentID])
)
GO

/* Exercise sample records */
print '' print '*** inserting sample Exercise records'
GO
INSERT INTO [dbo].[Exercise]
	([EquipmentID], [ExerciseType], [ExerciseName], [ExerciseDescription])
	VALUES
		(100000, 'Compound', 'Barbell squat', 'a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent of a squat, the hip and knee joints flex while the ankle joint dorsiflexes; conversely the hip and knee joints extend and the ankle joint plantarflexes when standing up. '),
		(100000, 'Compound', 'Barbell benchpress', 'a weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.'),
		(100000, 'Compound', 'Deadlift', 'weight training exercise in which a loaded barbell or bar is lifted off the ground to the level of the hips, torso perpendicular to the floor, before being placed back on the ground.'),
		(100001, 'isolation', 'Dumbell Curl', 'works your biceps'),
		(100001, 'Compound', 'Dumbell Benchpress', 'a weight training exercise in which the trainee presses a weight upwards while lying on a weight training bench.'),
		(100001, 'Compound', 'Dumbell RDL', 'a deadlift in which the body is bent at the hips and the knees are not bent.'),
		(100002, 'isolation', 'Chest Fly', ' a strength training exercise in which the hand and arm move through an arc while the elbow is kept at a constant angle.'),
		(100003, 'isolation', 'Skull Crushers', 'push an easy bar or dubell away from your face and back to it'),
		(NULL, 'Cardio', 'Sprints', 'Running')
GO


/* ExerciseWorkout join table to join Workout and Exercise */
print '' print '*** creating WorkoutExercises table'
GO
CREATE TABLE [dbo].[WorkoutExercises] (
	[WorkoutID]		[int]							NOT NULL,
	[ExerciseID]	[int]							NOT NULL,
	CONSTRAINT [fk_WorkoutExercises_WorkoutID]		FOREIGN KEY ([WorkoutID])
		REFERENCES [dbo].[Workout] ([WorkoutID]),
	
	CONSTRAINT [fk_WorkoutExercises_ExerciseID]		FOREIGN KEY ([ExerciseID])
		REFERENCES [dbo].[Exercise] ([ExerciseID]),
	
	CONSTRAINT [pk_WorkoutExercises] PRIMARY KEY ([WorkoutID], [ExerciseID])
)
GO


/* Exercise stats table */

print '' print '*** creating Exercise stats table'
GO
CREATE TABLE [dbo].[ExerciseStats] (
	[ExercisestatID]		[int] IDENTITY(1000,1)	NOT NULL,
	[Weight]				[int]						NOT NULL,
	[Sets]					[int]						NOT NULL,
	[Reps]					[int]						NOT NULL,
	[Deleted]				[bit]						NOT NULL DEFAULT 0,
	CONSTRAINT [pk_ExercisestatID] PRIMARY KEY([ExercisestatID])
)
GO

print '' print '*** inserting sample Exercise stats table'
GO
INSERT INTO [dbo].[ExerciseStats]
	([Weight],[Sets], [Reps] )
	VALUES
		(135,3,10),
		(135,3,10),
		(135,3,10),
		(135,3,10),
		(135,3,10)
GO


/* UserExercise join table to join stats with exercise, user, and workouts */
print '' print '*** creating UserExercise table'
GO
CREATE TABLE [dbo].[UserExercise] (
	[UserID]			[int]							NOT NULL,
	[WorkoutID]			[int]							NOT NULL,
	[ExerciseID]		[int]							NOT NULL,
	[ExercisestatID]	[int]							NOT NULL,
	CONSTRAINT [fk_UserExercise_WorkoutID]		FOREIGN KEY ([WorkoutID])
		REFERENCES [dbo].[Workout] ([WorkoutID]),
	
	CONSTRAINT [fk_UserExercise_ExerciseID]		FOREIGN KEY ([ExerciseID])
		REFERENCES [dbo].[Exercise] ([ExerciseID]),
		
	CONSTRAINT [fk_UserExercise_UserID]		FOREIGN KEY ([UserID])
		REFERENCES [dbo].[User] ([UserID]),
		
	CONSTRAINT [fk_UserExercise_ExercisestatID]		FOREIGN KEY ([ExercisestatID])
		REFERENCES [dbo].[ExerciseStats] ([ExercisestatID]),
	
	CONSTRAINT [pk_UserExercise] PRIMARY KEY ([WorkoutID],[ExerciseID] ,[UserID] ,[ExercisestatID])
)
GO 

print '' print '*** inserting sample UserExercise table'
GO
INSERT INTO [dbo].[UserExercise]
	([UserID],[WorkoutID], [ExerciseID],[ExercisestatID]  )
	VALUES
		(1006,100005,100001,1000),
		(1006,100005,100004,1001),
		(1006,100005,100006,1002),
		(1006,100005,100007,1003),
		(1006,100005,100001,1004)
GO



print '' print '*** creating sp_select_Exercises'
GO
CREATE PROCEDURE [dbo].[sp_select_Exercises]

AS
	BEGIN
		SELECT 	[ExerciseID],[ExerciseType],[ExerciseName],[ExerciseDescription]
		FROM	[Exercise]
	END
GO



/* login related stored procedures */
print '' print '*** creating sp_authenticate_user'
GO
CREATE PROCEDURE [dbo].[sp_authenticate_user]
(
	@Email			[nvarchar](100),
	@PasswordHash	[nvarchar](100)
)
AS
	BEGIN
		SELECT COUNT([UserID]) AS 'Authenticated'
		FROM		[User]
		WHERE		@Email = [Email]
			AND		@PasswordHash = [PasswordHash]
			AND		[Active] = 1
	END
GO

print '' print '*** creating sp_select_User_by_email'
GO
CREATE PROCEDURE [dbo].[sp_select_User_by_email]
(
	@Email 			[nvarchar](100)
)
AS	
	BEGIN
		SELECT [UserID], [GivenName], [FamilyName], 
				[Username], [Gender], [Email], [Active]
		FROM	[User]
		WHERE	@Email = [Email]
	END     
GO            

print '' print '*** creating sp_select_roles_by_UserID'
GO
CREATE PROCEDURE [dbo].[sp_select_roles_by_UserID]
(
	@UserID			[int]
)
AS
	BEGIN
		SELECT 	[RoleID]
		FROM	[UserRole]
		WHERE	@UserID = [UserID]
	END
GO

/* End of login stored procedures */


print '' print '*** creating sp_select_Workouts_by_UserID'
GO
CREATE PROCEDURE [dbo].[sp_select_Workouts_by_UserID]
(
	@UserID			[int]
)
AS	
	BEGIN
		SELECT 	[WorkoutID], [UserID], [WorkoutTypeName], [WorkoutName], [WorkoutDate] 
		FROM	[Workout]
		WHERE	@UserID = [UserID]
		AND 	[Deleted] = 0
	END
GO



print '' print '*** creating sp_select_ExerciseStats_by_WorkoutID'
GO
CREATE PROCEDURE [dbo].[sp_select_ExerciseStats_by_WorkoutID]
(
	@WorkoutID			[int]
)
AS
	BEGIN
		SELECT 	[ExerciseName],[ExerciseStats].[ExerciseStatID],[Weight], [Sets], [Reps]
		FROM	[ExerciseStats] Join [UserExercise] on [ExerciseStats].[ExerciseStatID] = [UserExercise].[ExerciseStatID] 
				Join [Exercise] on [UserExercise].[ExerciseID] = [Exercise].[ExerciseID] 
				Join [Workout] on [UserExercise].[WorkoutID] = [Workout].[WorkoutID]
		WHERE	@WorkoutID = [Workout].[WorkoutID]
		And 	[ExerciseStats].[Deleted] = 0
	END
GO


print '' print '*** creating sp_insert_ExerciseStats'
GO
CREATE PROCEDURE [dbo].[sp_insert_ExerciseStats]
(
	@Weight			[int],
	@Sets			[int],
	@Reps			[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[ExerciseStats]
	([Weight],[Sets], [Reps] )
	VALUES
		(@Weight,@Sets,@Reps)
	select scope_Identity()
	END
GO

print '' print '*** creating sp_insert_UserExercise'
GO
CREATE PROCEDURE [dbo].[sp_insert_UserExercise]
(
	@UserID				[int],
	@WorkoutID			[int],
	@ExerciseID			[int],
	@ExercisestatID		[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[UserExercise]
	([UserID],[WorkoutID], [ExerciseID],[ExercisestatID]  )
	VALUES
		(@UserID, @WorkoutID, @ExerciseID, @ExercisestatID)
	RETURN 	@@ROWCOUNT
	END
GO




print '' print '*** creating sp_Delete_ExerciseStats'	
GO
CREATE PROCEDURE [dbo].[sp_Delete_ExerciseStats]
(
	@ExerciseStatID 	[int]
)
AS
	BEGIN
		UPDATE	[ExerciseStats]
		  SET	[Deleted] =	1
		WHERE	@ExerciseStatID 	= 	[ExerciseStatID]
		  
		RETURN 	@@ROWCOUNT
	END
GO

print '' print '**creating sp_update_ExerciseStats'
GO
CREATE PROCEDURE [dbo].[sp_update_ExerciseStats]
(
	@ExerciseStatID				[int],
	@Weight						[int],
	@OldWeight					[int],
	@Sets						[int],
	@OldSets					[int],
	@Reps						[int],
	@OldReps					[int]
)
AS
	BEGIN
		UPDATE	[ExerciseStats]
		  SET	[Weight] = 	@Weight,
				[Sets] = 	@Sets,
				[Reps] = 	@Reps
		WHERE	[ExerciseStatID] 	= 	@ExerciseStatID	
		  AND	[Weight] 	= 		@OldWeight
		  AND	[Sets]		= 		@OldSets
		  AND	[Reps] 		= 		@OldReps
		  
		RETURN 	@@ROWCOUNT
	END
GO


print '' print '*** creating sp_insert_Workout'
GO
CREATE PROCEDURE [dbo].[sp_insert_Workout]
(
	@UserID					[int],
	@WorkoutTypeName		[NVARCHAR](50),
	@WorkoutName			[NVARCHAR](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[Workout]
	([UserID], [WorkoutTypeName], [WorkoutName], [WorkoutDate]  )
	VALUES
		(@UserID, @WorkoutTypeName, @WorkoutName, GETDATE())
	RETURN 	@@ROWCOUNT
	END
GO

print '' print '*** creating sp_Delete_Workout'	
GO
CREATE PROCEDURE [dbo].[sp_Delete_Workout]
(
	@WorkoutID 	[int]
)
AS
	BEGIN
		UPDATE	[Workout]
		  SET	[Deleted] =	1
		WHERE	@WorkoutID 	= 	[WorkoutID]
		  
		RETURN 	@@ROWCOUNT
	END
GO

print '' print '*** creating sp_insert_UserStats'
GO
CREATE PROCEDURE [dbo].[sp_insert_UserStats]
(
	@UserID				[int],
	@Bodyfat			[int],
	@calorieintake		[int],
	@weight				[decimal]
)
AS
	BEGIN
		INSERT INTO [dbo].[Userstats]
	([UserID], [Bodyfat],[calorieintake],[weight])
	VALUES
		(@UserID, @Bodyfat, @calorieintake,@weight)
	RETURN 	@@ROWCOUNT
	END
GO


print '' print '*** creating sp_select_UserStats_by_UserID'
GO
CREATE PROCEDURE [dbo].[sp_select_UserStats_by_UserID]
(
	@UserID			[int]
)
AS
	BEGIN
		SELECT 	[UserstatsID], [UserID], [bodyfat],[calorieintake], [weight], [Date]
		FROM	[Userstats] 
		WHERE	@userID = [userid]
	END
GO

print '' print '*** creating sp_insert_Exercise'
GO
CREATE PROCEDURE [dbo].[sp_insert_Exercise]
(
	@ExerciseType				[NVARCHAR](30),
	@ExerciseName				[NVARCHAR](50),
	@ExerciseDescription		[NVARCHAR](500)
)
AS
	BEGIN
		INSERT INTO [dbo].[Exercise]
	([ExerciseType], [ExerciseName], [ExerciseDescription])
	VALUES
		(@ExerciseType, @ExerciseName, @ExerciseDescription)
	RETURN 	@@ROWCOUNT
	END
GO



print '' print '*** creating sp_insert_Account'
GO
CREATE PROCEDURE [dbo].[sp_insert_Account]
(
	@Email						[NVARCHAR](100),
	@GivenName					[NVARCHAR](50),
	@FamilyName					[nvarchar](100),
	@Username					[NVARCHAR](50),
	@Gender						[NVARCHAR](10),
	@PasswordHash				[nvarchar](100)
)
AS
	BEGIN
		INSERT INTO [dbo].[User]
	([GivenName], [FamilyName], [Username], [Gender], [Email], [PasswordHash])
	VALUES
		(@GivenName, @FamilyName, @Username, @Gender, @Email, @PasswordHash)
	RETURN 	@@ROWCOUNT
	END
GO

	[UserID]		[int] IDENTITY(1000,1)	NOT NULL,
	[GivenName]		[nvarchar](50)				NOT NULL,
	[FamilyName]	[nvarchar](100)				NOT NULL,
	[Username]		[NVARCHAR](50)				NOT NULL,
	[Gender]		[NVARCHAR](10)				NOT NULL,
	[Email]			[nvarchar](100)				NOT NULL,
	[PasswordHash]	[nvarchar](100)				NOT NULL DEFAULT
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Active]		[bit]						NOT NULL DEFAULT 1,