CREATE TABLE `usuarios` (
  `idusuario` int(7) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(500) DEFAULT NULL,
  `password` varchar(500) DEFAULT NULL,
  `status` char(1) DEFAULT NULL COMMENT 'A = Activo, B = Baja',
  `nombre` varchar(500) DEFAULT NULL,
  `apellido` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE `cliente` (
  `idcliente` int(7) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(500) DEFAULT NULL,
  `direccion` varchar(500) DEFAULT NULL,
  `telefono` varchar(12) DEFAULT NULL,
  `status` char(1) DEFAULT NULL COMMENT 'A = Activo, B = Baja',
  PRIMARY KEY (`idcliente`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE `paquete` (
  `idpaquete` int(7) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(500) DEFAULT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  `status` char(1) DEFAULT NULL COMMENT 'A = Activo, B = Inactivo',
  `costo` double(7,2) NOT NULL,
  PRIMARY KEY (`idpaquete`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE `tipo_evento` (
  `idtevento` int(7) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(500) NOT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  `status` char(1) NOT NULL COMMENT 'A = Activo, B = Inactivo',

  PRIMARY KEY (`idtevento`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE `reservacion` (
  `idreservacion` int(7) NOT NULL AUTO_INCREMENT,
  `no_reservacion` varchar(8) NOT NULL,
  `idcliente` int(7) NOT NULL,
  `idpaquete` int(7) NOT NULL,
  `idusuario` int(7) NOT NULL,
  `idtevento` int(7) NOT NULL,
  `fecha_reservacion` date NOT NULL,
  `hora_reservacion` time NOT NULL,
  `total` double(7,2) NOT NULL,
  `estatus` char(1) NOT NULL,
  PRIMARY KEY (`idreservacion`),
  KEY `FK_CLIENTE` (`idcliente`),
  KEY `FK_PAQUETE` (`idpaquete`),
  CONSTRAINT `FK_CLIENTE` FOREIGN KEY (`idcliente`) REFERENCES `cliente` (`idcliente`),
  CONSTRAINT `FK_PAQUETE` FOREIGN KEY (`idpaquete`) REFERENCES `paquete` (`idpaquete`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;


CREATE TABLE `seguimiento` (
  `idseguimiento` int(7) NOT NULL AUTO_INCREMENT,
  `idreservacion` int(7) NOT NULL,
  `fecha_seguimiento` date NOT NULL,
  `observacion` varchar(500) DEFAULT NULL,
  `deposito` double(7,2) DEFAULT NULL,
  `saldo` double(7,2) DEFAULT NULL,
  PRIMARY KEY (`idseguimiento`),
  KEY `FK_IDRESERVACION` (`idreservacion`),
  CONSTRAINT `FK_IDRESERVACION` FOREIGN KEY (`idreservacion`) REFERENCES `reservacion` (`idreservacion`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

CREATE TABLE `permisos` (
  `idpermiso` int(7) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(500) DEFAULT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `status` char(1) DEFAULT NULL COMMENT 'A = Activo, B = Baja',
  PRIMARY KEY (`idpermiso`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;