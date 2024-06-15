CREATE TABLE geral.modalidades(
	id_modalidade SERIAL PRIMARY KEY,
	titulo VARCHAR(50),
	descricao VARCHAR(1000),
	valor_teto DECIMAL,
	pessoa_juridica BOOLEAN
)
	