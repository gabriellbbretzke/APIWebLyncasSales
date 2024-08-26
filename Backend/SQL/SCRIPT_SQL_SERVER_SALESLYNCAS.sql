CREATE DATABASE SALES_LYNCAS;

USE SALES_LYNCAS;

-----------------------CRIAÇÃO DE TABELAS------------------------------

CREATE TABLE [USUARIO]
	(id INT IDENTITY(1,1) NOT NULL,
	 email VARCHAR(100) NOT NULL,
	 senha VARCHAR(50) NOT NULL,
	 perfil_acesso VARCHAR(50) NOT NULL
CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED (id));

CREATE TABLE [CLIENTE]
	(id INT IDENTITY(1,1) NOT NULL,
	 nome VARCHAR(100) NOT NULL,
	 email VARCHAR(50) NOT NULL,
	 telefone VARCHAR(20) NOT NULL,
	 cpf VARCHAR(20) NOT NULL
CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED (id));

CREATE TABLE [VENDA]
	(id INT IDENTITY(1,1) NOT NULL,
	 id_usuario INT FOREIGN KEY REFERENCES [USUARIO](id) NOT NULL,
	 id_cliente INT FOREIGN KEY REFERENCES [CLIENTE](id) NOT NULL,
	 data_faturamento DATE NOT NULL,
	 total_venda FLOAT NOT NULL
CONSTRAINT [PK_VENDA] PRIMARY KEY CLUSTERED (id));

CREATE TABLE [ITEM_VENDA]
	(id INT IDENTITY(1,1) NOT NULL,
	 id_venda INT FOREIGN KEY REFERENCES VENDA(id) NOT NULL,
	 descricao VARCHAR(100) NOT NULL,
	 quantidade INT NOT NULL,
	 valor float NOT NULL,
	 total_itens_venda FLOAT NULL
CONSTRAINT [PK_ITEM_VENDA] PRIMARY KEY CLUSTERED (id));

-----------------------ADIÇÃO DE DADOS------------------------------

INSERT INTO [dbo].[CLIENTE]
           ([nome]
           ,[email]
           ,[telefone]
           ,[cpf])
     VALUES
		('Cliente nome 1','Clienteemail1,@teste.com.br','47 0 0000-0001','000.000.000-01'),
		('Cliente nome 2','Clienteemail2,@teste.com.br','47 0 0000-0002','000.000.000-02'),
		('Cliente nome 3','Clienteemail3,@teste.com.br','48 0 0000-0001','000.000.000-03'),
		('Cliente nome 4','Clienteemail4,@teste.com.br','48 0 0000-0002','000.000.000-04'),
		('Cliente nome 5','Clienteemail5,@teste.com.br','49 0 0000-0001','000.000.000-05'),
		('Cliente nome 6','Clienteemail6,@teste.com.br','49 0 0000-0002','000.000.000-06'),
		('Cliente nome 7','Clienteemail7,@teste.com.br','50 0 0000-0001','000.000.000-07'),
		('Cliente nome 8','Clienteemail8,@teste.com.br','50 0 0000-0002','000.000.000-08'),
		('Cliente nome 9','Clienteemail9,@teste.com.br','51 0 0000-0001','000.000.000-09'),
		('Cliente nome 10','Clienteemail10,@teste.com.br','51 0 0000-0002','000.000.000-10'),
		('Cliente nome 11','Clienteemail11,@teste.com.br','52 0 0000-0001','000.000.000-11'),
		('Cliente nome 12','Clienteemail12,@teste.com.br','52 0 0000-0002','000.000.000-12'),
		('Cliente nome 13','Clienteemail13,@teste.com.br','53 0 0000-0001','000.000.000-13'),
		('Cliente nome 14','Clienteemail14,@teste.com.br','53 0 0000-0002','000.000.000-14'),
		('Cliente nome 15','Clienteemail15,@teste.com.br','54 0 0000-0001','000.000.000-15'),
		('Cliente nome 16','Clienteemail16,@teste.com.br','54 0 0000-0002','000.000.000-16'),
		('Cliente nome 17','Clienteemail17,@teste.com.br','55 0 0000-0001','000.000.000-17'),
		('Cliente nome 18','Clienteemail18,@teste.com.br','55 0 0000-0002','000.000.000-18');

INSERT INTO [dbo].[USUARIO]
           ([email]
           ,[senha]
           ,[perfil_acesso])
     VALUES
		('Usuario nome 1','Usuarionome1@teste.com.br','Perfil 1'),
		('Usuario nome 2','Usuarionome2@teste.com.br','Perfil 1'),
		('Usuario nome 3','Usuarionome3@teste.com.br','Perfil 1'),
		('Usuario nome 4','Usuarionome4@teste.com.br','Perfil 1'),
		('Usuario nome 5','Usuarionome5@teste.com.br','Perfil 1'),
		('Usuario nome 6','Usuarionome6@teste.com.br','Perfil 1'),
		('Usuario nome 7','Usuarionome7@teste.com.br','Perfil 1'),
		('Usuario nome 8','Usuarionome8@teste.com.br','Perfil 1'),
		('Usuario nome 9','Usuarionome9@teste.com.br','Perfil 2'),
		('Usuario nome 10','Usuarionome10@teste.com.br','Perfil 2'),
		('Usuario nome 11','Usuarionome11@teste.com.br','Perfil 2'),
		('Usuario nome 12','Usuarionome12@teste.com.br','Perfil 2'),
		('Usuario nome 13','Usuarionome13@teste.com.br','Perfil 2'),
		('Usuario nome 14','Usuarionome14@teste.com.br','Perfil 2'),
		('Usuario nome 15','Usuarionome15@teste.com.br','Perfil 3'),
		('Usuario nome 16','Usuarionome16@teste.com.br','Perfil 3'),
		('Usuario nome 17','Usuarionome17@teste.com.br','Perfil 3'),
		('Usuario nome 18','Usuarionome18@teste.com.br','Perfil 3');

INSERT INTO [dbo].[VENDA]
           ([id_usuario]
           ,[id_cliente]
           ,[data_faturamento]
           ,[total_venda])
     VALUES
		(1,1,'2022-01-13',10),
		(2,2,'2022-01-13',10),
		(3,3,'2022-01-13',10),
		(4,4,'2022-01-13',10),
		(5,5,'2022-01-13',10),
		(6,6,'2022-01-13',10),
		(7,7,'2022-01-13',10),
		(8,8,'2022-01-13',10),
		(9,9,'2022-01-13',10),
		(10,10,'2022-01-13',10),
		(1,11,'2022-01-13',10),
		(2,12,'2022-01-13',10),
		(3,13,'2022-01-13',10),
		(4,14,'2022-01-13',10),
		(5,15,'2022-01-13',10),
		(6,16,'2022-01-13',10),
		(7,17,'2022-01-13',10),
		(8,18,'2022-01-13',10);

INSERT INTO [dbo].[ITEM_VENDA]
           ([id_venda]
           ,[descricao]
           ,[valor]
           ,[quantidade])
     VALUES
		(SCOPE_IDENTITY(),'Item1',0.01,1),
		(SCOPE_IDENTITY(),'Item2',0.02,1),
		(SCOPE_IDENTITY(),'Item3',0.03,1),
		(SCOPE_IDENTITY(),'Item4',0.04,1),
		(SCOPE_IDENTITY(),'Item5',0.05,1),
		(SCOPE_IDENTITY(),'Item6',0.06,1),
		(SCOPE_IDENTITY(),'Item7',0.07,1),
		(SCOPE_IDENTITY(),'Item8',0.08,1),
		(SCOPE_IDENTITY(),'Item9',0.09,1),
		(SCOPE_IDENTITY(),'Item10',0.1,1),
		(SCOPE_IDENTITY(),'Item11',0.11,1),
		(SCOPE_IDENTITY(),'Item12',0.12,1),
		(SCOPE_IDENTITY(),'Item13',0.13,1),
		(SCOPE_IDENTITY(),'Item14',0.14,1),
		(SCOPE_IDENTITY(),'Item15',0.15,1),
		(SCOPE_IDENTITY(),'Item16',0.16,1),
		(SCOPE_IDENTITY(),'Item17',0.17,1),
		(SCOPE_IDENTITY(),'Item18',0.18,1),
		(SCOPE_IDENTITY(),'Item12',0.1,2),
		(SCOPE_IDENTITY(),'Item22',0.2,2),
		(SCOPE_IDENTITY(),'Item32',0.3,2),
		(SCOPE_IDENTITY(),'Item42',0.4,2),
		(SCOPE_IDENTITY(),'Item52',0.5,2),
		(SCOPE_IDENTITY(),'Item62',0.6,2),
		(SCOPE_IDENTITY(),'Item72',0.7,2),
		(SCOPE_IDENTITY(),'Item82',0.8,2),
		(SCOPE_IDENTITY(),'Item92',0.9,2),
		(SCOPE_IDENTITY(),'Item102',0.1,3),
		(SCOPE_IDENTITY(),'Item112',0.11,3),
		(SCOPE_IDENTITY(),'Item122',0.12,3),
		(SCOPE_IDENTITY(),'Item132',0.13,3),
		(SCOPE_IDENTITY(),'Item142',0.14,3),
		(SCOPE_IDENTITY(),'Item152',0.15,3),
		(SCOPE_IDENTITY(),'Item162',0.16,3),
		(SCOPE_IDENTITY(),'Item172',0.17,3),
		(SCOPE_IDENTITY(),'Item182',0.18,1),
		(SCOPE_IDENTITY(),'Item12',1,2),
		(SCOPE_IDENTITY(),'Item22',2,2),
		(SCOPE_IDENTITY(),'Item32',3,2),
		(SCOPE_IDENTITY(),'Item42',4,2),
		(SCOPE_IDENTITY(),'Item52',5,2),
		(SCOPE_IDENTITY(),'Item62',6,2),
		(SCOPE_IDENTITY(),'Item72',7,2),
		(SCOPE_IDENTITY(),'Item82',8,2),
		(SCOPE_IDENTITY(),'Item92',9,2),
		(SCOPE_IDENTITY(),'Item302',1,3),
		(SCOPE_IDENTITY(),'Item312',11,3),
		(SCOPE_IDENTITY(),'Item22',12,3),
		(SCOPE_IDENTITY(),'Item332',13,3),
		(SCOPE_IDENTITY(),'Item442',14,3),
		(SCOPE_IDENTITY(),'Item552',15,3),
		(SCOPE_IDENTITY(),'Item662',16,3),
		(SCOPE_IDENTITY(),'Item772',17,3),
		(SCOPE_IDENTITY(),'Item882',18,1),
		(SCOPE_IDENTITY(),'Item22',1,2),
		(SCOPE_IDENTITY(),'Item32',2,2),
		(SCOPE_IDENTITY(),'Item32',3,2),
		(SCOPE_IDENTITY(),'Item42',4,2),
		(SCOPE_IDENTITY(),'Item532',5,2),
		(SCOPE_IDENTITY(),'Item63',6,2),
		(SCOPE_IDENTITY(),'Item42',7,2),
		(SCOPE_IDENTITY(),'Item32',8,2),
		(SCOPE_IDENTITY(),'Item32',9,2),
		(SCOPE_IDENTITY(),'Item302',1,3),
		(SCOPE_IDENTITY(),'Item312',11,3),
		(SCOPE_IDENTITY(),'Item322',12,3),
		(SCOPE_IDENTITY(),'Item332',13,3),
		(SCOPE_IDENTITY(),'Item342',14,3),
		(SCOPE_IDENTITY(),'Item352',15,3),
		(SCOPE_IDENTITY(),'Item362',16,3),
		(SCOPE_IDENTITY(),'Item372',17,3),
		(SCOPE_IDENTITY(),'Item382',18,1);