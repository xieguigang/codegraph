REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/21/2023 1:13:46 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace graphdb

''' <summary>
''' ```SQL
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("knowledge", Database:="graphdb", SchemaSQL:="
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
")>
Public Class knowledge: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
''' <summary>
''' the unique key of current knowledge node data
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("key"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="key")> Public Property key As String
''' <summary>
''' the display title text of current knowledge node data
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("display_title"), NotNull, DataType(MySqlDbType.Text), Column(Name:="display_title")> Public Property display_title As String
''' <summary>
''' the node type enumeration number value, string value could be found in the knowledge vocabulary table
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("node_type"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="node_type")> Public Property node_type As Long
''' <summary>
''' the number of connected links to current knowledge node
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("graph_size"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="graph_size")> Public Property graph_size As Long
''' <summary>
''' add time of current knowledge node data
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("add_time"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="add_time")> Public Property add_time As Date
''' <summary>
''' the description text about current knowledge data
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("description"), NotNull, DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `knowledge` (`key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `knowledge` (`key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `knowledge` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `knowledge` SET `id`='{0}', `key`='{1}', `display_title`='{2}', `node_type`='{3}', `graph_size`='{4}', `add_time`='{5}', `description`='{6}' WHERE `id` = '{7}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `knowledge` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
        Else
        Return String.Format(INSERT_SQL, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{key}', '{display_title}', '{node_type}', '{graph_size}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}', '{description}')"
        Else
            Return $"('{key}', '{display_title}', '{node_type}', '{graph_size}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}', '{description}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `graph_size`, `add_time`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
        Else
        Return String.Format(REPLACE_SQL, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `knowledge` SET `id`='{0}', `key`='{1}', `display_title`='{2}', `node_type`='{3}', `graph_size`='{4}', `add_time`='{5}', `description`='{6}' WHERE `id` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, key, display_title, node_type, graph_size, MySqlScript.ToMySqlDateTimeString(add_time), description, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As knowledge
                         Return DirectCast(MyClass.MemberwiseClone, knowledge)
                     End Function
End Class


End Namespace
