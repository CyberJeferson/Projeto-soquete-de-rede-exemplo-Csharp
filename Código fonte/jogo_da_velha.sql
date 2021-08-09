--Projeto Policia Ambiental, Jogo da velha - Jeferson Oliveira


--Use no mysql


CREATE TABLE ocorrencia (
  cd_ocorrenci int(11) NOT NULL,
 tipo_ocorrencia varchar(255) NOT NULL,
  ds_ocorrencia varchar(255) NOT NULL,
  latitude varchar(255) NOT NULL,
  longetude varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;




-- --------------------------------------------------------



CREATE TABLE player (
  cd_player int(255) NOT NULL,
  nm_player varchar(255) NOT NULL,
  senha_player varchar(255) NOT NULL,
  n_vitorias int(255) DEFAULT NULL,
  n_derrotas int(255) DEFAULT NULL,
  foto_player varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*
Inserindo chaves primárias e autoincrement's
*/
ALTER TABLE ocorrencia
  ADD PRIMARY KEY (cd_ocorrencia);


ALTER TABLE player
  ADD PRIMARY KEY (cd_player),
  ADD UNIQUE KEY nm_player (nm_player);



ALTER TABLE ocorrencia
  MODIFY cd_ocorrencia int(11) NOT NULL AUTO_INCREMENT;


ALTER TABLE player
  MODIFY cd_player int(255) NOT NULL AUTO_INCREMENT;

