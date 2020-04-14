USE bd_empreendedorismo;
GO

INSERT INTO tab_situacao_cadastral(cod_situacao_cadastral, nm_situacao_cadastral)
VALUES							  (01,'NULA'),
								  (02,'ATIVA'),
								  (03,'SUSPENSA'),
								  (04,'INAPTA'),
								  (08,'BAIXADA');
GO

BULK INSERT tab_cnae
FROM 'C:\db\tab_cnae.csv'
	with(
		format = 'csv',
		firstrow = 1,
		fieldterminator = ';',
		rowterminator = '\n',
		codepage = 'ACP',
		datafiletype = 'Char'
		);
GO

BULK INSERT cnpj_dados_cadastrais_pj
FROM 'C:\db\cnpj_dados_cadastrais_pj.csv'
	with(
		format = 'csv',
		firstrow = 2,
		fieldterminator = ';',
		rowterminator = '\n',
		codepage = 'ACP',
		datafiletype = 'Char'
		);
GO

BULK INSERT teste_socio
FROM 'C:\db\cnpj_dados_socios_pj.csv'
	with(
		format = 'csv',
		firstrow = 2,
		fieldterminator = ';',
		rowterminator = '\n',
		codepage = 'ACP',
		datafiletype = 'Char'
		);
GO