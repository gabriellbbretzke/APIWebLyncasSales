USE SALES_LYNCAS

SELECT * FROM CLIENTE
SELECT * FROM USUARIO
SELECT * FROM VENDA
SELECT * FROM ITEM_VENDA

--Retornar todos os pedidos onde o valor faturado for mais que um valor X (Escolher um valor);
--VALOR ESCOLHIDO 650
DECLARE @VALORESCOLHIDO FLOAT
SET @VALORESCOLHIDO = 650
SELECT * FROM VENDA WHERE total_venda >= @VALORESCOLHIDO;

--Retornar todos os pedidos onde há item/itens com a descrição X (Usar uma parcial do nome de algum item informado)
--DESCRIÇÃO: POSSUÍ O CARACTER '2'
SELECT * FROM VENDA A 
INNER JOIN ITEM_VENDA B
ON A.id = B.id_venda
WHERE B.descricao LIKE '%2%';

--Retornar o valor médio de todos os pedidos;
SELECT AVG(total_venda) FROM VENDA;

--Retornar o valor médio dos pedidos por cliente;
SELECT id_cliente, AVG(total_venda) AS [MÉDIA DE COMPRA POR CLIENTE], SUM(total_venda) AS [TOTAL COMPRA POR CLIENTE] FROM VENDA
GROUP BY id_cliente;

--Criar alguns pedidos que contenham o mesmo item, então faça uma consulta que me retorne (Item, quantidade total vendida, valor total vendido) 
--ITEM ESCOLHIDO: 'Item6'
SELECT * FROM ITEM_VENDA;
----LINHA DE COMANDO ABAIXO PARA VALIDAR UMA ITEM TOTAL-----
SELECT SUM(total_itens_venda) FROM ITEM_VENDA WHERE descricao LIKE 'Item6'
---RESPOSTA DO EXERCÍCIO ABAIXO-----------------------------
SELECT descricao, SUM(quantidade) AS [QUANT TOTAL VENDIDA], SUM(total_itens_venda) AS [VALOR TOTAL VENDIDO] FROM ITEM_VENDA GROUP BY descricao


