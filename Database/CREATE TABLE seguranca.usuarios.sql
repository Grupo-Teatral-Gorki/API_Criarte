CREATE TABLE seguranca.usuarios (
	id_usuario SERIAL PRIMARY KEY,
	email VARCHAR(100),
	senha VARCHAR(20),
	token VARCHAR(8),
	expiration_token TIMESTAMP
)