-- Criar a tabela projeto.integrantes com as colunas especificadas
CREATE TABLE projeto.integrantes (
    id SERIAL PRIMARY KEY,
    id_projeto INTEGER NOT NULL,
    nome_completo VARCHAR(255) NOT NULL,
    tipo_pessoa CHAR(1) NOT NULL CHECK (tipo_pessoa IN ('F', 'J')), -- 'F' para pessoa física, 'J' para pessoa jurídica
    funcao VARCHAR(255) NOT NULL,
    cpf CHAR(11),
    cnpj CHAR(14),
    CHECK (
        (tipo_pessoa = 'F' AND cpf IS NOT NULL AND cnpj IS NULL) OR
        (tipo_pessoa = 'J' AND cnpj IS NOT NULL AND cpf IS NULL)
    )
);
