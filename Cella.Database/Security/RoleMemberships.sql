ALTER ROLE [db_owner] ADD MEMBER [svc_user];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [svc_user];


GO
ALTER ROLE [db_datareader] ADD MEMBER [svc_user];

