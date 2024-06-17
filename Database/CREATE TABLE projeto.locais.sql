CREATE TABLE projeto.locais (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    id_cidade INTEGER NOT NULL,
    nome_local VARCHAR(255),
    lotacao VARCHAR(255),
    qtd_apresentacoes INTEGER,
    endereco_completo TEXT
);