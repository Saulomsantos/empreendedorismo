CREATE DATABASE bd_dados_qsa_cnpj;
GO

USE bd_dados_qsa_cnpj;
GO

CREATE TABLE tab_cnae (
	cod_cnae	INT PRIMARY KEY,
	nm_cnae		TEXT
);
GO

CREATE TABLE tab_situacao_cadastral (
	cod_situacao_cadastral			INT PRIMARY KEY,
	nm_situacao_cadastral			TEXT
);
GO

CREATE TABLE cnpj_dados_cadastrais_pj (
	cnpj				BIGINT PRIMARY KEY,
	razao_social		TEXT,
	nome_fantasia		TEXT,
	cnae_fiscal			INT FOREIGN KEY REFERENCES tab_cnae(cod_cnae),
	situacao_cadastral	INT FOREIGN KEY REFERENCES tab_situacao_cadastral(cod_situacao_cadastral),
	bairro				VARCHAR (255),
	uf					VARCHAR (255),
	municipio			VARCHAR (255)
);
GO