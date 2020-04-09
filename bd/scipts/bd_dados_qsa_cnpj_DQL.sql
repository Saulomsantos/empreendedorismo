USE bd_dados_qsa_cnpj;

SELECT * FROM tab_cnae;

SELECT * FROM tab_situacao_cadastral;

SELECT * FROM cnpj_dados_cadastrais_pj WHERE cnae_fiscal LIKE '4711302' AND bairro LIKE '%mateus%';
SELECT * FROM cnpj_dados_cadastrais_pj WHERE cnae_fiscal LIKE '4713004' AND bairro LIKE '%santa%';
SELECT * FROM cnpj_dados_cadastrais_pj WHERE cnae_fiscal LIKE '4712100' AND bairro LIKE '%santa%';