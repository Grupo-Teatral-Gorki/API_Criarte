CREATE TABLE projeto.responsaveis_tecnicos (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    nome VARCHAR(255) NOT NULL,
    cpf CHAR(11) NOT NULL
);
