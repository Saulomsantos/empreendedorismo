SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE cod_empresa >= 5600 AND cod_empresa <= 10000;

/*
SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE cod_empresa = 2934;

SELECT * FROM cnpj_dados_cadastrais_pj WHERE cod_empresa = 10498;

UPDATE cnpj_dados_cadastrais_pj SET lat = '-23.4987424' WHERE cod_empresa = 10498;
UPDATE cnpj_dados_cadastrais_pj SET lng = '-46.576317' WHERE cod_empresa = 10498;

SELECT cod_empresa, CNPJ, lat, lng FROM cnpj_dados_cadastrais_pj WHERE numero LIKE 'SN' ORDER BY (cod_empresa);

SELECT COUNT (cnpj) FROM cnpj_dados_cadastrais_pj WHERE situacao_cadastral = 2;