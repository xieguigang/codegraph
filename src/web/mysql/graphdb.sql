-- MySQL Script generated by MySQL Workbench
-- Wed Mar 22 20:41:34 2023
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
  `from_node` INT NOT NULL COMMENT 'the unique id of the knowledge data',
  `to_node` INT NOT NULL COMMENT 'the unique id of the knowledge data',
  `link_type` INT NOT NULL COMMENT 'the connection type between the two knowdge node, the enumeration text string value could be found in the knowledge vocabulary table',
  `weight` DOUBLE NOT NULL DEFAULT 0 COMMENT 'weight value of current connection link',
  `add_time` DATETIME NOT NULL COMMENT 'the create time of the current knowledge link',
  `note` MEDIUMTEXT NULL COMMENT 'description text about current knowledge link',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'the connection links between the knowledge nodes data';

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `graph` (`id` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `hash_index`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `hash_index` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `hash_index` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `hashcode` CHAR(32) NOT NULL COMMENT 'tolower(md5(tolower(term)))',
  `map` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `hash_index` (`id` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `md5_UNIQUE` ON `hash_index` (`hashcode` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `knowledge`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `knowledge` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `knowledge` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `key` VARCHAR(255) NOT NULL COMMENT 'the unique key of current knowledge node data',
  `display_title` TINYTEXT NOT NULL COMMENT 'the display title text of current knowledge node data',
  `node_type` INT NOT NULL COMMENT 'the node type enumeration number value, string value could be found in the knowledge vocabulary table',
  `graph_size` INT NOT NULL DEFAULT 0 COMMENT 'the number of connected links to current knowledge node',
  `add_time` DATETIME NOT NULL COMMENT 'add time of current knowledge node data',
  `description` LONGTEXT NOT NULL COMMENT 'the description text about current knowledge data',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'knowlege data pool';

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `knowledge` (`id` ASC) VISIBLE;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `knowledge_vocabulary`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `knowledge_vocabulary` ;

SHOW WARNINGS;
CREATE TABLE IF NOT EXISTS `knowledge_vocabulary` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `vocabulary` VARCHAR(255) NOT NULL COMMENT 'the short knowledge term type',
  `add_time` DATETIME NOT NULL,
  `color` CHAR(7) NOT NULL DEFAULT '#123456' COMMENT 'html color code of current term',
  `count` INT NOT NULL DEFAULT 0,
  `description` MEDIUMTEXT NULL COMMENT 'the description text value about current type of the knowledge term',
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'the knowledge term type';

SHOW WARNINGS;
CREATE UNIQUE INDEX `id_UNIQUE` ON `knowledge_vocabulary` (`id` ASC) VISIBLE;

SHOW WARNINGS;
CREATE UNIQUE INDEX `vocabulary_UNIQUE` ON `knowledge_vocabulary` (`vocabulary` ASC) VISIBLE;

SHOW WARNINGS;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
