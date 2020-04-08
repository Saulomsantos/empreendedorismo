SELECT cnpj, razao_social, cnae_fiscal, bairro, municipio, nm_cnae FROM cnpj_dados_cadastrais_pj
INNER JOIN tab_cnae
ON cnpj_dados_cadastrais_pj.cnae_fiscal = tab_cnae.cod_cnae
WHERE uf = 'SP' AND cnae_fiscal LIKE '4771701' ORDER BY municipio