SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE cod_empresa >= 650001 AND cod_empresa <= 700000 AND lat is null;

/*

SELECT COUNT (cod_empresa) FROM cnpj_dados_cadastrais_pj WHERE cod_empresa >= 600001 AND cod_empresa <= 650000 AND lat is null;

SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE cod_empresa >= 600001 AND cod_empresa <= 650000 AND lat is null;


SELECT * FROM cnpj_dados_cadastrais_pj WHERE cod_empresa = 679451;


UPDATE cnpj_dados_cadastrais_pj SET lat = '-23.6089523' WHERE cod_empresa = 679451;
UPDATE cnpj_dados_cadastrais_pj SET lng = '-46.4078592' WHERE cod_empresa = 679451;



SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE numero LIKE 'SN' ORDER BY (cod_empresa);

SELECT COUNT (cnpj) FROM cnpj_dados_cadastrais_pj WHERE situacao_cadastral = 2;

-- Brasilândia, Barra Funda

*/