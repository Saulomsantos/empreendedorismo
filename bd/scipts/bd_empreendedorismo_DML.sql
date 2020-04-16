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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_A.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_B.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_C.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_D.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_E.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_F.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_45.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_46.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_471.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_472.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_473.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_474.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_475.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_476.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_477.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_G_478.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_H.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_I.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_J.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_K.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_L.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_M.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_N.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_O.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_P.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_Q.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_R.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_S.csv'
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
FROM '\\Tfiesp01\f\db\cnpj_dados_cadastrais_pj_T.csv'
	with(
		format = 'csv',
		firstrow = 1,
		fieldterminator = ';',
		rowterminator = '\n',
		codepage = 'ACP',
		datafiletype = 'Char'
		);
GO


TRUNCATE TABLE cnpj_dados_cadastrais_pj;


UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'NI' WHERE porte_empresa = '0';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'ME' WHERE porte_empresa = '1';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'PP' WHERE porte_empresa = '3';
UPDATE cnpj_dados_cadastrais_pj SET porte_empresa = 'DEM' WHERE porte_empresa = '5';