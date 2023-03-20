-- MySQL Script generated by MySQL Workbench
-- Mon Mar 20 09:27:36 2023
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema graphdb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `graphdb` ;

-- -----------------------------------------------------
-- Schema graphdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `graphdb` DEFAULT CHARACTER SET utf8 ;
SHOW WARNINGS;
USE `graphdb` ;

-- -----------------------------------------------------
-- Table `graph`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `graph` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `graph` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `from_node` INT NOT NULL,
  `to_node` INT NOT NULL,
  `link_type` INT NOT NULL,
  `weight` DOUBLE NOT NULL DEFAULT 0,
  `add_time` DATETIME NOT NULL,
  `note` MEDIUMTEXT NOT NULL DEFAULT 'NA',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `graph` (`id` ASC);

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `knowledge`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `knowledge` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `knowledge` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `key` VARCHAR(255) NOT NULL,
  `display_title` TINYTEXT NOT NULL,
  `node_type` INT NOT NULL,
  `description` LONGTEXT NOT NULL DEFAULT 'NA',
  `add_time` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `knowledge` (`id` ASC);

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `knowledge_vocabulary`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `knowledge_vocabulary` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `knowledge_vocabulary` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `vocabulary` VARCHAR(255) NOT NULL,
  `description` MEDIUMTEXT NOT NULL DEFAULT 'NA',
  `add_time` DATETIME NOT NULL,
  `color` CHAR(7) NOT NULL DEFAULT '#123456',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `knowledge_vocabulary` (`id` ASC);

SHOW WARNINGS;
CREATE UNIQUE INDEX `vocabulary_UNIQUE` ON `knowledge_vocabulary` (`vocabulary` ASC);

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;