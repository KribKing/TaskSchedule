IF NOT EXISTS(select 1 from sysobjects where name='usp_jk_getjobzxtj') 
BEGIN     
  EXEC('
    CREATE PROC usp_jk_getjobzxtj  
     @id VARCHAR(32)='''',       
     @system VARCHAR(32)=''''    
    AS    
	DECLARE @kssj VARCHAR(32),@jssj VARCHAR(32)  
	SELECT @kssj=CONVERT(VARCHAR(32),GETDATE(),23),@jssj=CONVERT(VARCHAR(32),GETDATE()+1,23)  
	SELECT  ''{"startTime":"''+@kssj+''","endTime":"''+@jssj+''"}''
    RETURN
   ')
END  
GO 
