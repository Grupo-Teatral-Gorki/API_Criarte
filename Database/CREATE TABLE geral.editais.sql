CREATE TABLE geral.editais(
	id_edital SERIAL PRIMARY KEY,
	titulo VARCHAR(50),
	descricao VARCHAR(1000),
	data_inicial TIMESTAMP,
	data_final TIMESTAMP,
	valor_projeto DECIMAL
)
	