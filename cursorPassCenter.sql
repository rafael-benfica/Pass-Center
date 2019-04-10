delimiter $

create procedure MigrarAno(in vInstituicao int, in vPeriodo varchar(45))
begin
	declare _eau_codigo INT;
	declare _eau_periodo_identificacao VARCHAR(45);
	declare _eau_estado TINYINT;
	declare _eau_data_abertura DATETIME;
	declare _eau_data_fechamento DATETIME;
	declare _pes_codigo INT;
	declare _eve_codigo INT;
	declare _ins_codigo INT;

	declare i INT;
	declare total INT;

	declare c1 cursor for select * from enventos_auditores where ins_codigo = vInstituicao and eau_estado = 1;

	set i = 0;
	set total = 0;

	select count(*) into total from enventos_auditores where ins_codigo = vInstituicao and eau_estado = 1;


	open c1;
		while i<total do
			fetch c1 into _eau_codigo, _eau_periodo_identificacao, _eau_estado, _eau_data_abertura, 
			_eau_data_fechamento, _pes_codigo, _eve_codigo, _ins_codigo;
			
			update enventos_auditores set eau_estado = 0, eau_data_fechamento = NOW() where eau_codigo = _eau_codigo;
			
			insert into enventos_auditores values (0, vPeriodo, 1, NOW(), null, _pes_codigo, _eve_codigo, _ins_codigo);
			
		   set i = i + 1;
		
		end while;
	close c1;
end
$
