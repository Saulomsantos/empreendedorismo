USE bd_empreendedorismo;
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