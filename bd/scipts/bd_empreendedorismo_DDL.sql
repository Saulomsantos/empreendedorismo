CREATE DATABASE bd_empreendedorismo;
GO

USE bd_empreendedorismo;
GO

CREATE TABLE tab_cnae (
	cod_secao		VARCHAR (255),
	nm_secao		TEXT,
	cod_divisao		VARCHAR (255),
	nm_divisao		TEXT,
	cod_grupo		VARCHAR (255),
	nm_grupo		TEXT,
	cod_classe		VARCHAR (255),
	nm_classe		TEXT,
	cod_cnae		INT PRIMARY KEY,
	nm_cnae			TEXT
);
GO

CREATE TABLE tab_situacao_cadastral (
	cod_situacao_cadastral	INT PRIMARY KEY,
	nm_situacao_cadastral	TEXT
);
GO

CREATE TABLE cnpj_dados_cadastrais_pj (
	cod_empresa					INT PRIMARY KEY IDENTITY,
	cnpj						BIGINT,
	razao_social				TEXT,
	situacao_cadastral			INT FOREIGN KEY REFERENCES tab_situacao_cadastral(cod_situacao_cadastral),
	cnae_fiscal					INT FOREIGN KEY REFERENCES tab_cnae(cod_cnae),
	descricao_tipo_logradouro	TEXT,
	logradouro					TEXT,
	numero						TEXT,
	complemento					TEXT,
	bairro						VARCHAR (255),
	cep							VARCHAR (255),
	uf							VARCHAR (255),
	municipio					VARCHAR (255),
	ddd_telefone_1				TEXT,
	ddd_telefone_2				TEXT,
	ddd_fax						TEXT,
	correio_eletronico			TEXT,
	porte_empresa				VARCHAR (255)
);
GO

CREATE TABLE cnpj_dados_socios_pj (
	cod_socio				INT PRIMARY KEY,
	cnpj					BIGINT,
	identificador_socio		TEXT,
	nome_socio				TEXT,
	CNPJ_CPF_SOCIO			TEXT
);
GO