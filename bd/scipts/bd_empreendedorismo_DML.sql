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
FROM 'C:\db\cnpj_dados_cadastrais_pj_T.csv'
	with(
		format = 'csv',
		firstrow = 1,
		fieldterminator = ';',
		rowterminator = '\n',
		codepage = 'ACP',
		datafiletype = 'Char'
		);
GO

UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'NI' WHERE porte_empresa = '0';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'ME' WHERE porte_empresa = '1';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'PP' WHERE porte_empresa = '3';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'DEM' WHERE porte_empresa = '5';