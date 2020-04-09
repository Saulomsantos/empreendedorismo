USE bd_dados_qsa_cnpj;

SELECT * FROM tab_cnae;

SELECT * FROM tab_situacao_cadastral;

SELECT * FROM cnpj_dados_cadastrais_pj WHERE cnae_fiscal LIKE '47%' AND municipio LIKE '%santa%';