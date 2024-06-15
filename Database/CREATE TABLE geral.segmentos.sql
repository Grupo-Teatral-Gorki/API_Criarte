-- Criar a tabela com id_area como chave primária autoincrementada
CREATE TABLE geral.segmentos (
    id_area SERIAL PRIMARY KEY,
    nome_area VARCHAR(255) NOT NULL
);

-- Inserir as áreas culturais na tabela
INSERT INTO geral.segmentos (nome_area) VALUES
    ('Artes Plásticas, visuais e design'),
    ('Bibliotecas, arquivos e centros culturais'),
    ('Cinema'),
    ('Circo'),
    ('Cultura popular'),
    ('Dança'),
    ('Eventos carnavalescos e escolas de samba'),
    ('Hip-Hop'),
    ('Literatura'),
    ('Museu'),
    ('Música'),
    ('Ópera'),
    ('Patrimônio histórico e artístico'),
    ('Recuperação, construção e Manutenção de espaços de circulação da produção cultural no estado'),
    ('Restauração e conservação de bens protegidos pelo órgão oficial de preservação'),
    ('Teatro'),
    ('Vídeo'),
    ('Projetos especiais'),
    ('Bolsas de estudos para cursos de caráter cultural ou artístico'),
    ('Pesquisa e documentação'),
    ('Plano anual de atividades'),
    ('Festival de eventos'),
    ('Programas de rádio e de televisão com finalidades cultural, social e de prestação de serviço à comunidade');
