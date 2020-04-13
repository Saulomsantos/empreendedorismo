SELECT cnpj,
razao_social,
situacao_cadastral,
cnae_fiscal,
descricao_tipo_logradouro,
logradouro,
numero,
complemento,
bairro,
uf,
municipio,
ddd_telefone_1,
ddd_telefone_2,
ddd_fax,
correio_eletronico,
porte_empresa
FROM cnpj_dados_cadastrais_pj
INNER JOIN tab_cnae
ON cnpj_dados_cadastrais_pj.cnae_fiscal = tab_cnae.cod_cnae
WHERE municipio = 'SAO PAULO' AND cod_secao = 'A'