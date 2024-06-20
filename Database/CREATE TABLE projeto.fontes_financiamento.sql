-- Criar a tabela fontes_financiamento com as colunas especificadas
CREATE TABLE geral.fontes_financiamento (
    id_fonte_financiamento SERIAL PRIMARY KEY,
    nome_fonte VARCHAR(255) NOT NULL
);

INSERT INTO geral.fontes_financiamento (nome_fonte) VALUES
    ('Mercenato (Lei 8.313/91)'),
    ('Outras Leis Estaduais de Incentivo'),
    ('Recursos Orçamentários (Inclusive Fundo Nacional)'),
    ('Outros');

-- Criar a tabela projeto.fontes_financiamento com as colunas especificadas
CREATE TABLE projeto.fontes_financiamento (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    tipo_fonte_financiamento VARCHAR(20) NOT NULL,
    id_fonte_financiamento INTEGER NOT NULL,
    valor_financiamento NUMERIC(15, 2) NOT NULL,
    fonte_financiamento_externa VARCHAR(255)
);