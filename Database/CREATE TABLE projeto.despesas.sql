-- Criar a tabela grupo_despesas com as colunas especificadas
CREATE TABLE geral.grupo_despesas (
    id_grupo_despesa SERIAL PRIMARY KEY,
    nome_grupo VARCHAR(255) NOT NULL
);

-- Criar a tabela rubricas com as colunas especificadas
CREATE TABLE geral.rubricas (
    id_rubrica SERIAL PRIMARY KEY,
    nome_rubrica VARCHAR(255) NOT NULL
);

-- Criar a tabela tipo_unidade com as colunas especificadas
CREATE TABLE geral.tipo_unidade (
    id_tipo_unidade SERIAL PRIMARY KEY,
    nome_unidade VARCHAR(255) NOT NULL
);

-- Criar a tabela projeto.despesas com as colunas especificadas
CREATE TABLE projeto.despesas (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    id_grupo_despesa INTEGER NOT NULL,
    id_rubrica INTEGER NOT NULL,
    id_tipo_unidade INTEGER NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL,
    quantidade INTEGER NOT NULL,
    valor_unitario NUMERIC(15, 2) NOT NULL,
    observacao TEXT
);
