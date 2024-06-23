-- Criar a tabela projeto.detentores com as colunas especificadas
CREATE TABLE projeto.detentores (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    detentor VARCHAR(255) NOT NULL,
    acervo_envolvido TEXT NOT NULL
);
