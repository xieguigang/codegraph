REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/22/2023 8:45:18 PM


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
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("knowledge_vocabulary", Database:="graphdb", SchemaSQL:="
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
")>
Public Class knowledge_vocabulary: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="id"), XmlAttribute> Public Property id As Long
''' <summary>
''' the short knowledge term type
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("vocabulary"), NotNull, DataType(MySqlDbType.VarChar, "255"), Column(Name:="vocabulary")> Public Property vocabulary As String
    <DatabaseField("add_time"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="add_time")> Public Property add_time As Date
''' <summary>
''' html color code of current term
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("color"), NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="color")> Public Property color As String
    <DatabaseField("count"), NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="count")> Public Property count As Long
''' <summary>
''' the description text value about current type of the knowledge term
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `knowledge_vocabulary` (`vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `knowledge_vocabulary` (`vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `knowledge_vocabulary` WHERE `id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `knowledge_vocabulary` SET `id`='{0}', `vocabulary`='{1}', `add_time`='{2}', `color`='{3}', `count`='{4}', `description`='{5}' WHERE `id` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `knowledge_vocabulary` WHERE `id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, id, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
        Else
        Return String.Format(INSERT_SQL, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{id}', '{vocabulary}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}', '{color}', '{count}', '{description}')"
        Else
            Return $"('{vocabulary}', '{add_time.ToString("yyyy-MM-dd hh:mm:ss")}', '{color}', '{count}', '{description}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `knowledge_vocabulary` (`id`, `vocabulary`, `add_time`, `color`, `count`, `description`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, id, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
        Else
        Return String.Format(REPLACE_SQL, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `knowledge_vocabulary` SET `id`='{0}', `vocabulary`='{1}', `add_time`='{2}', `color`='{3}', `count`='{4}', `description`='{5}' WHERE `id` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, vocabulary, MySqlScript.ToMySqlDateTimeString(add_time), color, count, description, id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As knowledge_vocabulary
                         Return DirectCast(MyClass.MemberwiseClone, knowledge_vocabulary)
                     End Function
End Class


End Namespace
