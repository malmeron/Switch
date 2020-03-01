DELIMITER //
CREATE PROCEDURE sp_OBTER_USERS_POR_INST_ENSINO()
BEGIN

	select us.Nome as NomeUsuario, 
    us.SobreNome as SobreNomeUsuario,
    inst.Nome as NomeInstEnsino
    from usuarios us
    inner join instituicoesensino inst 
    on us.id = inst.usuarioid;

END//