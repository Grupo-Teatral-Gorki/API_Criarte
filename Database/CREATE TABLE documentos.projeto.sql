CREATE TABLE documentos.projeto(
	id_documento SERIAL PRIMARY KEY,
	id_projeto INT NOT NULL,
	id_tipo INT,
	nome_arquivo VARCHAR(50),
	formato VARCHAR(10),
	data_inclusao DATE
)