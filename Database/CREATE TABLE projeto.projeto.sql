CREATE TABLE projeto.projeto (
    id_projeto SERIAL PRIMARY KEY,
    nome_projeto VARCHAR(255),
    id_proponente INTEGER,
    id_area INTEGER,
    data_prevista_inicio DATE,
    data_prevista_fim DATE,
    resumo_projeto TEXT,
    descricao TEXT,
    objetivos TEXT,
    justificativa_projeto TEXT,
    contrapartida_projeto TEXT,
    plano_democratizacao TEXT,
    outras_informacoes TEXT,
    ingresso BOOLEAN,
    valor_ingresso NUMERIC(18, 2)
);