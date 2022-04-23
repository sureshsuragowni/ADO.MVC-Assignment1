create database SureshGowd; /* creating Database */

/* creating Table*/
create table FootBallLeague
(MatchID INTEGER NOT NULL PRIMARY KEY,
TeamName1 VARCHAR(100),
TeamName2 VARCHAR(100),
Status varchar(40),
WinningTeam varchar(50),
Points integer);

/* insert values into Table */

insert into FootBallLeague
(MatchID,
TeamName1,
TeamName2,
Status,
WinningTeam,
Points
)
values
(1001,'Italy','France','Win','France',4),
(1002,'Brazil','Portugal','Draw',null,2),
(1003,'England','Japan','Win','England',4),
(1004,'USA', 'Russia','Win',   'Russia',4),
(1005,'Portugal','Italy','Draw',null,2),
(1006,'Brazil','France','Win','Brazil',4),
(1007,'England','Russia','Win','Russia',4),
(1008,'Japan','USA','Draw',null,2);

/* Creating A stored procedure */

CREATE PROCEDURE Football
AS
SELECT * FROM FootBallLeague
GO;
exec Football;

/* Retrieve all the winning TeamNames */ 

select TeamName1,TeamName2 
from FootBallLeague
where Status='Win';

/*	Create View Match_View to display the teams whose status is Draw   */

CREATE VIEW MatchView  AS
SELECT TeamName1,TeamName2
FROM FootBallLeague
WHERE Status='Draw';

select * from [MatchView];  /* Display View */

/* Retrieve the details of all matches in which Japan played */

select * from FootBallLeague
where TeamName1='Japan' or TeamName2='Japan';

