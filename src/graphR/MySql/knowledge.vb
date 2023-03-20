REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/20/2023 10:11:46 PM


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
  `key` VARCHAR(255) NOT NULL,
  `display_title` TINYTEXT NOT NULL,
  `node_type` INT NOT NULL,
  `description` LONGTEXT,
  `add_time` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;")>
    Public Class knowledge : Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
        <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNULL, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
        <DatabaseField("key"), NotNULL, DataType(MySqlDbType.VarChar, "255"), Column(Name:="key")> Public Property key As String
        <DatabaseField("display_title"), NotNULL, DataType(MySqlDbType.Text), Column(Name:="display_title")> Public Property display_title As String
        <DatabaseField("node_type"), NotNULL, DataType(MySqlDbType.Int64, "11"), Column(Name:="node_type")> Public Property node_type As Long
        <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
        <DatabaseField("add_time"), NotNULL, DataType(MySqlDbType.DateTime), Column(Name:="add_time")> Public Property add_time As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
        Friend Shared ReadOnly INSERT_SQL$ =
            <SQL>INSERT INTO `knowledge` (`key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

        Friend Shared ReadOnly INSERT_AI_SQL$ =
            <SQL>INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

        Friend Shared ReadOnly REPLACE_SQL$ =
            <SQL>REPLACE INTO `knowledge` (`key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

        Friend Shared ReadOnly REPLACE_AI_SQL$ =
            <SQL>REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

        Friend Shared ReadOnly DELETE_SQL$ =
            <SQL>DELETE FROM `knowledge` WHERE `id` = '{0}';</SQL>

        Friend Shared ReadOnly UPDATE_SQL$ =
            <SQL>UPDATE `knowledge` SET `id`='{0}', `key`='{1}', `display_title`='{2}', `node_type`='{3}', `description`='{4}', `add_time`='{5}' WHERE `id` = '{6}';</SQL>

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
        ''' INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
        ''' ```
        ''' </summary>
        Public Overrides Function GetInsertSQL() As String
            Return String.Format(INSERT_SQL, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
        End Function

        ''' <summary>
        ''' ```SQL
        ''' INSERT INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
        ''' ```
        ''' </summary>
        Public Overrides Function GetInsertSQL(AI As Boolean) As String
            If AI Then
                Return String.Format(INSERT_AI_SQL, id, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
            Else
                Return String.Format(INSERT_SQL, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
            End If
        End Function

        ''' <summary>
        ''' <see cref="GetInsertSQL"/>
        ''' </summary>
        Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
            If AI Then
                Return $"('{id}', '{key}', '{display_title}', '{node_type}', '{description}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}')"
            Else
                Return $"('{key}', '{display_title}', '{node_type}', '{description}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}')"
            End If
        End Function


        ''' <summary>
        ''' ```SQL
        ''' REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
        ''' ```
        ''' </summary>
        Public Overrides Function GetReplaceSQL() As String
            Return String.Format(REPLACE_SQL, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
        End Function

        ''' <summary>
        ''' ```SQL
        ''' REPLACE INTO `knowledge` (`id`, `key`, `display_title`, `node_type`, `description`, `add_time`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
        ''' ```
        ''' </summary>
        Public Overrides Function GetReplaceSQL(AI As Boolean) As String
            If AI Then
                Return String.Format(REPLACE_AI_SQL, id, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
            Else
                Return String.Format(REPLACE_SQL, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time))
            End If
        End Function

        ''' <summary>
        ''' ```SQL
        ''' UPDATE `knowledge` SET `id`='{0}', `key`='{1}', `display_title`='{2}', `node_type`='{3}', `description`='{4}', `add_time`='{5}' WHERE `id` = '{6}';
        ''' ```
        ''' </summary>
        Public Overrides Function GetUpdateSQL() As String
            Return String.Format(UPDATE_SQL, id, key, display_title, node_type, description, MySqlScript.ToMySqlDateTimeString(add_time), id)
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
