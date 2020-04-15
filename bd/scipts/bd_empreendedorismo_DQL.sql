USE bd_empreendedorismo;
GO

SELECT cnpj, razao_social, situacao_cadastral, cnae_fiscal, descricao_tipo_logradouro,
logradouro, numero, complemento, bairro, uf, municipio, ddd_telefone_1, ddd_telefone_2,
ddd_fax, correio_eletronico, porte_empresa
FROM cnpj_dados_cadastrais_pj
INNER JOIN tab_cnae
ON cnpj_dados_cadastrais_pj.cnae_fiscal = tab_cnae.cod_cnae
WHERE municipio = 'SAO PAULO' AND cod_secao = 'A';
GO

SELECT * FROM cnpj_dados_cadastrais_pj
WHERE municipio = 'sao paulo' AND bairro = 'pinheiros' AND cnae_fiscal LIKE '152103';

SELECT tab_cnae.cod_cnae, COUNT (cnpj) AS [Qtd Empresas] FROM cnpj_dados_cadastrais_pj
INNER JOIN tab_cnae ON cnpj_dados_cadastrais_pj.cnae_fiscal = tab_cnae.cod_cnae
WHERE bairro = 'santa cecilia' GROUP BY tab_cnae.cod_cnae;

SELECT COUNT (cnpj) AS [Qtd Empresas] FROM cnpj_dados_cadastrais_pj
WHERE bairro = 'pinheiros' AND cnae_fiscal LIKE '152101';

SELECT * FROM tab_cnae;