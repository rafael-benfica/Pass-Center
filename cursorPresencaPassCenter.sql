drop procedure testeDeMerda;

DELIMITER $$  
CREATE PROCEDURE `testeDeMerda`(in list_of_ids VARCHAR(32))  
BEGIN  
   create TEMPORARY table if not exists teste(oi text);
   set @sql = concat('insert into teste (oi) values',list_of_ids,'');
   PREPARE stmt1 FROM @sql;
   
   EXECUTE stmt1;
   
   select usu.usu_codigo, pes.pes_codigo, concat(pes_nome, ' ', pes_sobrenomes) as 'nomes_concatenados', pes_matricula from turmas
	inner join eventos_auditores eau using (eau_codigo)
	inner join usuarios usu using (usu_codigo)
	inner join pessoas pes on usu.pes_codigo = pes.pes_codigo
	where eau_codigo = 1 and eau.pes_codigo = 4 and usu.usu_codigo not in (select * from teste);
   
   drop TEMPORARY table teste;

END$$;  
DELIMITER ; 
insert into teste (oi) values(5),(6);
call testeDeMerda('(5),(6)');
call testeDeMerda('(5)');
call testeDeMerda('(6)');
call testeDeMerda('(0)');
select * from usuarios;