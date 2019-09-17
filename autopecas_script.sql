create database T_AutoPecas;

use T_AutoPecas;

--------------------------------------------
create table Usuarios
(
IdUsuario    int primary key identity 
,Email       varchar (200) not null unique 
,Senha        varchar (200) not null unique

);
-----------inserir--------usuarios----------
insert into Usuarios (Email, Senha) values ('sp@gmail.com','123');
insert into Usuarios (Email, Senha) values ('mp@gmail.com','321');
----------select---------usuarios---------
select * from Usuarios
-------------------------------------------

--------------------------------------------
create table Fornecedores 
(
IdFornecedor    int primary key identity 
,cnpj			int
,razaoSocial    varchar (200) not null unique
,nomeFantasia   varchar (200) not null unique 
,endereco       varchar (200) not null 
,IdUsuario      int foreign key references Usuarios (IdUsuario)
);
-----------inserir--------usuarios----------
insert into Fornecedores (cnpj, razaoSocial, nomeFantasia, endereco,IdUsuario) values ('132','Sua Peça LTDA','Sua Peça','Rua biriri',1);
insert into Fornecedores (cnpj, razaoSocial, nomeFantasia, endereco,IdUsuario) values ('321','Move Peças LTDA','Move','Rua esquina',2);
----------select---------usuarios---------
select * from Fornecedores
-------------------------------------------

-------------------------------------------
create table Pecas
(
IdPecas       int primary key identity
,codigo       varchar (200) not null unique
,descricao    varchar (200) not null unique
,peso         float 
,precoCusto   money 
,precoVenda   money 
,IdFornecedor  int foreign key references Fornecedores (IdFornecedor)
);
-----------inserir--------usuarios----------
insert into Pecas  (codigo, descricao, peso, precoCusto, precoVenda,IdFornecedor) values ('A123','Disco de Freio',1 ,100,120,1);
insert into Pecas  (codigo, descricao, peso, precoCusto, precoVenda,IdFornecedor) values ('B123',' Radiador do Motor',2 ,200,120,1);
insert into Pecas  (codigo, descricao, peso, precoCusto, precoVenda,IdFornecedor) values ('C123','Válvula Termostática',0.5,60,120,2);
insert into Pecas  (codigo, descricao, peso, precoCusto, precoVenda,IdFornecedor) values ('D123','Pistão ',1,100,50,2);
----------select---------usuarios---------
select * from Pecas

