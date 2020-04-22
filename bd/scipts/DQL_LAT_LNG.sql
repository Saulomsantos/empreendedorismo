SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE cod_empresa > 1000 AND cod_empresa < 1701;

SELECT * FROM cnpj_dados_cadastrais_pj WHERE cod_empresa = 1065;

SELECT COUNT (cnpj) FROM cnpj_dados_cadastrais_pj WHERE situacao_cadastral = 2;