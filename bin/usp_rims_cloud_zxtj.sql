if exists(select 1 from sysobjects where name='usp_rims_cloud_zxtj')
   drop proc usp_rims_cloud_zxtj
go
create proc usp_rims_cloud_zxtj
@code varchar(64)=''
as

declare @kssj varchar(32),@jssj varchar(32)

select @kssj=convert(varchar,getdate()-1,23),@jssj=convert(varchar,getdate(),23)

if @code='BZ_MZ20'
begin
    select @kssj=convert(varchar,getdate()-30,23)
    select '<NETHIS>
				  <CSXX>
					  <JGDM>12310115MB2F024840</JGDM>
					  <KSRQ>'+@kssj+'</KSRQ>
					  <JSRQ>'+@jssj+'</JSRQ>
				  </CSXX>
			</NETHIS>'
end 
else if @code='BZ_MZ21'
begin
     select '<NETHIS>
				  <CSXX>
					  <JGDM>12310115MB2F024840</JGDM>
					  <KSRQ>'+@kssj+'</KSRQ>
					  <JSRQ>'+@jssj+'</JSRQ>
				  </CSXX>
			</NETHIS>'
end 
else if @code='BZ_ZY11'
begin
     select @kssj=convert(varchar,getdate()-30,23)
     select '<NETHIS>
				  <CSXX>
					  <JGDM>12310115MB2F024840</JGDM>
					  <KSRQ>'+@kssj+'</KSRQ>
					  <JSRQ>'+@jssj+'</JSRQ>
				  </CSXX>
			</NETHIS>'
end 
else if @code='BZ_ZY12'
begin
     select @kssj=convert(varchar,getdate()-10,23)
     select '<NETHIS>
				  <CSXX>
					  <JGDM>12310115MB2F024840</JGDM>
					  <KSRQ>'+@kssj+'</KSRQ>
					  <JSRQ>'+@jssj+'</JSRQ>
				  </CSXX>
			</NETHIS>'
end 

return 
go 